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
    public partial class Expense : Form
    {
        public Expense()
        {
            InitializeComponent();
        }

        // HOME PC database connection
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vreed\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");

        // LAPTOP database connection
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ryanl\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Clear()
        {
            expenseTitleTextBox.Text = "";
            expenseAmountTextBox.Text = "";
            expenseCategoryComboBox.SelectedIndex = 0;
            expenseDescriptionTextBox.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (expenseTitleTextBox.Text == "" || expenseAmountTextBox.Text == "" || expenseDescriptionTextBox.Text == "" || expenseCategoryComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO ExpenseTbl(Name, Amount, Category, Date, Description, Username) VALUES(@N, @A, @C, @D, @DE, @U)", conn);
                    cmd.Parameters.AddWithValue("@N", expenseTitleTextBox.Text);
                    cmd.Parameters.AddWithValue("@A", expenseAmountTextBox.Text);
                    cmd.Parameters.AddWithValue("@C", expenseCategoryComboBox.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@D", expenseDateTimePicker.Value.Date);
                    cmd.Parameters.AddWithValue("@DE", expenseDescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@U", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New expense record added!");
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

        private void incomeLabel_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
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
