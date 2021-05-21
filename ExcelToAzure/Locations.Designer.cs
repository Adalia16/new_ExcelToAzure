namespace ExcelToAzure
{
    partial class LocationsPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.SaveChanges = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.layout = new System.Windows.Forms.FlowLayoutPanel();
            this.id = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.bsf = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.Table.SuspendLayout();
            this.layout.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.MaximumSize = new System.Drawing.Size(6667, 62);
            this.labelTitle.MinimumSize = new System.Drawing.Size(67, 62);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(361, 62);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Edit Locations for Project";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SaveChanges
            // 
            this.SaveChanges.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveChanges.BackColor = System.Drawing.Color.CadetBlue;
            this.SaveChanges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveChanges.Dock = System.Windows.Forms.DockStyle.Right;
            this.SaveChanges.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.SaveChanges.FlatAppearance.BorderSize = 0;
            this.SaveChanges.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.SaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveChanges.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveChanges.ForeColor = System.Drawing.Color.White;
            this.SaveChanges.Location = new System.Drawing.Point(505, 0);
            this.SaveChanges.Margin = new System.Windows.Forms.Padding(0);
            this.SaveChanges.MaximumSize = new System.Drawing.Size(667, 62);
            this.SaveChanges.MinimumSize = new System.Drawing.Size(67, 62);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(213, 62);
            this.SaveChanges.TabIndex = 1;
            this.SaveChanges.TabStop = false;
            this.SaveChanges.Text = "Save Changes";
            this.SaveChanges.UseVisualStyleBackColor = false;
            this.SaveChanges.Click += new System.EventHandler(this.Save_Clicked);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.SaveChanges);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MaximumSize = new System.Drawing.Size(6666, 61);
            this.panel1.MinimumSize = new System.Drawing.Size(666, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 61);
            this.panel1.TabIndex = 2;
            // 
            // Table
            // 
            this.Table.AutoScroll = true;
            this.Table.AutoSize = true;
            this.Table.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Table.ColumnCount = 1;
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Table.Controls.Add(this.layout, 0, 0);
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.Location = new System.Drawing.Point(0, 120);
            this.Table.Margin = new System.Windows.Forms.Padding(0);
            this.Table.Name = "Table";
            this.Table.RowCount = 1;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.Table.Size = new System.Drawing.Size(720, 237);
            this.Table.TabIndex = 3;
            // 
            // layout
            // 
            this.layout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.layout.Controls.Add(this.id);
            this.layout.Controls.Add(this.code);
            this.layout.Controls.Add(this.name);
            this.layout.Controls.Add(this.bsf);
            this.layout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Margin = new System.Windows.Forms.Padding(0);
            this.layout.MinimumSize = new System.Drawing.Size(719, 59);
            this.layout.Name = "layout";
            this.layout.Padding = new System.Windows.Forms.Padding(21, 10, 21, 10);
            this.layout.Size = new System.Drawing.Size(720, 237);
            this.layout.TabIndex = 0;
            this.layout.WrapContents = false;
            // 
            // id
            // 
            this.id.AutoEllipsis = true;
            this.id.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(32, 20);
            this.id.Margin = new System.Windows.Forms.Padding(11, 10, 11, 0);
            this.id.MaximumSize = new System.Drawing.Size(267, 21);
            this.id.MinimumSize = new System.Drawing.Size(23, 21);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(64, 21);
            this.id.TabIndex = 0;
            this.id.Text = "id";
            this.id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // code
            // 
            this.code.AutoEllipsis = true;
            this.code.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code.Location = new System.Drawing.Point(118, 20);
            this.code.Margin = new System.Windows.Forms.Padding(11, 10, 11, 0);
            this.code.MaximumSize = new System.Drawing.Size(267, 21);
            this.code.MinimumSize = new System.Drawing.Size(23, 21);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(85, 21);
            this.code.TabIndex = 1;
            this.code.Text = "code";
            this.code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // name
            // 
            this.name.AutoEllipsis = true;
            this.name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layout.SetFlowBreak(this.name, true);
            this.name.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(225, 20);
            this.name.Margin = new System.Windows.Forms.Padding(11, 10, 11, 0);
            this.name.MaximumSize = new System.Drawing.Size(6667, 21);
            this.name.MinimumSize = new System.Drawing.Size(43, 21);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(295, 21);
            this.name.TabIndex = 2;
            this.name.Text = "name";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bsf
            // 
            this.bsf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bsf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bsf.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bsf.Location = new System.Drawing.Point(542, 15);
            this.bsf.Margin = new System.Windows.Forms.Padding(11, 5, 11, 5);
            this.bsf.MinimumSize = new System.Drawing.Size(159, 24);
            this.bsf.Name = "bsf";
            this.bsf.Size = new System.Drawing.Size(159, 29);
            this.bsf.TabIndex = 4;
            this.bsf.Text = "0.00";
            this.bsf.TextChanged += new System.EventHandler(this.Label_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 61);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(719, 59);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(21, 10, 21, 10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(720, 59);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(11, 10, 11, 0);
            this.label1.MaximumSize = new System.Drawing.Size(267, 21);
            this.label1.MinimumSize = new System.Drawing.Size(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(118, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(11, 10, 11, 0);
            this.label2.MaximumSize = new System.Drawing.Size(267, 21);
            this.label2.MinimumSize = new System.Drawing.Size(23, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "CODE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flowLayoutPanel1.SetFlowBreak(this.label3, true);
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(225, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(11, 10, 11, 0);
            this.label3.MaximumSize = new System.Drawing.Size(6667, 21);
            this.label3.MinimumSize = new System.Drawing.Size(43, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "NAME";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(542, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(11, 10, 11, 0);
            this.label4.MaximumSize = new System.Drawing.Size(267, 21);
            this.label4.MinimumSize = new System.Drawing.Size(23, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "GSF";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LocationsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 357);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LocationsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Table.ResumeLayout(false);
            this.layout.ResumeLayout(false);
            this.layout.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button SaveChanges;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel Table;
        private System.Windows.Forms.FlowLayoutPanel layout;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label code;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bsf;
    }
}