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

namespace BankReconciliation.UI
{
    public partial class LimitUi : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int accid, limitid;
        public LimitUi()
        {
            InitializeComponent();
        }

        private void grdld()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qry = "select BankAccounts.BankName, BankAccounts.BranchName,BankAccounts.AccountNo, BankAccounts.TypeOfAccount, BankAccounts.OD, BankAccounts.Acid from BankAccounts where BankAccounts.OD = 'OD' and BankAccounts.LimitSet='Not-set'";
            cmd = new SqlCommand(qry, con);
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dataGridView1.Rows.Clear();
            while (rdr.Read() == true)
            {
                dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
            }
            con.Close();
        }

        private void LimitUi_Load(object sender, EventArgs e)
        {
            grdld();
            grid2ld();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            accid = Convert.ToInt32(dr.Cells[5].Value.ToString());

            textBox1.Text = dr.Cells[0].Value.ToString();
            textBox2.Text = dr.Cells[1].Value.ToString();
            textBox3.Text = dr.Cells[2].Value.ToString();
            textBox4.Text = dr.Cells[3].Value.ToString();
        }

        private void grid2ld()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string q1 = "select LimitTable.BankName, LimitTable.BranchName, LimitTable.AccountNo, LimitTable.LimitAmount,LimitTable.LimitDate, LimitTable.ExpDate, LimitTable.InterestRate from LimitTable ";
                cmd = new SqlCommand(q1, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0],rdr[1],rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
                }
               con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void clearboxes()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.Value = DateTime.UtcNow;
            textBox6.Clear();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            grdld();
            grid2ld();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please input Bank Name from Grid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            else if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Please input Limit Ammount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Please input Expiry Date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Please input Interest Rate", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string q2 = "insert into LimitTable (LimitAmount, LimitDate, ExpDate, AccountNo, BankName, BranchName ,InterestRate, Date, Acid) values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(q2, con);
                    cmd.Parameters.AddWithValue("@d1", textBox5.Text);
                    cmd.Parameters.AddWithValue("@d2", DateTime.UtcNow.ToLocalTime());
                    cmd.Parameters.AddWithValue("@d3", dateTimePicker1.Value.ToLocalTime());
                    cmd.Parameters.AddWithValue("@d4", textBox3.Text);
                    cmd.Parameters.AddWithValue("@d5", textBox1.Text);
                    cmd.Parameters.AddWithValue("@d6", textBox2.Text);
                    cmd.Parameters.AddWithValue("@d7", textBox6.Text);
                    cmd.Parameters.AddWithValue("@d8", DateTime.UtcNow.ToLocalTime());
                    cmd.Parameters.AddWithValue("@d9",accid);

                    limitid = (int)cmd.ExecuteScalar();
                    con.Close();

                    con.Open();
                    string qup = "update BankAccounts set LimitSet='Set' where Acid = '"+ accid +"'  ";
                    cmd = new SqlCommand(qup,con);
                    cmd.ExecuteScalar();
                    con.Close();

                    con.Open();
                    string qqs = "insert into LimitLogTable (LimitId, LimitAmount,LimitDate,ExpDate,AccountNo,BankName,UserId,Acid) values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8) " + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(qqs, con);
                    cmd.Parameters.AddWithValue("@d1", limitid);
                    cmd.Parameters.AddWithValue("@d2", textBox5.Text);
                    cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                    cmd.Parameters.AddWithValue("@d4", dateTimePicker1.Value.ToLocalTime());
                    cmd.Parameters.AddWithValue("@d5", textBox3.Text);
                    cmd.Parameters.AddWithValue("@d6", textBox1.Text);
                    cmd.Parameters.AddWithValue("@d7", LoginForm.uId2);
                    cmd.Parameters.AddWithValue("@d8", accid);
                    cmd.ExecuteScalar();
                    con.Close();

                    con.Open();
                    string qr3 = "insert into InterestLogTable (InterestRate,LimitId,Date,UserId) values(@d1,@d2,@d3,@d4) " + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(qr3, con);
                    cmd.Parameters.AddWithValue("@d1", textBox6.Text);
                    cmd.Parameters.AddWithValue("@d2", limitid);
                    cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                    cmd.Parameters.AddWithValue("@d4", LoginForm.uId2);
                    cmd.ExecuteScalar();
                    con.Close();


                    con.Open();
                    string up = "Update BankAccounts set AvailableBalance = Balance + '" + decimal.Parse(textBox5.Text) + "' where BankAccounts.AccountNo = '" + textBox3.Text + "'  ";
                    cmd= new SqlCommand(up, con);
                    cmd.ExecuteScalar();
                    con.Close();

                    MessageBox.Show("Successful", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearboxes();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
        }



    }
}
