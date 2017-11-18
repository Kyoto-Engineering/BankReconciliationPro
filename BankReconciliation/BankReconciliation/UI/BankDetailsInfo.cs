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
using BankReconciliation.DAO;
using BankReconciliation.Manager;
using BankReconciliation.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BankReconciliation.UI
{
    public partial class BankDetailsInfo : Form
    {
       string intRowId;
         SqlConnection con;
         SqlCommand cmd;
        ConnectionString cs=new ConnectionString();
         SqlDataReader rdr;
        public string bsn;
        public BankDetailsInfo()
        {

            InitializeComponent();
        }
        private void SaveTempAccount()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                // string cb2 = "Update ChequeLoad set Status='" + cmbStatus.Text + "' where AccountNo='" + cmbAccountNo.Text + "' and CheckNo='" + cmbChequeNo.Text + "'";
                string cb2 = "insert into TempAccount(AccountNo,BankName) VALUES ('" + accountNoTextBox.Text + "','" + txtBankNameCombo.Text + "')";
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
        private void createButton_Click(object sender, EventArgs e)
        {
            intRowId = accountNoTextBox.Text;
            if (txtBankNameCombo.Text == "")
            {
                MessageBox.Show("Please Enter Bank name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBankNameCombo.Focus();
                return;
            }
            if (branchNameTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Branch name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                branchNameTextBox.Focus();
                return;
            }
            if (accountNoTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                accountNoTextBox.Focus();
                return;
            }
            int bd = 0;
           BankDetailsManager aManager=new BankDetailsManager();
            try
            {
                BankAccounts aBankDetails=new BankAccounts
                {
                    AccountNumber = accountNoTextBox.Text,
                    BankName=txtBankNameCombo.Text,
                    BankShortName = bankShortNameTextBox.Text,
                    BranchName = branchNameTextBox.Text,
                    TypeOfAccount =  typeOfAccountTextBox.Text,
                    AccountTitle = accountTitleTextBox.Text,
                    Balance = initialBalanceTextBox.Text                                   
                };
                bd = aManager.SaveBankdetails(aBankDetails);
                
               
                MessageBox.Show("An Account Successfully Created", "Message from Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //SaveTempAccount();
                Report();
                Reset();
                
                createButton.Enabled = false;
            }
            catch (FormatException formatException)
            {
                MessageBox.Show("Please Enter Input in Correct Format", formatException.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        public void Reset()
        {
            txtBankNameCombo.SelectedIndex = -1;
            branchNameTextBox.Text = "";
            typeOfAccountTextBox.Text = "";
            accountTitleTextBox.Text = "";
            accountNoTextBox.Text = "";
            initialBalanceTextBox.Text = "";
            bankShortNameTextBox.Clear();
        }
        private void Report()
        {
            //creating an object of ParameterField class
            ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
            ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            paramField.Name = "account no";

            //set the parameter value
            paramDiscreteValue.Value = intRowId;

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
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "BankReconciliationDBProNovember";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            BankDetailsInputCrystalReport cr = new BankDetailsInputCrystalReport();
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

        private void txtBankNameCombo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                bankShortNameTextBox.Focus();
                e.Handled = true;
            }
        }

        private void bankShortNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                branchNameTextBox.Focus();
                e.Handled = true;
            }
        }

        private void branchNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                typeOfAccountTextBox.Focus();
                e.Handled = true;
            }
        }

        private void typeOfAccountTextBox_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                accountTitleTextBox.Focus();
                e.Handled = true;
            }
        }

        private void accountTitleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                accountNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void accountNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                initialBalanceTextBox.Focus();
                e.Handled = true;
            }
        }

        private void initialBalanceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                createButton_Click(this, new EventArgs());
            }
        }

        private void txtBankNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtBankNameCombo.SelectedIndex != -1)
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qry = "select BankShortName from BankList where BankName = '" + txtBankNameCombo.Text + "'";
                    cmd = new SqlCommand(qry, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        bankShortNameTextBox.Text = rdr.GetString(0);
                    }
                    con.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void load_Acc_Type()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qr2 = "select AccountTypeName from AccountType ";
                cmd= new SqlCommand(qr2, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr.GetString(0));
                }
                con.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qr2 = "select AccountTypeName from AccountType where AccountTypeName = '" + comboBox1.Text + "' ";
                    cmd = new SqlCommand(qr2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == true)
                    {
                        typeOfAccountTextBox.Text = rdr.GetString(0);
                        
                        //if (typeOfAccountTextBox.Text == "CD")
                        //{
                        //    DialogResult res = MessageBox.Show("Is it Overdraft Account","Attention",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        //    if (res == DialogResult.Yes)
                        //    {
                        //        groupBox2.Visible = true;
                        //    }
                        //}
                        //else
                        //{
                        //    groupBox2.Visible = false;
                        //}
                    }
                    con.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BankDetailsInfo_Load(object sender, EventArgs e)
        {
            load_Acc_Type();
            groupBox2.Visible = false;
        }
    }
}
