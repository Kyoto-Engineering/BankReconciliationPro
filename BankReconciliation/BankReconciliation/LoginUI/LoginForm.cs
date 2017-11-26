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
using System.Windows.Forms.VisualStyles;
using BankReconciliation.UI;

namespace BankReconciliation.LoginUI
{
    public partial class LoginForm : Form
    {
         SqlConnection con;
         SqlCommand cmd;
         SqlDataReader rdr;
        ProgressBar ProgressBar1=new ProgressBar();
        ConnectionString cs=new ConnectionString();
        public static int uId2;
        public static int ulogid;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {




        }

        private void insertUserlog()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insqry = "INSERT INTO UserLogTable (UserId, LoginDatetime) VALUES (@d1, @d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insqry, con);
                cmd.Parameters.AddWithValue("@d1", uId2);
                cmd.Parameters.AddWithValue("@d2", DateTime.UtcNow.ToLocalTime());


                ulogid = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            


        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (txt2UserName.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt2UserName.Focus();
                return;
            }
            if (txt2Password.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt2Password.Focus();
                return;
            }
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(cs.DBConn);

                SqlCommand myCommand = default(SqlCommand);

                myCommand = new SqlCommand("SELECT Username,passwords FROM Registration WHERE Username = @username AND Passwords = @UserPassword", myConnection);
                SqlParameter uName = new SqlParameter("@username", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@UserPassword", SqlDbType.VarChar);
                uName.Value = txt2UserName.Text;
                uPassword.Value = txt2Password.Text;
                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);

                myCommand.Connection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    int i;
                    ProgressBar1.Visible = true;
                    ProgressBar1.Maximum = 5000;
                    ProgressBar1.Minimum = 0;
                    ProgressBar1.Value = 4;
                    ProgressBar1.Step = 1;

                    for (i = 0; i <= 5000; i++)
                    {
                        ProgressBar1.PerformStep();
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select usertype,UserId from Registration where Username='" + txt2UserName.Text + "'and Passwords='" + txt2Password.Text + "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        txtUserType.Text = (rdr.GetString(0));
                        uId2 = (rdr.GetInt32(1));

                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }

                    if (txtUserType.Text.Trim() == "Admin")
                    {
                        insertUserlog();
                        MainUI frm = new MainUI();
                        this.Visible = false;
                        frm.ShowDialog();
                        
                        this.Visible = true;
                        frm.lblUserk.Text = txt2UserName.Text;
                        
                    }
                    if (txtUserType.Text.Trim() == "User")
                    {
                        insertUserlog();
                       MasterPagesForUser frm=new MasterPagesForUser();
                       this.Visible = false;
                       frm.ShowDialog();
                        //insertUserlog();
                       this.Visible = true;
                        //insertUserlog();
                    }
                    
                }


                else
                {
                    MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txt2UserName.Clear();
                    txt2Password.Clear();
                    txt2UserName.Focus();

                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registeredButton_Click(object sender, EventArgs e)
        {
            //dynamic d = new Registration();
            //this.Visible = false;
            //d.ShowDialog();
            //this.Visible = true;
           
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword cp = new ChangePassword();
            cp.Show();
        }

        private void txt2Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt2Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(this, new EventArgs());
            }
        }

        private void txt2UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt2Password.Focus();
                e.Handled = true;
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt2Password.Focus();
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
