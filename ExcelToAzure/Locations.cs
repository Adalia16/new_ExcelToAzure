using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelToAzure
{
    public partial class LocationsPage : Form
    {
        List<Location> Data = new List<Location>();
        List<Row> rows = new List<Row>();
        Project project;
        public LocationsPage(Project p)
        {
            InitializeComponent();
            this.TopLevel = false;
            Dock = DockStyle.Fill;
            AutoScroll = true;
            project = p.New();
            this.VisibleChanged += (s, e) =>
            {
                if (Visible)
                    Reload();
            };
            Form1.Navigate(this);
            labelTitle.Text = "Showing Locations for " + p.name;
        }

        public static void Show(Project p) => new LocationsPage(p);

        static bool fetching = false;
        private void Reload()
        {
            if (fetching) 
                return;

            fetching = true;

            if (Row.DefaultRow == null)
                Row.DefaultRow = Table.Controls[0].Clone();

            rows.Clear();
            project.GetLocations((res) =>
            {
                Data = res;
                Table.Controls.Clear();
                Table.RowStyles.Clear();
                Table.RowCount = Data.Count();
                Data.ForEach(x =>
                {
                    var row = new Row(x);
                    RowStyle style = new RowStyle()
                    {
                        SizeType = SizeType.Absolute,
                        Height = 48
                    };
                    Table.Controls.Add(row.control);
                    Table.RowStyles.Add(style);
                    rows.Add(row);
                });
                Table.Controls.Add(new Panel());
                Table.Refresh();
                fetching = false;
            });
        }
        private void Label_TextChanged(object sender, EventArgs e)
        {
            var label = sender as TextBox;
            label.Text = label.NumbersOnly(true);
            label.SelectionStart = label.Text.Length;
        }

        bool saving = false;
        private void Save_Clicked(object sender, EventArgs e)
        {
            if (saving) return;
            saving = true;
            SaveChanges.ForeColor = Color.FromArgb(100, SaveChanges.ForeColor);
            SaveChanges.Text = "Saving...";
            Task.Run(() =>
            {
                rows.ForEach(row =>
                {
                    row.location.Update();
                });
                SaveChanges.SafeInvoke(b =>
                {
                    Reload();
                    b.ForeColor = Color.FromArgb(255, SaveChanges.ForeColor);
                    b.Text = "Save Changes";
                    saving = false;
                });
            });
        }

        private class Row
        {
            public static Control DefaultRow;
            Label id, name, code;
            TextBox bsf;
            public Control control;
            private Location data;
            //public EventHandler Clicked, RightClicked;

            public Row(Location loc)
            {
                control = DefaultRow.Clone();
                control.Size = DefaultRow.Size;
                var all = control.All();
                id = all.FindLink(id, "id");
                name = all.FindLink(name, "name");
                code = all.FindLink(code, "code");
                bsf = all.FindLink(bsf, "bsf");
                location = loc;
                bsf.TextChanged += (s, e) =>
                {
                    var label = s as TextBox;
                    label.Text = label.NumbersOnly(true);
                    label.SelectionStart = label.Text.Length;
                };
                control.Show();
                //all.ForEach(x => x.MouseClick += (s, e) =>
                //{
                //    if (e.Button == MouseButtons.Left)
                //        Clicked?.Invoke(location, e);
                //    else if (e.Button == MouseButtons.Right)
                //        RightClicked?.Invoke(location, e);
                //});
            }

            public Location location
            {
                get
                {
                    data.sf = bsf.ToDecimal();
                    return data.New();
                }
                set
                {
                    data = value.New();
                    id.Text = data.id.ToString();
                    name.Text = data.name;
                    code.Text = data.code;
                    bsf.Text = data.sf.ToString();
                }
            }
                
        }

    }
}
