using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankReconciliation.LoginUI;
using BankReconciliation.Reports;

namespace BankReconciliation.UI
{
    public partial class MasterPagesForUser : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public MasterPagesForUser()
        {
            InitializeComponent();
        }

        private void updatelogouttime()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string upqry = "UPDATE UserLogTable set LogoutDateTime = @date where UserLogId = '" + LoginForm.ulogid + "' ";
                cmd = new SqlCommand(upqry, con);
                cmd.Parameters.AddWithValue("@date", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void logOutButton_Click(object sender, EventArgs e)
        {
            updatelogouttime();
            this.Hide();
            LoginForm frm=new LoginForm();
             frm.Show();
        }

        private void addNewBankButton_Click(object sender, EventArgs e)
        {
            dynamic d = new BankDetailsInfo();
            this.Visible = false;
            d.ShowDialog();
            this.Visible = true;
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            dynamic dd = new ChequeDiposit();
            this.Visible = false;
            dd.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dynamic ww = new Withdraw();
            this.Visible = false;
            ww.ShowDialog();
            this.Visible = true;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.Show();
        }

        private void bankStatementButton_Click(object sender, EventArgs e)
        {
            BankStatements x = new BankStatements();
            this.Visible = false;
            x.ShowDialog();
            this.Visible = true;
        }
    }
}
