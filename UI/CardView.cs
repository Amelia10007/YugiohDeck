using System;
using System.Windows.Forms;
using YugiohDeck.Core;
using YugiohDeck.Database;
using System.Drawing;

namespace YugiohDeck.UI
{
    partial class CardView : UserControl
    {
        private Card card;
        public event EventHandler<Card> AddButtonClicked;
        public event EventHandler<Card> RemoveButtonClicked;
        public event EventHandler<Card> DescriptionRequested;
        public Card Card
        {
            get => this.card;
            set
            {
                this.card = value;
                this.pictureBox.Image = this.GetCardImageWithLimitation(value);
            }
        }
        public CardView()
        {
            InitializeComponent();
        }

        private Image GetCardImageWithLimitation(Card card)
        {
            var image = new Bitmap(CardImageCollection.GetImageOf(card.Name));
            if (card.Limitation.Equals(CardLimitation.Unlimited))
            {
                return image;
            }
            // カードの禁止制限に合わせたアイコンを描画する
            using (var graphic = Graphics.FromImage(image))
            {
                // アイコンサイズは見栄えが良くなるように適当に決めた
                var iconLength = Math.Min(image.Width, image.Height) * 2 / 5;
                var iconSize = new Size(iconLength, iconLength);
                // アイコンはカード画像の中心に表示させる
                var iconLocation = new Point((image.Width - iconSize.Width) / 2, (image.Height - iconSize.Height) / 2);
                var iconRectangle = new Rectangle(iconLocation, iconSize);
                //
                if (card.Limitation.Equals(CardLimitation.Forbidden))
                {
                    graphic.DrawIcon(SystemIcons.Error, iconRectangle);
                }
                else if (card.Limitation.Equals(CardLimitation.Limited))
                {
                    graphic.DrawIcon(SystemIcons.Warning, iconRectangle);
                }
                else if (card.Limitation.Equals(CardLimitation.SemiLimited))
                {
                    graphic.DrawIcon(SystemIcons.Information, iconRectangle);
                }
            }
            return image;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.AddButtonClicked?.Invoke(this, this.Card);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            this.RemoveButtonClicked?.Invoke(this, this.Card);
        }

        private void pictureBox_MouseHover(object sender, EventArgs e)
        {
            this.DescriptionRequested?.Invoke(this, this.card);
        }
    }
}
