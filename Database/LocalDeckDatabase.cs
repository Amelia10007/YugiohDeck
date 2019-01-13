using System;
using System.Collections.Generic;
using System.Linq;
using YugiohDeck.Core;
using YugiohDeck.Serialization;

namespace YugiohDeck.Database
{
    static class LocalDeckDatabase
    {
        private static readonly string deckKeyword = "deck";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deckName"></param>
        /// <returns></returns>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        public static Deck SearchDeck(string deckName)
        {
            var content = Storage.ReadString(deckKeyword, deckName);
            return Json.Deserialize<Deck>(content);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        public static IEnumerable<string> EnumerateDeckNames()
        {
            return Storage.EnumerateExistingFiles(false, deckKeyword)
                .Select(file => file.Last());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deck"></param>
        /// <exception cref="System.Runtime.Serialization.InvalidDataContractException"></exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        public static void SaveDeck(Deck deck)
        {
            var json = Json.Serialize(deck);
            Storage.WriteString(json.ToString(), deckKeyword, deck.Name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deckName"></param>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        public static void DeleteDeck(string deckName)
        {
            Storage.Delete(deckKeyword, deckName);
        }
    }
}
