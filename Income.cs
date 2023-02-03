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
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
        }

        // HOME PC database connection
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vreed\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");

        // LAPTOP database connection
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ryanl\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Clear()
        {
            incomeTitleTextBox.Text = "";
            incomeAmountTextBox.Text = "";
            incomeCategoryComboBox.SelectedIndex = 0;
            incomeDescriptionTextBox.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (incomeTitleTextBox.Text == "" || incomeAmountTextBox.Text == "" || incomeDescriptionTextBox.Text == "" || incomeCategoryComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO IncomeTbl(Name, Amount, Category, Date, Description, Username) VALUES(@N, @A, @C, @D, @DE, @U)", conn);
                    cmd.Parameters.AddWithValue("@N", incomeTitleTextBox.Text);
                    cmd.Parameters.AddWithValue("@A", incomeAmountTextBox.Text);
                    cmd.Parameters.AddWithValue("@C", incomeCategoryComboBox.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@D", incomeDateTimePicker.Value.Date);
                    cmd.Parameters.AddWithValue("@DE", incomeDescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@U", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New income record added!");
                    conn.Close();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void closeXPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardLabel_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void expenseLabel_Click(object sender, EventArgs e)
        {
            Expense expense = new Expense();
            expense.Show();
            this.Hide();
        }

        private void viewIncomeLabel_Click(object sender, EventArgs e)
        {
            ViewIncome viewIncome = new ViewIncome();
            viewIncome.Show();
            this.Hide();
        }

        private void viewExpenseLabel_Click(object sender, EventArgs e)
        {
            ViewExpense viewExpense = new ViewExpense();
            viewExpense.Show();
            this.Hide();
        }

        private void logoutLabel_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void exitLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
