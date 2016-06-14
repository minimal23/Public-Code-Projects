using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuChi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InputDataButton_Click(object sender, EventArgs e)
        {
            new InputData().Show();
            this.Hide();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work in progress", "Attention",MessageBoxButtons.OK);
        }

        private void PlanButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work in progress", "Attention", MessageBoxButtons.OK);
        }
    }
}
