namespace BankReconciliation.UI
{
    partial class EditDepositForm2
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
            this.textBoxk = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxk
            // 
            this.textBoxk.Location = new System.Drawing.Point(144, 26);
            this.textBoxk.Name = "textBoxk";
            this.textBoxk.Size = new System.Drawing.Size(100, 20);
            this.textBoxk.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(144, 108);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // EditDepositForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 261);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.textBoxk);
            this.Name = "EditDepositForm2";
            this.Text = "EditDepositForm2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       public System.Windows.Forms.TextBox textBoxk;
       private System.Windows.Forms.Button backButton;
    }
}