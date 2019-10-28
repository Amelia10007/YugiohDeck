using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YugiohDeck.Core;
using YugiohDeck.Database;
using System.Threading.Tasks;

namespace YugiohDeck.UI
{
    public partial class MainForm : Form
    {
        private DeckView ActiveDeckView => this.deckTab.SelectedTab?.Controls[0] as DeckView;
        public MainForm()
        {
            InitializeComponent();
            this.messageLabel.Text = "カード データベースを読み込み中...";
            try
            {
                LocalCardDatabase.LoadAllExistingCards();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "データベースの読み込みに失敗");
            }
            this.messageLabel.Text = "Ready";
        }

        private void AddSearchResult(Card card)
        {
            var result = new Searchresult() { Card = card };
            result.MainDeckAddButtonClicked += this.MainDeckAddButton_Click;
            result.ExtraDeckAddButtonClicked += this.ExtraDeckAddButton_Click;
            result.SideDeckAddButtonClicked += this.SideDeckAddButton_Click;
            this.searchResultPanel.Controls.Add(result);
        }

        private void ClearSearchResult()
        {
            foreach (var result in this.searchResultPanel.Controls)
            {
                if (result is Searchresult sr)
                {
                    sr.MainDeckAddButtonClicked -= this.MainDeckAddButton_Click;
                    sr.ExtraDeckAddButtonClicked -= this.ExtraDeckAddButton_Click;
                    sr.SideDeckAddButtonClicked -= this.SideDeckAddButton_Click;
                }
            }
            this.searchResultPanel.Controls.Clear();
        }

        private void AddDeckView(string deckName, bool createNew)
        {
            var deck = createNew ? new Deck(deckName) : LocalDeckDatabase.SearchDeck(deckName);
            var deckView = new DeckView() { Deck = deck };
            var tabPage = new TabPage(deckName);
            deckView.DescriptionRequested += (_, card) => this.ShowCardDescription(card);
            deckView.DeckRenamed += (_, name) => tabPage.Text = name;
            deckView.DeckRemoved += (_, __) => this.deckTab.TabPages.Remove(tabPage);
            deckView.DeckClosed += (_, __) => this.deckTab.TabPages.Remove(tabPage);
            deckView.MessageSent += (_, message) => this.messageLabel.Text = message;
            tabPage.Controls.Add(deckView);
            this.deckTab.TabPages.Add(tabPage);
            this.deckTab.SelectedIndex = this.deckTab.TabCount - 1;
        }

        private void ShowCardDescription(Card card)
        {
            this.cardDescription.Card = card;
        }

        private void EnableAllButtons(bool enabled)
        {
            this.offlineSearchButton.Enabled = enabled;
            this.onlineSearchButton.Enabled = enabled;
            this.createButton.Enabled = enabled;
            this.openButton.Enabled = enabled;
        }

        private void MainDeckAddButton_Click(object sender, Card e)
        {
            this.ActiveDeckView?.AddCardToMainDeck(e);
        }

        private void ExtraDeckAddButton_Click(object sender, Card e)
        {
            this.ActiveDeckView?.AddCardToExtraDeck(e);
        }

        private void SideDeckAddButton_Click(object sender, Card e)
        {
            this.ActiveDeckView?.AddCardToSideDeck(e);
        }

        private async void offlineSearchButton_Click(object sender, EventArgs e)
        {
            this.messageLabel.Text = "検索中...";
            this.EnableAllButtons(false);
            var keyword = this.keywordTextBox.Text;
            var cards = await Task.Run(() => LocalCardDatabase.SearchCardsByName(keyword.Split(new[] { ' ', '　' })));
            this.ClearSearchResult();
            foreach (var card in cards)
            {
                this.AddSearchResult(card);
            }
            this.messageLabel.Text = "検索終了";
            this.EnableAllButtons(true);
        }

        private async void onlineSearchButton_Click(object sender, EventArgs e)
        {
            this.messageLabel.Text = "検索中...";
            this.EnableAllButtons(false);
            var keyword = this.keywordTextBox.Text;
            var cards = await Task.Run(() => LocalCardDatabase.SearchCardsByText(keyword.Split(new[] { ' ', '　' })));
            this.ClearSearchResult();
            foreach (var card in cards)
            {
                this.AddSearchResult(card);
            }
            this.messageLabel.Text = "検索終了";
            this.EnableAllButtons(true);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var inputForm = new InputForm()
            {
                InputTitle = "新しいデッキ名を決めてください",
            };
            inputForm.ShowDialog(this.ParentForm);
            if (inputForm.InputResult != DialogResult.OK) return;
            var deckName = inputForm.InputText;
            if (LocalDeckDatabase.EnumerateDeckNames().Contains(deckName))
            {
                MessageBox.Show($"デッキ \'{deckName}\'は既に存在します．");
                return;
            }
            try
            {
                this.AddDeckView(deckName, true);
                this.messageLabel.Text = $"デッキ:{deckName}を作成しました．";
            }
            catch (Exception ex)
            {
                this.messageLabel.Text = $"デッキ:{deckName}の作成に失敗しました:{ex.Message}";
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var deckNames = LocalDeckDatabase.EnumerateDeckNames();
            var openedDeckNames = new List<string>();
            foreach (var page in this.deckTab.TabPages)
            {
                var deckName = ((page as TabPage)?.Controls[0] as DeckView)?.Deck.Name;
                if (deckName != null) openedDeckNames.Add(deckName);
            }
            var selectForm = new DeckSelectForm() { DeckNames = deckNames.ToArray() };
            var result = selectForm.ShowDialog();
            if (result != DialogResult.OK) return;
            var selectedDeckNames = selectForm.SelectedDeckNames;
            var openDeckNames = selectedDeckNames.Except(openedDeckNames);
            foreach (var deckName in openDeckNames)
            {
                try
                {
                    this.AddDeckView(deckName, false);
                    this.messageLabel.Text = $"デッキ:{deckName}を開きました．";
                }
                catch (Exception ex)
                {
                    this.messageLabel.Text = $"デッキ:{deckName}を開けませんでした:{ex.Message}";
                }
            }
        }
    }
}
