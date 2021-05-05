namespace ExcelToAzure
{
    partial class Data
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
            this.label1 = new System.Windows.Forms.Label();
            this.numberPanel = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.selected = new System.Windows.Forms.Label();
            this.propertyPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.propertyList = new System.Windows.Forms.CheckedListBox();
            this.numberList = new System.Windows.Forms.CheckedListBox();
            this.numberPanel.SuspendLayout();
            this.propertyPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "SELECT NUMBER VALUE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numberPanel
            // 
            this.numberPanel.Controls.Add(this.numberList);
            this.numberPanel.Controls.Add(this.label1);
            this.numberPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberPanel.Location = new System.Drawing.Point(332, 32);
            this.numberPanel.MinimumSize = new System.Drawing.Size(200, 0);
            this.numberPanel.Name = "numberPanel";
            this.numberPanel.Size = new System.Drawing.Size(236, 527);
            this.numberPanel.TabIndex = 5;
            // 
            // title
            // 
            this.title.Dock = System.Windows.Forms.DockStyle.Top;
            this.title.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(32, 0);
            this.title.Margin = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.title.MinimumSize = new System.Drawing.Size(0, 32);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(536, 32);
            this.title.TabIndex = 3;
            this.title.Text = "EXPORT TO EXCELL";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selected
            // 
            this.selected.Dock = System.Windows.Forms.DockStyle.Top;
            this.selected.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selected.Location = new System.Drawing.Point(0, 0);
            this.selected.Margin = new System.Windows.Forms.Padding(0);
            this.selected.Name = "selected";
            this.selected.Size = new System.Drawing.Size(300, 21);
            this.selected.TabIndex = 6;
            this.selected.Text = "SELECT PROPERTY VALUE";
            this.selected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // propertyPanel
            // 
            this.propertyPanel.Controls.Add(this.propertyList);
            this.propertyPanel.Controls.Add(this.selected);
            this.propertyPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.propertyPanel.Location = new System.Drawing.Point(32, 32);
            this.propertyPanel.Margin = new System.Windows.Forms.Padding(0);
            this.propertyPanel.MinimumSize = new System.Drawing.Size(300, 300);
            this.propertyPanel.Name = "propertyPanel";
            this.propertyPanel.Size = new System.Drawing.Size(300, 527);
            this.propertyPanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.next);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(32, 559);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MaximumSize = new System.Drawing.Size(10000, 42);
            this.panel1.MinimumSize = new System.Drawing.Size(300, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 42);
            this.panel1.TabIndex = 6;
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
            this.back.Click += new System.EventHandler(this.back_Click);
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
            this.next.Location = new System.Drawing.Point(459, 0);
            this.next.Margin = new System.Windows.Forms.Padding(0);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(77, 42);
            this.next.TabIndex = 3;
            this.next.Text = "NEXT";
            this.next.UseVisualStyleBackColor = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // propertyList
            // 
            this.propertyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyList.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.propertyList.FormattingEnabled = true;
            this.propertyList.Location = new System.Drawing.Point(0, 21);
            this.propertyList.Name = "propertyList";
            this.propertyList.Size = new System.Drawing.Size(300, 506);
            this.propertyList.TabIndex = 8;
            // 
            // numberList
            // 
            this.numberList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberList.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.numberList.FormattingEnabled = true;
            this.numberList.Location = new System.Drawing.Point(0, 21);
            this.numberList.Name = "numberList";
            this.numberList.Size = new System.Drawing.Size(236, 506);
            this.numberList.TabIndex = 8;
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(600, 617);
            this.ControlBox = false;
            this.Controls.Add(this.numberPanel);
            this.Controls.Add(this.propertyPanel);
            this.Controls.Add(this.title);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Data";
            this.Padding = new System.Windows.Forms.Padding(32, 0, 32, 16);
            this.Text = "Data";
            this.numberPanel.ResumeLayout(false);
            this.propertyPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel numberPanel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label selected;
        private System.Windows.Forms.Panel propertyPanel;
        private System.Windows.Forms.CheckedListBox numberList;
        private System.Windows.Forms.CheckedListBox propertyList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button next;
    }
}