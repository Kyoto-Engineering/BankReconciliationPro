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

namespace BankReconciliation.UI
{
    public partial class CreateOverDraftAcc : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int acid;
        public CreateOverDraftAcc()
        {
            InitializeComponent();
        }


        private void grdld()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qry = "select BankAccounts.BankName, BankAccounts.BranchName,BankAccounts.AccountNo, BankAccounts.TypeOfAccount, BankAccounts.OD, BankAccounts.Acid from BankAccounts where BankAccounts.TypeOfAccount = 'CD' and BankAccounts.OD = 'NON-OD'  ";
            cmd = new SqlCommand(qry, con);
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dataGridView1.Rows.Clear();
            while (rdr.Read() == true)
            {
                dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
            }
            con.Close();
        }

        private void CreateOverDraftAcc_Load(object sender, EventArgs e)
        {
            grdld();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            acid = Convert.ToInt32(dr.Cells[5].Value.ToString());

            textBox1.Text = dr.Cells[0].Value.ToString();
            textBox2.Text = dr.Cells[1].Value.ToString();
            textBox3.Text = dr.Cells[2].Value.ToString();
            textBox4.Text = dr.Cells[3].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please input Bank Name from Grid","Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please input Branch Name from Grid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please input Account Number from Grid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please input Account Type from Grid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please select Mark OD", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qq = "Update BankAccounts set OD = '" + comboBox1.Text + "' where Acid = '" + acid + "' ";
                    cmd = new SqlCommand(qq,con);
                    cmd.ExecuteScalar();
                    con.Close();
                    MessageBox.Show("Successfully Done", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    comboBox1.SelectedIndex = -1;
                    dataGridView1.Rows.Clear();
                    grdld();

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }


        }



    }
}
