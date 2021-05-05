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
    public partial class NewProject : Form
    {
        Action<bool> Saved;
        public NewProject()
        {
            InitializeComponent();
        }

        public static void Open (Project p, Action<bool> saved)
        {
            var form = new NewProject();
            form.Saved = saved;
            form.project = p;
            form.ShowDialog();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int id = -1;
        Project project
        {
            get => new Project()
            {
                id = id,
                name = name.Text.Trim(),
                description = description.Text.Trim(),
                owner = owner.Text.Trim(),
                type = type.Text.Trim(),
                duration = duration.ToDecimal(),
                gsf = gsf.ToDecimal()
            };
            set
            {
                id = value.id;
                name.Text = value.name;
                description.Text = value.description;
                owner.Text = value.owner;
                type.Text = value.type;
                duration.Text = value.duration.ToString();
                gsf.Text = value.gsf.ToString();
            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            if (create.Text == "Updating") return;
            if (name.Text.Trim().Length < 1)
            {
                this.Flash(200, 10, labelName);
                return;
            }
            create.Text = "Updating";
            create.BackColor = Color.Gold;
            
            project.Update((success) =>
            {
                if (success)
                {
                    this.Close();
                    Saved?.Invoke(true);
                }
                else
                    MessageBox.Show("Failed to Save this project!");

                create.Text = "SAVE";
                create.BackColor = Color.CadetBlue;
            });
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            var label = sender as TextBox;
            label.Text = label.Text.ToUpper();
            label.SelectionStart = label.Text.Length;
        }

        private void Label_TextChanged(object sender, EventArgs e)
        {
            var label = sender as TextBox;
            label.Text = label.NumbersOnly(true);
            label.SelectionStart = label.Text.Length;
        }
    }
}
