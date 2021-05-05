namespace ExcelToAzure
{
    partial class DataSelection
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
            this.title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.checkedList = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.results = new System.Windows.Forms.Label();
            this.selected = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Dock = System.Windows.Forms.DockStyle.Top;
            this.title.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(32, 0);
            this.title.Margin = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(417, 32);
            this.title.TabIndex = 1;
            this.title.Text = "LINK EXCEL COLUMNS TO DATA 1/20";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.next);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(32, 392);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MaximumSize = new System.Drawing.Size(10000, 42);
            this.panel1.MinimumSize = new System.Drawing.Size(600, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 42);
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
            this.next.Location = new System.Drawing.Point(659, 0);
            this.next.Margin = new System.Windows.Forms.Padding(0);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(77, 42);
            this.next.TabIndex = 3;
            this.next.Text = "NEXT";
            this.next.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.searchBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.checkAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(32, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(24);
            this.panel2.MaximumSize = new System.Drawing.Size(1000000, 93);
            this.panel2.MinimumSize = new System.Drawing.Size(500, 69);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 32, 0, 8);
            this.panel2.Size = new System.Drawing.Size(736, 69);
            this.panel2.TabIndex = 5;
            // 
            // searchBox
            // 
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.searchBox.Location = new System.Drawing.Point(134, 32);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(602, 29);
            this.searchBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "SEARCH";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkAll.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.checkAll.Location = new System.Drawing.Point(3, 32);
            this.checkAll.Margin = new System.Windows.Forms.Padding(24);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(61, 29);
            this.checkAll.TabIndex = 7;
            this.checkAll.Text = "ALL";
            this.checkAll.UseVisualStyleBackColor = true;
            // 
            // checkedList
            // 
            this.checkedList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedList.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.checkedList.FormattingEnabled = true;
            this.checkedList.Location = new System.Drawing.Point(32, 138);
            this.checkedList.Name = "checkedList";
            this.checkedList.Size = new System.Drawing.Size(736, 254);
            this.checkedList.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.results);
            this.panel3.Controls.Add(this.selected);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(32, 101);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3, 8, 0, 8);
            this.panel3.Size = new System.Drawing.Size(736, 37);
            this.panel3.TabIndex = 7;
            // 
            // results
            // 
            this.results.Dock = System.Windows.Forms.DockStyle.Right;
            this.results.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.results.Location = new System.Drawing.Point(487, 8);
            this.results.Margin = new System.Windows.Forms.Padding(0);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(249, 21);
            this.results.TabIndex = 6;
            this.results.Text = "RESULTS";
            this.results.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // selected
            // 
            this.selected.Dock = System.Windows.Forms.DockStyle.Left;
            this.selected.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selected.Location = new System.Drawing.Point(3, 8);
            this.selected.Margin = new System.Windows.Forms.Padding(0);
            this.selected.Name = "selected";
            this.selected.Size = new System.Drawing.Size(301, 21);
            this.selected.TabIndex = 5;
            this.selected.Text = "SELECTED";
            this.selected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.checkedList);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.title);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DataSelection";
            this.Padding = new System.Windows.Forms.Padding(32, 0, 32, 16);
            this.Text = "DataSelection";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label results;
        private System.Windows.Forms.Label selected;
    }
}