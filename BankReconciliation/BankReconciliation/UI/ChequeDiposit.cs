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
using BankReconciliation.UI;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BankReconciliation
{
    public partial class ChequeDiposit : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        ConnectionString cs=new ConnectionString();
        private SqlDataReader rdr;
        public int newRowID;
        public decimal mydecimal, availablebl;
        public string submittedBy2, fullName2;
        public string od;
        public string limitset;
        public decimal limitamount;

        public ChequeDiposit()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {  
          
        con = new SqlConnection(cs.DBConn);
        con.Open();
        string qq1 = "select BankAccounts.OD from BankAccounts where AccountNo='" + cmbAccountDNo.Text + "' ";
        cmd = new SqlCommand(qq1, con);
        rdr = cmd.ExecuteReader();
         if (rdr.Read() == true)
        {
              od = rdr.GetString(0);
        }
          con.Close();

            if (od == "OD")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ssd = "select BankAccounts.LimitSet from BankAccounts where AccountNo='" + cmbAccountDNo.Text + "'  ";
                cmd = new SqlCommand(ssd, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    limitset = rdr.GetString(0);
                }
                con.Close();

                if (limitset == "Set")

                {  
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                string q4 = "select LimitTable.LimitAmount from LimitTable where LimitTable.AccountNo = '" + cmbAccountDNo.Text + "'  ";
                    cmd = new SqlCommand(q4, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == true)
                    {
                        limitamount = rdr.GetDecimal(0);
                    }
                    con.Close();
                    //textBox2.Text = limitamount.ToString();
                    if (txtBankNameCombo.Text == "")
                    {
                        MessageBox.Show("Please Select Bank name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBankNameCombo.Focus();
                        return;
                    }
                    if (cmbAccountDNo.Text == "")
                    {
                        MessageBox.Show("Please Type valid Account Number", "Input Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        cmbAccountDNo.Focus();
                        return;
                    }
                    if (txtTransactionTypeCombo.Text == "")
                    {
                        MessageBox.Show("Please Select Transection Type", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        txtTransactionTypeCombo.Focus();
                        return;
                    }
                    //if (chequeFromBankTextBox.Text == "")
                    //{
                    //    MessageBox.Show("Please Enter the Recipient ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    chequeFromBankTextBox.Focus();
                    //    return;
                    //}
                    if (particularsTextBox.Text == "")
                    {
                        MessageBox.Show("Please Enter the Particulars ", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        particularsTextBox.Focus();
                        return;
                    }
                    if (creditTextBox.Text == "")
                    {
                        MessageBox.Show("Please Enter Credit Amount", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        creditTextBox.Focus();
                        return;
                    }

                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();

                        //string ct = "select AccountNo from Temp_Account2 where AccountNo='" + accountNoTextBox.Text + "'";
                        string ct = "select AccountNo from BankAccounts where AccountNo='" + cmbAccountDNo.Text + "'";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            // string cb2 = "Update Temp_Account2 set Balances=Balances + " + creditTextBox.Text + " where AccountNo='" + accountNoTextBox.Text + "'";
                            string cb2 = "Update BankAccounts set Balance=Balance + " + decimal.Parse(creditTextBox.Text) + "  where AccountNo='" + cmbAccountDNo.Text + "'";
                            cmd = new SqlCommand(cb2);
                            cmd.Connection = con;
                            cmd.ExecuteReader();
                            con.Close();

                            con.Open();
                            string cb3 = "update BankAccounts set AvailableBalance=Balance + " + limitamount + " where AccountNo='" + cmbAccountDNo.Text + "'  ";
                            cmd= new SqlCommand(cb3, con);
                            rdr = cmd.ExecuteReader();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Correct Account Number", "Input Error", MessageBoxButtons.OK);
                            //con = new SqlConnection(cs.DBConn);
                            //con.Open();
                            ////string cb1 = "insert into Temp_Account2(AccountNo,Balances) VALUES ('" + accountNoTextBox.Text + "'," + creditTextBox.Text + ")";
                            //string cb1 = "insert into BankAccounts(AccountNo,BankName,BranchName,Balances) VALUES ('" + accountNoTextBox.Text + "','"+txtBankNameCombo.Text+"'," + creditTextBox.Text + ")";
                            //cmd = new SqlCommand(cb1);
                            //cmd.Connection = con;

                            //cmd.ExecuteReader();
                            //con.Close();
                        }
                        //////
                        SqlConnection myConnection = default(SqlConnection);
                        myConnection = new SqlConnection(cs.DBConn);

                        SqlCommand myCommand = default(SqlCommand);

                        myCommand = new SqlCommand(
                            "SELECT AccountNo,BankName FROM BankAccounts WHERE AccountNo = @accountNo AND BankName = @bankName",
                            myConnection);
                        SqlParameter uName = new SqlParameter("@accountNo", SqlDbType.VarChar);
                        SqlParameter uPassword = new SqlParameter("@bankName", SqlDbType.VarChar);
                        uName.Value = cmbAccountDNo.Text;
                        uPassword.Value = txtBankNameCombo.Text;
                        myCommand.Parameters.Add(uName);
                        myCommand.Parameters.Add(uPassword);

                        myCommand.Connection.Open();

                        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                        if (myReader.Read() == true)
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ctk = "select Balance from BankAccounts where AccountNo='" + cmbAccountDNo.Text +
                                         "' and BankName='" + txtBankNameCombo.Text + "'";
                            cmd = new SqlCommand(ctk);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                // txtBalance.Text = (rdr.GetDouble(0).ToString());
                                mydecimal = (rdr.GetDecimal(0));
                            }
                            con.Close();
                            con.Open();
                            string avb = "select AvailableBalance from BankAccounts where AccountNo='" + cmbAccountDNo.Text + "' and BankName='" + txtBankNameCombo.Text + "'";
                            cmd= new SqlCommand(avb, con);
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                availablebl = rdr.GetDecimal(0);
                            }
                            con.Close();
                        }

                        
                        /////
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ctk2 = "Select Name from Registration where UserId='" + submittedBy2 + "'";
                        cmd = new SqlCommand(ctk2);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            fullName2 = (rdr.GetString(0));
                        }

                        //auto();
                        ///

                       // con.Close();


                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        // string cb = "insert into Transactions(BankName,AccountNo,TransactionType,Benificiary,Particulars,CheckNo,Credit,CurrentBalance,TransactionDates) VALUES ('" + txtBankNameCombo.Text + "','" + cmbAccountDNo.Text + "','" + txtTransactionTypeCombo.Text + "','" + benificiaryTextBox.Text + "','" + particularsTextBox.Text + "','" + checkNoTextBox.Text + "','" + creditTextBox.Text + "','" + txtBalance.Text + "', @d1)";
                        string cb = String.Format(
                            "insert into ODAccountTransaction(BankName,AccountNo,TransactionType,ChequeFromBank,EFTAccountNo,Particulars,CheckNo,Credit,SystemCurrentBalance,SystemTxnDate,Date,SystemAvailableBalance,UserId) VALUES (@bankName,@accountNo,@transactionType,@chequeFromBank,@eftAccountNo,@particulars,@chequeNo,@credit,@currentBalance,@d1,@d2,@sysavailable,@userid)" +
                            "SELECT CONVERT(int, SCOPE_IDENTITY());");
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@bankName", txtBankNameCombo.Text);
                        cmd.Parameters.AddWithValue("@accountNo", cmbAccountDNo.Text);
                        cmd.Parameters.AddWithValue("@transactionType", txtTransactionTypeCombo.Text);

                        cmd.Parameters.AddWithValue("@chequeFromBank", cmbCreditFromBank.Text);
                        cmd.Parameters.AddWithValue("@eftAccountNo", eftAccountNoTextBox.Text);
                        cmd.Parameters.AddWithValue("@particulars", particularsTextBox.Text);
                        cmd.Parameters.AddWithValue("@chequeNo", checkNoTextBox.Text);
                        cmd.Parameters.AddWithValue("@credit", creditTextBox.Text);
                        cmd.Parameters.AddWithValue("@currentBalance", mydecimal.ToString());
                        cmd.Parameters.AddWithValue("@d1", transactionDateTimePicker.Value.ToLocalTime());
                        cmd.Parameters.AddWithValue("@d2",
                            Convert.ToDateTime(transactionDateTimePicker.Text,
                                System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));

                        cmd.Parameters.AddWithValue("@sysavailable", availablebl.ToString());
                        cmd.Parameters.AddWithValue("@userid", LoginForm.uId2);
                        // cmd.Parameters.AddWithValue();
                        newRowID = (int) cmd.ExecuteScalar();

                        con.Close();
                        MessageBox.Show("Successfully Deposited, Your Current Transaction Id is:" + newRowID, "Record",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        saveButton.Enabled = false;
                        GetData();
                        Reset();
                       // Condition();
                        FillBank();




                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (limitset == "Not-set")
                {
                    MessageBox.Show("This OD Account does not Have Limit set. Please Set Limit For this Account","Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }

                else if (od == "NON-OD")
                {
                    if (txtBankNameCombo.Text == "")
                    {
                        MessageBox.Show("Please Select Bank name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBankNameCombo.Focus();
                        return;
                    }
                    if (cmbAccountDNo.Text == "")
                    {
                        MessageBox.Show("Please Type valid Account Number", "Input Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        cmbAccountDNo.Focus();
                        return;
                    }
                    if (txtTransactionTypeCombo.Text == "")
                    {
                        MessageBox.Show("Please Select Transection Type", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        txtTransactionTypeCombo.Focus();
                        return;
                    }
                    //if (chequeFromBankTextBox.Text == "")
                    //{
                    //    MessageBox.Show("Please Enter the Recipient ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    chequeFromBankTextBox.Focus();
                    //    return;
                    //}
                    if (particularsTextBox.Text == "")
                    {
                        MessageBox.Show("Please Enter the Particulars ", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        particularsTextBox.Focus();
                        return;
                    }
                    if (creditTextBox.Text == "")
                    {
                        MessageBox.Show("Please Enter Credit Amount", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        creditTextBox.Focus();
                        return;
                    }

                    try
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();

                        //string ct = "select AccountNo from Temp_Account2 where AccountNo='" + accountNoTextBox.Text + "'";
                        string ct = "select AccountNo from BankAccounts where AccountNo='" + cmbAccountDNo.Text + "'";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            // string cb2 = "Update Temp_Account2 set Balances=Balances + " + creditTextBox.Text + " where AccountNo='" + accountNoTextBox.Text + "'";
                            string cb2 = "Update BankAccounts set Balance=Balance + " +
                                         decimal.Parse(creditTextBox.Text) +
                                         " , AvailableBalance = AvailableBalance + " +
                                         decimal.Parse(creditTextBox.Text) +
                                         "  where AccountNo='" + cmbAccountDNo.Text + "'";
                            cmd = new SqlCommand(cb2);
                            cmd.Connection = con;
                            cmd.ExecuteReader();
                            con.Close();

                        }
                        else
                        {
                            MessageBox.Show("Please Enter Correct Account Number", "Input Error", MessageBoxButtons.OK);
                            //con = new SqlConnection(cs.DBConn);
                            //con.Open();
                            ////string cb1 = "insert into Temp_Account2(AccountNo,Balances) VALUES ('" + accountNoTextBox.Text + "'," + creditTextBox.Text + ")";
                            //string cb1 = "insert into BankAccounts(AccountNo,BankName,BranchName,Balances) VALUES ('" + accountNoTextBox.Text + "','"+txtBankNameCombo.Text+"'," + creditTextBox.Text + ")";
                            //cmd = new SqlCommand(cb1);
                            //cmd.Connection = con;

                            //cmd.ExecuteReader();
                            //con.Close();
                        }
                        //////
                        SqlConnection myConnection = default(SqlConnection);
                        myConnection = new SqlConnection(cs.DBConn);

                        SqlCommand myCommand = default(SqlCommand);

                        myCommand = new SqlCommand(
                            "SELECT AccountNo,BankName FROM BankAccounts WHERE AccountNo = @accountNo AND BankName = @bankName",
                            myConnection);
                        SqlParameter uName = new SqlParameter("@accountNo", SqlDbType.VarChar);
                        SqlParameter uPassword = new SqlParameter("@bankName", SqlDbType.VarChar);
                        uName.Value = cmbAccountDNo.Text;
                        uPassword.Value = txtBankNameCombo.Text;
                        myCommand.Parameters.Add(uName);
                        myCommand.Parameters.Add(uPassword);

                        myCommand.Connection.Open();

                        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                        if (myReader.Read() == true)
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ctk = "select Balance from BankAccounts where AccountNo='" + cmbAccountDNo.Text +
                                         "' and BankName='" + txtBankNameCombo.Text + "'";
                            cmd = new SqlCommand(ctk);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                // txtBalance.Text = (rdr.GetDouble(0).ToString());
                                mydecimal = (rdr.GetDecimal(0));
                            }
                        }
                        /////
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ctk2 = "Select Name from Registration where UserId='" + submittedBy2 + "'";
                        cmd = new SqlCommand(ctk2);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            fullName2 = (rdr.GetString(0));
                        }

                        //auto();
                        ///




                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        // string cb = "insert into Transactions(BankName,AccountNo,TransactionType,Benificiary,Particulars,CheckNo,Credit,CurrentBalance,TransactionDates) VALUES ('" + txtBankNameCombo.Text + "','" + cmbAccountDNo.Text + "','" + txtTransactionTypeCombo.Text + "','" + benificiaryTextBox.Text + "','" + particularsTextBox.Text + "','" + checkNoTextBox.Text + "','" + creditTextBox.Text + "','" + txtBalance.Text + "', @d1)";
                        string cb = String.Format(
                            "insert into ODAccountTransaction(BankName,AccountNo,TransactionType,ChequeFromBank,EFTAccountNo,Particulars,CheckNo,Credit,SystemCurrentBalance,SystemTxnDate,Date,SystemAvailableBalance,UserId) VALUES (@bankName,@accountNo,@transactionType,@chequeFromBank,@eftAccountNo,@particulars,@chequeNo,@credit,@currentBalance,@d1,@d2,@sysavailable,@userid)" +
                            "SELECT CONVERT(int, SCOPE_IDENTITY());");
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@bankName", txtBankNameCombo.Text);
                        cmd.Parameters.AddWithValue("@accountNo", cmbAccountDNo.Text);
                        cmd.Parameters.AddWithValue("@transactionType", txtTransactionTypeCombo.Text);

                        cmd.Parameters.AddWithValue("@chequeFromBank", cmbCreditFromBank.Text);
                        cmd.Parameters.AddWithValue("@eftAccountNo", eftAccountNoTextBox.Text);
                        cmd.Parameters.AddWithValue("@particulars", particularsTextBox.Text);
                        cmd.Parameters.AddWithValue("@chequeNo", checkNoTextBox.Text);
                        cmd.Parameters.AddWithValue("@credit", creditTextBox.Text);
                        cmd.Parameters.AddWithValue("@currentBalance", mydecimal.ToString());
                        cmd.Parameters.AddWithValue("@d1", transactionDateTimePicker.Value.ToLocalTime());
                        cmd.Parameters.AddWithValue("@d2",
                            Convert.ToDateTime(transactionDateTimePicker.Text,
                                System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));

                        cmd.Parameters.AddWithValue("@sysavailable", mydecimal.ToString());
                        cmd.Parameters.AddWithValue("@userid", LoginForm.uId2);
                        // cmd.Parameters.AddWithValue();
                        newRowID = (int) cmd.ExecuteScalar();

                        con.Close();
                        MessageBox.Show("Successfully Deposited, Your Current Transaction Id is:" + newRowID, "Record",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        saveButton.Enabled = false;
                        GetData();
                        Reset();
                       // Condition();
                        FillBank();




                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        

        //public ComboBox TxtBankNameCombo
        //{
        //    get { return txtBankNameCombo; }
        //    set { txtBankNameCombo = value; }
        //}

       

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
            txtBankNameCombo.Focus();
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
                    cmbAccountDNo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChequeDiposit_Load(object sender, EventArgs e)
        {
            submittedBy2 = LoginForm.uId2.ToString();

            //FillCombo();
            GetData();
            
            //con = new SqlConnection(cs.DBConn);
            //con.Open();
            //string selectQuery = "Select * from Temp_Account";

            //SqlDataAdapter myadapter = new SqlDataAdapter(selectQuery, con);
            //DataTable dt = new DataTable();
            //myadapter.Fill(dt);
            //dataGridView1.DataSource = dt; 
            //txtBankNameCombo.Focus();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
           
        }

        private void Reset()
        {
            txtBankNameCombo.SelectedIndexChanged -= txtBankNameCombo_SelectedIndexChanged;
            txtBankNameCombo.SelectedIndex = -1;
            txtBankNameCombo.SelectedIndexChanged += txtBankNameCombo_SelectedIndexChanged;
            cmbAccountDNo.SelectedIndexChanged -= cmbAccountDNo_SelectedIndexChanged;
            cmbAccountDNo.SelectedIndex = -1;
            cmbAccountDNo.SelectedIndexChanged += cmbAccountDNo_SelectedIndexChanged;
            txtTransactionTypeCombo.SelectedIndexChanged -= txtTransactionTypeCombo_SelectedIndexChanged;
            txtTransactionTypeCombo.SelectedIndex = -1;
            txtTransactionTypeCombo.SelectedIndexChanged += txtTransactionTypeCombo_SelectedIndexChanged;
            cmbCreditFromBank.SelectedIndex = -1;
            cmbCreditFromBank.Text = "";
            eftAccountNoTextBox.Text = "";
            particularsTextBox.Text = "";
            checkNoTextBox.Text = "";
            creditTextBox.Text = "";
            transactionDateTimePicker.Text = DateTime.Today.ToString();
            saveButton.Enabled = true;
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            
        }

        private void accountNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            dynamic d = new BankDetailsInfo();
            this.Visible = false;
            d.ShowDialog();
            this.Visible = true;
            //this.Hide();
            //BankDetailsInfo afh=new BankDetailsInfo();
            //afh.Show();
        }


        private void nextStepButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //EditDepositForm fgr=new EditDepositForm();
            //fgr.Show();
            //fgr.GetOtherFormTextBox();
        }

        private void MRTButton_Click(object sender, EventArgs e)
        {
            DataGridForDeposit frm=new DataGridForDeposit();
            frm.Show();
        }

        private void cmbAccountDNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTransactionTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillBank();
            if (txtTransactionTypeCombo.SelectedItem == "Chq(D)")

            {
                // do something
                label2.Visible = true;
                label21.Visible = true;
                cmbCreditFromBank.Visible = true;
                checkNoTextBox.Visible = true;
                eftAccountNoTextBox.Clear();
                eftAccountNoTextBox.Visible = false;
                label3.Visible = false;
                cmbCreditFromBank.SelectedIndex = -1;
               cmbCreditFromBank.Enabled = true;       //Using the TextBox.ReadOnly property
                eftAccountNoTextBox.ReadOnly = true;
                checkNoTextBox.ReadOnly = false;
                label2.Location=new Point(49,237);
                cmbCreditFromBank.Location = new Point(269, 237);
                label21.Location = new Point(68, 279);
                checkNoTextBox.Location = new Point(269, 279);
                label41.Location = new Point(105, 317);
                particularsTextBox.Location = new Point(269, 317);
                label51.Location = new Point(81, 364);
                creditTextBox.Location = new Point(269, 364);
                
            }
            else if (txtTransactionTypeCombo.SelectedItem == "EFT(D)")
            {
                // do something
                label2.Visible = true;
                label21.Visible = false;
                label3.Visible = true;
                cmbCreditFromBank.Visible = true;
                eftAccountNoTextBox.Visible = true;
                checkNoTextBox.Visible = false;
                cmbCreditFromBank.Enabled = true;       //Using the TextBox.ReadOnly property
                eftAccountNoTextBox.ReadOnly = false;
                checkNoTextBox.ReadOnly = true;
                checkNoTextBox.Clear();
                cmbCreditFromBank.SelectedIndex = -1;
                label2.Location = new Point(49, 237);
                cmbCreditFromBank.Location = new Point(269, 237);
                label3.Location = new Point(54, 279);
                eftAccountNoTextBox.Location = new Point(269, 279);
                label41.Location = new Point(105, 317);
                particularsTextBox.Location = new Point(269, 317);
                label51.Location = new Point(81, 364);
                creditTextBox.Location = new Point(269, 364);
                //cmbChequeNo.SelectedIndex = -1;
                //label21.Visible = false;
                //cmbChequeNo.Visible = false;
                //label5.Visible = true;
                //label3.Visible = true;
                //cmbdebitToBank.Visible = true;
                //eftAccountNoWTextBox.Visible = true;
                //cmbChequeNo.Enabled = false;
                //cmbdebitToBank.Enabled = true;
                //eftAccountNoWTextBox.ReadOnly = false;
                //cmbdebitToBank.Location = new Point(225, 201);
                //label5.Location = new Point(54, 201);
                //eftAccountNoWTextBox.Location = new Point(225, 244);
                //label3.Location = new Point(21, 244);
                //benificiaryWTextBox.Location = new Point(225, 291);
                //label2.Location = new Point(73, 291);
                //particularsWTextBox.Location = new Point(225, 344);
                //label41.Location = new Point(72, 344);
                //creditWTextBox.Location = new Point(225, 390);
                //label51.Location = new Point(54, 390);
            }
            else
            {
                label2.Visible = false;
                label21.Visible = false;
                cmbCreditFromBank.Visible = false;
                checkNoTextBox.Visible = false;
                eftAccountNoTextBox.Visible = false;
                label3.Visible = false;
                eftAccountNoTextBox.ReadOnly = true;
                cmbCreditFromBank.Enabled = false; 
                checkNoTextBox.ReadOnly = true;
                checkNoTextBox.Clear();
                cmbCreditFromBank.SelectedIndex = -1;
                eftAccountNoTextBox.Clear();
                label41.Location = new Point(105, 237);
                particularsTextBox.Location = new Point(269, 237);
                label51.Location = new Point(81, 279);
                creditTextBox.Location = new Point(269, 279);
                particularsTextBox.Focus();
            }
            
            //else
            //{
            //    eftAccountNoTextBox.ReadOnly = true;
            //    // cmbCreditFromBank.Enabled = false;
            //    //checkNoTextBox.ReadOnly = true;
            //}
        }

        private void txtBankNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT BankAccounts.AccountNo from BankAccounts WHERE BankAccounts.BankName = '" + txtBankNameCombo.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    // txtAccountNo.Text = rdr.GetInt32(0).ToString().Trim();
                    //txtAccountNo.Text = rdr.GetInt64(0).ToString().Trim();
                    txtBankNameCombo.Text = rdr.GetString(0).Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                txtBankNameCombo.Text = txtBankNameCombo.Text.Trim();
                cmbAccountDNo.Items.Clear();
                cmbAccountDNo.Text = "";
                cmbAccountDNo.Enabled = true;
                cmbAccountDNo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(BankAccounts.AccountNo) from BankAccounts  Where BankAccounts.BankName= '" + txtBankNameCombo.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbAccountDNo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            paramDiscreteValue.Value = newRowID;

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
            DepositInputCrystalReportCheque cr = new DepositInputCrystalReportCheque();
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
            paramDiscreteValue.Value = newRowID;

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
            DepositInputCrystalReportOthers cr = new DepositInputCrystalReportOthers();
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
            paramDiscreteValue.Value = newRowID;

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
            DepositInputCrystalReportEFT cr = new DepositInputCrystalReportEFT();
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
            if (txtTransactionTypeCombo.Text == "Cheque")
            {
                ReportCheque();
            }
            else if (txtTransactionTypeCombo.Text == "EFT")
            {
                ReportEFT();
            }
            else
            {
                ReportOther();
            }
        }

        private void checkNoTextBox_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void FillBank()
        {
            try
            {


               txtBankNameCombo.Items.Clear();
                txtBankNameCombo.Text = "";
                txtBankNameCombo.Enabled = true;
                txtBankNameCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select  distinct RTRIM(BankAccounts.BankName) from BankAccounts";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtBankNameCombo.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void creditTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void creditTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               saveButton_Click_1(this, new EventArgs());
            }
        }
    }
}
