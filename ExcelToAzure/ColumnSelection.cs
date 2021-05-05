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
    public partial class ColumnSelection : Form
    {
        static ColumnSelection control;
        List<Header> Headers = new List<Header>();
        List<Header> PairedHeaders = new List<Header>();
        List<string[]> Rows = new List<string[]>();
        Project project;
        Phase phase;
        int page = 0;

        public ColumnSelection()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.AutoScroll = true;
        }

        private void PhaseSelection_Load(object sender, EventArgs e)
        {
            control = this;
            control.TopLevel = false;
            AutoScroll = true;
        }

        public static void Open(List<string[]> rows, Project p, Phase ph)
        {
            if (!rows.Any())
            {
                MessageBox.Show("No data found");
                return;
            }
            if (control == null)
                control = new ColumnSelection();
            Form1.Navigate(control);
            control.SetData(rows, p, ph);
        }

        void SetData(List<string[]> rows, Project p, Phase ph)
        {
            page = 0;
            Headers.Clear();
            for (int i = 0; i < properties.Length; i++) PairedHeaders.Add(new Header());
            //PairedHeaders = (new Header[properties.Length]).ToList();
            for (int i = 0; i < rows.First().Length; i++)
            {
                Headers.Add(new Header() { index = i, value = rows.First()[i] });
                if (rows.Count() >= properties.Length)
                {
                    PairedHeaders[i] = new Header() { index = i, value = rows.First()[i] };
                }
            }
            Headers = Headers.OrderBy(x => x.index).ToList();
            project = p.New();
            phase = ph.New();
            Rows = rows.ToList();
            Rows.RemoveAt(0);
            SetListBox();
        }

        void SetListBox()
        {
            ListBox.Items.Clear();
            Headers.FindAll(x => !PairedHeaders.Select(p => p.index).Contains(x.index)).ForEach(item => ListBox.Items.Add(item.index.ToString() + " " + item.value));
            title.Text = string.Format("LINK EXCEL COLUMNS TO DATA {0}/{1}", (page + 1).ToString(), properties.Length.ToString());
            txtDataProperty.Text = properties[page];
            txtColumnName.Text = PairedHeaders[page].value;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (page > 0)
            {
                page--;
                SetListBox();
            }
            else if(MessageBox.Show("Data will be lost", "Go back to Project selection?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    Form1.Navigate(Form1.ImportPage);
        }

        private void create_Click(object sender, EventArgs e)
        {
            page++;
            if (page >= properties.Length)
            {
                Finish();
                page = properties.Length;
            }
            else
                SetListBox();
        }

        private void Finish()
        {
            if (PairedHeaders.Any(h => !(h.value ?? "").Any()))
            {
                MessageBox.Show("Go back and make sure all values are paired", "Some properties are missing a column data!");
                return;
            }
            var text = "These are the pairings (Excell --> DataBase):\n" + string.Join("\n", PairedHeaders.Select(x => string.Format("{0} --> {1}", x.value, properties[PairedHeaders.IndexOf(x)])));
            var result = MessageBox.Show(text, "Is everything correct?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
            if (result == DialogResult.Yes)
            {
                PrepData();
                Form1.Navigate(Form1.ImportPage);
                //Xls.ShowDataInNewApp(PrepData());
            }
        }

        private async void InsertDataToDB(List<Record> allrecs, List<Location> locations, List<Level1> level1s, List<Level2> level2s, List<Level3> level3s, List<Level4> level4s)
        {
            var success = false;
            while (Form1.Bar.Visible)
            {
                await Task.Delay(1000);
            }
            await Task.Run(() => success = SQL.ImportNewData(allrecs, locations, level1s, level2s, level3s, level4s));
            if (success)
                MessageBox.Show("Successfully imported data");
            else
                MessageBox.Show("Failed to import all the data");
            Form1.Main.SafeInvoke(x => LocationsPage.Show(project));
        }

        void PrepData()
        {
            phase.project = project.New();
            List<Record> records = new List<Record>();
            var recordRows = Rows.FindAll(x => x[PairedHeaders[0].index].ToInt() == 6).ToList();
            var locationRows = Rows.FindAll(x => x[PairedHeaders[0].index].ToInt() == 1).ToList();
            var level1Rows = Rows.FindAll(x => x[PairedHeaders[0].index].ToInt() == 2).ToList();
            var level2Rows = Rows.FindAll(x => x[PairedHeaders[0].index].ToInt() == 3).ToList();
            var level3Rows = Rows.FindAll(x => x[PairedHeaders[0].index].ToInt() == 4).ToList();
            var level4Rows = Rows.FindAll(x => x[PairedHeaders[0].index].ToInt() == 5).ToList();

            List<Location> locations = new List<Location>();
            List<Level1> level1s = new List<Level1>();
            List<Level2> level2s = new List<Level2>();
            List<Level3> level3s = new List<Level3>();
            List<Level4> level4s = new List<Level4>();

            locationRows.ForEach(x =>
            {
                var loc = new Location()
                {
                    code = x[PairedHeaders[(int)columns.LocCode].index],
                    name = x[PairedHeaders[(int)columns.LocationName].index],
                    sf = x[PairedHeaders[(int)columns.qty].index].ToDecimal(),
                    project = project.New()
                };
                locations.Add(loc);
            });

            level1Rows.ForEach(x =>
            {
                var lev = new Level1()
                {
                    code = x[PairedHeaders[(int)columns.LOD1Code].index],
                    description = x[PairedHeaders[(int)columns.LOD1Name].index],
                    Phase_UOM_qty = (phase.New(), x[PairedHeaders[(int)columns.UOM].index], x[PairedHeaders[(int)columns.qty].index].ToDecimal()),
                    project = project.New()
                };
                level1s.Add(lev);
            });

            level2Rows.ForEach(x =>
            {
                var lev = new Level2()
                {
                    code = x[PairedHeaders[(int)columns.LOD2Code].index],
                    description = x[PairedHeaders[(int)columns.LOD2Name].index],
                    Phase_UOM_qty = (phase.New(), x[PairedHeaders[(int)columns.UOM].index], x[PairedHeaders[(int)columns.qty].index].ToDecimal()),
                    level1 = level1s.Find(l1 => l1.code == x[PairedHeaders[(int)columns.LOD1Code].index])
                };
                level2s.Add(lev);
            });

            level3Rows.ForEach(x =>
            {
                var lev = new Level3()
                {
                    code = x[PairedHeaders[(int)columns.LOD3Code].index],
                    description = x[PairedHeaders[(int)columns.LOD3Name].index],
                    Phase_UOM_qty = (phase.New(), x[PairedHeaders[(int)columns.UOM].index], x[PairedHeaders[(int)columns.qty].index].ToDecimal()),
                    level2 = level2s.Find(l2 => l2.code == x[PairedHeaders[(int)columns.LOD2Code].index])
                };
                level3s.Add(lev);
            });

            level4Rows.ForEach(x =>
            {
                var lev = new Level4()
                {
                    code = x[PairedHeaders[(int)columns.LOD4Code].index],
                    description = x[PairedHeaders[(int)columns.LOD4Name].index],
                    Phase_UOM_qty = (phase.New(), x[PairedHeaders[(int)columns.UOM].index], x[PairedHeaders[(int)columns.qty].index].ToDecimal()),
                    level3 = level3s.Find(l3 => l3.code == x[PairedHeaders[(int)columns.LOD3Code].index])
                };
                level4s.Add(lev);
            });

            for (int iRow = 0; iRow < recordRows.Count(); iRow++)
            {
                records.Add(new Record());
                var lev4 = new Level4()
                {
                    code = recordRows[iRow][PairedHeaders[(int)columns.LOD4Code].index],
                    description = recordRows[iRow][PairedHeaders[(int)columns.LOD4Name].index],
                    level3 = new Level3()
                    {
                        code = recordRows[iRow][PairedHeaders[(int)columns.LOD3Code].index],
                        description = recordRows[iRow][PairedHeaders[(int)columns.LOD3Name].index],
                        level2 = new Level2()
                        {
                            code = recordRows[iRow][PairedHeaders[(int)columns.LOD2Code].index],
                            description = recordRows[iRow][PairedHeaders[(int)columns.LOD2Name].index],
                            level1 = new Level1()
                            {
                                code = recordRows[iRow][PairedHeaders[(int)columns.LOD1Code].index],
                                description = recordRows[iRow][PairedHeaders[(int)columns.LOD1Name].index],
                                project = project.New()
                            }
                        }
                    }
                };
                records[iRow].location = locations.Find(x => x.code == recordRows[iRow][PairedHeaders[(int)columns.LocCode].index]);
                records[iRow].phase = phase.New();
                records[iRow].template.description = recordRows[iRow][PairedHeaders[(int)columns.Description].index];
                records[iRow].template.code = recordRows[iRow][PairedHeaders[(int)columns.Code].index];
                records[iRow].template.ut = recordRows[iRow][PairedHeaders[(int)columns.UOM].index];
                records[iRow].template.level4 = lev4;
                records[iRow].qty = recordRows[iRow][PairedHeaders[(int)columns.qty].index].ToDecimal();
                records[iRow].total = recordRows[iRow][PairedHeaders[(int)columns.Extension].index].ToDecimal();
                records[iRow].comments = recordRows[iRow][PairedHeaders[(int)columns.comments].index];
                records[iRow].csi_code = new CSICode() 
                { 
                    code = recordRows[iRow][PairedHeaders[(int)columns.csi_code].index],
                    trade_code = new TradeCode()
                    {
                        code = recordRows[iRow][PairedHeaders[(int)columns.trade_code].index]
                    }
                };
                records[iRow].estimate_category = recordRows[iRow][PairedHeaders[(int)columns.estimate_category].index];
            }
            InsertDataToDB(records, locations, level1s, level2s, level3s, level4s);
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Text = ListBox.SelectedItem as string;
            this.Flash(140, 3, arrowlabel);
            PairedHeaders[page] = Headers.Find(x => (x.index.ToString() + " " + x.value) == Text);
            SetListBox();
        }

        private void txtColumnName_Click(object sender, EventArgs e)
        {
            PairedHeaders[page] = new Header() { index = -1, value = "" };
            SetListBox();
        }

        class Header
        {
            public string value = "";
            public int index = -1;
        }

        string[] properties = new string[]
        {
            "N",
            "LocCode",
            "LocationName",
            "LOD1Code",
            "LOD1Name",
            "LOD2Code",
            "LOD2Name",
            "LOD3Code",
            "LOD3Name",
            "LOD4Code",
            "LOD4Name",
            "Code",
            "Description",
            "qty",
            "UOM",
            "UnitPrice",
            "Extension",
            "comments",
            "csi_code",
            "trade_code",
            "estimate_category"
        };

        enum columns: int
        { 
            N,
            LocCode,
            LocationName,
            LOD1Code,
            LOD1Name,
            LOD2Code,
            LOD2Name,
            LOD3Code,
            LOD3Name,
            LOD4Code,
            LOD4Name,
            Code,
            Description,
            qty,
            UOM,
            UnitPrice,
            Extension,
            comments,
            csi_code,
            trade_code,
            estimate_category
        };
    }
}
