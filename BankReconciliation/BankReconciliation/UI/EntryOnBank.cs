using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BankReconciliation.UI
{
    public partial class EntryOnBank : Form
    {
        private SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        private SqlCommand cmd;
        private SqlDataReader rdr;
        public EntryOnBank()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                con =new SqlConnection(cs.DBConn);
                con.Open();
                cmd =
                    new SqlCommand(
                        "SELECT Transactions.Id, Transactions.Date, BankAccounts.ShortName AS 'Bank Name' , Transactions.AccountNo AS 'Account No', Transactions.TransactionType AS 'Txn Type', Transactions.Benificiary, Transactions.ChequeFromBank AS 'Txn with Bank', Transactions.CheckNo AS 'Cheque No', Transactions.Particulars,  Transactions.Credit, Transactions.Debit, Transactions.CurrentBalance AS 'Actual Balance' FROM Transactions INNER JOIN BankAccounts ON Transactions.AccountNo = BankAccounts.AccountNo Where Transactions.Reconciled=0", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //dataGridView1.Columns[0].Width = 40;
                //dataGridView1.Columns[1].Width = 70;
                //dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                //dataGridView1.Columns[2].Width = 55;
                //dataGridView1.Columns[3].Width = 95;
                //dataGridView1.Columns[4].Width = 55;
                //dataGridView1.Columns[5].Width = 100;
                //dataGridView1.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dataGridView1.Columns[6].Width = 70;
                //dataGridView1.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dataGridView1.Columns[7].Width = 70;
                //dataGridView1.Columns[8].Width = 130;
                //dataGridView1.Columns[8].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dataGridView1.Columns[9].Width = 70;
                //dataGridView1.Columns[9].DefaultCellStyle.NullValue = null;
                //dataGridView1.Columns[10].Width = 70;
                //dataGridView1.Columns[10].DefaultCellStyle.NullValue = null;
                //dataGridView1.Columns[11].Width = 95;
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9],
                        rdr[10], rdr[11]);
                }
               // string q =
               //     "SELECT Transactions.Id, Transactions.Date, BankAccounts.ShortName AS 'Bank Name' , Transactions.AccountNo AS 'Account No', Transactions.TransactionType AS 'Txn Type', Transactions.Benificiary, Transactions.ChequeFromBank AS 'Txn with Bank', Transactions.CheckNo AS 'Cheque No', Transactions.Particulars,  Transactions.Credit, Transactions.Debit, Transactions.CurrentBalance AS 'Actual Balance' FROM Transactions INNER JOIN BankAccounts ON Transactions.AccountNo = BankAccounts.AccountNo Where Transactions.ValueDate is null";
               //SqlDataAdapter dataAdapter =new SqlDataAdapter(q,con);
               // DataTable dataTable=new DataTable();
               // dataAdapter.Fill(dataTable);
               // dataGridView1.DataSource = dataTable;
                con.Close();
               
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EntryOnBank_Load(object sender, EventArgs e)
        {
                LoadData();
        }

        private void searchByIDTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                 con =new SqlConnection(cs.DBConn);
                con.Open();
                cmd =
                    new SqlCommand(
                    "SELECT Transactions.Id, Transactions.Date, BankAccounts.ShortName AS 'Bank Name' , Transactions.AccountNo AS 'Account No', Transactions.TransactionType AS 'Txn Type', Transactions.Benificiary, Transactions.ChequeFromBank AS 'Txn with Bank', Transactions.CheckNo AS 'Cheque No', Transactions.Particulars,  Transactions.Credit, Transactions.Debit, Transactions.CurrentBalance AS 'Actual Balance' FROM Transactions INNER JOIN BankAccounts ON Transactions.AccountNo = BankAccounts.AccountNo Where Transactions.ValueDate is null and Transactions.Id like '" + searchByIDTextBox.Text + "%'",con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(q, con);
                //DataTable dataTable1 = new DataTable();
                //dataAdapter.Fill(dataTable1);
                dataGridView1.Rows.Clear();
                //dataGridView1.ColumnHeadersVisible = false;
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9],
                        rdr[10], rdr[11]);
                }
                //dataGridView1.DataSource = dataTable1;
                //dataGridView1.Columns[0].Width = 40;
                //dataGridView1.Columns[1].Width = 70;
                //dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                //dataGridView1.Columns[2].Width = 55;
                //dataGridView1.Columns[3].Width = 95;
                //dataGridView1.Columns[4].Width = 55;
                //dataGridView1.Columns[5].Width = 100;
                //dataGridView1.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dataGridView1.Columns[6].Width = 70;
                //dataGridView1.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dataGridView1.Columns[7].Width = 70;
                //dataGridView1.Columns[8].Width = 130;
                //dataGridView1.Columns[8].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dataGridView1.Columns[9].Width = 70;
                //dataGridView1.Columns[9].DefaultCellStyle.NullValue = null;
                //dataGridView1.Columns[10].Width = 70;
                //dataGridView1.Columns[10].DefaultCellStyle.NullValue = null;
                //dataGridView1.Columns[11].Width = 95;
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void doneButton_Click(object sender, EventArgs e)
        {
            if (transactionIdTextBox.Text == "")
            {
                MessageBox.Show(@"Please Select Desired Row from the List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                transactionIdTextBox.Focus();
            }
            else if (!checkBox1.Checked)
            {
                MessageBox.Show(@"Select As Reconciled To Update");
            }
            else if (!dateTimePicker1.Checked)
            {
                MessageBox.Show(@"Select Value Date To Update");
            } 
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "UPDATE       Transactions SET ValueDate = @d1, Reconciled = 1 WHERE (Id = @d2)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@d2", transactionIdTextBox.Text);
                rdr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Reset()
        {
            checkBox1.Checked = false;
            dateTimePicker1.Checked = false;
            transactionIdTextBox.Clear();
            amountTextBox.Clear();
        }
        private void searchByCreditBalanceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand(
                    "SELECT Transactions.Id, Transactions.Date, BankAccounts.ShortName AS 'Bank Name' , Transactions.AccountNo AS 'Account No', Transactions.TransactionType AS 'Txn Type', Transactions.Benificiary, Transactions.ChequeFromBank AS 'Txn with Bank', Transactions.CheckNo AS 'Cheque No', Transactions.Particulars,  Transactions.Credit, Transactions.Debit, Transactions.CurrentBalance AS 'Actual Balance' FROM Transactions INNER JOIN BankAccounts ON Transactions.AccountNo = BankAccounts.AccountNo Where Transactions.ValueDate is null and Transactions.Credit like '" + searchByCreditBalanceTextBox.Text + "%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9],
                        rdr[10], rdr[11]);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchByDebitBalanceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand(
                    "SELECT Transactions.Id, Transactions.Date, BankAccounts.ShortName AS 'Bank Name' , Transactions.AccountNo AS 'Account No', Transactions.TransactionType AS 'Txn Type', Transactions.Benificiary, Transactions.ChequeFromBank AS 'Txn with Bank', Transactions.CheckNo AS 'Cheque No', Transactions.Particulars,  Transactions.Credit, Transactions.Debit, Transactions.CurrentBalance AS 'Actual Balance' FROM Transactions INNER JOIN BankAccounts ON Transactions.AccountNo = BankAccounts.AccountNo Where Transactions.ValueDate is null and Transactions.Debit like '" + searchByDebitBalanceTextBox.Text + "%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9],
                        rdr[10], rdr[11]);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            transactionIdTextBox.Text = dr.Cells[0].Value.ToString();
            if (dr.Cells[9].Value.ToString() == "")
            {
                transactionLabel.Text = "Debit Amount";
                amountTextBox.Text = dr.Cells[10].Value.ToString();
            }
            else if (dr.Cells[10].Value.ToString() == "")
            {
                transactionLabel.Text = "Credit Amount";
                amountTextBox.Text = dr.Cells[9].Value.ToString();
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
