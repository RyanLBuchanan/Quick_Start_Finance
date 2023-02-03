using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_Start_Finance
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
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

        private void closeXPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void dashboardPanel_Paint(object sender, PaintEventArgs e)
        //{

        //    //logoutPanel.BackColor = Color.SteelBlue; // Active navigation element highlighted
        //    //settingsPanel.BackColor = Color.LightSteelBlue; // Active navigation element highlighted
        //}

        //private void dashboardPanel_MouseClick(object sender, MouseEventArgs e)
        //{

        //}

        //private void incomePanel_MouseClick(object sender, MouseEventArgs e)
        //{

        //}

        //private void expensePanel_MouseClick(object sender, MouseEventArgs e)
        //{

        //}

        //private void viewIncomePanel_MouseClick(object sender, MouseEventArgs e)
        //{

        //}

        //private void viewExpensePanel_MouseClick(object sender, MouseEventArgs e)
        //{

        //}

        //private void settingsPanel_MouseClick(object sender, MouseEventArgs e)
        //{

        //}

        //private void logoutPanel_MouseClick(object sender, MouseEventArgs e)
        //{

        //}
    }
}
