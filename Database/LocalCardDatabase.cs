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
        public static IEnumerable<Card> SearchCardsByCondition(SearchCondition searchCondition)
        {
            return searchCondition.Matches(cards.Values);
        }

        public static Card GetCardByName(string cardName)
        {
            return cards[cardName];
        }
    }
}
