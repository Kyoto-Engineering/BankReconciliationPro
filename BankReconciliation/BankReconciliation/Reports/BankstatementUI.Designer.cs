namespace BankReconciliation.Reports
{
    partial class BankstatementUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankstatementUI));
            this.bankSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.accountNoComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bankSelectionComboBox
            // 
            this.bankSelectionComboBox.FormattingEnabled = true;
            this.bankSelectionComboBox.Items.AddRange(new object[] {
            "AB Bank Limited",
            "Agrani Bank Limited",
            "Al-Arafah Islami Bank Limited ",
            "Bangladesh Commerce Bank Limited",
            "Bangladesh Development Bank Limited",
            "Bangladesh Krishi Bank Limited",
            "Bank Al-Falah",
            "Bank Asia Limited",
            "BASIC Bank Limited",
            "BRAC Bank Limited",
            "Citibank NA",
            "Commercial Bank of Ceylon",
            "Dhaka Bank Limited",
            "Dutch Bangla Bank Limited",
            "Eastern Bank Limited",
            "Export Import Bank of Bangladesh Limited",
            "First Security Islami Bank Limited",
            "Habib Bank Limited",
            "HSBC (The Hong Kong and Shanghai Banking Corporation Ltd.)",
            "ICB Islamic Bank Limited",
            "IFIC Bank Limited",
            "Islami Bank Bangladesh Limited",
            "Jamuna Bank Limited",
            "Janata Bank Limited",
            "Meghna Bank Limited",
            "Mercantile Bank Limited",
            "Midland Bank Limited",
            "Modhumoti Bank Limited",
            "Mutual Trust Bank Limited",
            "National Bank Limited",
            "National Bank of Pakistan",
            "NCC Bank Limited",
            "NRB Bank Limited",
            "NRB Commercial Bank Limited",
            "NRB Global Bank Limited",
            "One Bank Limited",
            "Palli Sanchay Bank",
            "Prime Bank Limited",
            "Pubali Bank Limited",
            "Rajshahi Krishi Unnoyon Bank (RKUB)",
            "Rupali Bank Limited",
            "Shahjalal islami Bank Limited",
            "Shimanto Bank Limited",
            "Social Islami Bank Limited ",
            "Sonali Bank Limited ",
            "South Bangla Agriculture and Commerce Bank Limited ",
            "Southeast Bank Limited ",
            "Standard Bank Limited",
            "Standard Chartered Bank",
            "State Bank of India",
            "The City Bank Limited",
            "The Farmers Bank Limited",
            "The Premier Bank Limited",
            "Trust Bank Limited",
            "Union Bank Limited",
            "United Commercial Bank Limited",
            "Uttara Bank Limited ",
            "Woori Bank"});
            this.bankSelectionComboBox.Location = new System.Drawing.Point(332, 144);
            this.bankSelectionComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.bankSelectionComboBox.Name = "bankSelectionComboBox";
            this.bankSelectionComboBox.Size = new System.Drawing.Size(301, 32);
            this.bankSelectionComboBox.TabIndex = 0;
            this.bankSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.bankSelectionComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bank Name";
            // 
            // accountNoComboBox
            // 
            this.accountNoComboBox.FormattingEnabled = true;
            this.accountNoComboBox.Location = new System.Drawing.Point(332, 196);
            this.accountNoComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.accountNoComboBox.Name = "accountNoComboBox";
            this.accountNoComboBox.Size = new System.Drawing.Size(301, 32);
            this.accountNoComboBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 210);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account No";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(61, 391);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 65);
            this.button1.TabIndex = 4;
            this.button1.Text = "All Transaction";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(293, 390);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 66);
            this.button2.TabIndex = 5;
            this.button2.Text = "Transaction Of A Period";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(512, 390);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 65);
            this.button3.TabIndex = 6;
            this.button3.Text = "Transaction of a Single Day";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BankstatementUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(744, 563);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.accountNoComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bankSelectionComboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BankstatementUI";
            this.Text = "BankstatementUI";
            this.Load += new System.EventHandler(this.BankstatementUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox bankSelectionComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox accountNoComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}