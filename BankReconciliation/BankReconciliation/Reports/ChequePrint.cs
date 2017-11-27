using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BankReconciliation.Reports
{
    public partial class ChequePrint : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        ConnectionString cs = new ConnectionString();
        private SqlDataReader rdr;
        private int x;
        public ChequePrint()
        {
            InitializeComponent();
        }

        private void ChequePrint_Load(object sender, EventArgs e)
        {
            try
            {


                bankNameComboBox.Items.Clear();
                bankNameComboBox.Text = "";
                bankNameComboBox.Enabled = true;
                bankNameComboBox.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ODAccountTransaction.BankName) from ODAccountTransaction Where ODAccountTransaction.Debit IS NOT NULL";
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
                string ct = "select distinct RTRIM(BankAccounts.AccountNo) from BankAccounts  Where BankAccounts.BankName= '" + bankNameComboBox.Text + "' ";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                chequeComboBox.Items.Clear();
                chequeComboBox.Text = "";
                chequeComboBox.Enabled = true;
                chequeComboBox.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ChequeLoad.CheckNo) from ChequeLoad Where ChequeLoad.Status2 IS NULL And ChequeLoad.Status='Written' And ChequeLoad.Bankname='" + bankNameComboBox.Text + "' And ChequeLoad.AccountNo='" + cmbAccountDNo.Text + "'"; 
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
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ODAccountTransaction.OdTransactionId from ODAccountTransaction Where ODAccountTransaction.Debit IS NOT NULL And  ODAccountTransaction.Bankname='" + bankNameComboBox.Text + "'And ODAccountTransaction.CheckNo='" + chequeComboBox.Text + "' And ODAccountTransaction.AccountNo='" + cmbAccountDNo.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr=cmd.ExecuteReader();
                if (rdr.Read())
                {
                    x = (rdr.GetInt32(0));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           condition();
        }

        private void condition()
        {
            if (bankNameComboBox.Text == "Bank Asia Limited")
            {
                Report1();
            }
            else if (bankNameComboBox.Text == "AB Bank Limited")
            {
                Report2();
            }
            else
            { MessageBox.Show( "Cheuqe Can Not Be Printed Contact With IT Department","Printing Facility Not Developed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
            with1.ServerName = "tcp:kyotoServer,49172";
            with1.DatabaseName = "BankReconciliationDBProNovember";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            BankAsiaCheque cr = new BankAsiaCheque();
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
        private void Report2()
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
            with1.ServerName = "tcp:kyotoServer,49172";
            with1.DatabaseName = "BankReconciliationDBProNovember";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            ABBankCheque cr = new ABBankCheque();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb2 = "Update ChequeLoad Set Status2='Printed' Where ChequeLoad.AccountNo='" + cmbAccountDNo.Text + "'And ChequeLoad.CheckNo='" + chequeComboBox.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                  
        }
    }
}
