using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace QuanLyThuChi
{
    public partial class LoginForm : Form
    {
        
        public static string userID;  
        public static string userPW;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (this.username.Text == userID && this.password.Text == userPW)
            {
                MessageBox.Show("Logged in successfully", "Login Successful");
                new MainForm().Show();
                this.Hide();
            }
            else MessageBox.Show("Wrong Username or Password", "Login Failed");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult Warning;
            Warning = (MessageBox.Show("Are you sure ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (Warning == DialogResult.Yes)
                Application.Exit();
        }

        private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterForm().Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (File.Exists("account.txt"))
            {
                userID = File.ReadLines("account.txt").Skip(0).Take(1).First();
                userPW = File.ReadLines("account.txt").Skip(1).Take(1).First();
            }
            else
                MessageBox.Show("You must register before using for the first time", "Attention");
        }
    }
}
