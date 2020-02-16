using System;
using System.Collections.Generic;
using YugiohCardDatabase;

#nullable enable

namespace YugiohDeck.Database
{
    static class LocalCardDatabase
    {
        private static readonly IDictionary<string, Card> cards = new Dictionary<string, Card>();

        public static void LoadAllExistingCards(Action<string> notification)
        {
            cards.Clear();
            //
            var i = 0;
            foreach(var card in Storage.EnumerateCards())
            {
                cards.Add(card.IdentityShortName, card);
                notification?.Invoke($"Loaded card {i++}");
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
