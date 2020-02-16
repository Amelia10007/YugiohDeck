using System.Collections.Generic;
using System.IO;
using System.Drawing;

#nullable enable

namespace YugiohDeck.Database
{
    static class CardImageCollection
    {
        static private readonly IDictionary<string, Image> cardImages = new Dictionary<string, Image>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
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
