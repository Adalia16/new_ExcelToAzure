using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Security;
using System.IO;
using Newtonsoft.Json;

namespace ExcelToAzure
{
    public partial class Form1 : Form
    {
        public static Form1 Main;
        public static Control Dash, LoginPage, DataPage, ImportPage;
        public static List<Record> Records = new List<Record>();
        public static ProgressBar Bar;
        public Form1()
        {
            InitializeComponent();
            Main = this;
            Dash = Dashboard;
            Bar = progressBar;
            CheckShow();
            LoginPage = GetActiveControl(new LoginPage());
            ImportPage = GetActiveControl(new ImportPage());
            LoginPage = GetActiveControl(new LoginPage());
        }
        public void CheckShow()
        {
            bool visible = ExcelToAzure.LoginPage.LoggedIn;
            ImportMenu.Visible = visible;
            DataMenu.Visible = visible;

            if (visible)
            {
                //fetching_data = true;
                //Record.All(  //Fetching....
                //(all) =>    //Finished fetching => do next thing
                //{
                //    fetching_data = false;
                //    Records = all;
                //    MessageBox.Show("All data loaded!");
                //});
            }
        }
        Control GetActiveControl(Form f)
        {
            f.TopLevel = false;
            return f;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Navigate(LoginPage);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Navigate(LoginPage);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Navigate(ImportPage);
        }

        //bool fetching_data = false;
        private void btnData_Click(object sender, EventArgs e)
        {
            //if (fetching_data) return;
            //fetching_data = true;
            LoadingData.Show(() =>
            Record.All(  //Fetching....
            (all) =>    //Finished fetching => do next thing
            {
                //fetching_data = false;
                Records = all;
            }),
            () => DataSelection.Show(Records));
        }

        public static void Navigate (Control page)
        {
            var goToPage = ExcelToAzure.LoginPage.LoggedIn ? page : LoginPage;

            Dash.SafeInvoke(dashboard =>
            {
                dashboard.Controls.Clear();
                dashboard.Controls.Add(goToPage);
                goToPage.Dock = DockStyle.Fill;
                goToPage.Show();
                Form1.Main.Dashboard.AutoScroll = true;
            });
        }
    }
}
