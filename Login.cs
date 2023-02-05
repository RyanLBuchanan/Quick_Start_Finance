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

namespace Quick_Start_Finance
{
    public partial class Login : Form
    {
        //SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = QSFDB");

        // HOME PC database connection
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vreed\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");

        // LAPTOP database connection
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ryanl\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");

        public static string User;

        public Login()
        {
            InitializeComponent();
        }
        
        private void registerLabel_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginUsernameTextBox.Text == "" || loginPasswordTextBox.Text == "")
            {
                MessageBox.Show("Please enter both username and password.");
            } else
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM UserTbl WHERE Name = '" + loginUsernameTextBox.Text + "' AND Password = '" + loginPasswordTextBox.Text + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    User = loginUsernameTextBox.Text;
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.");
                    loginUsernameTextBox.Text = "";
                    loginPasswordTextBox.Text = "";
                }
                conn.Close();
            }
        }

        private void closeXPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheckBox.Checked == true)
            {
                loginPasswordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                loginPasswordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void clearLoginFieldsLabel_Click(object sender, EventArgs e)
        {
            loginUsernameTextBox.Text = "";
            loginPasswordTextBox.Text = "";
        }
    }
}
