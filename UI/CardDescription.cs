using System.Drawing;
using System.Windows.Forms;
using YugiohDeck.Database;
using YugiohCardDatabase;

namespace YugiohDeck.UI
{
    partial class CardDescription : UserControl
    {
        private Card card;
        public Card Card
        {
            get => this.card;
            set
            {
                if (value == null)
                {
                    this.card = null;
                    this.pictureBox.Image = this.pictureBox.ErrorImage;
                    return;
                }
                this.card = value;
                this.headerLabel.Text = value.ConstructFormattedInfoWithoutDescription();
                this.descriptionLabel.Text = value.Description;
                var back = CardColor.GetColor(value.Kinds);
                var front = Color.FromArgb(back.R ^ 0xff, back.G ^ 0xff, back.B ^ 0xff);
                this.headerLabel.ForeColor = front;
                this.descriptionLabel.ForeColor = front;
                this.BackColor = back;
                this.pictureBox.Image = CardImageCollection.GetImageOf(value.IdentityShortName);
            }
        }
        public CardDescription()
        {
            InitializeComponent();
        }
    }
}
