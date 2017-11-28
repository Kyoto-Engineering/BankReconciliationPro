namespace BankReconciliation.Reports
{
    partial class PositivePayInstruction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositivePayInstruction));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.accountNoComboBox = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(75, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 26);
            this.label3.TabIndex = 12;
            this.label3.Text = "Select Cheque Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cheque No";
            // 
            // accountNoComboBox
            // 
            this.accountNoComboBox.FormattingEnabled = true;
            this.accountNoComboBox.Location = new System.Drawing.Point(182, 101);
            this.accountNoComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.accountNoComboBox.Name = "accountNoComboBox";
            this.accountNoComboBox.Size = new System.Drawing.Size(223, 21);
            this.accountNoComboBox.TabIndex = 10;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Snow;
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Bold);
            this.button10.ForeColor = System.Drawing.Color.Green;
            this.button10.Location = new System.Drawing.Point(134, 152);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(138, 47);
            this.button10.TabIndex = 13;
            this.button10.Text = "Get";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // PositivePayInstruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(439, 261);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.accountNoComboBox);
            this.Name = "PositivePayInstruction";
            this.Text = "PositivePayInstruction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox accountNoComboBox;
    }
}