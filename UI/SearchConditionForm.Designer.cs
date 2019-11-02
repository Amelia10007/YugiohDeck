namespace YugiohDeck.UI
{
    partial class SearchConditionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchConditionForm));
            this.searchButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.pronunciationLabel = new System.Windows.Forms.Label();
            this.pronunciationTextBox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.defenceCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.levelMaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.levelRangeLabel = new System.Windows.Forms.Label();
            this.levelMinUpDown = new System.Windows.Forms.NumericUpDown();
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
            this.monsterAttributeLabel = new System.Windows.Forms.Label();
            this.resultCountLabel = new System.Windows.Forms.Label();
            this.attackCheckBox = new System.Windows.Forms.CheckBox();
            this.resultCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.levelCheckBox = new System.Windows.Forms.CheckBox();
            this.clearConditionButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelMaxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelMinUpDown)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDefenceMinUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDefenceMaxUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterAttackMaxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterAttackMinUpDown)).BeginInit();
            this.kindFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultCountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(12, 547);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(270, 33);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(149, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(220, 19);
            this.nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(4, 7);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(45, 12);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "カード名";
            // 
            // pronunciationLabel
            // 
            this.pronunciationLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pronunciationLabel.AutoSize = true;
            this.pronunciationLabel.Location = new System.Drawing.Point(4, 33);
            this.pronunciationLabel.Name = "pronunciationLabel";
            this.pronunciationLabel.Size = new System.Drawing.Size(28, 12);
            this.pronunciationLabel.TabIndex = 3;
            this.pronunciationLabel.Text = "読み";
            // 
            // pronunciationTextBox
            // 
            this.pronunciationTextBox.Location = new System.Drawing.Point(149, 30);
            this.pronunciationTextBox.Name = "pronunciationTextBox";
            this.pronunciationTextBox.Size = new System.Drawing.Size(220, 19);
            this.pronunciationTextBox.TabIndex = 4;
            // 
            // textLabel
            // 
            this.textLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(4, 59);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(65, 12);
            this.textLabel.TabIndex = 5;
            this.textLabel.Text = "効果テキスト";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.87302F));
            this.tableLayoutPanel.Controls.Add(this.defenceCheckBox, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel3, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel2, 1, 8);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 7);
            this.tableLayoutPanel.Controls.Add(this.monsterTypeListBox, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.monsterAttributeListBox, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.monsterTypeLabel, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.kindLabel, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.textTextBox, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.kindFlowLayoutPanel, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.nameTextBox, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.pronunciationTextBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.pronunciationLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.monsterAttributeLabel, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.resultCountLabel, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.attackCheckBox, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.resultCountUpDown, 1, 9);
            this.tableLayoutPanel.Controls.Add(this.levelCheckBox, 0, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 10;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(461, 539);
            this.tableLayoutPanel.TabIndex = 6;
            this.tableLayoutPanel.TabStop = true;
            // 
            // defenceCheckBox
            // 
            this.defenceCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.defenceCheckBox.AutoSize = true;
            this.defenceCheckBox.Location = new System.Drawing.Point(4, 471);
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
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel3.Controls.Add(this.levelMaxUpDown, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.levelRangeLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.levelMinUpDown, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(149, 234);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(180, 26);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // levelMaxUpDown
            // 
            this.levelMaxUpDown.Location = new System.Drawing.Point(102, 3);
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
            this.levelMaxUpDown.Size = new System.Drawing.Size(70, 19);
            this.levelMaxUpDown.TabIndex = 13;
            this.levelMaxUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // levelRangeLabel
            // 
            this.levelRangeLabel.AutoSize = true;
            this.levelRangeLabel.Location = new System.Drawing.Point(79, 5);
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
            this.levelMinUpDown.Size = new System.Drawing.Size(70, 19);
            this.levelMinUpDown.TabIndex = 12;
            this.levelMinUpDown.Value = new decimal(new int[] {
            1,
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(149, 464);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(308, 28);
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
            5000,
            0,
            0,
            0});
            this.monsterDefenceMaxUpDown.Name = "monsterDefenceMaxUpDown";
            this.monsterDefenceMaxUpDown.Size = new System.Drawing.Size(92, 19);
            this.monsterDefenceMaxUpDown.TabIndex = 18;
            // 
            // monsterDefenceAllowUndefinitionCheckBox
            // 
            this.monsterDefenceAllowUndefinitionCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.monsterDefenceAllowUndefinitionCheckBox.AutoSize = true;
            this.monsterDefenceAllowUndefinitionCheckBox.Location = new System.Drawing.Point(227, 6);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(149, 428);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(308, 28);
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
            5000,
            0,
            0,
            0});
            this.monsterAttackMaxUpDown.Name = "monsterAttackMaxUpDown";
            this.monsterAttackMaxUpDown.Size = new System.Drawing.Size(92, 19);
            this.monsterAttackMaxUpDown.TabIndex = 17;
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
            this.monsterAttackAllowUndefinitionCheckBox.Location = new System.Drawing.Point(227, 6);
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
            this.monsterTypeListBox.Location = new System.Drawing.Point(149, 328);
            this.monsterTypeListBox.Name = "monsterTypeListBox";
            this.monsterTypeListBox.Size = new System.Drawing.Size(170, 88);
            this.monsterTypeListBox.TabIndex = 10;
            // 
            // monsterAttributeListBox
            // 
            this.monsterAttributeListBox.FormattingEnabled = true;
            this.monsterAttributeListBox.ItemHeight = 12;
            this.monsterAttributeListBox.Location = new System.Drawing.Point(149, 269);
            this.monsterAttributeListBox.Name = "monsterAttributeListBox";
            this.monsterAttributeListBox.Size = new System.Drawing.Size(170, 52);
            this.monsterAttributeListBox.TabIndex = 9;
            // 
            // monsterTypeLabel
            // 
            this.monsterTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.monsterTypeLabel.AutoSize = true;
            this.monsterTypeLabel.Location = new System.Drawing.Point(4, 368);
            this.monsterTypeLabel.Name = "monsterTypeLabel";
            this.monsterTypeLabel.Size = new System.Drawing.Size(29, 12);
            this.monsterTypeLabel.TabIndex = 10;
            this.monsterTypeLabel.Text = "種族";
            // 
            // kindLabel
            // 
            this.kindLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kindLabel.AutoSize = true;
            this.kindLabel.Location = new System.Drawing.Point(4, 147);
            this.kindLabel.Name = "kindLabel";
            this.kindLabel.Size = new System.Drawing.Size(57, 12);
            this.kindLabel.TabIndex = 7;
            this.kindLabel.Text = "カード種類";
            // 
            // textTextBox
            // 
            this.textTextBox.Location = new System.Drawing.Point(149, 56);
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(220, 19);
            this.textTextBox.TabIndex = 6;
            // 
            // kindFlowLayoutPanel
            // 
            this.kindFlowLayoutPanel.Controls.Add(this.kindListBox1);
            this.kindFlowLayoutPanel.Controls.Add(this.kindListBox2);
            this.kindFlowLayoutPanel.Location = new System.Drawing.Point(149, 82);
            this.kindFlowLayoutPanel.Name = "kindFlowLayoutPanel";
            this.kindFlowLayoutPanel.Size = new System.Drawing.Size(226, 143);
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
            this.kindListBox2.Location = new System.Drawing.Point(3, 73);
            this.kindListBox2.Name = "kindListBox2";
            this.kindListBox2.Size = new System.Drawing.Size(217, 64);
            this.kindListBox2.TabIndex = 12;
            // 
            // monsterAttributeLabel
            // 
            this.monsterAttributeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.monsterAttributeLabel.AutoSize = true;
            this.monsterAttributeLabel.Location = new System.Drawing.Point(4, 289);
            this.monsterAttributeLabel.Name = "monsterAttributeLabel";
            this.monsterAttributeLabel.Size = new System.Drawing.Size(29, 12);
            this.monsterAttributeLabel.TabIndex = 9;
            this.monsterAttributeLabel.Text = "属性";
            // 
            // resultCountLabel
            // 
            this.resultCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.resultCountLabel.AutoSize = true;
            this.resultCountLabel.Location = new System.Drawing.Point(4, 512);
            this.resultCountLabel.Name = "resultCountLabel";
            this.resultCountLabel.Size = new System.Drawing.Size(117, 12);
            this.resultCountLabel.TabIndex = 18;
            this.resultCountLabel.Text = "検索結果 最大表示数";
            // 
            // attackCheckBox
            // 
            this.attackCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.attackCheckBox.AutoSize = true;
            this.attackCheckBox.Location = new System.Drawing.Point(4, 434);
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
            this.resultCountUpDown.Location = new System.Drawing.Point(149, 508);
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
            10,
            0,
            0,
            0});
            // 
            // levelCheckBox
            // 
            this.levelCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.levelCheckBox.AutoSize = true;
            this.levelCheckBox.Location = new System.Drawing.Point(4, 239);
            this.levelCheckBox.Name = "levelCheckBox";
            this.levelCheckBox.Size = new System.Drawing.Size(138, 16);
            this.levelCheckBox.TabIndex = 24;
            this.levelCheckBox.Text = "レベル/ランク/リンク検索";
            this.levelCheckBox.UseVisualStyleBackColor = true;
            // 
            // clearConditionButton
            // 
            this.clearConditionButton.Location = new System.Drawing.Point(294, 552);
            this.clearConditionButton.Name = "clearConditionButton";
            this.clearConditionButton.Size = new System.Drawing.Size(155, 23);
            this.clearConditionButton.TabIndex = 7;
            this.clearConditionButton.Text = "検索条件クリア";
            this.clearConditionButton.UseVisualStyleBackColor = true;
            this.clearConditionButton.Click += new System.EventHandler(this.clearConditionButton_Click);
            // 
            // SearchConditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(461, 592);
            this.Controls.Add(this.clearConditionButton);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.searchButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchConditionForm";
            this.Text = "カード検索";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelMaxUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelMinUpDown)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label pronunciationLabel;
        private System.Windows.Forms.TextBox pronunciationTextBox;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.Label kindLabel;
        private System.Windows.Forms.FlowLayoutPanel kindFlowLayoutPanel;
        private System.Windows.Forms.ListBox monsterAttributeListBox;
        private System.Windows.Forms.Label monsterTypeLabel;
        private System.Windows.Forms.Label monsterAttributeLabel;
        private System.Windows.Forms.ListBox monsterTypeListBox;
        private System.Windows.Forms.Label monsterAttackRangeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox monsterAttackAllowUndefinitionCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox monsterDefenceAllowUndefinitionCheckBox;
        private System.Windows.Forms.Button clearConditionButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label levelRangeLabel;
        private System.Windows.Forms.ListBox kindListBox1;
        private System.Windows.Forms.Label resultCountLabel;
        private System.Windows.Forms.NumericUpDown monsterAttackMaxUpDown;
        private System.Windows.Forms.NumericUpDown monsterAttackMinUpDown;
        private System.Windows.Forms.NumericUpDown monsterDefenceMinUpDown;
        private System.Windows.Forms.NumericUpDown monsterDefenceMaxUpDown;
        private System.Windows.Forms.CheckBox defenceCheckBox;
        private System.Windows.Forms.CheckBox attackCheckBox;
        private System.Windows.Forms.NumericUpDown resultCountUpDown;
        private System.Windows.Forms.ListBox kindListBox2;
        private System.Windows.Forms.NumericUpDown levelMaxUpDown;
        private System.Windows.Forms.NumericUpDown levelMinUpDown;
        private System.Windows.Forms.CheckBox levelCheckBox;
    }
}