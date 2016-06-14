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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (PasswordInput.Text == "" || UsernameInput.Text == "" || PasswordInput2.Text == "")
                MessageBox.Show("All field are required", "Error", MessageBoxButtons.OK);
            else
                if (PasswordInput.Text != PasswordInput2.Text)
                    MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK);
                else
                {
                    StreamWriter writer = new StreamWriter("account.txt");
                    writer.WriteLine(this.UsernameInput.Text);
                    writer.WriteLine(this.PasswordInput.Text);
                    writer.Close();
                    LoginForm.userID = File.ReadLines("account.txt").Skip(0).Take(1).First();
                    LoginForm.userPW = File.ReadLines("account.txt").Skip(1).Take(1).First();
                    MessageBox.Show("Registered Successfully", "Register Success", MessageBoxButtons.OK);
                    this.Close();
                }
        }
    }
}
