using System;
using System.IO;
using System.Drawing;
using System.Runtime.Serialization;
using System.Drawing.Imaging;

namespace YugiohDeck.Core
{
    [DataContract]
    class CardImage
    {
        private static readonly int imageWidth = 120;
        public Image Image { get; private set; }
        [DataMember]
        private byte[] ImageBytes
        {
            get
            {
                using (var stream = new MemoryStream())
                {
                    this.Image.Save(stream, ImageFormat.Jpeg);
                    return stream.ToArray();
                }
            }
            set
            {
                using (var stream = new MemoryStream(value))
                {
                    this.Image = new Bitmap(stream);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <exception cref="Exception"></exception>
        public CardImage(Bitmap bitmap)
        {
            var resizeWidth = Math.Min(bitmap.Width, imageWidth);
            var resizeHeight = (int)(bitmap.Height * ((double)resizeWidth / (double)bitmap.Width));
            var resized = new Bitmap(resizeWidth, resizeHeight);
            using (var g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(bitmap, 0, 0, resizeWidth, resizeHeight);
            }
            this.Image = resized;
        }
    }
}
