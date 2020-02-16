using System.Collections.Generic;
using System.Drawing;

#nullable enable

namespace YugiohDeck.Database
{
    static class CardImageCollection
    {
        static private readonly IDictionary<string, Image> cardImages = new Dictionary<string, Image>();

        public static Image GetImageOf(string cardName)
        {
            if (!cardImages.ContainsKey(cardName))
            {
                var image = Storage.ReadImage(cardName);
                cardImages.Add(cardName, image);
            }
            return cardImages[cardName];
        }
    }
}
