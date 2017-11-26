using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankReconciliation.UI
{
    public partial class OverDraftFacilities : Form
    {
        public OverDraftFacilities()
        {
            InitializeComponent();
        }

        private void OverDraftFacilities_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateOverDraftAcc coa = new CreateOverDraftAcc();
            this.Visible = false;
            coa.ShowDialog();
            this.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LimitUi Lui = new LimitUi();
            this.Visible = false;
            Lui.ShowDialog();
            this.Visible = true;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.Focus();
                e.Handled = true;
            }
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            
                 if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
                e.Handled = true;
            }
        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3_Click(this, new EventArgs());
            }
        }
    }
}
