namespace YugiohDeck.UI
{
    partial class DrawTestForm
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
            this.drawCountTextBox = new System.Windows.Forms.TextBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.additionalDrawButton = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // drawCountTextBox
            // 
            this.drawCountTextBox.Location = new System.Drawing.Point(13, 12);
            this.drawCountTextBox.Name = "drawCountTextBox";
            this.drawCountTextBox.Size = new System.Drawing.Size(100, 19);
            this.drawCountTextBox.TabIndex = 0;
            this.drawCountTextBox.Text = "5";
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(119, 12);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(95, 23);
            this.drawButton.TabIndex = 1;
            this.drawButton.Text = "枚新規ドロー！";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // additionalDrawButton
            // 
            this.additionalDrawButton.Location = new System.Drawing.Point(220, 12);
            this.additionalDrawButton.Name = "additionalDrawButton";
            this.additionalDrawButton.Size = new System.Drawing.Size(103, 23);
            this.additionalDrawButton.TabIndex = 2;
            this.additionalDrawButton.Text = "1枚追加ドロー！";
            this.additionalDrawButton.UseVisualStyleBackColor = true;
            this.additionalDrawButton.Click += new System.EventHandler(this.additionalDrawButton_Click);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(13, 60);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(460, 234);
            this.panel.TabIndex = 3;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(13, 297);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(59, 12);
            this.messageLabel.TabIndex = 4;
            this.messageLabel.Text = "ドローテスト";
            // 
            // DrawTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 318);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.additionalDrawButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.drawCountTextBox);
            this.Name = "DrawTestForm";
            this.Text = "DrawTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox drawCountTextBox;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button additionalDrawButton;
        private System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.Label messageLabel;
    }
}