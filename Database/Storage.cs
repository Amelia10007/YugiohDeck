using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using YugiohDeck.Core;
using YugiohCardDatabase;

#nullable enable

namespace YugiohDeck.Database
{
    static class Storage
    {
        private static readonly string cardTextDirectory;
        private static readonly string cardImageDirectory;
        private static readonly string limitRegulationPath;
        private static readonly string deckDirectory;

        static Storage()
        {
            var settingFilePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\setting.txt";
            var lines = File.ReadAllLines(settingFilePath);
            foreach (var line in lines)
            {
                if (line.IndexOf("CardDataDirectory=") != -1)
                {
                    var index = line.IndexOf("CardDataDirectory=");
                    var cardDataDirectory = line.Substring(index + "CardDataDirectory=".Length).Replace("/", "\\").TrimEnd('\\');
                    cardTextDirectory = cardDataDirectory + "\\text\\";
                    cardImageDirectory = cardDataDirectory + "\\image\\";
                    limitRegulationPath = cardDataDirectory + "\\LimitRegulation.json";
                }
                else if (line.IndexOf("DeckDirectory=") != -1)
                {
                    var index = line.IndexOf("DeckDirectory=");
                    deckDirectory = line.Substring(index + "DeckDirectory=".Length).Replace("/", "\\").TrimEnd('\\') + "\\";
                }
            }
            if (cardTextDirectory == null || cardImageDirectory == null || limitRegulationPath == null)
            {
                throw new InvalidOperationException("カードデータフォルダを特定できません");
            }
            if (deckDirectory == null)
            {
                throw new InvalidOperationException("デッキ保存フォルダを特定できません");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IEnumerable<Card> EnumerateCards()
        {
            return Directory.EnumerateFiles(cardTextDirectory)
                .Where(path => Path.GetExtension(path).ToLower() == ".json")
                .Select(path => File.ReadAllText(path))
                .Select(json => Json.Deserialize<Card>(json))
                .Where(card => card.IdentityShortName != null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IEnumerable<string> EnumerateDecknames()
        {
            return Directory.EnumerateFiles(deckDirectory)
                .Where(path => Path.GetExtension(path).ToLower() == ".json")
                .Select(path => Path.GetFileNameWithoutExtension(path));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static Bitmap ReadImage(string cardName)
        {
            var path = cardImageDirectory + cardName + ".jpg";
            return new Bitmap(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static LimitRegulationDatabase ReadLimitRegulationDatabase()
        {
            var json = File.ReadAllText(limitRegulationPath);
            return Json.Deserialize<LimitRegulationDatabase>(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deckName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Deck ReadDeck(string deckName)
        {
            var path = deckDirectory + deckName + ".json";
            var json = File.ReadAllText(path);
            return Json.Deserialize<Deck>(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deck"></param>
        /// <exception cref="Exception"></exception>
        public static void WriteDeck(Deck deck)
        {
            var path = deckDirectory + deck.Name + ".json";
            var json = Json.Serialize(deck);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deckName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static void DeleteDeck(string deckName)
        {
            var path = deckDirectory + deckName + ".json";
            File.Delete(path);
        }
    }
}
