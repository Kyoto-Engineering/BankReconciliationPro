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

namespace BankReconciliation.UI
{
    public partial class DataGridForWithdraw : Form
    {
        ConnectionString cs=new ConnectionString();
        private SqlConnection con;
        public DataGridForWithdraw()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                // string selectQuery = "Select AccountNo,Balances from Temp_Account2";
                string selectQuery = "Select TransactionType,Benificiary,Particulars,CheckNo,BankName, AccountNo,Credit,SystemCurrentBalance, SystemAvailableBalance ,SystemTxnDate, BankCurrentBalance, BankAvailableBalance,BankTxnDate from ODAccountTransaction order by OdTransactionId desc";

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
        private void DataGridForWithdraw_Load(object sender, EventArgs e)
        {
            GetData();

        }
    }
}
