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

        private void dashboardPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboardPanel_MouseClick(object sender, MouseEventArgs e)
        {
            dashboardPanel.BackColor = Color.SteelBlue; // Active navigation element highlighted
            logoutPanel.BackColor = Color.LightSteelBlue; // Active navigation element highlighted
        }

        private void incomePanel_MouseClick(object sender, MouseEventArgs e)
        {
            incomePanel.BackColor = Color.SteelBlue; // Active navigation element highlighted
            dashboardPanel.BackColor = Color.LightSteelBlue; // Active navigation element highlighted
        }

        private void expensePanel_MouseClick(object sender, MouseEventArgs e)
        {
            expensePanel.BackColor = Color.SteelBlue; // Active navigation element highlighted
            incomePanel.BackColor = Color.LightSteelBlue; // Active navigation element highlighted
        }

        private void viewIncomePanel_MouseClick(object sender, MouseEventArgs e)
        {
            viewIncomePanel.BackColor = Color.SteelBlue; // Active navigation element highlighted
            expensePanel.BackColor = Color.LightSteelBlue; // Active navigation element highlighted
        }

        private void viewExpensePanel_MouseClick(object sender, MouseEventArgs e)
        {
            viewExpensePanel.BackColor = Color.SteelBlue; // Active navigation element highlighted
            viewIncomePanel.BackColor = Color.LightSteelBlue; // Active navigation element highlighted
        }

        private void settingsPanel_MouseClick(object sender, MouseEventArgs e)
        {
            settingsPanel.BackColor = Color.SteelBlue; // Active navigation element highlighted
            viewExpensePanel.BackColor = Color.LightSteelBlue; // Active navigation element highlighted
        }

        private void logoutPanel_MouseClick(object sender, MouseEventArgs e)
        {
            logoutPanel.BackColor = Color.SteelBlue; // Active navigation element highlighted
            settingsPanel.BackColor = Color.LightSteelBlue; // Active navigation element highlighted
        }
    }
}
