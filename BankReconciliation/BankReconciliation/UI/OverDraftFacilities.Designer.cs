﻿namespace BankReconciliation.UI
{
    partial class OverDraftFacilities
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Overdraft Facility Management";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "Create OD Account";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(62, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 47);
            this.button2.TabIndex = 3;
            this.button2.Text = "Edit OD Facility";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(62, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 47);
            this.button3.TabIndex = 4;
            this.button3.Text = "Assign OD Limit";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.DarkRed;
            this.button4.Location = new System.Drawing.Point(62, 297);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 47);
            this.button4.TabIndex = 5;
            this.button4.Text = "Facility Approval Sheet";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // OverDraftFacilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 528);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "OverDraftFacilities";
            this.Text = "OverDraftFacilitiesUI";
            this.Load += new System.EventHandler(this.OverDraftFacilities_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}