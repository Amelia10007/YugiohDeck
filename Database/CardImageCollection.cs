using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace YugiohDeck.Database
{
    static class CardImageCollection
    {
        static private readonly IDictionary<string, Image> cardImages = new Dictionary<string, Image>();
        public static long ImageByteCount { get; private set; } = 0;
        public static Image GetImageOf(string cardName)
        {
            if (!cardImages.ContainsKey(cardName))
            {
                LoadImageOf(cardName);
            }
            return cardImages[cardName];
        }
        public static void ClearAllImages()
        {
            var initialSize = ImageByteCount;
            cardImages.Clear();
            ImageByteCount = 0;
        }
        private static void LoadImageOf(string cardName)
        {
            var bytes = Storage.ReadBytes(new[] { "card", "image", $"{cardName}.jpg" });
            using (var stream = new MemoryStream(bytes))
            {
                var image = new Bitmap(stream);
                cardImages.Add(cardName, image);
                ImageByteCount += stream.Length;
            }
        }
    }
}
