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
        private readonly SearchConditionForm searchConditionForm;
        private DeckView ActiveDeckView => this.deckTab.SelectedTab?.Controls[0] as DeckView;
        public MainForm()
        {
            InitializeComponent();
            //検索用ウィンドウも同時に作る
            this.searchConditionForm = new SearchConditionForm();
            this.searchConditionForm.SearchButtonClicked += this.PerformSearch;
            this.searchConditionForm.Show();
            //
            this.Shown += this.ReadyForEditingAsync;
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
            this.createButton.Enabled = enabled;
            this.openButton.Enabled = enabled;
            this.searchConditionForm.AllButtonsEnabled = enabled;
        }

        private async void ReadyForEditingAsync(object sender, EventArgs e)
        {
            this.EnableAllButtons(false);
            this.messageLabel.Text = "カード データベースを読み込み中...";
            await Task.Run(() =>
            {
                try
                {
                    LocalCardDatabase.LoadAllExistingCards();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "データベースの読み込みに失敗");
                }
            });
            this.messageLabel.Text = "Ready";
            this.EnableAllButtons(true);
        }

        private async void PerformSearch(object sender, SearchCondition searchCondition)
        {
            this.messageLabel.Text = "検索中...";
            this.EnableAllButtons(false);
            this.ClearSearchResult();
            var matchedCards = (await Task.Run(() => LocalCardDatabase.SearchCardsByCondition(searchCondition))).ToArray();
            this.messageLabel.Text = $"{matchedCards.Length}件ヒット";
            foreach (var card in matchedCards)
            {
                this.AddSearchResult(card);
            }
            this.EnableAllButtons(true);
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
