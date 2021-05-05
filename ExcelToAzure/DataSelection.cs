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
    public partial class DataSelection : Form
    {
        public static DataSelection Instance;
        enum Pages { Project, Phase, Location, Level1, Level2, Level3, Level4, Template, Record }

        Pages Stage = Pages.Project;

        List<Record> data = new List<Record>();
        public DataSelection()
        {
            InitializeComponent();
            this.TopLevel = false;
            searchBox.TextChanged += (s, e) =>
            {
                SetList();
            };
            checkAll.Click += (s, e) =>
            {
                for (int i = 0; i < checkedList.Items.Count; i++)
                {
                    checkedList.SetItemCheckState(i, checkAll.CheckState);
                }
                UpdateSelectedLabel();
            };
            checkedList.MouseUp += (s, e) => UpdateSelectedLabel();
            back.Click += (s, e) => GoBack();
            next.Click += (s, e) => GoNext();
        }

        private void GoNext()
        {
            if (checkedList.CheckedItems.Count < 1) return;

            var checkedStrings = checkedList.CheckedItems.Cast<string>().ToList();
            switch (Stage)
            {
                case Pages.Project:
                    Stage = Pages.Phase;
                    Current = Current.FindAll(x => checkedStrings.Any(s => s == string.Format("{0} {1} {2}", x.location.project.id.ToString(), x.location.project.name, x.location.project.description)));
                    searchBox.Text = "";
                    SetList();
                    break;

                case Pages.Phase:
                    Stage = Pages.Location;
                    Current = Current.FindAll(x => checkedStrings.Any(s => s == string.Format("{0} {1}", x.phase.id.ToString(), x.phase.phase)));
                    searchBox.Text = "";
                    SetList();
                    break;

                case Pages.Location:
                    Stage = Pages.Level1;
                    Current = Current.FindAll(x => checkedStrings.Any(s => s == string.Format("{0} {1} {2}", x.location.id.ToString(), x.location.code, x.location.name)));
                    searchBox.Text = "";
                    SetList();
                    break;

                case Pages.Level1:
                    Stage = Pages.Level2;
                    Current = Current.FindAll(x => checkedStrings.Any(s => s == string.Format("{0} {1}", x.template.level4.level3.level2.level1.code, x.template.level4.level3.level2.level1.description)));
                    searchBox.Text = "";
                    SetList();
                    break;

                case Pages.Level2:
                    Stage = Pages.Level3;
                    Current = Current.FindAll(x => checkedStrings.Any(s => s == string.Format("{0} {1}", x.template.level4.level3.level2.code, x.template.level4.level3.level2.description)));
                    searchBox.Text = "";
                    SetList();
                    break;

                case Pages.Level3:
                    Stage = Pages.Level4;
                    Current = Current.FindAll(x => checkedStrings.Any(s => s == string.Format("{0} {1}", x.template.level4.level3.code, x.template.level4.level3.description)));
                    searchBox.Text = "";
                    SetList();
                    break;

                case Pages.Level4:
                    Stage = Pages.Template;
                    Current = Current.FindAll(x => checkedStrings.Any(s => s == string.Format("{0} {1}", x.template.level4.code, x.template.level4.description)));
                    searchBox.Text = "";
                    SetList();
                    break;

                case Pages.Template:
                    Stage = Pages.Record;
                    Current = Current.FindAll(x => checkedStrings.Any(s => s == string.Format("{0} {1} {2}", x.template.id.ToString(), x.template.code, x.template.description)));
                    searchBox.Text = "";
                    SetList();
                    break;

                case Pages.Record:
                    Data.Show(Current.FindAll(x => checkedStrings.Any(s => s == string.Format("{0} {1} {2}", x.id.ToString(), x.csi_code.code, x.csi_code.trade_code.code))));
                    break;
            }
            UpdateSelectedLabel();
        }

        void SetList()
        {
            var search = searchBox.Text.Trim();
            checkAll.CheckState = CheckState.Unchecked;
            title.Text = "Select " + Stage.ToString();
            switch (Stage)
            {
                case Pages.Project:
                    DataSource = search.Any() ? Current.FindAll(r => search.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().Any(x => r.location.project.ToJSONCleanString().ToUpper().Contains(x))).ToList() : Current.ToList();
                    DataSource = DataSource.DistinctBy(x => x.location.project.id).ToList();
                    checkedList.Items.Clear();
                    DataSource.Select(d => d.location.project).ToList().ForEach(x => checkedList.Items.Add(string.Format("{0} {1} {2}", x.id.ToString(), x.name, x.description)));
                    break;

                case Pages.Phase:
                    DataSource = search.Any() ? Current.FindAll(r => search.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().Any(x => r.phase.ToJSONCleanString().ToUpper().Contains(x))).ToList() : Current.ToList();
                    DataSource = DataSource.DistinctBy(x => x.phase.id).ToList();
                    checkedList.Items.Clear();
                    DataSource.Select(d => d.phase).ToList().ForEach(x => checkedList.Items.Add(string.Format("{0} {1}", x.id.ToString(), x.phase)));
                    break;

                case Pages.Location:
                    DataSource = search.Any() ? Current.FindAll(r => search.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().Any(x => r.location.ToJSONCleanString().ToUpper().Contains(x))).ToList() : Current.ToList();
                    DataSource = DataSource.DistinctBy(x => x.location.id).ToList();
                    checkedList.Items.Clear();
                    DataSource.Select(d => d.location).ToList().ForEach(x => checkedList.Items.Add(string.Format("{0} {1} {2}", x.id.ToString(), x.code, x.name)));
                    break;

                case Pages.Level1:
                    DataSource = search.Any() ? Current.FindAll(r => search.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().Any(x => r.template.level4.ToJSONCleanString().ToUpper().Contains(x))).ToList() : Current.ToList();
                    DataSource = DataSource.DistinctBy(x => x.template.level4.level3.level2.level1.code).ToList();
                    checkedList.Items.Clear();
                    DataSource.Select(d => d.template.level4).ToList().ForEach(x => checkedList.Items.Add(string.Format("{0} {1}", x.level3.level2.level1.code, x.level3.level2.level1.description)));
                    break;

                case Pages.Level2:
                    DataSource = search.Any() ? Current.FindAll(r => search.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().Any(x => r.template.level4.ToJSONCleanString().ToUpper().Contains(x))).ToList() : Current.ToList();
                    DataSource = DataSource.DistinctBy(x => x.template.level4.level3.level2.code).ToList();
                    checkedList.Items.Clear();
                    DataSource.Select(d => d.template.level4).ToList().ForEach(x => checkedList.Items.Add(string.Format("{0} {1}", x.level3.level2.code, x.level3.level2.description)));
                    break;

                case Pages.Level3:
                    DataSource = search.Any() ? Current.FindAll(r => search.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().Any(x => r.template.level4.ToJSONCleanString().ToUpper().Contains(x))).ToList() : Current.ToList();
                    DataSource = DataSource.DistinctBy(x => x.template.level4.level3).ToList();
                    checkedList.Items.Clear();
                    DataSource.Select(d => d.template.level4).ToList().ForEach(x => checkedList.Items.Add(string.Format("{0} {1}", x.level3.code, x.level3.description)));
                    break;

                case Pages.Level4:
                    DataSource = search.Any() ? Current.FindAll(r => search.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().Any(x => r.template.level4.ToJSONCleanString().ToUpper().Contains(x))).ToList() : Current.ToList();
                    DataSource = DataSource.DistinctBy(x => x.template.level4.code).ToList();
                    checkedList.Items.Clear();
                    DataSource.Select(d => d.template.level4).ToList().ForEach(x => checkedList.Items.Add(string.Format("{0} {1}", x.code, x.description)));
                    break;

                case Pages.Template:
                    DataSource = search.Any() ? Current.FindAll(r => search.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().Any(x => r.template.ToJSONCleanString().ToUpper().Contains(x))).ToList() : Current.ToList();
                    DataSource = DataSource.DistinctBy(x => x.template.id).ToList();
                    checkedList.Items.Clear();
                    DataSource.Select(d => d.template).ToList().ForEach(x => checkedList.Items.Add(string.Format("{0} {1} {2}", x.id, x.code, x.description)));
                    break;

                case Pages.Record:
                    DataSource = search.Any() ? Current.FindAll(r => search.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().Any(x => r.ToJSONCleanString().ToUpper().Contains(x))).ToList() : Current.ToList();
                    DataSource = DataSource.DistinctBy(x => x.id).ToList();
                    checkedList.Items.Clear();
                    DataSource.ForEach(x => checkedList.Items.Add(string.Format("{0} {1} {2}", x.id, x.csi_code.code, x.csi_code.trade_code.code)));
                    break;
            }
            results.Text = DataSource.Count().ToString() + " RESULTS";
        }

        void UpdateSelectedLabel() => selected.Text = checkedList.CheckedItems.Count.ToString() + " SELECTED";

        private void GoBack()
        {
            searchBox.Text = "";
            var tocheck = Current.ToList();
            switch (Stage)
            {
                case Pages.Phase:
                    Stage = Pages.Project;
                    Current = Records.ToList();
                    SetList();
                    for (int i = 0; i < checkedList.Items.Count; i++)
                    {
                        checkedList.SetItemCheckState(i, tocheck.Any(c => checkedList.Items[i].ToString().StartsWith(c.location.project.id.ToString() + " ", StringComparison.CurrentCultureIgnoreCase)) ? CheckState.Checked : CheckState.Unchecked);
                    }
                    break;

                case Pages.Location:
                    Stage = Pages.Phase;
                    Current = Records.FindAll(x => Current.Any(c => c.location.project.id == x.location.project.id)).ToList();
                    SetList();
                    for (int i = 0; i < checkedList.Items.Count; i++)
                    {
                        checkedList.SetItemCheckState(i, tocheck.Any(c => checkedList.Items[i].ToString().StartsWith(c.phase.id.ToString() + " ", StringComparison.CurrentCultureIgnoreCase)) ? CheckState.Checked : CheckState.Unchecked);
                    }
                    break;

                case Pages.Level1:
                    Stage = Pages.Location;
                    Current = Records.FindAll(x => Current.Any(c => c.phase.id == x.phase.id)).ToList();
                    SetList();
                    for (int i = 0; i < checkedList.Items.Count; i++)
                    {
                        checkedList.SetItemCheckState(i, tocheck.Any(c => checkedList.Items[i].ToString().StartsWith(c.location.id.ToString() + " ", StringComparison.CurrentCultureIgnoreCase)) ? CheckState.Checked : CheckState.Unchecked);
                    }
                    break;

                case Pages.Level2:
                    Stage = Pages.Level1;
                    Current = Records.FindAll(x => Current.Any(c => c.location.id == x.location.id)).ToList();
                    SetList();
                    for (int i = 0; i < checkedList.Items.Count; i++)
                    {
                        checkedList.SetItemCheckState(i, tocheck.Any(c => checkedList.Items[i].ToString().StartsWith(c.template.level4.level3.level2.level1.code + " ", StringComparison.CurrentCultureIgnoreCase)) ? CheckState.Checked : CheckState.Unchecked);
                    }
                    break;

                case Pages.Level3:
                    Stage = Pages.Level2;
                    Current = Records.FindAll(x => Current.Any(c => c.template.level4.level3.level2.level1.code == x.template.level4.level3.level2.level1.code)).ToList();
                    SetList();
                    for (int i = 0; i < checkedList.Items.Count; i++)
                    {
                        checkedList.SetItemCheckState(i, tocheck.Any(c => checkedList.Items[i].ToString().StartsWith(c.template.level4.level3.level2.code + " ", StringComparison.CurrentCultureIgnoreCase)) ? CheckState.Checked : CheckState.Unchecked);
                    }
                    break;

                case Pages.Level4:
                    Stage = Pages.Level3;
                    Current = Records.FindAll(x => Current.Any(c => c.template.level4.level3.level2.code == x.template.level4.level3.level2.code)).ToList();
                    SetList();
                    for (int i = 0; i < checkedList.Items.Count; i++)
                    {
                        checkedList.SetItemCheckState(i, tocheck.Any(c => checkedList.Items[i].ToString().StartsWith(c.template.level4.level3.code + " ", StringComparison.CurrentCultureIgnoreCase)) ? CheckState.Checked : CheckState.Unchecked);
                    }
                    break;

                case Pages.Template:
                    Stage = Pages.Level4;
                    Current = Records.FindAll(x => Current.Any(c => c.template.level4.level3.code == x.template.level4.level3.code)).ToList();
                    SetList();
                    for (int i = 0; i < checkedList.Items.Count; i++)
                    {
                        checkedList.SetItemCheckState(i, tocheck.Any(c => checkedList.Items[i].ToString().StartsWith(c.template.level4.code + " ", StringComparison.CurrentCultureIgnoreCase)) ? CheckState.Checked : CheckState.Unchecked);
                    }
                    break;

                case Pages.Record:
                    Stage = Pages.Template;
                    Current = Records.FindAll(x => Current.Any(c => c.template.level4.code == x.template.level4.code)).ToList();
                    SetList();
                    for (int i = 0; i < checkedList.Items.Count; i++)
                    {
                        checkedList.SetItemCheckState(i, tocheck.Any(c => checkedList.Items[i].ToString().StartsWith(c.template.id.ToString() + " ", StringComparison.CurrentCultureIgnoreCase)) ? CheckState.Checked : CheckState.Unchecked);
                    }
                    break;
            }
            UpdateSelectedLabel();
        }

        public static void Show(List<Record> data)
        {
            if (Instance == null)
                Instance = new DataSelection();
            Form1.Navigate(Instance);
            Instance.Records = data.ToList();
        }


        public List<Record> Records
        {
            get => data.ToList();
            set
            {
                data = value.ToList();
                Stage = Pages.Project;
                searchBox.Text = "";
                checkAll.Checked = false;
                Current = data.ToList();
                SetList();
            }
        }

        List<Record> Current = new List<Record>();
        List<Record> DataSource = new List<Record>();
    }
}
