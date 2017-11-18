namespace BankReconciliation.UI
{
    partial class Bank_Account_Management_UI
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
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.addNewBankButton = new System.Windows.Forms.Button();
            this.checkLoadingButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bank Account Management UI";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Snow;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.Location = new System.Drawing.Point(76, 174);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 54);
            this.button6.TabIndex = 12;
            this.button6.Text = "Overdraft Facilities";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // addNewBankButton
            // 
            this.addNewBankButton.BackColor = System.Drawing.Color.Snow;
            this.addNewBankButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewBankButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addNewBankButton.Location = new System.Drawing.Point(76, 110);
            this.addNewBankButton.Name = "addNewBankButton";
            this.addNewBankButton.Size = new System.Drawing.Size(117, 54);
            this.addNewBankButton.TabIndex = 13;
            this.addNewBankButton.Text = "Create Bank  Account";
            this.addNewBankButton.UseVisualStyleBackColor = false;
            this.addNewBankButton.Click += new System.EventHandler(this.addNewBankButton_Click);
            // 
            // checkLoadingButton
            // 
            this.checkLoadingButton.BackColor = System.Drawing.Color.SeaShell;
            this.checkLoadingButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLoadingButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkLoadingButton.Location = new System.Drawing.Point(76, 240);
            this.checkLoadingButton.Name = "checkLoadingButton";
            this.checkLoadingButton.Size = new System.Drawing.Size(117, 57);
            this.checkLoadingButton.TabIndex = 14;
            this.checkLoadingButton.Text = "Cheque";
            this.checkLoadingButton.UseVisualStyleBackColor = false;
            this.checkLoadingButton.Click += new System.EventHandler(this.checkLoadingButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.AntiqueWhite;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.Location = new System.Drawing.Point(79, 313);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(113, 51);
            this.registerButton.TabIndex = 15;
            this.registerButton.Text = "Register New User ";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // Bank_Account_Management_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 553);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.checkLoadingButton);
            this.Controls.Add(this.addNewBankButton);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label1);
            this.Name = "Bank_Account_Management_UI";
            this.Text = "Bank_Account_Management_UI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button addNewBankButton;
        private System.Windows.Forms.Button checkLoadingButton;
        private System.Windows.Forms.Button registerButton;
    }
}