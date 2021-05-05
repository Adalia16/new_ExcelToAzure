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
    public partial class SelectFromList : Form
    {
        Action<string> Selected;
        //List<string> list = new List<string>();
        public SelectFromList(List<string> list, string Title, Action<string> action)
        {
            InitializeComponent();
            ListBox.Items.Clear();
            list.ForEach(s =>
            {
                ListBox.Items.Add(s);
            });
            this.labelTitle.Text = Title;
            this.Selected = action;
            if (list.Any())
                this.ShowDialog();
        }

        public static void Open(List<string> list, string Title, Action<string> selected) => new SelectFromList(list.ToList(), Title, selected);

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (ListBox.SelectedIndex < 0) return;
            this.Close();
            Selected?.Invoke(ListBox.SelectedItem as string);
        }
    }
}
