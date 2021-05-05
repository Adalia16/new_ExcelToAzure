namespace ExcelToAzure
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Dashboard = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.LoginMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DataMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dashboard
            // 
            this.Dashboard.AutoScroll = true;
            this.Dashboard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Dashboard.BackColor = System.Drawing.Color.White;
            this.Dashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dashboard.Location = new System.Drawing.Point(0, 106);
            this.Dashboard.Margin = new System.Windows.Forms.Padding(0);
            this.Dashboard.MinimumSize = new System.Drawing.Size(664, 400);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Size = new System.Drawing.Size(664, 400);
            this.Dashboard.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoginMenu,
            this.ImportMenu,
            this.DataMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.menuStrip1.Size = new System.Drawing.Size(664, 96);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // LoginMenu
            // 
            this.LoginMenu.AutoSize = false;
            this.LoginMenu.BackColor = System.Drawing.Color.Transparent;
            this.LoginMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginMenu.ForeColor = System.Drawing.Color.Black;
            this.LoginMenu.Image = ((System.Drawing.Image)(resources.GetObject("LoginMenu.Image")));
            this.LoginMenu.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.LoginMenu.Name = "LoginMenu";
            this.LoginMenu.Padding = new System.Windows.Forms.Padding(0);
            this.LoginMenu.Size = new System.Drawing.Size(128, 96);
            this.LoginMenu.Text = "Login";
            this.LoginMenu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LoginMenu.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.LoginMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LoginMenu.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ImportMenu
            // 
            this.ImportMenu.AutoSize = false;
            this.ImportMenu.BackColor = System.Drawing.Color.Transparent;
            this.ImportMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImportMenu.ForeColor = System.Drawing.Color.Black;
            this.ImportMenu.Image = ((System.Drawing.Image)(resources.GetObject("ImportMenu.Image")));
            this.ImportMenu.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ImportMenu.Name = "ImportMenu";
            this.ImportMenu.Padding = new System.Windows.Forms.Padding(0);
            this.ImportMenu.Size = new System.Drawing.Size(128, 96);
            this.ImportMenu.Text = "Import";
            this.ImportMenu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ImportMenu.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.ImportMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ImportMenu.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // DataMenu
            // 
            this.DataMenu.AutoSize = false;
            this.DataMenu.BackColor = System.Drawing.Color.Transparent;
            this.DataMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DataMenu.ForeColor = System.Drawing.Color.Black;
            this.DataMenu.Image = ((System.Drawing.Image)(resources.GetObject("DataMenu.Image")));
            this.DataMenu.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.DataMenu.Name = "DataMenu";
            this.DataMenu.Padding = new System.Windows.Forms.Padding(0);
            this.DataMenu.Size = new System.Drawing.Size(128, 96);
            this.DataMenu.Text = "Data";
            this.DataMenu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DataMenu.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.DataMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DataMenu.Click += new System.EventHandler(this.btnData_Click);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.progressBar.Location = new System.Drawing.Point(0, 96);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(664, 10);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 496);
            this.Controls.Add(this.Dashboard);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(680, 535);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Dashboard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DataMenu;
        private System.Windows.Forms.ToolStripMenuItem LoginMenu;
        private System.Windows.Forms.ToolStripMenuItem ImportMenu;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

