using System;
using System.Windows.Forms;
using YugiohDeck.Database;
using System.Drawing;
using YugiohCardDatabase;

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
                try
                {
                    this.pictureBox.Image = new Bitmap(CardImageCollection.GetImageOf(value.IdentityShortName));
                }
                catch
                {
                    this.pictureBox.Image = this.pictureBox.ErrorImage;
                }
            }
        }
        public CardView()
        {
            InitializeComponent();
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
