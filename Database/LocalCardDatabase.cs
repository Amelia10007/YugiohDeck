using System.Collections.Generic;
using System.Linq;
using YugiohDeck.Core;
using YugiohDeck.Serialization;
using System.IO;

namespace YugiohDeck.Database
{
    static class LocalCardDatabase
    {
        private static readonly string fileExtension = ".json";
        private static readonly IDictionary<string, Card> cards = new Dictionary<string, Card>();
        public static void LoadAllExistingCards()
        {
            cards.Clear();
            //
            var files = Storage.EnumerateExistingFiles(false, new[] { "card", "text" });
            var existingCards =
              from file in files
              let extension = new string(Path.GetExtension(file.Last()).ToArray()).ToLower()
              where extension == fileExtension
              let content = Storage.ReadString(file)
              let card = Json.Deserialize<Card>(content)
              select card;
            //
            foreach (var card in existingCards)
            {
                cards.Add(card.Name, card);
            }
        }
        public static Card GetCardByName(string cardName)
        {
            if (!cards.ContainsKey(cardName))
            {

            }
            return cards[cardName];
        }
        public static IEnumerable<Card> SearchCardsByName(string[] nameKeywords)
        {
            foreach (var pair in cards)
            {
                var name = pair.Key;
                if (nameKeywords.Any(keyword => !name.Contains(keyword)))
                {
                    continue;
                }
                yield return pair.Value;
            }
        }
        public static IEnumerable<Card> SearchCardsByText(string[] keywords)
        {
            foreach (var card in cards.Values)
            {
                var text = card.Name + card.Pronunciation + card.Description;
                if (keywords.Any(keyword => !text.Contains(keyword)))
                {
                    continue;
                }
                yield return card;
            }
        }
    }
}
