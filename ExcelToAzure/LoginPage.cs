using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelToAzure
{
    public partial class LoginPage : Form
    {
        public static bool LoggedIn = false;
        public LoginPage()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "LOGIN")
            {
                btnLogin.Text = "ATTEMPTING TO LOGIN...";
                btnLogin.BackColor = Color.PaleTurquoise;

                if (SQL.Connect(txtUsername.Text, txtPassword.Text))
                {
                    LoggedIn = true;
                    Form1.Main.CheckShow();
                    MessageBox.Show("Success!", "Login");
                    txtPassword.Text = "";
                    Form1.Navigate(Form1.ImportPage);
                }
                else
                {
                    LoggedIn = false;
                    Form1.Main.CheckShow();
                    MessageBox.Show("Try again", "Failed!");
                }

                btnLogin.Text = "LOGIN";
                btnLogin.BackColor = Color.Teal;
            }
        }

        private void LoginPage_Resize(object sender, EventArgs e)
        {
            //Flow.Dock = DockStyle.Fill;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, new EventArgs());
        }
    }
}
