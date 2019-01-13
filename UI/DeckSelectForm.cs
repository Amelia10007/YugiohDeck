using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace YugiohDeck.UI
{
    partial class DeckSelectForm : Form
    {
        public string[] DeckNames
        {
            set
            {
                this.deckCheckedListBox.Items.Clear();
                this.deckCheckedListBox.Items.AddRange(value);
            }
        }
        public IReadOnlyList<string> SelectedDeckNames
        {
            get
            {
                var value = new List<string>();
                foreach (var item in this.deckCheckedListBox.CheckedItems)
                {
                    value.Add(item.ToString());
                }
                return value;
            }
        }
        public DeckSelectForm()
        {
            InitializeComponent();
        }

        private void allCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var check = this.allCheckBox.Checked;
            foreach (var i in Enumerable.Range(0, this.deckCheckedListBox.Items.Count))
            {
                this.deckCheckedListBox.SetItemChecked(i, check);
            }
            this.allCheckBox.Text = check ? "すべて解除" : "すべて選択";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
