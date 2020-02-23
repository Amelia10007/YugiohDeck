using System;
using System.Linq;
using System.Windows.Forms;
using YugiohCardDatabase;

namespace YugiohDeck.UI
{
    partial class Searchresult : UserControl
    {
        public event EventHandler<Card> MainDeckAddButtonClicked;
        public event EventHandler<Card> ExtraDeckAddButtonClicked;
        public event EventHandler<Card> SideDeckAddButtonClicked;
     
        public Card Card
        {
            get => this.cardDescription.Card;
            set
            {
                this.cardDescription.LimitRegulationDatabase = this.LimitRegulationDatabase;
                this.cardDescription.Card = value;
                var back = CardColor.GetColor(value.Kinds);
                this.BackColor = back;
            }
        }

        public LimitRegulationDatabase LimitRegulationDatabase { get; set; }
        
        public Searchresult()
        {
            InitializeComponent();
        }

        private void mainDeckButton_Click(object sender, EventArgs e)
        {
            if (this.Card.Kinds.Any(k => k.IsExtra))
            {
                this.ExtraDeckAddButtonClicked?.Invoke(this, this.Card);
            }
            else
            {
                this.MainDeckAddButtonClicked?.Invoke(this, this.Card);
            }
        }

        private void sideDeckButton_Click(object sender, EventArgs e)
        {
            this.SideDeckAddButtonClicked?.Invoke(this, this.Card);
        }
    }
}
