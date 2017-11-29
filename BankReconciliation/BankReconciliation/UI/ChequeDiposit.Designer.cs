namespace BankReconciliation
{
    partial class ChequeDiposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChequeDiposit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cmbCreditFromBank = new System.Windows.Forms.ComboBox();
            this.eftAccountNoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAccountDNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.transactionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.MRTButton = new System.Windows.Forms.Button();
            this.nextStepButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTransactionTypeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.creditTextBox = new System.Windows.Forms.TextBox();
            this.particularsTextBox = new System.Windows.Forms.TextBox();
            this.checkNoTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBankNameCombo = new System.Windows.Forms.ComboBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.cmbCreditFromBank);
            this.groupBox1.Controls.Add(this.eftAccountNoTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbAccountDNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.transactionDateTimePicker);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTransactionTypeCombo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label51);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.creditTextBox);
            this.groupBox1.Controls.Add(this.particularsTextBox);
            this.groupBox1.Controls.Add(this.checkNoTextBox);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtBankNameCombo);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 605);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deposit";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(269, 237);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(293, 32);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(76, 448);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 32);
            this.textBox2.TabIndex = 9;
            this.textBox2.Visible = false;
            // 
            // cmbCreditFromBank
            // 
            this.cmbCreditFromBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreditFromBank.FormattingEnabled = true;
            this.cmbCreditFromBank.ItemHeight = 24;
            this.cmbCreditFromBank.Items.AddRange(new object[] {
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
            "National Bank of Pakistan",
            "National Bank Limited",
            "NCC Bank Limited",
            "NRB Bank Limited",
            "NRB Commercial Bank Limited",
            "NRB Global Bank Limited",
            "One Bank Limited",
            "Prime Bank Limited",
            "Pubali Bank Limited",
            "Rajshahi Krishi Unnoyon Bank (RKUB)",
            "Rupali Bank Limited",
            "Shahjalal islami Bank Limited",
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
            "United Commercial Bank Limited",
            "Uttara Bank Limited ",
            "Union Bank Limited",
            "Woori Bank"});
            this.cmbCreditFromBank.Location = new System.Drawing.Point(269, 317);
            this.cmbCreditFromBank.Name = "cmbCreditFromBank";
            this.cmbCreditFromBank.Size = new System.Drawing.Size(293, 32);
            this.cmbCreditFromBank.TabIndex = 6;
            this.cmbCreditFromBank.Visible = false;
            // 
            // eftAccountNoTextBox
            // 
            this.eftAccountNoTextBox.Location = new System.Drawing.Point(269, 414);
            this.eftAccountNoTextBox.MaxLength = 50;
            this.eftAccountNoTextBox.Name = "eftAccountNoTextBox";
            this.eftAccountNoTextBox.Size = new System.Drawing.Size(293, 32);
            this.eftAccountNoTextBox.TabIndex = 8;
            this.eftAccountNoTextBox.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 24);
            this.label3.TabIndex = 49;
            this.label3.Text = "Account No(EFT)";
            this.label3.Visible = false;
            // 
            // cmbAccountDNo
            // 
            this.cmbAccountDNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountDNo.FormattingEnabled = true;
            this.cmbAccountDNo.Location = new System.Drawing.Point(269, 188);
            this.cmbAccountDNo.Name = "cmbAccountDNo";
            this.cmbAccountDNo.Size = new System.Drawing.Size(293, 32);
            this.cmbAccountDNo.TabIndex = 3;
            this.cmbAccountDNo.SelectedIndexChanged += new System.EventHandler(this.cmbAccountDNo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 24);
            this.label4.TabIndex = 41;
            this.label4.Text = "Transaction  Date";
            // 
            // transactionDateTimePicker
            // 
            this.transactionDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.transactionDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.transactionDateTimePicker.Location = new System.Drawing.Point(269, 40);
            this.transactionDateTimePicker.Name = "transactionDateTimePicker";
            this.transactionDateTimePicker.Size = new System.Drawing.Size(293, 32);
            this.transactionDateTimePicker.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MRTButton);
            this.groupBox3.Controls.Add(this.nextStepButton);
            this.groupBox3.Controls.Add(this.createButton);
            this.groupBox3.Location = new System.Drawing.Point(154, 497);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 94);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View and Print";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(435, 452);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(127, 51);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Confirm Txn";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click_1);
            // 
            // MRTButton
            // 
            this.MRTButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MRTButton.Location = new System.Drawing.Point(43, 30);
            this.MRTButton.Name = "MRTButton";
            this.MRTButton.Size = new System.Drawing.Size(131, 54);
            this.MRTButton.TabIndex = 3;
            this.MRTButton.Text = "Show  Most  Recent  Transaction";
            this.MRTButton.UseVisualStyleBackColor = true;
            this.MRTButton.Click += new System.EventHandler(this.MRTButton_Click);
            // 
            // nextStepButton
            // 
            this.nextStepButton.Location = new System.Drawing.Point(292, 32);
            this.nextStepButton.Name = "nextStepButton";
            this.nextStepButton.Size = new System.Drawing.Size(90, 51);
            this.nextStepButton.TabIndex = 0;
            this.nextStepButton.Text = "Save";
            this.nextStepButton.UseVisualStyleBackColor = true;
            this.nextStepButton.Visible = false;
            this.nextStepButton.Click += new System.EventHandler(this.nextStepButton_Click);
            // 
            // createButton
            // 
            this.createButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(171, 31);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(115, 54);
            this.createButton.TabIndex = 2;
            this.createButton.Text = "Create Account";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Visible = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 24);
            this.label2.TabIndex = 37;
            this.label2.Text = "Credit From Bank";
            this.label2.Visible = false;
            // 
            // txtTransactionTypeCombo
            // 
            this.txtTransactionTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTransactionTypeCombo.FormattingEnabled = true;
            this.txtTransactionTypeCombo.Items.AddRange(new object[] {
            "Cash(D)",
            "Chq(D)",
            "EFT(D)",
            "Intrst(D)",
            "ITrns(D)",
            "PO(D)",
            "Othr(D)"});
            this.txtTransactionTypeCombo.Location = new System.Drawing.Point(269, 86);
            this.txtTransactionTypeCombo.Name = "txtTransactionTypeCombo";
            this.txtTransactionTypeCombo.Size = new System.Drawing.Size(293, 32);
            this.txtTransactionTypeCombo.TabIndex = 1;
            this.txtTransactionTypeCombo.SelectedIndexChanged += new System.EventHandler(this.txtTransactionTypeCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 35;
            this.label1.Text = "Transaction Type";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(81, 287);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(142, 24);
            this.label51.TabIndex = 32;
            this.label51.Text = "Credit Amount";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(105, 245);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(108, 24);
            this.label41.TabIndex = 31;
            this.label41.Text = "Particulars";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(67, 196);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(162, 24);
            this.label31.TabIndex = 30;
            this.label31.Text = "Account Number";
            // 
            // creditTextBox
            // 
            this.creditTextBox.Location = new System.Drawing.Point(269, 279);
            this.creditTextBox.MaxLength = 150;
            this.creditTextBox.Name = "creditTextBox";
            this.creditTextBox.ShortcutsEnabled = false;
            this.creditTextBox.Size = new System.Drawing.Size(293, 32);
            this.creditTextBox.TabIndex = 5;
            this.creditTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.creditTextBox_KeyDown);
            this.creditTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.creditTextBox_KeyPress);
            // 
            // particularsTextBox
            // 
            this.particularsTextBox.Location = new System.Drawing.Point(571, 237);
            this.particularsTextBox.Name = "particularsTextBox";
            this.particularsTextBox.Size = new System.Drawing.Size(35, 32);
            this.particularsTextBox.TabIndex = 4;
            this.particularsTextBox.Visible = false;
            // 
            // checkNoTextBox
            // 
            this.checkNoTextBox.Location = new System.Drawing.Point(269, 364);
            this.checkNoTextBox.MaxLength = 150;
            this.checkNoTextBox.Name = "checkNoTextBox";
            this.checkNoTextBox.Size = new System.Drawing.Size(293, 32);
            this.checkNoTextBox.TabIndex = 7;
            this.checkNoTextBox.Visible = false;
            this.checkNoTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkNoTextBox_MouseClick);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(68, 377);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(138, 20);
            this.label21.TabIndex = 25;
            this.label21.Text = "Cheque Number";
            this.label21.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(54, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 24);
            this.label11.TabIndex = 24;
            this.label11.Text = "Select Bank  Name";
            // 
            // txtBankNameCombo
            // 
            this.txtBankNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtBankNameCombo.Location = new System.Drawing.Point(269, 142);
            this.txtBankNameCombo.Name = "txtBankNameCombo";
            this.txtBankNameCombo.Size = new System.Drawing.Size(293, 32);
            this.txtBankNameCombo.TabIndex = 2;
            this.txtBankNameCombo.SelectedIndexChanged += new System.EventHandler(this.txtBankNameCombo_SelectedIndexChanged);
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.Color.Gray;
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtBalance.Location = new System.Drawing.Point(1, 627);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(19, 13);
            this.txtBalance.TabIndex = 45;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(647, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 601);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Bank details";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(481, 560);
            this.dataGridView1.TabIndex = 12;
            // 
            // ChequeDiposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1020, 732);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChequeDiposit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque Diposit";
            this.Load += new System.EventHandler(this.ChequeDiposit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label31;
        public System.Windows.Forms.TextBox creditTextBox;
        public System.Windows.Forms.TextBox particularsTextBox;
        public System.Windows.Forms.TextBox checkNoTextBox;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox txtBankNameCombo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox txtTransactionTypeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker transactionDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button nextStepButton;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button MRTButton;
        private System.Windows.Forms.ComboBox cmbAccountDNo;
        private System.Windows.Forms.ComboBox cmbCreditFromBank;
        private System.Windows.Forms.TextBox eftAccountNoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}