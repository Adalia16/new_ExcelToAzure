using LiveCharts.Definitions.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExcelToAzure
{
    public partial class Data : Form
    {
        static Data Instance;
        public List<Record> data = new List<Record>();
        enum Properties { Project, Phase, Location, Name1, Name2, Name3, Name4, Template, Record }
        enum Numbers { TotalPrice, Qty, UnitPrice, LocationBSF, ProjectGSF, TotalPrice_per_LocationBSF, TotalPrice_per_ProjectGSF }

        Properties SelectedProperty = Properties.Project;
        Numbers SelectedNumber = Numbers.TotalPrice;
        public Data()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.AutoScroll = true;
            var propertylist = "Project, Phase, Location, Name1, Name2, Name3, Name4, Template, Record".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            propertylist.ForEach(s => propertyList.Items.Add(s));
            var numberlist = "TotalPrice, Qty, UnitPrice, LocationBSF, ProjectGSF, TotalPrice_per_LocationBSF, TotalPrice_per_ProjectGSF".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            numberlist.ForEach(s => numberList.Items.Add(s));

            propertyList.SelectedIndexChanged += (s, e) => PropertySelected(propertyList.SelectedItem as string);
            numberList.SelectedIndexChanged += (s, e) => NumberSelected(numberList.SelectedItem as string);
        }

        private Numbers NumberSelected(string selected)
        {
            if (Numbers.TotalPrice.ToString() == selected)
                SelectedNumber = Numbers.TotalPrice;
            else if (Numbers.Qty.ToString() == selected)
                SelectedNumber = Numbers.Qty;
            else if (Numbers.UnitPrice.ToString() == selected)
                SelectedNumber = Numbers.UnitPrice;
            else if (Numbers.LocationBSF.ToString() == selected)
                SelectedNumber = Numbers.LocationBSF;
            else if (Numbers.ProjectGSF.ToString() == selected)
                SelectedNumber = Numbers.ProjectGSF;
            else if (Numbers.TotalPrice_per_LocationBSF.ToString() == selected)
                SelectedNumber = Numbers.TotalPrice_per_LocationBSF;
            else if (Numbers.TotalPrice_per_ProjectGSF.ToString() == selected)
                SelectedNumber = Numbers.TotalPrice_per_ProjectGSF;
            
            return SelectedNumber;
        }

        private Properties PropertySelected(string selected)
        {
            if (Properties.Project.ToString() == selected)
                SelectedProperty = Properties.Project;
            else if (Properties.Phase.ToString() == selected)
                SelectedProperty = Properties.Phase;
            else if (Properties.Location.ToString() == selected)
                SelectedProperty = Properties.Location;
            else if (Properties.Name1.ToString() == selected)
                SelectedProperty = Properties.Name1;
            else if (Properties.Name2.ToString() == selected)
                SelectedProperty = Properties.Name2;
            else if (Properties.Name3.ToString() == selected)
                SelectedProperty = Properties.Name3;
            else if (Properties.Name4.ToString() == selected)
                SelectedProperty = Properties.Name4;
            else if (Properties.Template.ToString() == selected)
                SelectedProperty = Properties.Template;
            else if (Properties.Record.ToString() == selected)
                SelectedProperty = Properties.Record;

            return SelectedProperty;
        }

        List<List<Record>> FilterRecords(Properties Property)
        {
            // Data arrays
            List<string> seriesArray = new List<string>();
            List<decimal> pointsArray = new List<decimal>();
            List<List<Record>> pointsData = new List<List<Record>>();

            switch (Property)
            {
                case Properties.Project:
                    var tempP = Records.Select(x => x.location.project).DistinctBy(p => p.id).ToList();
                    for (int i = 0; i < tempP.Count(); i++)
                    {
                        pointsData.Add(Records.FindAll(r => r.location.project.id == tempP[i].id));
                        seriesArray.Add(tempP[i].name);
                    }
                    break;

                case Properties.Location:
                    var tempL = Records.Select(x => x.location).DistinctBy(p => p.id).ToList();
                    for (int i = 0; i < tempL.Count(); i++)
                    {
                        pointsData.Add(Records.FindAll(r => r.location.id == tempL[i].id));
                        seriesArray.Add(tempL[i].name);
                    }
                    break;

                case Properties.Phase:
                    var tempPh = Records.Select(x => x.phase).DistinctBy(p => p.id).ToList();
                    for (int i = 0; i < tempPh.Count(); i++)
                    {
                        pointsData.Add(Records.FindAll(r => r.phase.id == tempPh[i].id));
                        seriesArray.Add(tempPh[i].phase);
                    }
                    break;

                case Properties.Name1:
                    var temp1 = Records.Select(x => x.template.level4.level3.level2.level1).DistinctBy(p => p.code).ToList();
                    for (int i = 0; i < temp1.Count(); i++)
                    {
                        pointsData.Add(Records.FindAll(r => r.template.level4.level3.level2.level1.code == temp1[i].code));
                        seriesArray.Add(temp1[i].description);
                    }
                    break;

                case Properties.Name2:
                    var temp2 = Records.Select(x => x.template.level4.level3.level2).DistinctBy(p => p.code).ToList();
                    for (int i = 0; i < temp2.Count(); i++)
                    {
                        pointsData.Add(Records.FindAll(r => r.template.level4.level3.level2.code == temp2[i].code));
                        seriesArray.Add(temp2[i].description);
                    }
                    break;

                case Properties.Name3:
                    var temp3 = Records.Select(x => x.template.level4.level3).DistinctBy(p => p.code).ToList();
                    for (int i = 0; i < temp3.Count(); i++)
                    {
                        pointsData.Add(Records.FindAll(r => r.template.level4.level3.code == temp3[i].code));
                        seriesArray.Add(temp3[i].description);
                    }
                    break;

                case Properties.Name4:
                    var temp4 = Records.Select(x => x.template.level4).DistinctBy(p => p.code).ToList();
                    for (int i = 0; i < temp4.Count(); i++)
                    {
                        pointsData.Add(Records.FindAll(r => r.template.level4.code == temp4[i].code));
                        seriesArray.Add(temp4[i].description);
                    }
                    break;

                case Properties.Template:
                    var temp = Records.Select(x => x.template).DistinctBy(p => p.id).ToList();
                    for (int i = 0; i < temp.Count(); i++)
                    {
                        pointsData.Add(Records.FindAll(r => r.template.id == temp[i].id));
                        seriesArray.Add(temp[i].code);
                    }
                    break;

                case Properties.Record:
                    var tempR = Records.ToList();
                    for (int i = 0; i < tempR.Count(); i++)
                    {
                        pointsData.Add(Records.FindAll(r => r.id == tempR[i].id));
                        seriesArray.Add(tempR[i].csi_code.code);
                    }
                    break;
            }

            return pointsData;
        }

        public static void Show(List<Record> records)
        {
            if (Instance == null)
                Instance = new Data();
            Form1.Navigate(Instance);
            Instance.Records = records;
        }

        public List<Record> Records
        {
            get => data.ToList();
            set
            {
                data = value.ToList();
                propertyList.SelectedIndex = -1;
                numberList.SelectedIndex = -1;
                for (int i = 0; i < propertyList.Items.Count; i++)
                {
                    propertyList.SetItemCheckState(i, CheckState.Unchecked);
                }
                for (int i = 0; i < numberList.Items.Count; i++)
                {
                    numberList.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form1.Navigate(DataSelection.Instance);
        }

        private void next_Click(object sender, EventArgs e)
        {
            var temps = FilterRecords(PropertySelected(propertyList.CheckedItems.Cast<string>().Last()));

            var properties = propertyList.CheckedItems.Cast<string>().Select(PropertySelected).ToList();
            var numbers = numberList.CheckedItems.Cast<string>().Select(NumberSelected).ToList();
            var result = new List<Dictionary<string, object>>();
            var tempdata = temps.Merge();
            for(int i =0; i < temps.Count(); i++)
            {
                var keys = GetValuePairs(temps[i][0], properties);
                keys.AddRange(GetValuePairs(temps[i], numbers));
                var dictionary = keys.ToDictionary(k => k.Key, k => k.Value);
                result.Add(dictionary);
            }
            Xls.ShowDataInNewApp(result);
        }

        List<KeyValuePair<string, object>> GetValuePairs(List<Record> records, List<Numbers> numbers)
        {
            var keys = new List<KeyValuePair<string, object>>();
            numbers.ForEach(number =>
            {
                switch(number)
                {
                    case Numbers.LocationBSF:
                        var tempL = records.Select(x => x.location).DistinctBy(l => l.id).ToList();
                        keys.Add(new KeyValuePair<string, object>(number.ToString(), tempL.Sum(t => t.sf)));
                        break;

                    case Numbers.ProjectGSF:
                        var tempP = records.Select(x => x.location.project).DistinctBy(l => l.id).ToList();
                        keys.Add(new KeyValuePair<string, object>(number.ToString(), tempP.Sum(t => t.gsf)));
                        break;

                    case Numbers.Qty:
                        keys.Add(new KeyValuePair<string, object>(number.ToString(), records.Sum(t => t.qty)));
                        break;

                    case Numbers.TotalPrice:
                        keys.Add(new KeyValuePair<string, object>(number.ToString(), records.Sum(t => t.total)));
                        break;

                    case Numbers.UnitPrice:
                        keys.Add(new KeyValuePair<string, object>(number.ToString(), records.Sum(t => t.unit_price)));
                        break;

                    case Numbers.TotalPrice_per_ProjectGSF:
                        var tempPP = records.Select(x => x.location.project).DistinctBy(l => l.id).ToList();
                        keys.Add(new KeyValuePair<string, object>(number.ToString(), Divide(records.Sum(t => t.total), tempPP.Sum(t => t.gsf))));
                        break;

                    case Numbers.TotalPrice_per_LocationBSF:
                        var tempPL = records.Select(x => x.location).DistinctBy(l => l.id).ToList();
                        keys.Add(new KeyValuePair<string, object>(number.ToString(), Divide(records.Sum(t => t.total), tempPL.Sum(t => t.sf))));
                        break;
                }
            });
            return keys;
        }

        decimal Divide(decimal top, decimal bottom)
        {
            bottom = bottom == 0 ? 1 : bottom;
            return top / bottom;
        }

        List<KeyValuePair<string, object>> GetValuePairs(Record record, List<Properties> properties)
        {
            var keys = new List<KeyValuePair<string, object>>();
            properties.ForEach(property =>
            {
                switch (property)
                {
                    case Properties.Location:
                        keys.Add(new KeyValuePair<string, object>(property.ToString(), record.location.name));
                        break;

                    case Properties.Name1:
                        keys.Add(new KeyValuePair<string, object>(property.ToString(), record.template.level4.level3.level2.level1.description));
                        break;

                    case Properties.Name2:
                        keys.Add(new KeyValuePair<string, object>(property.ToString(), record.template.level4.level3.level2.description));
                        break;

                    case Properties.Name3:
                        keys.Add(new KeyValuePair<string, object>(property.ToString(), record.template.level4.level3.description));
                        break;

                    case Properties.Name4:
                        keys.Add(new KeyValuePair<string, object>(property.ToString(), record.template.level4.description));
                        break;

                    case Properties.Phase:
                        keys.Add(new KeyValuePair<string, object>(property.ToString(), record.phase.phase));
                        break;

                    case Properties.Project:
                        keys.Add(new KeyValuePair<string, object>(property.ToString(), record.location.project.name));
                        break;

                    case Properties.Record:
                        keys.Add(new KeyValuePair<string, object>(property.ToString(), record.csi_code));
                        break;

                    case Properties.Template:
                        keys.Add(new KeyValuePair<string, object>(property.ToString(), record.template.code));
                        break;
                }
            });
            return keys;
        }
    }
}
