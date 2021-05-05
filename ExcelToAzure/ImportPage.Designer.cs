namespace ExcelToAzure
{
    partial class ImportPage
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
            this.CreateNewCompany = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.layout = new System.Windows.Forms.FlowLayoutPanel();
            this.id = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.Table.SuspendLayout();
            this.layout.SuspendLayout();
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
            this.labelTitle.MaximumSize = new System.Drawing.Size(5000, 50);
            this.labelTitle.MinimumSize = new System.Drawing.Size(50, 50);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(334, 50);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Select Project to Import Data";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CreateNewCompany
            // 
            this.CreateNewCompany.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateNewCompany.BackColor = System.Drawing.Color.CadetBlue;
            this.CreateNewCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateNewCompany.Dock = System.Windows.Forms.DockStyle.Right;
            this.CreateNewCompany.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.CreateNewCompany.FlatAppearance.BorderSize = 0;
            this.CreateNewCompany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.CreateNewCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateNewCompany.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewCompany.ForeColor = System.Drawing.Color.White;
            this.CreateNewCompany.Location = new System.Drawing.Point(378, 0);
            this.CreateNewCompany.Margin = new System.Windows.Forms.Padding(0);
            this.CreateNewCompany.MaximumSize = new System.Drawing.Size(500, 50);
            this.CreateNewCompany.MinimumSize = new System.Drawing.Size(50, 50);
            this.CreateNewCompany.Name = "CreateNewCompany";
            this.CreateNewCompany.Size = new System.Drawing.Size(160, 50);
            this.CreateNewCompany.TabIndex = 1;
            this.CreateNewCompany.TabStop = false;
            this.CreateNewCompany.Text = "Create New Project";
            this.CreateNewCompany.UseVisualStyleBackColor = false;
            this.CreateNewCompany.Click += new System.EventHandler(this.CreateNewCompany_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.CreateNewCompany);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MaximumSize = new System.Drawing.Size(5000, 50);
            this.panel1.MinimumSize = new System.Drawing.Size(500, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 50);
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
            this.Table.Location = new System.Drawing.Point(0, 50);
            this.Table.Margin = new System.Windows.Forms.Padding(0);
            this.Table.Name = "Table";
            this.Table.RowCount = 1;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.Table.Size = new System.Drawing.Size(540, 240);
            this.Table.TabIndex = 3;
            // 
            // layout
            // 
            this.layout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.layout.Controls.Add(this.id);
            this.layout.Controls.Add(this.name);
            this.layout.Controls.Add(this.description);
            this.layout.Controls.Add(this.type);
            this.layout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Margin = new System.Windows.Forms.Padding(0);
            this.layout.MinimumSize = new System.Drawing.Size(540, 48);
            this.layout.Name = "layout";
            this.layout.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.layout.Size = new System.Drawing.Size(540, 240);
            this.layout.TabIndex = 0;
            this.layout.WrapContents = false;
            // 
            // id
            // 
            this.id.AutoEllipsis = true;
            this.id.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(24, 16);
            this.id.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.id.MaximumSize = new System.Drawing.Size(200, 17);
            this.id.MinimumSize = new System.Drawing.Size(17, 17);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(48, 17);
            this.id.TabIndex = 0;
            this.id.Text = "id";
            this.id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // name
            // 
            this.name.AutoEllipsis = true;
            this.name.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(88, 16);
            this.name.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.name.MaximumSize = new System.Drawing.Size(200, 17);
            this.name.MinimumSize = new System.Drawing.Size(17, 17);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(64, 17);
            this.name.TabIndex = 1;
            this.name.Text = "name";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // description
            // 
            this.description.AutoEllipsis = true;
            this.description.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layout.SetFlowBreak(this.description, true);
            this.description.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(168, 16);
            this.description.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.description.MaximumSize = new System.Drawing.Size(5000, 17);
            this.description.MinimumSize = new System.Drawing.Size(32, 17);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(221, 17);
            this.description.TabIndex = 2;
            this.description.Text = "description description description ";
            this.description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // type
            // 
            this.type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.type.AutoEllipsis = true;
            this.type.AutoSize = true;
            this.type.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.type.Location = new System.Drawing.Point(405, 16);
            this.type.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.type.MaximumSize = new System.Drawing.Size(200, 17);
            this.type.MinimumSize = new System.Drawing.Size(17, 17);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(35, 17);
            this.type.TabIndex = 3;
            this.type.Text = "type";
            this.type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImportPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 290);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ImportPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Table.ResumeLayout(false);
            this.layout.ResumeLayout(false);
            this.layout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button CreateNewCompany;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel Table;
        private System.Windows.Forms.FlowLayoutPanel layout;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label type;
        private System.Windows.Forms.Label description;
    }
}