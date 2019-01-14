using System;
using System.Collections.Generic;
using System.Linq;
using YugiohDeck.Core;
using YugiohDeck.Serialization;

namespace YugiohDeck.Database
{
    class LocalCardDatabase
    {
        private static readonly string fileExtension = ".json";
        private static readonly string cardKeyword = "card";
        private readonly IDictionary<string, Card> cardMemo;
        public LocalCardDatabase()
        {
            this.cardMemo = new Dictionary<string, Card>();
        }
        public bool Exists(string cardName)
        {
            var memoExistance = this.cardMemo.ContainsKey(cardName);
            if (memoExistance) return true;
            var keywords = GetKeywords(cardName);
            return Storage.Exists(keywords);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        public Card SearchCard(string cardName)
        {
            var keywords = GetKeywords(cardName);
            var content = Storage.ReadString(keywords);
            var card = Json.Deserialize<Card>(content);
            this.AddCardMemo(card);
            return card;
        }
        public Card[] SearchCards(string[] keywords)
        {
            //
            var mathedMemoCards = this.cardMemo
                .Where(pair => MatchKeywords(keywords, pair.Key))
                .Select(pair => pair.Value)
                .ToArray();
            //
            var files = Storage.EnumerateExistingFiles(false, cardKeyword.ToEnumerable());
            var storageCards =
              (from file in files
               let cardNameWithExtension = file.Last()
               let cardName = cardNameWithExtension.Replace(fileExtension, "")
               where MatchKeywords(keywords, cardName)
               where !this.cardMemo.ContainsKey(cardName)
               let content = Storage.ReadString(file)
               let card = Json.Deserialize<Card>(content)
               select card)
              .ToArray();
            //
            foreach (var card in storageCards)
            {
                this.AddCardMemo(card);
            }
            return storageCards.Concat(mathedMemoCards).ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        /// <exception cref="System.Runtime.Serialization.InvalidDataContractException"></exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        public void SaveCard(Card card)
        {
            var json = Json.Serialize(card, false);
            var keywords = GetKeywords(card.Name);
            Storage.WriteString(json.ToString(), keywords);
            if (this.cardMemo.ContainsKey(card.Name)) this.cardMemo[card.Name] = card;
            else this.cardMemo.Add(card.Name, card);
        }
        private void AddCardMemo(Card card)
        {
            if (this.cardMemo.ContainsKey(card.Name)) this.cardMemo[card.Name] = card;
            else this.cardMemo.Add(card.Name, card);
        }
        private static string[] GetKeywords(string cardName) => new[] { cardKeyword, cardName + fileExtension };
        private static bool MatchKeywords(string[] keywords, string cardName) => keywords.All(k => cardName.Contains(k));
    }
}
