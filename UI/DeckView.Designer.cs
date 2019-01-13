namespace YugiohDeck.UI
{
    partial class DeckView
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainDeckPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.extraDeckPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sideDeckPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.deckCountLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainDeckPanel
            // 
            this.mainDeckPanel.AutoScroll = true;
            this.mainDeckPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainDeckPanel.Location = new System.Drawing.Point(4, 3);
            this.mainDeckPanel.Name = "mainDeckPanel";
            this.mainDeckPanel.Size = new System.Drawing.Size(703, 296);
            this.mainDeckPanel.TabIndex = 0;
            // 
            // extraDeckPanel
            // 
            this.extraDeckPanel.AutoScroll = true;
            this.extraDeckPanel.BackColor = System.Drawing.Color.Thistle;
            this.extraDeckPanel.Location = new System.Drawing.Point(4, 305);
            this.extraDeckPanel.Name = "extraDeckPanel";
            this.extraDeckPanel.Size = new System.Drawing.Size(703, 105);
            this.extraDeckPanel.TabIndex = 1;
            // 
            // sideDeckPanel
            // 
            this.sideDeckPanel.AutoScroll = true;
            this.sideDeckPanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.sideDeckPanel.Location = new System.Drawing.Point(4, 416);
            this.sideDeckPanel.Name = "sideDeckPanel";
            this.sideDeckPanel.Size = new System.Drawing.Size(703, 100);
            this.sideDeckPanel.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(4, 521);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(246, 521);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "デッキ削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(84, 521);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // deckCountLabel
            // 
            this.deckCountLabel.AutoSize = true;
            this.deckCountLabel.Location = new System.Drawing.Point(566, 532);
            this.deckCountLabel.Name = "deckCountLabel";
            this.deckCountLabel.Size = new System.Drawing.Size(126, 12);
            this.deckCountLabel.TabIndex = 6;
            this.deckCountLabel.Text = "Main: 0, Extra: 0, Side: 0";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(324, 521);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(165, 521);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(75, 23);
            this.renameButton.TabIndex = 8;
            this.renameButton.Text = "名前変更";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // DeckView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deckCountLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.sideDeckPanel);
            this.Controls.Add(this.extraDeckPanel);
            this.Controls.Add(this.mainDeckPanel);
            this.Name = "DeckView";
            this.Size = new System.Drawing.Size(710, 547);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainDeckPanel;
        private System.Windows.Forms.FlowLayoutPanel extraDeckPanel;
        private System.Windows.Forms.FlowLayoutPanel sideDeckPanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label deckCountLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button renameButton;
    }
}
