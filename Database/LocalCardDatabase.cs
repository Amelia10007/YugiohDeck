using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YugiohDeck.Core;
using YugiohDeck.Serialization;

namespace YugiohDeck.Database
{
    class LocalCardDatabase
    {
        private static readonly string cardKeyword = "card";
        public bool Exists(string cardName)
        {
            return Storage.Exists(cardKeyword, cardName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Card SearchCard(string cardName)
        {
            try
            {
                var content = Storage.ReadString(cardKeyword, cardName);
                return Json.Deserialize<Card>(content);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("", e);
            }
        }
        public IReadOnlyCollection<Card> SearchCards(string[] keywords)
        {
            var files = Storage.EnumerateExistingFiles(false, cardKeyword);
            var cards =
            from file in files
            let cardName = file.Last()
            where keywords.All(k => cardName.Contains(k))
            let content = Storage.ReadString(cardKeyword, cardName)
            let card = Json.Deserialize<Card>(content)
            select card;
            return cards.ToArray();
        }
        public void SaveCard(Card card)
        {
            var json = Json.Serialize(card);
            Storage.WriteString(json.ToString(), cardKeyword, card.Name.ToString());
        }
    }
}
