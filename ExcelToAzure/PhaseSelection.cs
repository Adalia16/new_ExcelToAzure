using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelToAzure
{
    public partial class PhaseSelection : Form
    {
        static PhaseSelection control;
        static Project data;

        private OpenFileDialog openFileDialog1;
        public PhaseSelection()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.AutoScroll = true;
            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a Excel file",
                Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx",
                Title = "Open Excel file"
            };
        }

        private void PhaseSelection_Load(object sender, EventArgs e)
        {
            control = this;
            control.TopLevel = false;
            AutoScroll = true;
        }

        public static void Open(Project p)
        {
            if (control == null)
                control = new PhaseSelection();
            Form1.Navigate(control);
            control.project = p;
        }

        public Project project
        {
            get => data.New();
            set
            {
                data = value.New();
                name.Text = "";
                Phase.GetAll((all) =>
                {
                    ListBox.Items.Clear();
                    all.Select(x => x.phase).Distinct().ToList().ForEach(x => ListBox.Items.Add(x.ToUpper()));
                });
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Form1.Navigate(Form1.ImportPage);
        }

        private void create_Click(object sender, EventArgs e)
        {
            var phase = new Phase() { phase = name.Text.Trim().ToUpper(), project = project.New() };
            if (create.Text == "Saving..." || !phase.phase.Any()) return;
            create.Text = "Saving...";
            create.BackColor = Color.Gold;
            phase.Update((updated) =>
            {
                project = data;
                create.Text = "SELECT FILE";
                create.BackColor = Color.CadetBlue;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var filePath = openFileDialog1.FileName;
                        Xls.GetArrayFromFile(filePath, (rowsresult) =>
                        {
                            var withoutlastrow = rowsresult.ToList();
                            withoutlastrow.Remove(withoutlastrow.Last());
                            ColumnSelection.Open(withoutlastrow, project, updated);
                        });
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }
            });
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            name.Text = ListBox.SelectedItem as string;
        }
    }
}
