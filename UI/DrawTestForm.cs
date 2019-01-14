using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YugiohDeck.Core;

namespace YugiohDeck.UI
{
    partial class DrawTestForm : Form
    {
        private readonly Random random = new Random();
        private readonly Card[] cards;
        private IList<int> drawnCardIndexes;
        public event EventHandler<Card> DescriptionRequested;
        public DrawTestForm(IEnumerable<Card> cards)
        {
            InitializeComponent();
            this.cards = cards.ToArray();
            this.drawnCardIndexes = new List<int>();
        }
        private void DrawRandomCard()
        {
            var remainingIndexes = Enumerable.Range(0, this.cards.Length)
                .Except(this.drawnCardIndexes)
                .ToArray();
            if (!remainingIndexes.Any())
            {
                this.messageLabel.Text = "もう引けるカードがない！";
                return;
            }
            var drawIndex = remainingIndexes[this.random.Next(remainingIndexes.Length)];
            var drawnCard = this.cards[drawIndex];
            this.drawnCardIndexes.Add(drawIndex);
            this.AddCardToView(drawnCard);
        }
        private void AddCardToView(Card card)
        {
            var cardView = new CardView() { Card = card };
            cardView.DescriptionRequested += (_, e) => this.DescriptionRequested?.Invoke(this, e);
            this.panel.Controls.Add(cardView);
            this.messageLabel.Text = $"{card.Name}を引いた";
        }
        private void drawButton_Click(object sender, EventArgs e)
        {
            this.drawnCardIndexes.Clear();
            this.panel.Controls.Clear();
            if (!int.TryParse(this.drawCountTextBox.Text, out var drawCount))
            {
                this.messageLabel.Text = $"'{this.drawCountTextBox.Text}'を整数に変換できません．";
                return;
            }
            foreach (var _ in Enumerable.Range(0,drawCount))
            {
                this.DrawRandomCard();
            }
        }

        private void additionalDrawButton_Click(object sender, EventArgs e)
        {
            this.DrawRandomCard();
        }
    }
}
