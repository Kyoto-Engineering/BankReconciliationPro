namespace BankReconciliation
{
    partial class ChequeLoader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChequeLoader));
            this.txtLBankNameCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chequeStartNoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chequeEndNoTextBox = new System.Windows.Forms.TextBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.cmbCAccountNo = new System.Windows.Forms.ComboBox();
            this.txtAccountNo2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLBankNameCombo
            // 
            this.txtLBankNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtLBankNameCombo.FormattingEnabled = true;
            this.txtLBankNameCombo.Location = new System.Drawing.Point(192, 27);
            this.txtLBankNameCombo.Margin = new System.Windows.Forms.Padding(5);
            this.txtLBankNameCombo.Name = "txtLBankNameCombo";
            this.txtLBankNameCombo.Size = new System.Drawing.Size(233, 29);
            this.txtLBankNameCombo.TabIndex = 0;
            this.txtLBankNameCombo.SelectedIndexChanged += new System.EventHandler(this.txtBankNameCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(55, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bank Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cheque Start No";
            // 
            // chequeStartNoTextBox
            // 
            this.chequeStartNoTextBox.Location = new System.Drawing.Point(192, 101);
            this.chequeStartNoTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.chequeStartNoTextBox.Name = "chequeStartNoTextBox";
            this.chequeStartNoTextBox.Size = new System.Drawing.Size(233, 29);
            this.chequeStartNoTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(47, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "End Cheque";
            // 
            // chequeEndNoTextBox
            // 
            this.chequeEndNoTextBox.Location = new System.Drawing.Point(192, 140);
            this.chequeEndNoTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.chequeEndNoTextBox.Name = "chequeEndNoTextBox";
            this.chequeEndNoTextBox.Size = new System.Drawing.Size(233, 29);
            this.chequeEndNoTextBox.TabIndex = 5;
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.White;
            this.loadButton.ForeColor = System.Drawing.Color.Green;
            this.loadButton.Location = new System.Drawing.Point(235, 193);
            this.loadButton.Margin = new System.Windows.Forms.Padding(5);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(125, 37);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load Check";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(55, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "AccountNo";
            // 
            // newButton
            // 
            this.newButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.newButton.Location = new System.Drawing.Point(-3, 290);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(10, 38);
            this.newButton.TabIndex = 11;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // cmbCAccountNo
            // 
            this.cmbCAccountNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCAccountNo.FormattingEnabled = true;
            this.cmbCAccountNo.Location = new System.Drawing.Point(192, 66);
            this.cmbCAccountNo.Name = "cmbCAccountNo";
            this.cmbCAccountNo.Size = new System.Drawing.Size(233, 29);
            this.cmbCAccountNo.TabIndex = 12;
            this.cmbCAccountNo.SelectedIndexChanged += new System.EventHandler(this.cmbAccountNo_SelectedIndexChanged);
            // 
            // txtAccountNo2
            // 
            this.txtAccountNo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtAccountNo2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAccountNo2.Location = new System.Drawing.Point(13, 290);
            this.txtAccountNo2.Name = "txtAccountNo2";
            this.txtAccountNo2.Size = new System.Drawing.Size(28, 22);
            this.txtAccountNo2.TabIndex = 13;
            // 
            // ChequeLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(509, 284);
            this.Controls.Add(this.txtAccountNo2);
            this.Controls.Add(this.cmbCAccountNo);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.chequeEndNoTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chequeStartNoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLBankNameCombo);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ChequeLoader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Cheque Book";
            this.Load += new System.EventHandler(this.ChequeLoader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox txtLBankNameCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox chequeStartNoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox chequeEndNoTextBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.ComboBox cmbCAccountNo;
        private System.Windows.Forms.TextBox txtAccountNo2;
    }
}