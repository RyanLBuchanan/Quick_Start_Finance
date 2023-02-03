using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quick_Start_Finance
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        // HOME PC database connection
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vreed\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");
        
        // LAPTOP database connection
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ryanl\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Clear()
        {
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            phoneTextBox.Text = "";
            addressTextBox.Text = "";
        }

        private void closeXPictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "" || phoneTextBox.Text == "" || passwordTextBox.Text == "" || addressTextBox.Text == "")
            {
                MessageBox.Show("Missing information");
            } else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO UserTbl(Name, Dob, Phone, Password, Address) VALUES(@N, @D, @P, @PA, @A)", conn);
                    cmd.Parameters.AddWithValue("@N", usernameTextBox.Text);
                    cmd.Parameters.AddWithValue("@D", dateOfBirthDateTimePicker.Value.Date);
                    cmd.Parameters.AddWithValue("@P", phoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@PA", passwordTextBox.Text);
                    cmd.Parameters.AddWithValue("@A", addressTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New user added!");
                    conn.Close();
                    Clear();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
