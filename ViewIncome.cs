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
    public partial class ViewIncome : Form
    {
        public ViewIncome()
        {
            InitializeComponent();
            DisplayIncome();
        }

        // HOME PC database connection
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vreed\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");

        // LAPTOP database connection
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ryanl\Documents\QSFDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayIncome()
        {
            conn.Open();
            string query = "SELECT * FROM IncomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            incomeDataGridView.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void dashboardLabel_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void closeXPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
