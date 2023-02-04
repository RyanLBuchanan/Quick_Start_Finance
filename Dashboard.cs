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

        private int Income, Expense;

        public Dashboard()
        {
            InitializeComponent();
            
            // Income statistics
            GetTotalIncome();
            GetNumIncomeRecords();
            GetLastIncomeDate();
            GetMaxIncome();
            GetMinIncome();
            GetMostIncomeCategory();

            // Expense statistics
            GetTotalExpense();
            GetNumExpenseRecords();
            GetLastExpenseDate();
            GetMaxExpense();
            GetMinExpense();
            GetMostExpenseCategory();

            // Get Current Balance
            GetBalance();
        }

        private void GetTotalIncome()
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(Amount) FROM IncomeTbl WHERE Username = '" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Income = Convert.ToInt32(dt.Rows[0][0]);
                totalIncomeAmountLabel.Text = $"{dt.Rows[0][0]:C}";
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetNumIncomeRecords()
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM IncomeTbl WHERE Username = '" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                numberIncomeTransactionsLabel.Text = dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetLastIncomeDate()
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT MAX(Date) FROM IncomeTbl WHERE Username = '" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                lastIncomeTransactionDateLabel.Text = dt.Rows[0][0].ToString();
                mostRecentIncomeAmountLabel.Text = dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetMaxIncome()
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT MAX(Amount) FROM IncomeTbl WHERE Username = '" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                maxIncomeAmountLabel.Text = $"{dt.Rows[0][0]:C}";
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetMinIncome()
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Min(Amount) FROM IncomeTbl WHERE Username = '" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                minIncomeAmountLabel.Text = $"{dt.Rows[0][0]:C}";
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetMostIncomeCategory()
        {
            try
            {
                conn.Open();
                string innerQuery = "SELECT MAX(Amount) FROM IncomeTbl WHERE Username = '" + Login.User + "'";
                SqlDataAdapter sda = new SqlDataAdapter(innerQuery, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                string innerQuery1 = "SELECT Category FROM IncomeTbl WHERE Amount = '" + dt.Rows[0][0] + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(innerQuery1, conn);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                mostIncomeCategoryLabel.Text = $"{dt1.Rows[0][0]:C}";
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetTotalExpense()
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(Amount) FROM ExpenseTbl WHERE Username = '" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Expense = Convert.ToInt32(dt.Rows[0][0]);
                totalExpenseAmountLabel.Text = $"{dt.Rows[0][0]:C}";
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetNumExpenseRecords()
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM ExpenseTbl WHERE Username = '" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                numberExpenseTransactionsLabel.Text = dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetLastExpenseDate()
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT MAX(Date) FROM ExpenseTbl WHERE Username = '" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                lastExpenseTransactionDateLabel.Text = dt.Rows[0][0].ToString();
                mostRecentExpenseAmountLabel.Text = dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetMaxExpense()
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT MAX(Amount) FROM ExpenseTbl WHERE Username = '" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                maxExpenseAmountLabel.Text = $"{dt.Rows[0][0]:C}";
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetMinExpense()
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Min(Amount) FROM ExpenseTbl WHERE Username = '" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                minExpenseAmountLabel.Text = $"{dt.Rows[0][0]:C}";
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetMostExpenseCategory()
        {
            try
            {
                conn.Open();
                string innerQuery = "SELECT MAX(Amount) FROM ExpenseTbl WHERE Username = '" + Login.User + "'";
                SqlDataAdapter sda = new SqlDataAdapter(innerQuery, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                string innerQuery1 = "SELECT Category FROM ExpenseTbl WHERE Amount = '" + dt.Rows[0][0] + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(innerQuery1, conn);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                mostExpenseCategoryLabel.Text = $"{dt1.Rows[0][0]:C}";
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
        }

        private void GetBalance()
        {
            try
            {
                double Balance = Income - Expense;
                balanceLabel.Text = Balance.ToString("C2");
            }
            catch (Exception ex)
            {
                
            }
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
