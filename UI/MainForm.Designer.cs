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
            this.keywordTextBox = new System.Windows.Forms.TextBox();
            this.offlineSearchButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.searchResultPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.deckTab = new System.Windows.Forms.TabControl();
            this.onlineSearchButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.cardDescription = new YugiohDeck.UI.CardDescription();
            this.SuspendLayout();
            // 
            // keywordTextBox
            // 
            this.keywordTextBox.Location = new System.Drawing.Point(12, 12);
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(439, 19);
            this.keywordTextBox.TabIndex = 0;
            this.keywordTextBox.Text = "input";
            // 
            // offlineSearchButton
            // 
            this.offlineSearchButton.Location = new System.Drawing.Point(457, 10);
            this.offlineSearchButton.Name = "offlineSearchButton";
            this.offlineSearchButton.Size = new System.Drawing.Size(69, 23);
            this.offlineSearchButton.TabIndex = 3;
            this.offlineSearchButton.Text = "カード名";
            this.offlineSearchButton.UseVisualStyleBackColor = true;
            this.offlineSearchButton.Click += new System.EventHandler(this.offlineSearchButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(93, 676);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 7;
            this.openButton.Text = "開く";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(12, 676);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 8;
            this.createButton.Text = "新規";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // searchResultPanel
            // 
            this.searchResultPanel.AutoScroll = true;
            this.searchResultPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.searchResultPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.searchResultPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.searchResultPanel.Location = new System.Drawing.Point(2, 38);
            this.searchResultPanel.Name = "searchResultPanel";
            this.searchResultPanel.Size = new System.Drawing.Size(683, 442);
            this.searchResultPanel.TabIndex = 10;
            this.searchResultPanel.WrapContents = false;
            // 
            // deckTab
            // 
            this.deckTab.Location = new System.Drawing.Point(691, 6);
            this.deckTab.Name = "deckTab";
            this.deckTab.SelectedIndex = 0;
            this.deckTab.Size = new System.Drawing.Size(720, 693);
            this.deckTab.TabIndex = 11;
            // 
            // onlineSearchButton
            // 
            this.onlineSearchButton.Location = new System.Drawing.Point(526, 10);
            this.onlineSearchButton.Name = "onlineSearchButton";
            this.onlineSearchButton.Size = new System.Drawing.Size(67, 23);
            this.onlineSearchButton.TabIndex = 14;
            this.onlineSearchButton.Text = "全文検索";
            this.onlineSearchButton.UseVisualStyleBackColor = true;
            this.onlineSearchButton.Click += new System.EventHandler(this.onlineSearchButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(255, 681);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(50, 12);
            this.messageLabel.TabIndex = 15;
            this.messageLabel.Text = "message";
            // 
            // cardDescription
            // 
            this.cardDescription.Card = null;
            this.cardDescription.Location = new System.Drawing.Point(44, 486);
            this.cardDescription.Name = "cardDescription";
            this.cardDescription.Size = new System.Drawing.Size(582, 184);
            this.cardDescription.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 711);
            this.Controls.Add(this.cardDescription);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.onlineSearchButton);
            this.Controls.Add(this.deckTab);
            this.Controls.Add(this.searchResultPanel);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.offlineSearchButton);
            this.Controls.Add(this.keywordTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Yugioh deck editor 0.01";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox keywordTextBox;
        private System.Windows.Forms.Button offlineSearchButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.FlowLayoutPanel searchResultPanel;
        private System.Windows.Forms.TabControl deckTab;
        private System.Windows.Forms.Button onlineSearchButton;
        private System.Windows.Forms.Label messageLabel;
        private CardDescription cardDescription;
    }
}

