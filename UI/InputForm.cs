using System;
using System.Windows.Forms;

namespace YugiohDeck.UI
{
    public partial class InputForm : Form
    {
        public string InputTitle
        {
            get => this.Text;
            set => this.Text = value;
        }
        /// <summary>
        /// ユーザからの入力結果．OKまたはCancelが指定される．
        /// </summary>
        public DialogResult InputResult { get; private set; }
        /// <summary>
        /// ユーザの入力文字列．入力がキャンセルされた場合はnullとなる．
        /// </summary>
        public string InputText { get; private set; }
        public InputForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.InputResult = DialogResult.OK;
            this.InputText = this.inputTextBox.Text;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.InputResult = DialogResult.Cancel;
            this.InputText = null;
            this.Close();
        }
    }
}
