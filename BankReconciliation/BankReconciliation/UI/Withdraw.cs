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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BankReconciliation.UI
{
    public partial class Withdraw : Form
    {
        SqlConnection con;
        ConnectionString cs=new ConnectionString();
         SqlCommand cmd;
         SqlDataReader rdr;
        public string fullName, submittedBy,fund;
        public int newRowId;
        public decimal mydecimal2, availablebl12;
        public string od12;
        public string limitset12;
        public decimal limitamount12;
        public Withdraw()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            cmbChequeNo.SelectedIndexChanged -= cmbChequeNo_SelectedIndexChanged;
            cmbChequeNo.Items.Clear();
            cmbChequeNo.SelectedIndex = -1;
            cmbChequeNo.SelectedIndexChanged += cmbChequeNo_SelectedIndexChanged;
            cmbAccountNo.SelectedIndexChanged -= cmbAccountNo_SelectedIndexChanged;
            cmbAccountNo.Items.Clear();
            cmbAccountNo.SelectedIndex = -1;
            cmbAccountNo.SelectedIndexChanged += cmbAccountNo_SelectedIndexChanged;
            cmbdebitToBank.SelectedIndex = -1;
            txtWBankNameCombo.SelectedIndexChanged -= txtWBankNameCombo_SelectedIndexChanged;
            txtWBankNameCombo.Items.Clear();
            txtWBankNameCombo.SelectedIndex = -1;
            txtWBankNameCombo.SelectedIndexChanged += txtWBankNameCombo_SelectedIndexChanged;
            txtWTransactionTypeCombo.SelectedIndexChanged -= txtWTransactionTypeCombo_SelectedIndexChanged;
            txtWTransactionTypeCombo.SelectedIndex = -1;
            txtWTransactionTypeCombo.SelectedIndexChanged += txtWTransactionTypeCombo_SelectedIndexChanged;
            benificiaryWTextBox.Text = "";
            particularsWTextBox.Text = "";
            eftAccountNoWTextBox.Text = "";
            
            creditWTextBox.Text = "";
            transactionWDateTimePicker.Value = DateTime.Today;
            debitButton.Enabled = true;
        }
        private void debitButton_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qq1 = "select BankAccounts.OD from BankAccounts where AccountNo='" + cmbAccountNo.Text + "' ";
            cmd = new SqlCommand(qq1, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read() == true)
            {
                od12 = rdr.GetString(0);
            }
            con.Close();
            
            if (od12 == "OD")

            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ssd = "select BankAccounts.LimitSet from BankAccounts where AccountNo='" + cmbAccountNo.Text + "'  ";
                cmd = new SqlCommand(ssd, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    limitset12 = rdr.GetString(0);
                }
                con.Close();

                if (limitset12 == "Set")
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string q4 = "select LimitTable.LimitAmount from LimitTable where LimitTable.AccountNo = '" + cmbAccountNo.Text + "'  ";
                    cmd = new SqlCommand(q4, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == true)
                    {
                        limitamount12 = rdr.GetDecimal(0);
                    }
                    con.Close();



                    if (txtWBankNameCombo.Text == "")
                    {
                        MessageBox.Show("Please Select Bank name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtWBankNameCombo.Focus();
                        return;
                    }
                    if (cmbAccountNo.Text == "")
                    {
                        MessageBox.Show("Please Enter Valid Account No", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        cmbAccountNo.Focus();
                        return;
                    }
                    if (txtWTransactionTypeCombo.Text == "")
                    {
                        MessageBox.Show("Please Select Transaction Type", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        txtWTransactionTypeCombo.Focus();
                        return;
                    }
                    if (creditWTextBox.Text == "")
                    {
                        MessageBox.Show("Please Enter debit amount", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        creditWTextBox.Focus();
                        return;
                    }
                    try
                    {
                        if (string.IsNullOrWhiteSpace(textBox2.Text))
                        {
                            fund = null;
                        }
                        else
                        {
                            fund = textBox2.Text;
                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct = "select AccountNo,Balance from BankAccounts where AccountNo='" + cmbAccountNo.Text +
                                    "'";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        string dbl = creditWTextBox.Text;
                        if (rdr.Read())
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb2 = "Update BankAccounts set Balance=Balance -" +
                                         decimal.Parse(creditWTextBox.Text) + " where AccountNo='" + cmbAccountNo.Text +
                                         "'";
                            cmd = new SqlCommand(cb2);
                            cmd.Connection = con;
                            cmd.ExecuteReader();
                            con.Close();

                            con.Open();
                            string cb3 = "update BankAccounts set AvailableBalance=Balance + " + limitamount12 + " where AccountNo='" + cmbAccountNo.Text + "'  ";
                            cmd = new SqlCommand(cb3, con);
                            rdr = cmd.ExecuteReader();
                            con.Close();


                        }
                        else
                        {
                            MessageBox.Show("Please Enter Correct Account Number", "Input Error", MessageBoxButtons.OK);

                        }
                        SqlConnection myConnection = default(SqlConnection);
                        myConnection = new SqlConnection(cs.DBConn);
                        SqlCommand myCommand = default(SqlCommand);
                        myCommand = new SqlCommand(
                            "SELECT AccountNo,BankName FROM BankAccounts WHERE AccountNo = @accountNo AND BankName = @bankName",
                            myConnection);
                        SqlParameter uName = new SqlParameter("@accountNo", SqlDbType.VarChar);
                        SqlParameter uPassword = new SqlParameter("@bankName", SqlDbType.VarChar);
                        uName.Value = cmbAccountNo.Text;
                        uPassword.Value = txtWBankNameCombo.Text;
                        myCommand.Parameters.Add(uName);
                        myCommand.Parameters.Add(uPassword);
                        myCommand.Connection.Open();

                        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                        if (myReader.Read() == true)
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ctk = "select Balance from BankAccounts where AccountNo='" + cmbAccountNo.Text +
                                         "' and BankName='" + txtWBankNameCombo.Text + "'";
                            cmd = new SqlCommand(ctk);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                // txtBalance2.Text = (rdr.GetString(0));
                                mydecimal2 = rdr.GetDecimal(0);
                            }
                            con.Close();

                            con.Open();
                            string avb = "select AvailableBalance from BankAccounts where AccountNo='" + cmbAccountNo.Text + "' and BankName='" + txtWBankNameCombo.Text + "'";
                            cmd = new SqlCommand(avb, con);
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                availablebl12 = rdr.GetDecimal(0);
                            }
                            con.Close();

                        }

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cty4 = "select Name from Registration where UserId='" + submittedBy + "'";
                        cmd = new SqlCommand(cty4);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            fullName = (rdr.GetString(0));
                        }
                        //auto();
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb =
                            "insert into ODAccountTransaction(BankName,AccountNo,TransactionType,Benificiary,ChequeFromBank,Particulars,CheckNo,Debit,SystemCurrentBalance,SystemTxnDate,Date,FundRNo,SystemAvailableBalance, UserId) VALUES (@bankName,@accountNo,@transactionType,@banificiary,@debitToBank,@particulars,@cheque,@debit,@currentBalance,@d1,@dt,@fr,@avlbl,@userid)" +
                            "SELECT CONVERT(int, SCOPE_IDENTITY());";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@bankName", txtWBankNameCombo.Text);
                        cmd.Parameters.AddWithValue("@accountNo", cmbAccountNo.Text);
                        cmd.Parameters.AddWithValue("@transactionType", txtWTransactionTypeCombo.Text);
                        cmd.Parameters.AddWithValue("@banificiary", benificiaryWTextBox.Text);
                        cmd.Parameters.AddWithValue("@debitToBank", cmbdebitToBank.Text);
                        cmd.Parameters.AddWithValue("@particulars", particularsWTextBox.Text);
                        cmd.Parameters.AddWithValue("@cheque", cmbChequeNo.Text);
                        cmd.Parameters.AddWithValue("@debit", creditWTextBox.Text);
                        cmd.Parameters.AddWithValue("@currentBalance", mydecimal2.ToString());
                        //cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(transactionWDateTimePicker.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                        cmd.Parameters.AddWithValue("@d1", transactionWDateTimePicker.Value.ToLocalTime());
                        cmd.Parameters.AddWithValue("@dt",
                            Convert.ToDateTime(transactionWDateTimePicker.Text,
                                System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                        cmd.Parameters.AddWithValue("@fr", (object) fund ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@avlbl", availablebl12.ToString());
                        cmd.Parameters.AddWithValue("@userid", LoginForm.uId2);
                        //cmd.ExecuteReader();
                        newRowId = (int) cmd.ExecuteScalar();
                        con.Close();
                        MessageBox.Show("Successfully Debited.Your Current Transaction Id is:" + newRowId, "Record",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        debitButton.Enabled = false;
                        SaveSTatus();
                        Reset();
                        //Condition();
                        GetData();



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (limitset12 == "Not-set")
                {
                    MessageBox.Show("This OD Account does not Have Limit set. Please Set Limit For this Account", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else if (od12 == "NON-OD")
            {
                if (txtWBankNameCombo.Text == "")
                {
                    MessageBox.Show("Please Select Bank name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtWBankNameCombo.Focus();
                    return;
                }
                if (cmbAccountNo.Text == "")
                {
                    MessageBox.Show("Please Enter Valid Account No", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    cmbAccountNo.Focus();
                    return;
                }
                if (txtWTransactionTypeCombo.Text == "")
                {
                    MessageBox.Show("Please Select Transaction Type", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtWTransactionTypeCombo.Focus();
                    return;
                }
                if (creditWTextBox.Text == "")
                {
                    MessageBox.Show("Please Enter debit amount", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    creditWTextBox.Focus();
                    return;
                }
                try
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        fund = null;
                    }
                    else
                    {
                        fund = textBox2.Text;
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select AccountNo,Balance from BankAccounts where AccountNo='" + cmbAccountNo.Text +
                                "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    string dbl = creditWTextBox.Text;
                    if (rdr.Read())
                    {

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb2 = "Update BankAccounts set Balance=Balance -" +
                                     decimal.Parse(creditWTextBox.Text) + ", AvailableBalance=Balance -" + decimal.Parse(creditWTextBox.Text) + "  where AccountNo='" + cmbAccountNo.Text +
                                     "'";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.ExecuteReader();
                        con.Close();

                        //con.Open();
                        //string cb3 = "update BankAccounts set AvailableBalance=Balance + " + limitamount12 + " where AccountNo='" + cmbAccountNo.Text + "'  ";
                        //cmd = new SqlCommand(cb3, con);
                        //rdr = cmd.ExecuteReader();
                        //con.Close();


                    }
                    else
                    {
                        MessageBox.Show("Please Enter Correct Account Number", "Input Error", MessageBoxButtons.OK);

                    }
                    SqlConnection myConnection = default(SqlConnection);
                    myConnection = new SqlConnection(cs.DBConn);
                    SqlCommand myCommand = default(SqlCommand);
                    myCommand = new SqlCommand(
                        "SELECT AccountNo,BankName FROM BankAccounts WHERE AccountNo = @accountNo AND BankName = @bankName",
                        myConnection);
                    SqlParameter uName = new SqlParameter("@accountNo", SqlDbType.VarChar);
                    SqlParameter uPassword = new SqlParameter("@bankName", SqlDbType.VarChar);
                    uName.Value = cmbAccountNo.Text;
                    uPassword.Value = txtWBankNameCombo.Text;
                    myCommand.Parameters.Add(uName);
                    myCommand.Parameters.Add(uPassword);
                    myCommand.Connection.Open();

                    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    if (myReader.Read() == true)
                    {

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ctk = "select Balance from BankAccounts where AccountNo='" + cmbAccountNo.Text +
                                     "' and BankName='" + txtWBankNameCombo.Text + "'";
                        cmd = new SqlCommand(ctk);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            // txtBalance2.Text = (rdr.GetString(0));
                            mydecimal2 = rdr.GetDecimal(0);
                        }
                        con.Close();

                        con.Open();
                        string avb = "select AvailableBalance from BankAccounts where AccountNo='" + cmbAccountNo.Text + "' and BankName='" + txtWBankNameCombo.Text + "'";
                        cmd = new SqlCommand(avb, con);
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            availablebl12 = rdr.GetDecimal(0);
                        }
                        con.Close();

                    }

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cty4 = "select Name from Registration where UserId='" + submittedBy + "'";
                    cmd = new SqlCommand(cty4);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        fullName = (rdr.GetString(0));
                    }
                    //auto();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb =
                        "insert into ODAccountTransaction(BankName,AccountNo,TransactionType,Benificiary,ChequeFromBank,Particulars,CheckNo,Debit,SystemCurrentBalance,SystemTxnDate,Date,FundRNo,SystemAvailableBalance, UserId) VALUES (@bankName,@accountNo,@transactionType,@banificiary,@debitToBank,@particulars,@cheque,@debit,@currentBalance,@d1,@dt,@fr,@avlbl,@userid)" +
                        "SELECT CONVERT(int, SCOPE_IDENTITY());";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@bankName", txtWBankNameCombo.Text);
                    cmd.Parameters.AddWithValue("@accountNo", cmbAccountNo.Text);
                    cmd.Parameters.AddWithValue("@transactionType", txtWTransactionTypeCombo.Text);
                    cmd.Parameters.AddWithValue("@banificiary", benificiaryWTextBox.Text);
                    cmd.Parameters.AddWithValue("@debitToBank", cmbdebitToBank.Text);
                    cmd.Parameters.AddWithValue("@particulars", particularsWTextBox.Text);
                    cmd.Parameters.AddWithValue("@cheque", cmbChequeNo.Text);
                    cmd.Parameters.AddWithValue("@debit", creditWTextBox.Text);
                    cmd.Parameters.AddWithValue("@currentBalance", mydecimal2.ToString());
                    //cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(transactionWDateTimePicker.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.Parameters.AddWithValue("@d1", transactionWDateTimePicker.Value.ToLocalTime());
                    cmd.Parameters.AddWithValue("@dt",
                        Convert.ToDateTime(transactionWDateTimePicker.Text,
                            System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.Parameters.AddWithValue("@fr", (object)fund ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@avlbl", availablebl12.ToString());
                    cmd.Parameters.AddWithValue("@userid", LoginForm.uId2);
                    //cmd.ExecuteReader();
                    newRowId = (int)cmd.ExecuteScalar();
                    con.Close();
                    MessageBox.Show("Successfully Debited.Your Current Transaction Id is:" + newRowId, "Record",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    debitButton.Enabled = false;
                    SaveSTatus();
                    Reset();
                   // Condition();
                    GetData();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            

        }
        private void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                // string selectQuery = "Select AccountNo,Balances from Temp_Account2";
                string selectQuery = "Select BankName,BranchName, AccountNo, AvailableBalance from BankAccounts";

                SqlDataAdapter myadapter = new SqlDataAdapter(selectQuery, con);
                DataTable dt = new DataTable();
                myadapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void FillCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(AccountNo) from BankAccounts order by AccountNo";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                   cmbAccountNo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSTatus()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
               // string cb2 = "Update ChequeLoad set Status='" + cmbStatus.Text + "' where AccountNo='" + cmbAccountNo.Text + "' and CheckNo='" + cmbChequeNo.Text + "'";
                string cb2 = "Update ChequeLoad set Status='Written' where AccountNo='" + cmbAccountNo.Text + "' and CheckNo='" + cmbChequeNo.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();

                con.Close();
                //MessageBox.Show("Successfully Set status", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                  
               // }
            }
            
        

        
        private void Withdraw_Load(object sender, EventArgs e)
        {
            submittedBy = LoginForm.uId2.ToString();
           // FillCombo();
            GetData();
        }


        private void SMRTButton_Click(object sender, EventArgs e)
        {
            DataGridForDeposit  frm=new DataGridForDeposit();
            frm.Show();

        }

        private void accountWNoTextBox_TextChanged(object sender, EventArgs e)
        {
        //    try
        //    {
        //        con = new SqlConnection(cs.DBConn);

        //        con.Open();
        //        cmd = con.CreateCommand();

        //        cmd.CommandText = "SELECT AccountNo from BankAccounts WHERE AccountNo = '" + cmbAccountNo.Text + "'";
        //        rdr = cmd.ExecuteReader();

        //        if (rdr.Read())
        //        {
        //            txtAccountNo.Text = rdr.GetInt32(0).ToString().Trim();
        //        }
        //        if ((rdr != null))
        //        {
        //            rdr.Close();
        //        }
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //        cmbAccountNo.Text = cmbAccountNo.Text.Trim();
        //        cmbChequeNo.Items.Clear();
        //        cmbChequeNo.Text = "";
        //        cmbChequeNo.Enabled = true;
        //        cmbChequeNo.Focus();

        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string ct = "select distinct RTRIM(CheckNo) from BankAccounts,Withdraw where BankAccounts.AccountNo=Withdraw.AccountNo and AccountNo= '" + cmbAccountNo.Text + "'";
        //        cmd = new SqlCommand(ct);
        //        cmd.Connection = con;
        //        rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            cmbChequeNo.Items.Add(rdr[0]);
        //        }
        //        con.Close();

        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        }

        private void cmbChequeNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT Id from ChequeLoad WHERE CheckNo = '" + cmbChequeNo.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    txtWithwrawId.Text = rdr.GetInt32(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbAccountNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT AccountNo from BankAccounts WHERE AccountNo = '" + cmbAccountNo.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    
                   // txtAccountNo.Text = rdr.GetInt32(0).ToString().Trim();
                    //txtAccountNo.Text = rdr.GetInt64(0).ToString().Trim();
                    txtAccountNo.Text = rdr.GetString(0).Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmbAccountNo.Text = cmbAccountNo.Text.Trim();
                cmbChequeNo.Items.Clear();
                cmbChequeNo.Text = "";
                cmbChequeNo.Enabled = true;
                cmbChequeNo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(CheckNo) from BankAccounts,ChequeLoad where BankAccounts.AccountNo=ChequeLoad.AccountNo and BankAccounts.AccountNo= '" + cmbAccountNo.Text + "' and ChequeLoad.Status!='Written'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbChequeNo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void creditWTextBox_Validating(object sender, CancelEventArgs e)
        {
            //decimal val1 = mydecimal2;
            decimal val1 = availablebl12;
            decimal val2 = 0;
         
           decimal.TryParse(creditWTextBox.Text, out val2);
            if (val2 > val1)
            {
                MessageBox.Show("Insufficient Balance, Your Current balance is:" + availablebl12, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                creditWTextBox.Text = "";
                txtBalance2.Text = "";
                creditWTextBox.Focus();
                return;
            }
        }

        private void creditWTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
            
            
            //if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private void creditWTextBox_TextChanged(object sender, EventArgs e)
        {
            SqlConnection myConnection = default(SqlConnection);
            myConnection = new SqlConnection(cs.DBConn);
            SqlCommand myCommand = default(SqlCommand);
            myCommand = new SqlCommand("SELECT AccountNo,BankName FROM BankAccounts WHERE AccountNo = @accountNo AND BankName = @bankName", myConnection);
            SqlParameter uName = new SqlParameter("@accountNo", SqlDbType.VarChar);
            SqlParameter uPassword = new SqlParameter("@bankName", SqlDbType.VarChar);
            uName.Value = cmbAccountNo.Text;
            uPassword.Value = txtWBankNameCombo.Text;
            myCommand.Parameters.Add(uName);
            myCommand.Parameters.Add(uPassword);
            myCommand.Connection.Open();

            SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            if (myReader.Read() == true)
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "select AvailableBalance from BankAccounts where AccountNo='" + cmbAccountNo.Text + "' and BankName='" + txtWBankNameCombo.Text + "'";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    availablebl12 = (rdr.GetDecimal(0));
                }
            }
        }

        private void txtWBankNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT BankAccounts.AccountNo from BankAccounts WHERE BankAccounts.BankName = '" + txtWBankNameCombo.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    txtWBankNameCombo.Text = rdr.GetString(0).Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                txtWBankNameCombo.Text = txtWBankNameCombo.Text.Trim();
                cmbAccountNo.Items.Clear();
                cmbAccountNo.Text = "";
                cmbAccountNo.Enabled = true;
                cmbAccountNo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(BankAccounts.AccountNo) from BankAccounts  Where BankAccounts.BankName= '" + txtWBankNameCombo.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbAccountNo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtWTransactionTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillBank();
            if (txtWTransactionTypeCombo.SelectedItem == "Chq(W)")
            {
                // do something
                label21.Visible = true;
                cmbChequeNo.Visible = true;
                label5.Visible = false;
                label3.Visible = false;
                cmbdebitToBank.SelectedIndex = -1;
                cmbdebitToBank.Visible = false;
                eftAccountNoWTextBox.Clear();
                eftAccountNoWTextBox.Visible = false;
                cmbChequeNo.Enabled = true;
                cmbdebitToBank.Enabled = false;
                eftAccountNoWTextBox.ReadOnly = true;
                cmbChequeNo.Location=new Point(225, 201);
                label21.Location=new Point(73, 201);
                benificiaryWTextBox.Location = new Point(225, 244);
                label2.Location=new Point(73, 244);
                particularsWTextBox.Location=new Point(225, 291);
                label41.Location=new Point(72, 291);
                creditWTextBox.Location = new Point(225, 344);
                label51.Location = new Point(54, 344);
            }
            else if (txtWTransactionTypeCombo.SelectedItem == "EFT(W)")
            {
                // do something
                cmbChequeNo.SelectedIndex = -1;
                label21.Visible = false;
                cmbChequeNo.Visible = false;
                label5.Visible = true;
                label3.Visible = true;
                cmbdebitToBank.Visible = true;
                eftAccountNoWTextBox.Visible = true;
                cmbChequeNo.Enabled = false;
                cmbdebitToBank.Enabled = true;
                eftAccountNoWTextBox.ReadOnly = false;
                cmbdebitToBank.Location = new Point(225, 201);
                label5.Location = new Point(54, 201);
                eftAccountNoWTextBox.Location = new Point(225, 244);
                label3.Location = new Point(21, 244);
                benificiaryWTextBox.Location = new Point(225, 291);
                label2.Location = new Point(73, 291);
                particularsWTextBox.Location = new Point(225, 344);
                label41.Location = new Point(72, 344);
                creditWTextBox.Location = new Point(225, 390);
                label51.Location = new Point(54, 390);
                cmbdebitToBank.SelectedIndex = -1;
            }
            else
            {
                cmbChequeNo.SelectedIndex = -1;
                cmbdebitToBank.SelectedIndex = -1;
                eftAccountNoWTextBox.Clear();
                label21.Visible = false;
                cmbChequeNo.Visible = false;
                label5.Visible = false;
                label3.Visible = false;
                cmbdebitToBank.Visible = false;
                eftAccountNoWTextBox.Visible = false;
                cmbChequeNo.Enabled = false;
                cmbChequeNo.Items.Clear();
                cmbdebitToBank.Enabled = false;
                eftAccountNoWTextBox.ReadOnly = true;
                benificiaryWTextBox.Location = new Point(225, 201);
                label2.Location = new Point(73, 201);
                particularsWTextBox.Location = new Point(225, 244);
                label41.Location = new Point(72, 244);
                creditWTextBox.Location = new Point(225, 291);
                label51.Location = new Point(54, 291);
                benificiaryWTextBox.Focus();
            }

            //if (txtWTransactionTypeCombo.SelectedItem == "EFT(W)")
            //{
            //    // do something
            //    cmbChequeNo.Enabled = false;
            //    cmbdebitToBank.Enabled = true;
            //    eftAccountNoWTextBox.ReadOnly = false;

            //}
            //else
            //{
            //    //cmbChequeNo.Enabled = false;
            //    cmbdebitToBank.Enabled = false;
            //    eftAccountNoWTextBox.ReadOnly = true;
                
            //}
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void ReportCheque()
        {
            //creating an object of ParameterField class
            ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
            ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            paramField.Name = "id";

            //set the parameter value
            paramDiscreteValue.Value = newRowId;

            //add the parameter value in the ParameterField object
            paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
            paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:kyotoServer,49172";
            with1.DatabaseName = "BankReconciliationDBProNovember";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            WithdrawInputCrystalReportCheque cr = new WithdrawInputCrystalReportCheque();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ParameterFieldInfo = paramFields;  //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }
        private void ReportOther()
        {
            //creating an object of ParameterField class
            ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
            ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            paramField.Name = "id";

            //set the parameter value
            paramDiscreteValue.Value = newRowId;

            //add the parameter value in the ParameterField object
            paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
            paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:kyotoServer,49172";
            with1.DatabaseName = "BankReconciliationDBProNovember";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            WithdrawInputCrystalReportOthers cr = new WithdrawInputCrystalReportOthers();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ParameterFieldInfo = paramFields;  //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }
        private void ReportEFT()
        {
            //creating an object of ParameterField class
            ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
            ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            paramField.Name = "id";

            //set the parameter value
            paramDiscreteValue.Value = newRowId;

            //add the parameter value in the ParameterField object
            paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
            paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:kyotoServer,49172";
            with1.DatabaseName = "BankReconciliationDBProNovember";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            WithdrawInputCrystalReportEFT cr = new WithdrawInputCrystalReportEFT();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ParameterFieldInfo = paramFields;  //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }
        void Condition()
        {
            if (txtWTransactionTypeCombo.Text == "Cheque")
            {
                ReportCheque();
            }
            else if (txtWTransactionTypeCombo.Text == "EFT")
            {
                ReportEFT();
            }
            else
            {
                ReportOther();
            }
        }

        private void eftAccountNoWTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                benificiaryWTextBox.Focus();
                e.Handled = true;
            }
        }

        private void benificiaryWTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                particularsWTextBox.Focus();
                e.Handled = true;
            }
        }

        private void particularsWTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                creditWTextBox.Focus();
                e.Handled = true;
            }
        }

        private void creditWTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal val1 = availablebl12;
                decimal val2 = 0;

                decimal.TryParse(creditWTextBox.Text, out val2);
                if (val2 > val1)
                {
                    MessageBox.Show("Insufficient Balance, Your Current balance is:" + availablebl12, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    creditWTextBox.Text = "";
                    txtBalance2.Text = "";
                    creditWTextBox.Focus();
                    return;
                }
                else
                {
                    debitButton_Click(this, new EventArgs());
                }
                
            }
        }
        private void FillBank()
        {
            try
            {


                txtWBankNameCombo.Items.Clear();
                txtWBankNameCombo.Text = "";
                txtWBankNameCombo.Enabled = true;
                txtWBankNameCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select  distinct RTRIM(BankAccounts.BankName) from BankAccounts";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtWBankNameCombo.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void transactionWDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void transactionWDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            txtWTransactionTypeCombo.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //{
            //    PositivePayInstruction f2 = new PositivePayInstruction();
            //    this.Visible = false;
            //    f2.ShowDialog();
            //    this.Visible = true;
            //}

            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:kyotoServer,49172";
            with1.DatabaseName = "BankReconciliationDBProNovember";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            PositivePayInstructionUnimade cr = new PositivePayInstructionUnimade();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }
      //  private void transactionWDateTimePicker_ValueChanged(object sender, EventArgs e)
       // {
//
       // }
    }
}
