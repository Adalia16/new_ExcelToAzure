namespace ExcelToAzure
{
    partial class ColumnSelection
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtColumnName = new System.Windows.Forms.Label();
            this.txtDataProperty = new System.Windows.Forms.Label();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.arrowlabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.title);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.ListBox);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(600, 376);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(32);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(664, 400);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(32, 32);
            this.title.Margin = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(417, 32);
            this.title.TabIndex = 1;
            this.title.Text = "LINK EXCEL COLUMNS TO DATA 1/20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "COLUMN FOR THIS DATA PROPERTY";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.arrowlabel);
            this.panel2.Controls.Add(this.txtColumnName);
            this.panel2.Controls.Add(this.txtDataProperty);
            this.panel2.Location = new System.Drawing.Point(32, 117);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panel2.MinimumSize = new System.Drawing.Size(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 25);
            this.panel2.TabIndex = 6;
            // 
            // txtColumnName
            // 
            this.txtColumnName.AutoSize = true;
            this.txtColumnName.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtColumnName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnName.ForeColor = System.Drawing.Color.Crimson;
            this.txtColumnName.Location = new System.Drawing.Point(440, 0);
            this.txtColumnName.Margin = new System.Windows.Forms.Padding(0);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(160, 25);
            this.txtColumnName.TabIndex = 6;
            this.txtColumnName.Text = "SELECT EXISTING";
            this.txtColumnName.Click += new System.EventHandler(this.txtColumnName_Click);
            // 
            // txtDataProperty
            // 
            this.txtDataProperty.AutoSize = true;
            this.txtDataProperty.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDataProperty.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataProperty.Location = new System.Drawing.Point(0, 0);
            this.txtDataProperty.Margin = new System.Windows.Forms.Padding(0);
            this.txtDataProperty.Name = "txtDataProperty";
            this.txtDataProperty.Size = new System.Drawing.Size(160, 25);
            this.txtDataProperty.TabIndex = 5;
            this.txtDataProperty.Text = "SELECT EXISTING";
            // 
            // ListBox
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.ListBox, true);
            this.ListBox.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.ListBox.FormattingEnabled = true;
            this.ListBox.ItemHeight = 25;
            this.ListBox.Location = new System.Drawing.Point(32, 150);
            this.ListBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(600, 129);
            this.ListBox.TabIndex = 2;
            this.ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.next);
            this.panel1.Location = new System.Drawing.Point(32, 303);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MaximumSize = new System.Drawing.Size(10000, 42);
            this.panel1.MinimumSize = new System.Drawing.Size(600, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 42);
            this.panel1.TabIndex = 4;
            // 
            // back
            // 
            this.back.AutoSize = true;
            this.back.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.back.Dock = System.Windows.Forms.DockStyle.Left;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(0, 0);
            this.back.Margin = new System.Windows.Forms.Padding(0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(78, 42);
            this.back.TabIndex = 2;
            this.back.Text = "BACK";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.cancel_Click);
            // 
            // next
            // 
            this.next.AutoSize = true;
            this.next.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.next.BackColor = System.Drawing.Color.CadetBlue;
            this.next.Dock = System.Windows.Forms.DockStyle.Right;
            this.next.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next.ForeColor = System.Drawing.Color.White;
            this.next.Location = new System.Drawing.Point(523, 0);
            this.next.Margin = new System.Windows.Forms.Padding(0);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(77, 42);
            this.next.TabIndex = 3;
            this.next.Text = "NEXT";
            this.next.UseVisualStyleBackColor = false;
            this.next.Click += new System.EventHandler(this.create_Click);
            // 
            // arrowlabel
            // 
            this.arrowlabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arrowlabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.arrowlabel.Location = new System.Drawing.Point(160, 0);
            this.arrowlabel.Margin = new System.Windows.Forms.Padding(0);
            this.arrowlabel.Name = "arrowlabel";
            this.arrowlabel.Size = new System.Drawing.Size(280, 25);
            this.arrowlabel.TabIndex = 7;
            this.arrowlabel.Text = "-------------->";
            this.arrowlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColumnSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 400);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(664, 400);
            this.Name = "ColumnSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PhaseSelection_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.ListBox ListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtDataProperty;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtColumnName;
        private System.Windows.Forms.Label arrowlabel;
    }
}