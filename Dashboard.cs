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
    public partial class Dashboard : Form
    {
        // HOME PC database connection
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vreed\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");

        // LAPTOP database connection
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ryanl\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");

        public Dashboard()
        {
            InitializeComponent();
            GetTotalIncome();
            GetNumIncomeRecords();
            GetLastIncomeDate();
            GetTotalExpense();
            GetNumExpenseRecords();
            GetLastExpenseDate();
        }

        private void GetTotalIncome()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(Amount) FROM IncomeTbl WHERE Username = '" + Login.User + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            totalIncomeAmountLabel.Text = $"{dt.Rows[0][0]:C}";
            conn.Close();
        }

        private void GetNumIncomeRecords()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM IncomeTbl WHERE Username = '" + Login.User + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            numberIncomeTransactionsLabel.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }

        private void GetLastIncomeDate()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT MAX(Date) FROM IncomeTbl WHERE Username = '" + Login.User + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lastIncomeTransactionDateLabel.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }

        private void GetTotalExpense()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(Amount) FROM ExpenseTbl WHERE Username = '" + Login.User + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            totalExpenseAmountLabel.Text = $"{dt.Rows[0][0]:C}";
            conn.Close();
        }

        private void GetNumExpenseRecords()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM ExpenseTbl WHERE Username = '" + Login.User + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            numberExpenseTransactionsLabel.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }

        private void GetLastExpenseDate()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT MAX(Date) FROM ExpenseTbl WHERE Username = '" + Login.User + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lastExpenseTransactionDateLabel.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }

        private void incomeLabel_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
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
