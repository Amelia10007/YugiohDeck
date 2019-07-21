using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Drawing;
using AngleSharp.Parser.Html;
using AngleSharp.Dom.Html;
using YugiohDeck.Core;

namespace YugiohDeck.Database
{
    class YugiohListDotComDatabase : ICardDatabase
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public YugiohListDotComDatabase()
        {
        }
        public async Task<bool> ExistsAsync(string cardName)
        {
            var cards = await this.SearchCardsAsync(new[] { cardName });
            return cards.Any(c => c.Name == cardName);
        }
        public async Task<Card> SearchCardAsync(string cardName)
        {
            try
            {
                var cards = await this.SearchCardsAsync(new[] { cardName });
                return cards.Single(c => c.Name == cardName);
            }
            catch
            {
                return null;
            }
        }
        public async Task<IReadOnlyCollection<Card>> SearchCardsAsync(string[] keywords)
        {
            IHtmlDocument document;
            try
            {
                document = await GetSearchResultPageAsync(keywords);
            }
            catch (HttpRequestException)
            {
                return new List<Card>();
            }
            return await this.LoadCardsFromHtmlAsync(document);
        }
        private async Task<IReadOnlyCollection<Card>> LoadCardsFromHtmlAsync(IHtmlDocument htmlDocument)
        {
            var cards = new List<Card>();
            var searchResultElement = htmlDocument.GetElementById("search_result");
            var cardDeclarationTags = searchResultElement.GetElementsByTagName("tr")
                .Skip(2)
                .ToArray();
            for (var index = 0; index < cardDeclarationTags.Length - 1;)
            {
                var cardDeclarationTag = cardDeclarationTags[index];
                var tableDataTags = cardDeclarationTag.GetElementsByTagName("td");
                try
                {
                    var cardName = tableDataTags[2].GetElementsByTagName("a")[0].TextContent;
                    var imageTag = tableDataTags[0].GetElementsByTagName("img")[0];
                    var imageUri = new Uri($"https://yugioh-list.com{imageTag.Attributes[0].Value}");
                    var image = await GetCardImageAsync(imageUri);
                    var limitationText = tableDataTags[2].GetElementsByTagName("font")?.FirstOrDefault()?.TextContent;
                    var limitation = limitationText == null ? CardLimitation.Unlimited
                        : limitationText == "準制限" ? CardLimitation.SemiLimited
                        : limitationText == "制限" ? CardLimitation.Limited
                        : CardLimitation.Forbidden;
                    var kinds = GetCardKinds(tableDataTags[3].GetElementsByTagName("a").Select(element => element.TextContent)).ToList();
                    var isMonster = kinds.Any(k => k.IsMonster);
                    if (isMonster)
                    {
                        var monsterStatusElement = cardDeclarationTag.NextElementSibling;
                        var monsterTableDataTags = monsterStatusElement.GetElementsByTagName("td");
                        var monsterAttribute = Extension.TryGet<string, Exception>(() => monsterTableDataTags[0].GetElementsByTagName("img")[0].Attributes[1].Value.Substring(0, 1), "None");
                        var monsterLevel = Extension.TryGet<string, Exception>(() => monsterTableDataTags[1].TextContent, "None");
                        var monsterType = Extension.TryGet<string, Exception>(() => monsterTableDataTags[2].GetElementsByTagName("a")[0].TextContent.TrimEnd('族'), "None");
                        var monsterAttack = Extension.TryGet<int?, Exception>(() => GetMonsterBattleStatus(monsterTableDataTags[3].TextContent), null);
                        var monsterDefence = Extension.TryGet<int?, Exception>(() => GetMonsterBattleStatus(monsterTableDataTags[4].TextContent), null);
                        var cardTextElement = monsterStatusElement.NextElementSibling ?? monsterStatusElement;
                        var cardText = GetCardText(cardTextElement.GetElementsByTagName("span")[0].TextContent);
                        if (cardText.StartsWith("リバース："))
                        {
                            kinds.Add(CardKind.ReverseMonster);
                        }
                        if (kinds.Contains(CardKind.LinkMonster))
                        {
                            monsterLevel = monsterStatusElement.NextElementSibling
                                .GetElementsByTagName("tr")[1]
                                .GetElementsByTagName("td")[1]
                                .TextContent
                                .Last()
                                .ToString();
                        }
                        var card = new Card(cardName, limitation, kinds, monsterLevel, monsterAttribute, monsterType, monsterAttack, monsterDefence, cardText, image);
                        index += 3;
                        cards.Add(card);
                    }
                    else
                    {
                        var cardText = GetCardText(cardDeclarationTag.NextElementSibling.GetElementsByTagName("span")[0].TextContent);
                        var card = new Card(cardName, limitation, kinds, null, null, null, null, null, cardText, image);
                        index += 2;
                        cards.Add(card);
                    }
                }
                catch
                {
                    break;
                }
            }
            return cards;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        private static async Task<IHtmlDocument> GetSearchResultPageAsync(string[] keywords)
        {
            var keyword = keywords.Aggregate((current, next) => current + " " + next);
            var searchUri = $"https://yugioh-list.com/searches/result?keyword1=1&keyword2=1&keyword3=1&keyword={keyword}";
            var bytes = await httpClient.GetByteArrayAsync(searchUri);
            var s = System.Text.Encoding.UTF8.GetString(bytes);
            var parser = new HtmlParser();
            return await parser.ParseAsync(s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardImageUri"></param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="Exception"></exception>
        private static async Task<CardImage> GetCardImageAsync(Uri cardImageUri)
        {
            using (var stream = await httpClient.GetStreamAsync(cardImageUri))
            {
                var image = new Bitmap(stream);
                return new CardImage(image);
            }
        }
        private static IEnumerable<CardKind> GetCardKinds(IEnumerable<string> kinds)
        {
            if (kinds.Contains("通常モンスター")) yield return CardKind.NormalMonster;
            if (kinds.Contains("効果モンスター")) yield return CardKind.EffectMonster;
            if (kinds.Contains("デュアルモンスター")) yield return CardKind.DualMonster;
            if (kinds.Contains("スピリットモンスター")) yield return CardKind.SpiritMonster;
            if (kinds.Contains("チューナーモンスター")) yield return CardKind.TunarMonster;
            if (kinds.Contains("リバースモンスター")) yield return CardKind.ReverseMonster;
            if (kinds.Contains("トゥーンモンスター")) yield return CardKind.ToonMonster;
            if (kinds.Contains("特殊召喚モンスター")) yield return CardKind.SpecialSummonMonster;
            if (kinds.Contains("儀式モンスター")) yield return CardKind.RitualMonster;
            if (kinds.Contains("融合モンスター")) yield return CardKind.FusionMonster;
            if (kinds.Contains("シンクロモンスター")) yield return CardKind.SynchroMonster;
            if (kinds.Contains("エクシーズモンスター")) yield return CardKind.XyzMonster;
            if (kinds.Contains("ペンデュラムモンスター")) yield return CardKind.PendulumMonster;
            if (kinds.Contains("リンクモンスター")) yield return CardKind.LinkMonster;
            if (kinds.Contains("通常魔法")) yield return CardKind.NormalSpell;
            if (kinds.Contains("儀式魔法")) yield return CardKind.RitualSpell;
            if (kinds.Contains("装備魔法")) yield return CardKind.EquipSpell;
            if (kinds.Contains("フィールド魔法")) yield return CardKind.FieldSpell;
            if (kinds.Contains("永続魔法")) yield return CardKind.ContinuousSpell;
            if (kinds.Contains("速攻魔法")) yield return CardKind.QuickSpell;
            if (kinds.Contains("通常罠")) yield return CardKind.NormalTrap;
            if (kinds.Contains("永続罠")) yield return CardKind.ContinuousTrap;
            if (kinds.Contains("カウンター罠")) yield return CardKind.CounterTrap;
        }
        private static string GetCardText(string text)
        {
            var value = text.Trim(' ');
            while (value.Contains('<'))
            {
                var start = value.IndexOf('<');
                var end = value.IndexOf('>');
                var removeCount = end - start + 1;
                value = value.Remove(start, removeCount);
            }
            return value;
        }
        private static int? GetMonsterBattleStatus(string status)
        {
            if (int.TryParse(status, out var n)) return n;
            else return null;
        }
    }
}
