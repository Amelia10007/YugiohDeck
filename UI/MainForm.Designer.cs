namespace YugiohDeck.UI
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.deckTab = new System.Windows.Forms.TabControl();
            this.messageLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.defenceCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.levelRangeLabel = new System.Windows.Forms.Label();
            this.levelMinUpDown = new System.Windows.Forms.NumericUpDown();
            this.levelMaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.monsterDefenceMinUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.monsterDefenceMaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.monsterDefenceAllowUndefinitionCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.monsterAttackMaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.monsterAttackRangeLabel = new System.Windows.Forms.Label();
            this.monsterAttackAllowUndefinitionCheckBox = new System.Windows.Forms.CheckBox();
            this.monsterAttackMinUpDown = new System.Windows.Forms.NumericUpDown();
            this.monsterTypeListBox = new System.Windows.Forms.ListBox();
            this.monsterAttributeListBox = new System.Windows.Forms.ListBox();
            this.monsterTypeLabel = new System.Windows.Forms.Label();
            this.kindLabel = new System.Windows.Forms.Label();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.kindFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.kindListBox1 = new System.Windows.Forms.ListBox();
            this.kindListBox2 = new System.Windows.Forms.ListBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.pronunciationTextBox = new System.Windows.Forms.TextBox();
            this.pronunciationLabel = new System.Windows.Forms.Label();
            this.monsterAttributeLabel = new System.Windows.Forms.Label();
            this.resultCountLabel = new System.Windows.Forms.Label();
            this.attackCheckBox = new System.Windows.Forms.CheckBox();
            this.resultCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.searchButton = new System.Windows.Forms.Button();
            this.conditionClearButton = new System.Windows.Forms.Button();
            this.levelRankLinkGroupBox = new System.Windows.Forms.GroupBox();
            this.linkRadioButton = new System.Windows.Forms.RadioButton();
            this.rankRadioButton = new System.Windows.Forms.RadioButton();
            this.levelRadioButton = new System.Windows.Forms.RadioButton();
            this.nonRadioButton = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.searchResultPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cardDescription = new YugiohDeck.UI.CardDescription();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelMinUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelMaxUpDown)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDefenceMinUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDefenceMaxUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterAttackMaxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterAttackMinUpDown)).BeginInit();
            this.kindFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultCountUpDown)).BeginInit();
            this.levelRankLinkGroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(91, 721);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(112, 23);
            this.openButton.TabIndex = 7;
            this.openButton.Text = "既存デッキを開く";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(10, 721);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 8;
            this.createButton.Text = "新規デッキ";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // deckTab
            // 
            this.deckTab.Location = new System.Drawing.Point(732, 6);
            this.deckTab.Name = "deckTab";
            this.deckTab.SelectedIndex = 0;
            this.deckTab.Size = new System.Drawing.Size(720, 733);
            this.deckTab.TabIndex = 11;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(253, 726);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(50, 12);
            this.messageLabel.TabIndex = 15;
            this.messageLabel.Text = "message";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 6);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(714, 519);
            this.tabControl.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(706, 493);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "検索条件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.defenceCheckBox, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel3, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel2, 1, 9);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 8);
            this.tableLayoutPanel.Controls.Add(this.monsterTypeListBox, 1, 7);
            this.tableLayoutPanel.Controls.Add(this.monsterAttributeListBox, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.monsterTypeLabel, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.kindLabel, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.textTextBox, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.kindFlowLayoutPanel, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.nameLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.textLabel, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.nameTextBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.pronunciationTextBox, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.pronunciationLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.monsterAttributeLabel, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.resultCountLabel, 0, 10);
            this.tableLayoutPanel.Controls.Add(this.attackCheckBox, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.resultCountUpDown, 1, 10);
            this.tableLayoutPanel.Controls.Add(this.searchButton, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.conditionClearButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.levelRankLinkGroupBox, 0, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 11;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(700, 484);
            this.tableLayoutPanel.TabIndex = 7;
            this.tableLayoutPanel.TabStop = true;
            // 
            // defenceCheckBox
            // 
            this.defenceCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.defenceCheckBox.AutoSize = true;
            this.defenceCheckBox.Location = new System.Drawing.Point(4, 432);
            this.defenceCheckBox.Name = "defenceCheckBox";
            this.defenceCheckBox.Size = new System.Drawing.Size(84, 16);
            this.defenceCheckBox.TabIndex = 22;
            this.defenceCheckBox.Text = "守備力検索";
            this.defenceCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.Controls.Add(this.levelRangeLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.levelMinUpDown, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.levelMaxUpDown, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(211, 186);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(191, 26);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // levelRangeLabel
            // 
            this.levelRangeLabel.AutoSize = true;
            this.levelRangeLabel.Location = new System.Drawing.Point(81, 5);
            this.levelRangeLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.levelRangeLabel.Name = "levelRangeLabel";
            this.levelRangeLabel.Size = new System.Drawing.Size(17, 12);
            this.levelRangeLabel.TabIndex = 11;
            this.levelRangeLabel.Text = "～";
            // 
            // levelMinUpDown
            // 
            this.levelMinUpDown.Location = new System.Drawing.Point(3, 3);
            this.levelMinUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.levelMinUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.levelMinUpDown.Name = "levelMinUpDown";
            this.levelMinUpDown.Size = new System.Drawing.Size(69, 19);
            this.levelMinUpDown.TabIndex = 12;
            this.levelMinUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // levelMaxUpDown
            // 
            this.levelMaxUpDown.Location = new System.Drawing.Point(104, 3);
            this.levelMaxUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.levelMaxUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.levelMaxUpDown.Name = "levelMaxUpDown";
            this.levelMaxUpDown.Size = new System.Drawing.Size(69, 19);
            this.levelMaxUpDown.TabIndex = 13;
            this.levelMaxUpDown.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel2.Controls.Add(this.monsterDefenceMinUpDown, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.monsterDefenceMaxUpDown, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.monsterDefenceAllowUndefinitionCheckBox, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(211, 428);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(308, 24);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // monsterDefenceMinUpDown
            // 
            this.monsterDefenceMinUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.monsterDefenceMinUpDown.Location = new System.Drawing.Point(3, 3);
            this.monsterDefenceMinUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.monsterDefenceMinUpDown.Name = "monsterDefenceMinUpDown";
            this.monsterDefenceMinUpDown.Size = new System.Drawing.Size(93, 19);
            this.monsterDefenceMinUpDown.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "～";
            // 
            // monsterDefenceMaxUpDown
            // 
            this.monsterDefenceMaxUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.monsterDefenceMaxUpDown.Location = new System.Drawing.Point(128, 3);
            this.monsterDefenceMaxUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.monsterDefenceMaxUpDown.Name = "monsterDefenceMaxUpDown";
            this.monsterDefenceMaxUpDown.Size = new System.Drawing.Size(92, 19);
            this.monsterDefenceMaxUpDown.TabIndex = 18;
            this.monsterDefenceMaxUpDown.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // monsterDefenceAllowUndefinitionCheckBox
            // 
            this.monsterDefenceAllowUndefinitionCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.monsterDefenceAllowUndefinitionCheckBox.AutoSize = true;
            this.monsterDefenceAllowUndefinitionCheckBox.Location = new System.Drawing.Point(227, 4);
            this.monsterDefenceAllowUndefinitionCheckBox.Name = "monsterDefenceAllowUndefinitionCheckBox";
            this.monsterDefenceAllowUndefinitionCheckBox.Size = new System.Drawing.Size(73, 16);
            this.monsterDefenceAllowUndefinitionCheckBox.TabIndex = 15;
            this.monsterDefenceAllowUndefinitionCheckBox.Text = "\'?\'を含める";
            this.monsterDefenceAllowUndefinitionCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.Controls.Add(this.monsterAttackMaxUpDown, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.monsterAttackRangeLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.monsterAttackAllowUndefinitionCheckBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.monsterAttackMinUpDown, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(211, 394);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(308, 27);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // monsterAttackMaxUpDown
            // 
            this.monsterAttackMaxUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.monsterAttackMaxUpDown.Location = new System.Drawing.Point(128, 3);
            this.monsterAttackMaxUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.monsterAttackMaxUpDown.Name = "monsterAttackMaxUpDown";
            this.monsterAttackMaxUpDown.Size = new System.Drawing.Size(92, 19);
            this.monsterAttackMaxUpDown.TabIndex = 17;
            this.monsterAttackMaxUpDown.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // monsterAttackRangeLabel
            // 
            this.monsterAttackRangeLabel.AutoSize = true;
            this.monsterAttackRangeLabel.Location = new System.Drawing.Point(102, 5);
            this.monsterAttackRangeLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.monsterAttackRangeLabel.Name = "monsterAttackRangeLabel";
            this.monsterAttackRangeLabel.Size = new System.Drawing.Size(17, 12);
            this.monsterAttackRangeLabel.TabIndex = 14;
            this.monsterAttackRangeLabel.Text = "～";
            // 
            // monsterAttackAllowUndefinitionCheckBox
            // 
            this.monsterAttackAllowUndefinitionCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.monsterAttackAllowUndefinitionCheckBox.AutoSize = true;
            this.monsterAttackAllowUndefinitionCheckBox.Location = new System.Drawing.Point(227, 5);
            this.monsterAttackAllowUndefinitionCheckBox.Name = "monsterAttackAllowUndefinitionCheckBox";
            this.monsterAttackAllowUndefinitionCheckBox.Size = new System.Drawing.Size(73, 16);
            this.monsterAttackAllowUndefinitionCheckBox.TabIndex = 15;
            this.monsterAttackAllowUndefinitionCheckBox.Text = "\'?\'を含める";
            this.monsterAttackAllowUndefinitionCheckBox.UseVisualStyleBackColor = true;
            // 
            // monsterAttackMinUpDown
            // 
            this.monsterAttackMinUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.monsterAttackMinUpDown.Location = new System.Drawing.Point(3, 3);
            this.monsterAttackMinUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.monsterAttackMinUpDown.Name = "monsterAttackMinUpDown";
            this.monsterAttackMinUpDown.Size = new System.Drawing.Size(93, 19);
            this.monsterAttackMinUpDown.TabIndex = 16;
            // 
            // monsterTypeListBox
            // 
            this.monsterTypeListBox.FormattingEnabled = true;
            this.monsterTypeListBox.ItemHeight = 12;
            this.monsterTypeListBox.Location = new System.Drawing.Point(211, 266);
            this.monsterTypeListBox.Name = "monsterTypeListBox";
            this.monsterTypeListBox.Size = new System.Drawing.Size(170, 112);
            this.monsterTypeListBox.TabIndex = 10;
            // 
            // monsterAttributeListBox
            // 
            this.monsterAttributeListBox.FormattingEnabled = true;
            this.monsterAttributeListBox.ItemHeight = 12;
            this.monsterAttributeListBox.Location = new System.Drawing.Point(211, 219);
            this.monsterAttributeListBox.Name = "monsterAttributeListBox";
            this.monsterAttributeListBox.Size = new System.Drawing.Size(170, 40);
            this.monsterAttributeListBox.TabIndex = 9;
            // 
            // monsterTypeLabel
            // 
            this.monsterTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.monsterTypeLabel.AutoSize = true;
            this.monsterTypeLabel.Location = new System.Drawing.Point(4, 320);
            this.monsterTypeLabel.Name = "monsterTypeLabel";
            this.monsterTypeLabel.Size = new System.Drawing.Size(29, 12);
            this.monsterTypeLabel.TabIndex = 10;
            this.monsterTypeLabel.Text = "種族";
            // 
            // kindLabel
            // 
            this.kindLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kindLabel.AutoSize = true;
            this.kindLabel.Location = new System.Drawing.Point(4, 138);
            this.kindLabel.Name = "kindLabel";
            this.kindLabel.Size = new System.Drawing.Size(57, 12);
            this.kindLabel.TabIndex = 7;
            this.kindLabel.Text = "カード種類";
            // 
            // textTextBox
            // 
            this.textTextBox.Location = new System.Drawing.Point(211, 83);
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(220, 19);
            this.textTextBox.TabIndex = 6;
            // 
            // kindFlowLayoutPanel
            // 
            this.kindFlowLayoutPanel.Controls.Add(this.kindListBox1);
            this.kindFlowLayoutPanel.Controls.Add(this.kindListBox2);
            this.kindFlowLayoutPanel.Location = new System.Drawing.Point(211, 109);
            this.kindFlowLayoutPanel.Name = "kindFlowLayoutPanel";
            this.kindFlowLayoutPanel.Size = new System.Drawing.Size(547, 70);
            this.kindFlowLayoutPanel.TabIndex = 7;
            // 
            // kindListBox1
            // 
            this.kindListBox1.FormattingEnabled = true;
            this.kindListBox1.ItemHeight = 12;
            this.kindListBox1.Location = new System.Drawing.Point(3, 3);
            this.kindListBox1.Name = "kindListBox1";
            this.kindListBox1.Size = new System.Drawing.Size(217, 64);
            this.kindListBox1.TabIndex = 10;
            // 
            // kindListBox2
            // 
            this.kindListBox2.FormattingEnabled = true;
            this.kindListBox2.ItemHeight = 12;
            this.kindListBox2.Location = new System.Drawing.Point(226, 3);
            this.kindListBox2.Name = "kindListBox2";
            this.kindListBox2.Size = new System.Drawing.Size(217, 64);
            this.kindListBox2.TabIndex = 12;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(4, 34);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(45, 12);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "カード名";
            // 
            // textLabel
            // 
            this.textLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(4, 86);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(65, 12);
            this.textLabel.TabIndex = 5;
            this.textLabel.Text = "効果テキスト";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(211, 31);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(220, 19);
            this.nameTextBox.TabIndex = 1;
            // 
            // pronunciationTextBox
            // 
            this.pronunciationTextBox.Location = new System.Drawing.Point(211, 57);
            this.pronunciationTextBox.Name = "pronunciationTextBox";
            this.pronunciationTextBox.Size = new System.Drawing.Size(220, 19);
            this.pronunciationTextBox.TabIndex = 4;
            // 
            // pronunciationLabel
            // 
            this.pronunciationLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pronunciationLabel.AutoSize = true;
            this.pronunciationLabel.Location = new System.Drawing.Point(4, 60);
            this.pronunciationLabel.Name = "pronunciationLabel";
            this.pronunciationLabel.Size = new System.Drawing.Size(28, 12);
            this.pronunciationLabel.TabIndex = 3;
            this.pronunciationLabel.Text = "読み";
            // 
            // monsterAttributeLabel
            // 
            this.monsterAttributeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.monsterAttributeLabel.AutoSize = true;
            this.monsterAttributeLabel.Location = new System.Drawing.Point(4, 233);
            this.monsterAttributeLabel.Name = "monsterAttributeLabel";
            this.monsterAttributeLabel.Size = new System.Drawing.Size(29, 12);
            this.monsterAttributeLabel.TabIndex = 9;
            this.monsterAttributeLabel.Text = "属性";
            // 
            // resultCountLabel
            // 
            this.resultCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.resultCountLabel.AutoSize = true;
            this.resultCountLabel.Location = new System.Drawing.Point(4, 463);
            this.resultCountLabel.Name = "resultCountLabel";
            this.resultCountLabel.Size = new System.Drawing.Size(117, 12);
            this.resultCountLabel.TabIndex = 18;
            this.resultCountLabel.Text = "検索結果 最大表示数";
            // 
            // attackCheckBox
            // 
            this.attackCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.attackCheckBox.AutoSize = true;
            this.attackCheckBox.Location = new System.Drawing.Point(4, 399);
            this.attackCheckBox.Name = "attackCheckBox";
            this.attackCheckBox.Size = new System.Drawing.Size(84, 16);
            this.attackCheckBox.TabIndex = 21;
            this.attackCheckBox.Text = "攻撃力検索";
            this.attackCheckBox.UseVisualStyleBackColor = true;
            // 
            // resultCountUpDown
            // 
            this.resultCountUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.resultCountUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.resultCountUpDown.Location = new System.Drawing.Point(211, 460);
            this.resultCountUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.resultCountUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.resultCountUpDown.Name = "resultCountUpDown";
            this.resultCountUpDown.Size = new System.Drawing.Size(120, 19);
            this.resultCountUpDown.TabIndex = 23;
            this.resultCountUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.searchButton.Location = new System.Drawing.Point(4, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(117, 20);
            this.searchButton.TabIndex = 25;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // conditionClearButton
            // 
            this.conditionClearButton.Location = new System.Drawing.Point(211, 4);
            this.conditionClearButton.Name = "conditionClearButton";
            this.conditionClearButton.Size = new System.Drawing.Size(151, 20);
            this.conditionClearButton.TabIndex = 26;
            this.conditionClearButton.Text = "検索条件リセット";
            this.conditionClearButton.UseVisualStyleBackColor = true;
            this.conditionClearButton.Click += new System.EventHandler(this.conditionClearButton_Click);
            // 
            // levelRankLinkGroupBox
            // 
            this.levelRankLinkGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.levelRankLinkGroupBox.Controls.Add(this.linkRadioButton);
            this.levelRankLinkGroupBox.Controls.Add(this.rankRadioButton);
            this.levelRankLinkGroupBox.Controls.Add(this.levelRadioButton);
            this.levelRankLinkGroupBox.Controls.Add(this.nonRadioButton);
            this.levelRankLinkGroupBox.Location = new System.Drawing.Point(4, 186);
            this.levelRankLinkGroupBox.Name = "levelRankLinkGroupBox";
            this.levelRankLinkGroupBox.Size = new System.Drawing.Size(200, 26);
            this.levelRankLinkGroupBox.TabIndex = 27;
            this.levelRankLinkGroupBox.TabStop = false;
            // 
            // linkRadioButton
            // 
            this.linkRadioButton.AutoSize = true;
            this.linkRadioButton.Location = new System.Drawing.Point(136, 7);
            this.linkRadioButton.Name = "linkRadioButton";
            this.linkRadioButton.Size = new System.Drawing.Size(44, 16);
            this.linkRadioButton.TabIndex = 3;
            this.linkRadioButton.Text = "Link";
            this.linkRadioButton.UseVisualStyleBackColor = true;
            // 
            // rankRadioButton
            // 
            this.rankRadioButton.AutoSize = true;
            this.rankRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rankRadioButton.Location = new System.Drawing.Point(87, 7);
            this.rankRadioButton.Name = "rankRadioButton";
            this.rankRadioButton.Size = new System.Drawing.Size(49, 16);
            this.rankRadioButton.TabIndex = 2;
            this.rankRadioButton.Text = "Rank";
            this.rankRadioButton.UseVisualStyleBackColor = true;
            // 
            // levelRadioButton
            // 
            this.levelRadioButton.AutoSize = true;
            this.levelRadioButton.Location = new System.Drawing.Point(46, 7);
            this.levelRadioButton.Name = "levelRadioButton";
            this.levelRadioButton.Size = new System.Drawing.Size(35, 16);
            this.levelRadioButton.TabIndex = 1;
            this.levelRadioButton.Text = "Lv";
            this.levelRadioButton.UseVisualStyleBackColor = true;
            // 
            // nonRadioButton
            // 
            this.nonRadioButton.AutoSize = true;
            this.nonRadioButton.Checked = true;
            this.nonRadioButton.Location = new System.Drawing.Point(7, 7);
            this.nonRadioButton.Name = "nonRadioButton";
            this.nonRadioButton.Size = new System.Drawing.Size(42, 16);
            this.nonRadioButton.TabIndex = 0;
            this.nonRadioButton.TabStop = true;
            this.nonRadioButton.Text = "なし";
            this.nonRadioButton.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.searchResultPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(706, 493);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "検索結果";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // searchResultPanel
            // 
            this.searchResultPanel.AutoScroll = true;
            this.searchResultPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.searchResultPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.searchResultPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.searchResultPanel.Location = new System.Drawing.Point(5, 2);
            this.searchResultPanel.Name = "searchResultPanel";
            this.searchResultPanel.Size = new System.Drawing.Size(697, 488);
            this.searchResultPanel.TabIndex = 11;
            this.searchResultPanel.WrapContents = false;
            // 
            // cardDescription
            // 
            this.cardDescription.AutoScroll = true;
            this.cardDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cardDescription.Card = null;
            this.cardDescription.Location = new System.Drawing.Point(43, 527);
            this.cardDescription.Name = "cardDescription";
            this.cardDescription.Size = new System.Drawing.Size(607, 192);
            this.cardDescription.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 751);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cardDescription);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.deckTab);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.createButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Yugioh deck editor 1.0.1";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelMinUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelMaxUpDown)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDefenceMinUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDefenceMaxUpDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterAttackMaxUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterAttackMinUpDown)).EndInit();
            this.kindFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultCountUpDown)).EndInit();
            this.levelRankLinkGroupBox.ResumeLayout(false);
            this.levelRankLinkGroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.TabControl deckTab;
        private System.Windows.Forms.Label messageLabel;
        private CardDescription cardDescription;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel searchResultPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.CheckBox defenceCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown levelMaxUpDown;
        private System.Windows.Forms.Label levelRangeLabel;
        private System.Windows.Forms.NumericUpDown levelMinUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown monsterDefenceMinUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown monsterDefenceMaxUpDown;
        private System.Windows.Forms.CheckBox monsterDefenceAllowUndefinitionCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown monsterAttackMaxUpDown;
        private System.Windows.Forms.Label monsterAttackRangeLabel;
        private System.Windows.Forms.CheckBox monsterAttackAllowUndefinitionCheckBox;
        private System.Windows.Forms.NumericUpDown monsterAttackMinUpDown;
        private System.Windows.Forms.ListBox monsterTypeListBox;
        private System.Windows.Forms.ListBox monsterAttributeListBox;
        private System.Windows.Forms.Label monsterTypeLabel;
        private System.Windows.Forms.Label kindLabel;
        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.FlowLayoutPanel kindFlowLayoutPanel;
        private System.Windows.Forms.ListBox kindListBox1;
        private System.Windows.Forms.ListBox kindListBox2;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox pronunciationTextBox;
        private System.Windows.Forms.Label pronunciationLabel;
        private System.Windows.Forms.Label monsterAttributeLabel;
        private System.Windows.Forms.Label resultCountLabel;
        private System.Windows.Forms.CheckBox attackCheckBox;
        private System.Windows.Forms.NumericUpDown resultCountUpDown;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button conditionClearButton;
        private System.Windows.Forms.GroupBox levelRankLinkGroupBox;
        private System.Windows.Forms.RadioButton linkRadioButton;
        private System.Windows.Forms.RadioButton rankRadioButton;
        private System.Windows.Forms.RadioButton levelRadioButton;
        private System.Windows.Forms.RadioButton nonRadioButton;
    }
}

