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
    public partial class LoadingData : Form
    {
        public static LoadingData Instance;
        public LoadingData()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.AutoScroll = true;
            this.progressBar.Value = 0;
        }

        public static int Maximum { get => Instance.progressBar.Maximum; set => Instance.progressBar.Maximum = value; }
        public static int Value { get => Instance.progressBar.Value; set => Instance.progressBar.Value = value; }
        public static string ProgressText { get => Instance.subtitle.Text; set => Instance.subtitle.Text = value; }
        public static string Title { get => Instance.title.Text; set => Instance.title.Text = value; }

        public static bool Finished => Maximum <= Value;

        static bool showing = false;
        public static void Show(Action Loading, Action nextAction)
        {
            MessageBox.Show("Data exporting and analytics not ready yet!");
            if (Instance == null)
                Instance = new LoadingData();
            Form1.Navigate(Instance);
            if (showing) return;
            showing = true;
            Loading?.SafeInvoke();
            Instance.next.MouseClick += (s, e) =>
            {
                if (Finished)
                {
                    nextAction?.SafeInvoke();
                    showing = false;
                }
            };
        }
    }
}
