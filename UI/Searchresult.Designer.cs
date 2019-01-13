namespace YugiohDeck.UI
{
    partial class Searchresult
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
            this.mainDeckButton = new System.Windows.Forms.Button();
            this.sideDeckButton = new System.Windows.Forms.Button();
            this.cardDescription = new YugiohDeck.UI.CardDescription();
            this.SuspendLayout();
            // 
            // mainDeckButton
            // 
            this.mainDeckButton.Location = new System.Drawing.Point(-1, 40);
            this.mainDeckButton.Name = "mainDeckButton";
            this.mainDeckButton.Size = new System.Drawing.Size(58, 36);
            this.mainDeckButton.TabIndex = 2;
            this.mainDeckButton.Text = "デッキへ追加";
            this.mainDeckButton.UseVisualStyleBackColor = true;
            this.mainDeckButton.Click += new System.EventHandler(this.mainDeckButton_Click);
            // 
            // sideDeckButton
            // 
            this.sideDeckButton.Location = new System.Drawing.Point(3, 120);
            this.sideDeckButton.Name = "sideDeckButton";
            this.sideDeckButton.Size = new System.Drawing.Size(54, 35);
            this.sideDeckButton.TabIndex = 4;
            this.sideDeckButton.Text = "サイドへ追加";
            this.sideDeckButton.UseVisualStyleBackColor = true;
            this.sideDeckButton.Click += new System.EventHandler(this.sideDeckButton_Click);
            // 
            // cardDescription
            // 
            this.cardDescription.Location = new System.Drawing.Point(56, 3);
            this.cardDescription.Name = "cardDescription";
            this.cardDescription.Size = new System.Drawing.Size(582, 184);
            this.cardDescription.TabIndex = 5;
            // 
            // Searchresult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cardDescription);
            this.Controls.Add(this.sideDeckButton);
            this.Controls.Add(this.mainDeckButton);
            this.Name = "Searchresult";
            this.Size = new System.Drawing.Size(641, 190);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button mainDeckButton;
        private System.Windows.Forms.Button sideDeckButton;
        private CardDescription cardDescription;
    }
}
