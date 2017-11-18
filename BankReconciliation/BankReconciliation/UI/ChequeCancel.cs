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
using BankReconciliation.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BankReconciliation.UI
{
    public partial class ChequeCancel : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        ConnectionString cs = new ConnectionString();
        private SqlDataReader rdr;
        public string submittedBy2, fullName2;
        private int x;

        public ChequeCancel()
        {
            InitializeComponent();
        }

        private void ChequeCancel_Load(object sender, EventArgs e)
        {
            FillBank();


        }

        private void bankNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);


                bankNameComboBox.Text = bankNameComboBox.Text.Trim();
                cmbAccountDNo.Items.Clear();
                cmbAccountDNo.Text = "";
                cmbAccountDNo.Enabled = true;
                cmbAccountDNo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct =
                    "select distinct RTRIM(BankAccounts.AccountNo) from BankAccounts  Where BankAccounts.BankName= '" +
                    bankNameComboBox.Text + "' ";
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

        private void cmbAccountDNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                chequeComboBox.Items.Clear();
                chequeComboBox.Text = "";
                chequeComboBox.Enabled = true;
                chequeComboBox.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct =
                    "select distinct RTRIM(ChequeLoad.CheckNo) from ChequeLoad Where ChequeLoad.Status='Written' And ChequeLoad.Status2='Printed'  And ChequeLoad.Bankname='" +
                    bankNameComboBox.Text + "' And ChequeLoad.AccountNo='" + cmbAccountDNo.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    chequeComboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult =
                MessageBox.Show(
                    "Are you Surely want To reverse this " + chequeComboBox.Text + " From account no" + cmbAccountDNo.Text + " of " + bankNameComboBox.Text, "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                try
                {
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
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "Update ChequeLoad Set ChequeLoad.Status3='Canceled' ,ChequeLoad.ChangedBy='" + fullName2 + "', ChequeLoad.Cause='" + causeTextBox.Text + "' Where ChequeLoad.AccountNo='" + cmbAccountDNo.Text + "'And ChequeLoad.CheckNo='" + chequeComboBox.Text + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteReader();

                    
                    MessageBox.Show("Successfully Canceled " + chequeComboBox.Text + " From account no" + cmbAccountDNo.Text + " of " + bankNameComboBox.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select Transactions.Id from Transactions Where Transactions.Debit IS NOT NULL And  Transactions.Bankname='" + bankNameComboBox.Text + "'And Transactions.CheckNo='" + chequeComboBox.Text + "' And Transactions.AccountNo='" + cmbAccountDNo.Text + "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        x = (rdr.GetInt32(0));
                    }


                    con.Close();
                    Clear();
                    Report1();
                    FillBank();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                Clear();
                FillBank();
            }
        }
        private void Clear()
        {
            chequeComboBox.Items.Clear();
            chequeComboBox.Text = "";
            cmbAccountDNo.Items.Clear();
            cmbAccountDNo.Text = "";
            bankNameComboBox.Items.Clear();
            bankNameComboBox.Text = "";
            causeTextBox.Clear();
        }

        private void FillBank()
        {
            try
            {


                bankNameComboBox.Items.Clear();
                bankNameComboBox.Text = "";
                bankNameComboBox.Enabled = true;
                bankNameComboBox.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select  distinct RTRIM(BankAccounts.BankName) from BankAccounts";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bankNameComboBox.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Report1()
        {
            //creating an object of ParameterField class
            ParameterField paramField1 = new ParameterField();
            // ParameterField paramField2 = new ParameterField();

            //creating an object of ParameterFields class
            ParameterFields paramFields1 = new ParameterFields();
            // ParameterFields paramFields2 = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
            //ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();

            //set the parameter field name
            paramField1.Name = "id";
            // paramField2.Name = "cheque no";

            //set the parameter value
            paramDiscreteValue1.Value = x;
            //paramDiscreteValue2.Value = cmbAccountDNo.Text;



            //add the parameter value in the ParameterField object
            paramField1.CurrentValues.Add(paramDiscreteValue1);
            //paramField2.CurrentValues.Add(paramDiscreteValue2);
            //add the parameter in the ParameterFields object
            paramFields1.Add(paramField1);
            // paramFields2.Add(paramField2);
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
            Reports.ChequeCancel cr = new Reports.ChequeCancel();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ParameterFieldInfo = paramFields1;
            //   f2.crystalReportViewer1.ParameterFieldInfo = paramFields2; //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }
    }
}
