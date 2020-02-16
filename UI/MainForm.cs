﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YugiohDeck.Core;
using YugiohDeck.Database;
using System.Threading.Tasks;
using System.Threading;
using YugiohCardDatabase;

namespace YugiohDeck.UI
{
    public partial class MainForm : Form
    {
        private static readonly string listBoxNoSelectedItem = "None";

        private readonly SynchronizationContext uiContext;
        private LimitRegulationDatabase limitRegulationDatabase;


        private DeckView ActiveDeckView => this.deckTab.SelectedTab?.Controls[0] as DeckView;

        public MainForm()
        {
            InitializeComponent();
            this.uiContext = SynchronizationContext.Current;
            //検索タブの初期化
            foreach (var kindListBox in this.kindFlowLayoutPanel.Controls)
            {
                if (!(kindListBox is ListBox))
                {
                    throw new InvalidOperationException($"All children must be {typeof(ListBox)}");
                }
                var asListBox = kindListBox as ListBox;
                asListBox.Items.Clear();
                asListBox.Items.Add(listBoxNoSelectedItem);
                foreach (var kind in CardKind.CardKinds)
                {
                    asListBox.Items.Add(kind);
                }
            }
            //
            this.monsterAttributeListBox.Items.Clear();
            this.monsterAttributeListBox.Items.AddRange(new[] { listBoxNoSelectedItem, "光", "闇", "炎", "水", "地", "風", "神" });
            //
            this.monsterTypeListBox.Items.Clear();
            this.monsterTypeListBox.Items.AddRange(new[]
            {
                listBoxNoSelectedItem, "ドラゴン","魔法使い","アンデット","戦士","獣戦士","獣","鳥獣","悪魔","天使","昆虫","恐竜","爬虫類","魚","海竜","機械","雷","水","炎","岩石","植物","サイキック","サイバース","幻竜","幻神獣","創造神"
            });
            //
            this.Shown += this.ReadyForEditingAsync;
        }

        private void SetMessageLabel(string message)
        {
            this.uiContext.Post(_ => { this.messageLabel.Text = message; }, null);
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
            Deck deck;
            if (createNew)
            {
                deck = new Deck(deckName);
            }
            else
            {
                try
                {
                    deck = Storage.ReadDeck(deckName);
                }
                catch (Exception ex)
                {
                    this.messageLabel.Text = $"デッキ:{deckName}を読み込めませんでした:{ex.Message}";
                    return;
                }
            }
            var deckView = new DeckView(this.limitRegulationDatabase) { Deck = deck };
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
            this.searchButton.Enabled = enabled;
            this.conditionClearButton.Enabled = enabled;
            this.createButton.Enabled = enabled;
            this.openButton.Enabled = enabled;
        }

        private async void ReadyForEditingAsync(object sender, EventArgs e)
        {
            this.EnableAllButtons(false);
            await Task.Run(() =>
            {
                try
                {
                    LocalCardDatabase.LoadAllExistingCards(s => this.SetMessageLabel(s));
                    this.limitRegulationDatabase = Storage.ReadLimitRegulationDatabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "データベースの読み込みに失敗");
                    throw;
                }
            });
            this.SetMessageLabel("Ready");
            this.EnableAllButtons(true);
        }

        private Option<TextSearchCondition> GetNameCondition()
        {
            if (this.nameTextBox.Text.Any())
            {
                var keywords = GetKeywords(this.nameTextBox.Text);
                return Option.Some(new TextSearchCondition()
                {
                    Combination = SearchConditionCombination.And,
                    Words = keywords
                });
            }
            else
            {
                return Option.None<TextSearchCondition>();
            }
        }

        private Option<PronunciationSearchCondition> GetPronunciationCondition()
        {
            if (this.pronunciationTextBox.Text.Any())
            {
                var keywords = GetKeywords(this.pronunciationTextBox.Text);
                return Option.Some(new PronunciationSearchCondition()
                {
                    Combination = SearchConditionCombination.And,
                    Words = keywords,
                });
            }
            else
            {
                return Option.None<PronunciationSearchCondition>();
            }
        }

        private Option<TextSearchCondition> GetDescriptionCondition()
        {
            if (this.textTextBox.Text.Any())
            {

                var keywords = GetKeywords(this.textTextBox.Text);
                return Option.Some(new TextSearchCondition()
                {
                    Combination = SearchConditionCombination.And,
                    Words = keywords
                });
            }
            else
            {
                return Option.None<TextSearchCondition>();
            }
        }

        private Option<CardKindSearchCondition> GetCardKindCondition()
        {
            var kinds = new List<CardKind>();
            foreach (var kindListBox in this.kindFlowLayoutPanel.Controls)
            {
                if (!(kindListBox is ListBox))
                {
                    throw new InvalidOperationException($"All children must be {typeof(ListBox)}");
                }
                var asListBox = kindListBox as ListBox;
                if (asListBox.SelectedIndex == -1)
                {
                    continue;
                }
                if (asListBox.SelectedItem == (object)listBoxNoSelectedItem)
                {
                    continue;
                }
                kinds.Add(asListBox.SelectedItem as CardKind);
            }
            if (kinds.Any())
            {
                return Option.Some(new CardKindSearchCondition()
                {
                    CardKinds = kinds,
                    Combination = SearchConditionCombination.And,
                });
            }
            else
            {
                return Option.None<CardKindSearchCondition>();
            }
        }

        private Option<MonsterLevelSearchCondition> GetMonsterLevelCondition()
        {
            if (!this.levelRadioButton.Checked)
            {
                return Option.None<MonsterLevelSearchCondition>();
            }
            try
            {
                var min = this.levelMinUpDown.Value;
                var max = this.levelMaxUpDown.Value;
                return Option.Some(new MonsterLevelSearchCondition()
                {
                    Range = new Range<byte>((byte)min, (byte)max),
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return Option.None<MonsterLevelSearchCondition>();
            }
        }

        private Option<MonsterRankSearchCondition> GetMonsterRankSearchCondition()
        {
            if (!this.rankRadioButton.Checked)
            {
                return Option.None<MonsterRankSearchCondition>();
            }
            try
            {
                var min = this.levelMinUpDown.Value;
                var max = this.levelMaxUpDown.Value;
                return Option.Some(new MonsterRankSearchCondition()
                {
                    Range = new Range<byte>((byte)min, (byte)max),
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return Option.None<MonsterRankSearchCondition>();
            }
        }

        private Option<MonsterLinkSearchCondition> GetMonsterLinkSearchCondition()
        {

            if (!this.linkRadioButton.Checked)
            {
                return Option.None<MonsterLinkSearchCondition>();
            }
            try
            {
                var min = this.levelMinUpDown.Value;
                var max = this.levelMaxUpDown.Value;
                return Option.Some(new MonsterLinkSearchCondition()
                {
                    Range = new Range<int>((int)min, (int)max),
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return Option.None<MonsterLinkSearchCondition>();
            }
        }

        private Option<MonsterAttribute> GetMonsterAttributeCondition()
        {
            if (this.monsterAttributeListBox.SelectedIndex == -1 || this.monsterAttributeListBox.SelectedItem == (object)listBoxNoSelectedItem)
            {
                return Option.None<MonsterAttribute>();
            }
            else
            {
                return Option.Some(new MonsterAttribute(this.monsterAttributeListBox.SelectedItem.ToString()));
            }
        }

        private Option<MonsterRace> GetMonsterRaceCondition()
        {
            if (this.monsterTypeListBox.SelectedIndex == -1 || this.monsterTypeListBox.SelectedItem == (object)listBoxNoSelectedItem)
            {
                return Option.None<MonsterRace>();
            }
            else
            {
                return Option.Some(new MonsterRace(this.monsterTypeListBox.SelectedItem.ToString()));
            }
        }

        private Option<MonsterAttackRange> GetMonsterAttackCondition()
        {
            if (!this.attackCheckBox.Checked)
            {
                return Option.None<MonsterAttackRange>();
            }
            try
            {
                var min = (int)this.monsterAttackMinUpDown.Value;
                var max = (int)this.monsterAttackMaxUpDown.Value;
                var allowUndefinition = this.monsterAttackAllowUndefinitionCheckBox.Checked;
                return Option.Some(new MonsterAttackRange()
                {
                    Range = new Range<int>(min, max),
                    AllowUndefinedBattleStatus = allowUndefinition,
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return Option.None<MonsterAttackRange>();
            }
        }

        private Option<MonsterDefenceRange> GetMonsterDefenceCondition()
        {
            if (!this.defenceCheckBox.Checked)
            {
                return Option.None<MonsterDefenceRange>();
            }
            try
            {
                var min = (int)this.monsterDefenceMinUpDown.Value;
                var max = (int)this.monsterDefenceMaxUpDown.Value;
                var allowUndefinition = this.monsterDefenceAllowUndefinitionCheckBox.Checked;
                return Option.Some(new MonsterDefenceRange()
                {
                    Range = new Range<int>(min, max),
                    AllowUndefinedBattleStatus = allowUndefinition,
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return Option.None<MonsterDefenceRange>();
            }
        }

        private int GetResultCount()
        {
            return (int)this.resultCountUpDown.Value;
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
            try
            {
                if (Storage.EnumerateDecknames().Contains(deckName))
                {
                    MessageBox.Show($"デッキ \'{deckName}\'は既に存在します．");
                    return;
                }
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
            var openedDeckNames = new List<string>();
            foreach (var page in this.deckTab.TabPages)
            {
                var deckName = ((page as TabPage)?.Controls[0] as DeckView)?.Deck.Name;
                if (deckName != null) openedDeckNames.Add(deckName);
            }
            DeckSelectForm selectForm;
            try
            {
                selectForm = new DeckSelectForm() { DeckNames = Storage.EnumerateDecknames().ToArray() };
            }
            catch (Exception ex)
            {
                this.messageLabel.Text = $"デッキ選択フォームを開けませんでした:{ex.Message}";
                return;
            }
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

        private async void searchButton_Click(object sender, EventArgs e)
        {
            this.SetMessageLabel("検索中...");
            this.EnableAllButtons(false);
            var searchCondition = new SearchCondition()
            {
                NameCondition = this.GetNameCondition(),
                PronunciationCondition = this.GetPronunciationCondition(),
                DescriptionCondition = this.GetDescriptionCondition(),
                CardKindCondition = this.GetCardKindCondition(),
                LevelCondition = this.GetMonsterLevelCondition(),
                RankCondition = this.GetMonsterRankSearchCondition(),
                LinkCondition = this.GetMonsterLinkSearchCondition(),
                AttributeCondition = this.GetMonsterAttributeCondition(),
                RaceCodition = this.GetMonsterRaceCondition(),
                AttackCondition = this.GetMonsterAttackCondition(),
                DefenceCondition = this.GetMonsterDefenceCondition(),
                MaxResultCount = this.GetResultCount(),
            };
            this.ClearSearchResult();
            var matchedCards = (await Task.Run(() => LocalCardDatabase.SearchCardsByCondition(searchCondition))).ToArray();
            this.SetMessageLabel($"{matchedCards.Length}件ヒット");
            foreach (var card in matchedCards)
            {
                this.AddSearchResult(card);
            }
            this.tabControl.SelectedIndex = 1;
            this.EnableAllButtons(true);
        }

        private void conditionClearButton_Click(object sender, EventArgs e)
        {
            this.nameTextBox.Text = "";
            this.pronunciationTextBox.Text = "";
            this.textTextBox.Text = "";
            //card kind
            foreach (var kindListBox in this.kindFlowLayoutPanel.Controls)
            {
                if (!(kindListBox is ListBox))
                {
                    throw new InvalidOperationException($"All children must be {typeof(ListBox)}");
                }
                var asListBox = kindListBox as ListBox;
                asListBox.SelectedIndex = -1;
            }
            //level
            this.nonRadioButton.Checked = true;
            this.levelMinUpDown.Value = this.levelMinUpDown.Minimum;
            this.levelMaxUpDown.Value = this.levelMaxUpDown.Maximum;
            //
            this.monsterAttributeListBox.SelectedIndex = -1;
            this.monsterTypeListBox.SelectedIndex = -1;
            //attack
            this.attackCheckBox.Checked = false;
            this.monsterAttackMinUpDown.Value = this.monsterAttackMinUpDown.Minimum;
            this.monsterAttackMaxUpDown.Value = this.monsterAttackMaxUpDown.Maximum;
            this.monsterAttackAllowUndefinitionCheckBox.Checked = false;
            //defence
            this.defenceCheckBox.Checked = false;
            this.monsterDefenceMinUpDown.Value = this.monsterDefenceMinUpDown.Minimum;
            this.monsterDefenceMaxUpDown.Value = this.monsterDefenceMaxUpDown.Maximum;
            this.monsterDefenceAllowUndefinitionCheckBox.Checked = false;
        }

        private static string[] GetKeywords(string source)
        {
            return source.Split(' ', ',', ' ', '\t');
        }
    }
}
