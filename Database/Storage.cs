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
    enum FileType
    {
        CardText,
        CardImage,
        LimitRegulation,
        Deck,
    }

    static class Storage
    {
        private static readonly Dictionary<FileType, string> directoryPaths = new Dictionary<FileType, string>();

        public static IEnumerable<Card> EnumerateCards()
        {
            if (!directoryPaths.Any()) LoadDirectoryPathSetting();
            var ss = directoryPaths[FileType.CardText];
            return Directory.EnumerateFiles(directoryPaths[FileType.CardText])
                .Where(path => Path.GetExtension(path).ToLower() == ".json")
                .Select(path => File.ReadAllText(path))
                .Select(json => Json.Deserialize<Card>(json))
                .Where(card => card.IdentityShortName != null);
        }

        public static IEnumerable<string> EnumerateDecknames()
        {
            if (!directoryPaths.Any()) LoadDirectoryPathSetting();
            return Directory.EnumerateFiles(directoryPaths[FileType.Deck])
                .Where(path => Path.GetExtension(path).ToLower() == ".json")
                .Select(path => Path.GetFileNameWithoutExtension(path));
        }

        public static Card ReadCard(string cardName)
        {
            if (!directoryPaths.Any()) LoadDirectoryPathSetting();
            var path = directoryPaths[FileType.CardText] + cardName + ".json";
            var json = File.ReadAllText(path);
            return Json.Deserialize<Card>(json);
        }

        public static Bitmap ReadImage(string cardName)
        {
            if (!directoryPaths.Any()) LoadDirectoryPathSetting();
            var path = directoryPaths[FileType.CardImage] + cardName + ".jpg";
            return new Bitmap(path);
        }

        public static LimitRegulationDatabase ReadLimitRegulationDatabase()
        {
            if (!directoryPaths.Any()) LoadDirectoryPathSetting();
            var path = directoryPaths[FileType.LimitRegulation];
            var json = File.ReadAllText(path);
            return Json.Deserialize<LimitRegulationDatabase>(json);
        }

        public static Deck ReadDeck(string deckName)
        {
            if (!directoryPaths.Any()) LoadDirectoryPathSetting();
            var path = directoryPaths[FileType.Deck] + deckName + ".json";
            var json = File.ReadAllText(path);
            return Json.Deserialize<Deck>(json);
        }

        public static void WriteDeck(Deck deck)
        {
            if (!directoryPaths.Any()) LoadDirectoryPathSetting();
            var path = directoryPaths[FileType.Deck] + deck.Name + ".json";
            var json = Json.Serialize(deck);
            File.WriteAllText(path, json);
        }

        public static void DeleteDeck(string deckName)
        {
            if (!directoryPaths.Any()) LoadDirectoryPathSetting();
            var path = directoryPaths[FileType.Deck] + deckName + ".json";
            File.Delete(path);
        }

        private static void LoadDirectoryPathSetting()
        {
            directoryPaths.Clear();
            var settingFilePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\setting.txt";
            var lines = File.ReadAllLines(settingFilePath);
            foreach (var line in lines)
            {
                if (line.IndexOf("CardDataDirectory=") != -1)
                {
                    var index = line.IndexOf("CardDataDirectory=");
                    var cardDataDirectory = line.Substring(index + "CardDataDirectory=".Length).Replace("/", "\\").TrimEnd('\\');
                    if (!directoryPaths.ContainsKey(FileType.CardText))
                    {
                        directoryPaths.Add(FileType.CardText, cardDataDirectory + "\\text\\");
                    }
                    if (!directoryPaths.ContainsKey(FileType.CardImage))
                    {
                        directoryPaths.Add(FileType.CardImage, cardDataDirectory + "\\image\\");
                    }
                    if (!directoryPaths.ContainsKey(FileType.LimitRegulation))
                    {
                        directoryPaths.Add(FileType.LimitRegulation, cardDataDirectory + "\\LimitRegulation.json");
                    }
                }
                else if (line.IndexOf("DeckDirectory=") != -1)
                {
                    var index = line.IndexOf("DeckDirectory=");
                    var deckDirectory = line.Substring(index + "DeckDirectory=".Length).Replace("/", "\\").TrimEnd('\\') + "\\";
                    if (!directoryPaths.ContainsKey(FileType.Deck))
                    {
                        directoryPaths.Add(FileType.Deck, deckDirectory);
                    }
                }
            }
        }
    }
}
