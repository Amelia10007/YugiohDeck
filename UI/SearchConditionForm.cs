using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YugiohDeck.Core;
using YugiohDeck.Database;

namespace YugiohDeck.UI
{
    partial class SearchConditionForm : Form
    {
        private static readonly string listBoxNoSelectedItem = "None";

        public bool AllButtonsEnabled
        {
            set
            {
                this.searchButton.Enabled = value;
                this.clearConditionButton.Enabled = value;
            }
        }

        public event EventHandler<SearchCondition> SearchButtonClicked;

        public SearchConditionForm()
        {
            InitializeComponent();
            //
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
        }

        private SearchCondition CreateSearchConditionFromForm()
        {
            return new SearchCondition()
            {
                NameCondition = this.GetNameCondition(),
                PronunciationCondition = this.GetPronunciationCondition(),
                DescriptionCondition = this.GetDescriptionCondition(),
                CardKindCondition = this.GetCardKindCondition(),
                MonsterLevel = this.GetMonsterLevelCondition(),
                MonsterAttribute = this.GetMonsterAttributeCondition(),
                MonsterType = this.GetMonsterTypeCondition(),
                MonsterAttack = this.GetMonsterAttackCondition(),
                MonsterDefence = this.GetMonsterDefenceCondition(),
                MaxResultCount = this.GetResultCount(),
            };
        }

        private Option<TextSearchCondition> GetNameCondition()
        {
            if (this.nameTextBox.Text.Any())
            {
                var keywords = GetKeywords(this.nameTextBox.Text);
                return Option<TextSearchCondition>.Some(new TextSearchCondition()
                {
                    Combination = SearchConditionCombination.And,
                    Words = keywords
                });
            }
            else
            {
                return Option<TextSearchCondition>.None;
            }
        }

        private Option<PronunciationSearchCondition> GetPronunciationCondition()
        {
            if (this.pronunciationTextBox.Text.Any())
            {
                var keywords = GetKeywords(this.pronunciationTextBox.Text);
                return Option<PronunciationSearchCondition>.Some(new PronunciationSearchCondition()
                {
                    Combination = SearchConditionCombination.And,
                    Words = keywords,
                });
            }
            else
            {
                return Option<PronunciationSearchCondition>.None;
            }
        }

        private Option<TextSearchCondition> GetDescriptionCondition()
        {
            if (this.textTextBox.Text.Any())
            {

                var keywords = GetKeywords(this.textTextBox.Text);
                return Option<TextSearchCondition>.Some(new TextSearchCondition()
                {
                    Combination = SearchConditionCombination.And,
                    Words = keywords
                });
            }
            else
            {
                return Option<TextSearchCondition>.None;
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
                return Option<CardKindSearchCondition>.Some(new CardKindSearchCondition()
                {
                    CardKinds = kinds,
                    Combination = SearchConditionCombination.And,
                });
            }
            else
            {
                return Option<CardKindSearchCondition>.None;
            }
        }

        private Option<MonsterLevelSearchCondition> GetMonsterLevelCondition()
        {
            if (!this.levelCheckBox.Checked)
            {
                return Option<MonsterLevelSearchCondition>.None;
            }
            try
            {
                var min = (int)this.levelMinUpDown.Value;
                var max = (int)this.levelMaxUpDown.Value;
                return Option<MonsterLevelSearchCondition>.Some(new MonsterLevelSearchCondition()
                {
                    Range = new Range<int>(min, max),
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return Option<MonsterLevelSearchCondition>.None;
            }
        }

        private Option<string> GetMonsterAttributeCondition()
        {
            if (this.monsterAttributeListBox.SelectedIndex == -1 || this.monsterAttributeListBox.SelectedItem == (object)listBoxNoSelectedItem)
            {
                return Option<string>.None;
            }
            else
            {
                return Option<string>.Some(this.monsterAttributeListBox.SelectedItem.ToString());
            }
        }

        private Option<string> GetMonsterTypeCondition()
        {
            if (this.monsterTypeListBox.SelectedIndex == -1 || this.monsterTypeListBox.SelectedItem == (object)listBoxNoSelectedItem)
            {
                return Option<string>.None;
            }
            else
            {
                return Option<string>.Some(this.monsterTypeListBox.SelectedItem.ToString());
            }
        }

        private Option<MonsterBattleStatusRange> GetMonsterAttackCondition()
        {
            if (!this.attackCheckBox.Checked)
            {
                return Option<MonsterBattleStatusRange>.None;
            }
            try
            {
                var min = (int)this.monsterAttackMinUpDown.Value;
                var max = (int)this.monsterAttackMaxUpDown.Value;
                var allowUndefinition = this.monsterAttackAllowUndefinitionCheckBox.Checked;
                return Option<MonsterBattleStatusRange>.Some(new MonsterBattleStatusRange()
                {
                    Range = Option<Range<int>>.Some(new Range<int>(min, max)),
                    AllowUndefinedBattleStatus = allowUndefinition,
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return Option<MonsterBattleStatusRange>.None;
            }
        }

        private Option<MonsterBattleStatusRange> GetMonsterDefenceCondition()
        {
            if (!this.defenceCheckBox.Checked)
            {
                return Option<MonsterBattleStatusRange>.None;
            }
            try
            {
                var min = (int)this.monsterDefenceMinUpDown.Value;
                var max = (int)this.monsterDefenceMaxUpDown.Value;
                var allowUndefinition = this.monsterDefenceAllowUndefinitionCheckBox.Checked;
                return Option<MonsterBattleStatusRange>.Some(new MonsterBattleStatusRange()
                {
                    Range = Option<Range<int>>.Some(new Range<int>(min, max)),
                    AllowUndefinedBattleStatus = allowUndefinition,
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return Option<MonsterBattleStatusRange>.None;
            }
        }

        private int GetResultCount()
        {
            return (int)this.resultCountUpDown.Value;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var condition = this.CreateSearchConditionFromForm();
            this.SearchButtonClicked?.Invoke(this, condition);
        }

        private void clearConditionButton_Click(object sender, EventArgs e)
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
            this.levelCheckBox.Checked = false;
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
