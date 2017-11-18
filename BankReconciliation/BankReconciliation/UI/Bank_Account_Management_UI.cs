using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankReconciliation.LoginUI;

namespace BankReconciliation.UI
{
    public partial class Bank_Account_Management_UI : Form
    {
        public Bank_Account_Management_UI()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OverDraftFacilities ovfui = new OverDraftFacilities();
            this.Visible = false;
            ovfui.ShowDialog();
            this.Visible = true;

        }

        private void addNewBankButton_Click(object sender, EventArgs e)
        {
            dynamic d = new BankDetailsInfo();
            this.Visible = false;
            d.ShowDialog();
            this.Visible = true;
        }

        private void checkLoadingButton_Click(object sender, EventArgs e)
        {
            dynamic f2 = new UI.Cheque();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            UserRegistrationForm frm = new UserRegistrationForm();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = false;
        }
    }
}
