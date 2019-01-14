using System;
using System.Drawing;
using System.Windows.Forms;
using YugiohDeck.Core;
using YugiohDeck.Database;

namespace YugiohDeck.UI
{
    partial class DeckView : UserControl
    {
        public event EventHandler<string> MessageSent;
        private Deck deck;
        public Deck Deck
        {
            get => this.deck;
            set
            {
                this.deck = value;
                this.UpdateDeckView(value.MainDeck, this.mainDeckPanel);
                this.UpdateDeckView(value.ExtraDeck, this.extraDeckPanel);
                this.UpdateDeckView(value.SideDeck, this.sideDeckPanel);
            }
        }
        public event EventHandler<Card> DescriptionRequested;
        public event EventHandler<string> DeckRenamed;
        public event EventHandler DeckRemoved;
        public event EventHandler DeckClosed;
        public DeckView()
        {
            InitializeComponent();
        }
        public void AddCardToMainDeck(Card card)
        {
            this.Deck.MainDeck.Add(card);
            this.AddCardToDeckView(this.mainDeckPanel, this.Deck.MainDeck, card);
            this.MessageSent?.Invoke(this, $"{card.Name}をメインデッキに追加しました．");
        }
        public void AddCardToExtraDeck(Card card)
        {
            this.Deck.ExtraDeck.Add(card);
            this.AddCardToDeckView(this.extraDeckPanel, this.Deck.ExtraDeck, card);
            this.MessageSent?.Invoke(this, $"{card.Name}をエクストラデッキに追加しました．");
        }
        public void AddCardToSideDeck(Card card)
        {
            this.Deck.SideDeck.Add(card);
            this.AddCardToDeckView(this.sideDeckPanel, this.Deck.SideDeck, card);
            this.MessageSent?.Invoke(this, $"{card.Name}をサイドデッキに追加しました．");
        }
        private void UpdateDeckCountLabel()
        {
            var isLegal = this.Deck.IsLegalDeck();
            var labelColor = isLegal ? Color.Black : Color.Red;
            this.deckCountLabel.ForeColor = labelColor;
            this.deckCountLabel.Text = $"Main: {this.Deck.MainDeck.Count}, Extra: {this.Deck.ExtraDeck.Count}, Side: {this.Deck.SideDeck.Count}";
        }
        private void UpdateDeckView(DeckUnit deck, Panel panel)
        {
            panel.Controls.Clear();
            foreach (var card in deck.Cards)
            {
                this.AddCardToDeckView(panel, deck, card);
            }
        }
        private void AddCardToDeckView(Panel panel, DeckUnit deck, Card card)
        {
            var insertIndex = deck.Cards.IndexOf(card);
            var view = new CardView() { Card = card };
            view.DescriptionRequested += (_, e) => this.DescriptionRequested?.Invoke(this, e);
            view.AddButtonClicked += (_, e) =>
            {
                deck.Add(card);
                this.AddCardToDeckView(panel, deck, card);
                this.MessageSent?.Invoke(this, $"{card.Name}をデッキに追加しました．");
            };
            view.RemoveButtonClicked += (_, e) =>
            {
                this.RemoveCardFromDeckView(panel, deck, card);
                this.MessageSent?.Invoke(this, $"{card.Name}をデッキから削除しました．");
            };
            panel.Controls.Add(view);
            panel.Controls.SetChildIndex(view, insertIndex);
            this.UpdateDeckCountLabel();
        }

        private void RemoveCardFromDeckView(Panel panel, DeckUnit deck, Card card)
        {
            var removeIndex = deck.Cards.IndexOf(card);
            deck.Remove(card);
            panel.Controls.RemoveAt(removeIndex);
            this.UpdateDeckCountLabel();
            this.MessageSent?.Invoke(this, $"{card.Name}をデッキから削除しました．");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                LocalDeckDatabase.SaveDeck(this.Deck);
                this.MessageSent?.Invoke(this, $"デッキ:{this.Deck.Name}を保存しました．");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.ParentForm, "デッキの保存に失敗しました．\n" + ex.Message);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("デッキの内容をクリアしますか?", "デッキクリア", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                this.Deck.Clear();
                this.mainDeckPanel.Controls.Clear();
                this.extraDeckPanel.Controls.Clear();
                this.sideDeckPanel.Controls.Clear();
            }
            this.MessageSent?.Invoke(this, $"デッキ:{this.Deck.Name}から全カードを削除しました．");
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            var inputForm = new InputForm()
            {
                InputTitle = "新しいデッキ名を決めてください",
            };
            inputForm.ShowDialog(this.ParentForm);
            if (inputForm.InputResult != DialogResult.OK) return;
            var deckName = inputForm.InputText;
            try
            {
                LocalDeckDatabase.DeleteDeck(this.Deck.Name);
                this.Deck.Name = deckName;
                LocalDeckDatabase.SaveDeck(this.Deck);
                this.DeckRenamed?.Invoke(this, deckName);
                this.MessageSent?.Invoke(this, "デッキ名を変更しました．");
            }
            catch(Exception ex)
            {
                MessageBox.Show(this.ParentForm, "デッキの名前変更に失敗しました．\n" + ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("デッキを削除しますか?", "デッキ削除", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                try
                {
                    LocalDeckDatabase.DeleteDeck(this.Deck.Name);
                    this.DeckRemoved?.Invoke(this, EventArgs.Empty);
                    this.MessageSent?.Invoke(this, $"デッキ:{this.Deck.Name}を削除しました．");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this.ParentForm, "デッキの削除に失敗しました．\n" + ex.Message);
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DeckClosed?.Invoke(this, EventArgs.Empty);
            this.MessageSent?.Invoke(this, $"デッキ:{this.Deck.Name}を閉じました．");
        }

        private void drawTestButton_Click(object sender, EventArgs e)
        {
            var drawTestForm = new DrawTestForm(this.Deck.MainDeck.Cards);
            drawTestForm.Show(this.ParentForm);
        }
    }
}
