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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BankReconciliation.Reports
{
    public partial class BankStatements : Form
    {

        private SqlConnection con;
        private SqlCommand cmd;
        ConnectionString cs = new ConnectionString();
        private SqlDataReader rdr;
        public string fullName2;
        private int x, submittedBy2;
        public BankStatements()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankstatementUI x=new BankstatementUI();
            this.Visible = false;
            x.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
            AllPaymentStatementCrystalReport cr = new AllPaymentStatementCrystalReport();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            AllDepositStatementCrystalReport cr = new AllDepositStatementCrystalReport();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {

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
            SummaryOfBalanceCrystalReport cr = new SummaryOfBalanceCrystalReport();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

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
            BenificiaryPaymentStatementCrystalReport cr = new BenificiaryPaymentStatementCrystalReport();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

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
            ParticularsPaymentStatementCrystalReport cr = new ParticularsPaymentStatementCrystalReport();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BankstatementUI x = new BankstatementUI();
            this.Visible = false;
            x.ShowDialog();
            this.Visible = true;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ParameterField paramField1 = new ParameterField();


            //creating an object of ParameterFields class
            ParameterFields paramFields1 = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();

            //set the parameter field name
            paramField1.Name = "id";

            //set the parameter value
            paramDiscreteValue1.Value = x;

            //add the parameter value in the ParameterField object
            paramField1.CurrentValues.Add(paramDiscreteValue1);

            //add the parameter in the ParameterFields object
            paramFields1.Add(paramField1);
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
            SummaryOfBalanceCrystalReport cr = new SummaryOfBalanceCrystalReport();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ParameterFieldInfo = paramFields1;
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
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
            AllDepositStatementCrystalReport cr = new AllDepositStatementCrystalReport();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Benificiary f2 = new Benificiary();
            //TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            //TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            //ConnectionInfo reportConInfo = new ConnectionInfo();
            //Tables tables = default(Tables);
            ////	Table table = default(Table);
            //var with1 = reportConInfo;
            //with1.ServerName = "tcp:KyotoServer,49172";
            //with1.DatabaseName = "BankReconciliationDBProNovember";
            //with1.UserID = "sa";
            //with1.Password = "SystemAdministrator";
            //BenificiaryPaymentStatementCrystalReport cr = new BenificiaryPaymentStatementCrystalReport();
            //tables = cr.Database.Tables;
            //foreach (Table table in tables)
            //{
            //    reportLogonInfo = table.LogOnInfo;
            //    reportLogonInfo.ConnectionInfo = reportConInfo;
            //    table.ApplyLogOnInfo(reportLogonInfo);
            //}
            //f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Particulers f2 = new Particulers();
            //TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            //TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            //ConnectionInfo reportConInfo = new ConnectionInfo();
            //Tables tables = default(Tables);
            ////	Table table = default(Table);
            //var with1 = reportConInfo;
            //with1.ServerName = "tcp:KyotoServer,49172";
            //with1.DatabaseName = "BankReconciliationDBProNovember";
            //with1.UserID = "sa";
            //with1.Password = "SystemAdministrator";
            //ParticularsPaymentStatementCrystalReport cr = new ParticularsPaymentStatementCrystalReport();
            //tables = cr.Database.Tables;
            //foreach (Table table in tables)
            //{
            //    reportLogonInfo = table.LogOnInfo;
            //    reportLogonInfo.ConnectionInfo = reportConInfo;
            //    table.ApplyLogOnInfo(reportLogonInfo);
            //}
            //f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
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
            AllPaymentStatementCrystalReport cr = new AllPaymentStatementCrystalReport();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void BankStatements_Load(object sender, EventArgs e)
        {
            submittedBy2 = LoginForm.uId2;
            //con = new SqlConnection(cs.DBConn);
            //con.Open();
            //string ctk2 = "Select Name from Registration where UserId='" + submittedBy2 + "'";
            //cmd = new SqlCommand(ctk2);
            //cmd.Connection = con;
            //rdr = cmd.ExecuteReader();
            //if (rdr.Read())
            //{
            //    fullName2 = (rdr.GetString(0));
            //}
            x = submittedBy2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ParameterField paramField1 = new ParameterField();


            //creating an object of ParameterFields class
            ParameterFields paramFields1 = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();

            //set the parameter field name
            paramField1.Name = "id";

            //set the parameter value
            paramDiscreteValue1.Value = x;

            //add the parameter value in the ParameterField object
            paramField1.CurrentValues.Add(paramDiscreteValue1);

            //add the parameter in the ParameterFields object
            paramFields1.Add(paramField1);
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
           NewSummrybalance cr = new NewSummrybalance();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ParameterFieldInfo = paramFields1;
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
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
            AllTransactionCrystalReport cr = new AllTransactionCrystalReport();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }
    }
}
