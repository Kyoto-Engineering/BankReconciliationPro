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
    public partial class AccountWiseTransaction : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        ConnectionString cs = new ConnectionString();
        private SqlDataReader rdr;

        public AccountWiseTransaction()
        {
            InitializeComponent();
        }

        private void bankSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT BankAccounts.BankName from BankAccounts WHERE BankAccounts.BankName = '" + bankSelectionComboBox.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    // txtAccountNo.Text = rdr.GetInt32(0).ToString().Trim();
                    //txtAccountNo.Text = rdr.GetInt64(0).ToString().Trim();
                    bankSelectionComboBox.Text = rdr.GetString(0).Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                bankSelectionComboBox.Text = bankSelectionComboBox.Text.Trim();
                accountNoComboBox.Items.Clear();
                accountNoComboBox.Text = "";
                accountNoComboBox.Enabled = true;
                accountNoComboBox.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(BankAccounts.AccountNo) from BankAccounts  Where BankAccounts.BankName= '" + bankSelectionComboBox.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    accountNoComboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            //creating an object of ParameterField class
            ParameterField paramField = new ParameterField();
            ParameterField paramField1 = new ParameterField();

            //creating an object of ParameterFields class
            ParameterFields paramFields = new ParameterFields();
            ParameterFields paramFields1 = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();

            //set the parameter field name
            paramField.Name = "AccountNum";
            paramField1.Name = "BankName";
            //set the parameter value
            paramDiscreteValue.Value = accountNoComboBox.Text;
            paramDiscreteValue1.Value = bankSelectionComboBox.Text;
            //add the parameter value in the ParameterField object
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramField1.CurrentValues.Add(paramDiscreteValue1);
           
            //add the parameter in the ParameterFields object
            paramFields.Add(paramField);
            paramFields1.Add(paramField1);
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
            Step1BankReconciliation cr = new Step1BankReconciliation();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            f2.crystalReportViewer1.ParameterFieldInfo = paramFields1;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }



    }
}
