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
    public partial class Step1Reconciliation : Form
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private SqlDataAdapter sda;

        public int txnid;
        public string currbalnc;
        public string availblbalnc;

        public string ReturnValue1 { get; set; }
        public string ReturnValue2 { get; set; }
        public Step1Reconciliation()
        {
            InitializeComponent();
        }


        void LoadData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd =
                    new SqlCommand(
                        "SELECT ODAccountTransaction.OdTransactionId,ODAccountTransaction.SystemTxnDate,ODAccountTransaction.BankTxnDate,Generate.CodeName,ODAccountTransaction.AccountNo,ODAccountTransaction.CheckNo,ODAccountTransaction.Credit,ODAccountTransaction.Debit,ODAccountTransaction.TransactionType,ODAccountTransaction.Particulars,ODAccountTransaction.Benificiary, ODAccountTransaction.SystemCurrentBalance, ODAccountTransaction.SystemAvailableBalance   from ODAccountTransaction left outer join Generate ON ODAccountTransaction.AccountNo = Generate.AccountNo  ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9],
                        rdr[10],rdr[11], rdr[12]);
                }
              
                con.Close();

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                txnid = Convert.ToInt32(dr.Cells[0].Value.ToString());
                
                SystemTxnDatetextBox.Text = dr.Cells[3].Value.ToString();
                textBox1.Text = txnid.ToString();
               // textBox2.Text = dr.Cells[4].Value.ToString();
                textBox2.Text = dr.Cells[4].Value.ToString();
                textBox4.Text = dr.Cells[5].Value.ToString();
                textBox9.Text = dr.Cells[7].Value.ToString();
                textBox3.Text = dr.Cells[6].Value.ToString();
                textBox5.Text = dr.Cells[10].Value.ToString();
                textBox6.Text = dr.Cells[9].Value.ToString();

                currbalnc = dr.Cells[11].Value.ToString();
                availblbalnc = dr.Cells[12].Value.ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    cmd = new SqlCommand();
            //    cmd.Connection = con;
            //    //cmd.CommandText = "SELECT FirstSet.CompanyId, FirstSet.CompanyName, FirstSet.Branch ,FirstSet.CompanyTypeName, FirstSet.IndustryCategory, FirstSet.CompanyNature, FirstSet.Email, FirstSet.ContactNo, FirstSet.IdentificationNo, FirstSet.WebSiteUrl, FirstSet.CFlatNo, FirstSet.CHouseNo, FirstSet.CRoadNo, FirstSet.CBlock, FirstSet.CArea, FirstSet.CLandmark, FirstSet.CContactNo, FirstSet.BuildingName, FirstSet.RoadName, FirstSet.Division,FirstSet.District, FirstSet.Thana,FirstSet.PostOfficeName,FirstSet.PostCode, QUERYTWO.TFlatNo, QUERYTWO.THouseNo, QUERYTWO.TRoadNo, QUERYTWO.TBlock, QUERYTWO.TArea, QUERYTWO.TLandmark, QUERYTWO.TContactNo, QUERYTWO.BuildingName, QUERYTWO.RoadName,QUERYTWO.Division,QUERYTWO.District, QUERYTWO.Thana,QUERYTWO.PostOfficeName,QUERYTWO.PostCode,FirstSet.CPicture from(SELECT Company.CompanyId, Company.CompanyName, CompanyType.CompanyTypeName, IndustryCategorys.IndustryCategory, NatureOfCompanies.CompanyNature, Company.Email, Company.ContactNo, Company.IdentificationNo, Company.WebSiteUrl,Company.CPicture,CorporateAddresses.Branch, CorporateAddresses.CFlatNo, CorporateAddresses.CHouseNo, CorporateAddresses.CRoadNo, CorporateAddresses.CBlock, CorporateAddresses.CArea, CorporateAddresses.CLandmark, CorporateAddresses.CContactNo, CorporateAddresses.BuildingName, CorporateAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana,PostOffice.PostOfficeName,PostOffice.PostCode  FROM  Company LEFT JOIN CompanyType ON Company.CompanyTypeId = CompanyType.CompanyTypeId LEFT JOIN IndustryCategorys ON Company.IndustryCategoryId = IndustryCategorys.IndustryCategoryId LEFT JOIN NatureOfCompanies ON Company.NatureOfCompanyId = NatureOfCompanies.NatureOfCompanyId LEFT JOIN CorporateAddresses ON Company.CompanyId = CorporateAddresses.CompanyId LEFT JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId LEFT JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID LEFT JOIN Districts ON Thanas.D_ID = Districts.D_ID LEFT JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS FirstSet lEFT jOIN (SELECT Company.CompanyId,TraddingAddresses.TFlatNo, TraddingAddresses.THouseNo, TraddingAddresses.TRoadNo, TraddingAddresses.TBlock, TraddingAddresses.TArea, TraddingAddresses.TLandmark, TraddingAddresses.TContactNo, TraddingAddresses.BuildingName, TraddingAddresses.RoadName,Divisions.Division,Districts.District,Thanas.Thana, PostOffice.PostOfficeName,PostOffice.PostCode FROM  Company LEFT JOIN TraddingAddresses ON Company.CompanyId = TraddingAddresses.CompanyId LEFT JOIN PostOffice ON TraddingAddresses.PostOfficeId = PostOffice.PostOfficeId LEFT JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID LEFT JOIN Districts ON Thanas.D_ID = Districts.D_ID LEFT JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID) AS QUERYTWO ON FirstSet.CompanyId =  QUERYTWO.CompanyId  order by FirstSet.CompanyName asc";
            //    cmd.CommandText =
            //        "SELECT ODAccountTransaction.OdTransactionId,ODAccountTransaction.SystemTxnDate,ODAccountTransaction.BankTxnDate,Generate.CodeName,ODAccountTransaction.AccountNo,ODAccountTransaction.CheckNo,ODAccountTransaction.Credit,ODAccountTransaction.Debit,ODAccountTransaction.TransactionType,ODAccountTransaction.Particulars,ODAccountTransaction.Benificiary FROM ODAccountTransaction left join Generate ON  ODAccountTransaction.Acid=Generate.Acid";

            //    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //    dataGridView1.Rows.Clear();
            //    while (rdr.Read() == true)
            //    {
            //        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11]);
            //    }

            //    dataGridView1.Columns[38].Width = 120;
            //    dataGridView1.Columns[38].DefaultCellStyle.NullValue = null;
            //    for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //        if (dataGridView1.Columns[i] is DataGridViewImageColumn)
            //        {
            //            ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;

            //        }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void Step1Reconciliation_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void searchByIDTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd =
                    new SqlCommand(
                        "SELECT ODAccountTransaction.OdTransactionId,ODAccountTransaction.SystemTxnDate,ODAccountTransaction.BankTxnDate,Generate.CodeName,ODAccountTransaction.AccountNo,ODAccountTransaction.CheckNo,ODAccountTransaction.Credit,ODAccountTransaction.Debit,ODAccountTransaction.TransactionType,ODAccountTransaction.Particulars,ODAccountTransaction.Benificiary from ODAccountTransaction left outer join Generate ON ODAccountTransaction.AccountNo = Generate.AccountNo where ODAccountTransaction.OdTransactionId= '" + searchByIDTextBox.Text + "' ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(q, con);
                //DataTable dataTable1 = new DataTable();
                //dataAdapter.Fill(dataTable1);
                dataGridView1.Rows.Clear();
                //dataGridView1.ColumnHeadersVisible = false;
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9],
                        rdr[10]);
                }

                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchByCreditBalanceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd =
                    new SqlCommand(
                        "SELECT ODAccountTransaction.OdTransactionId,ODAccountTransaction.SystemTxnDate,ODAccountTransaction.BankTxnDate,Generate.CodeName,ODAccountTransaction.AccountNo,ODAccountTransaction.CheckNo,ODAccountTransaction.Credit,ODAccountTransaction.Debit,ODAccountTransaction.TransactionType,ODAccountTransaction.Particulars,ODAccountTransaction.Benificiary from ODAccountTransaction left outer join Generate ON ODAccountTransaction.AccountNo = Generate.AccountNo where ODAccountTransaction.Credit='" + searchByCreditBalanceTextBox.Text + "'  ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(q, con);
                //DataTable dataTable1 = new DataTable();
                //dataAdapter.Fill(dataTable1);
                dataGridView1.Rows.Clear();
                //dataGridView1.ColumnHeadersVisible = false;
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9],
                        rdr[10]);
                }

                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd =
                    new SqlCommand(
                        "SELECT ODAccountTransaction.OdTransactionId,ODAccountTransaction.SystemTxnDate,ODAccountTransaction.BankTxnDate,ODAccountTransaction.FundRNo,ODAccountTransaction.AccountNo,ODAccountTransaction.CheckNo,ODAccountTransaction.Credit,ODAccountTransaction.Debit,ODAccountTransaction.TransactionType,ODAccountTransaction.Particulars,ODAccountTransaction.SystemTxnDate from ODAccountTransaction where ODAccountTransaction.Debit ='" + textBox7.Text + "' ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(q, con);
                //DataTable dataTable1 = new DataTable();
                //dataAdapter.Fill(dataTable1);
                dataGridView1.Rows.Clear();
                //dataGridView1.ColumnHeadersVisible = false;
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9],
                        rdr[10]);
                }

                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd =
                    new SqlCommand(
                        "SELECT ODAccountTransaction.OdTransactionId,ODAccountTransaction.SystemTxnDate,ODAccountTransaction.BankTxnDate,ODAccountTransaction.FundRNo,ODAccountTransaction.AccountNo,ODAccountTransaction.CheckNo,ODAccountTransaction.Credit,ODAccountTransaction.Debit,ODAccountTransaction.TransactionType,ODAccountTransaction.Particulars,ODAccountTransaction.Benificiary from ODAccountTransaction where ODAccountTransaction.Benificiary='" + textBox8.Text + "' ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(q, con);
                //DataTable dataTable1 = new DataTable();
                //dataAdapter.Fill(dataTable1);
                dataGridView1.Rows.Clear();
                //dataGridView1.ColumnHeadersVisible = false;
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9],
                        rdr[10]);
                }

                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void clear()
        {
            SystemTxnDatetextBox.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox9.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dataGridView1.Rows.Clear();
            LoadData();




        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qq3 = "update ODAccountTransaction set ODAccountTransaction.BankTxnDate= @bdtn , ODAccountTransaction.BankCurrentBalance = @bcb, ODAccountTransaction.BankAvailableBalance = @bab where ODAccountTransaction.OdTransactionId = '" + txnid + "' ";
                cmd = new SqlCommand(qq3, con);
                cmd.Parameters.AddWithValue("@bdtn", BankdateTimePicker.Value.ToLocalTime());
                cmd.Parameters.AddWithValue("@bcb", currbalnc);
                cmd.Parameters.AddWithValue("@bab", availblbalnc);
                cmd.ExecuteScalar();
                con.Close();

                con.Open();
                string qq4 = "insert into BankTxnTable (OdTransactionId,Bankname,AccountNo,BankTxnDate ) values(@d1, @d2, @d3, @d4)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(qq4, con);
                cmd.Parameters.AddWithValue("@d1", txnid);
                cmd.Parameters.AddWithValue("@d2", SystemTxnDatetextBox.Text);
                cmd.Parameters.AddWithValue("@d3", textBox2.Text);
                cmd.Parameters.AddWithValue("@d4", BankdateTimePicker.Value.ToLocalTime());
                cmd.ExecuteScalar();
                con.Close();

                MessageBox.Show("Update Successfully", "successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private void searchByIDTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchByCreditBalanceTextBox.Focus();
                e.Handled = true;
            }
        }

        private void searchByCreditBalanceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
                 if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
                e.Handled = true;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            
                       if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();
                e.Handled = true;
            }
        }

        private void SystemTxnDatetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.Handled = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
                e.Handled = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
                e.Handled = true;
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
                e.Handled = true;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            
                  if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
                e.Handled = true;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BankdateTimePicker.Focus();
                e.Handled = true;
            }
        }

        private void BankdateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Enter)
            {
                button10.Focus();
                e.Handled = true;
            }
        }

        private void button10_KeyDown(object sender, KeyEventArgs e)
        {
            textBox7_TextChanged(this, new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                //AccountWiseTransaction f2 = new AccountWiseTransaction();
                //this.Visible = false;
                //f2.ShowDialog();
                //this.Visible = true;
                //Step1BankReconciliationAllTran f2 = new Step1BankReconciliationAllTran();
                //this.Visible = false;
                //f2.ShowDialog();
                //this.Visible = true;
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
                //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
                //set the parameterfield information in the crystal report
                f2.crystalReportViewer1.ReportSource = cr;
                this.Visible = false;
                f2.ShowDialog();
                this.Visible = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //{
            //    DateWiseTransaction f2 = new DateWiseTransaction();
            //    this.Visible = false;
            //    f2.ShowDialog();
            //    this.Visible = true;
            //}

            //AccountWiseTransaction f2 = new AccountWiseTransaction();
            //this.Visible = false;
            //f2.ShowDialog();
            //this.Visible = true;
            //Step1BankReconciliationAllTran f2 = new Step1BankReconciliationAllTran();
            //this.Visible = false;
            //f2.ShowDialog();
            //this.Visible = true;
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
            Step1ReconciliationBank1Account1DateRange cr = new Step1ReconciliationBank1Account1DateRange();
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

        private void PendingBankTransactionbutton_Click(object sender, EventArgs e)
        {
            //{
            //    PendingBankTxn f2 = new PendingBankTxn();
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
            PendingTypeStep1ReconciliationAll cr = new PendingTypeStep1ReconciliationAll();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Step1BankReconciliationAllTran f2 = new Step1BankReconciliationAllTran();
            //this.Visible = false;
            //f2.ShowDialog();
            //this.Visible = true;
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
            Step1BankReconciliationAllTran cr = new Step1BankReconciliationAllTran();
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
    }
}
