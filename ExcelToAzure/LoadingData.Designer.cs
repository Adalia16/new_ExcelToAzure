﻿namespace ExcelToAzure
{
    partial class LoadingData
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.next = new System.Windows.Forms.Button();
            this.subtitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Dock = System.Windows.Forms.DockStyle.Top;
            this.title.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(43, 39);
            this.title.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(981, 39);
            this.title.TabIndex = 2;
            this.title.Text = "LOADING DATA";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(43, 201);
            this.progressBar.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar.MaximumSize = new System.Drawing.Size(13333, 74);
            this.progressBar.MinimumSize = new System.Drawing.Size(533, 49);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(981, 74);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 3;
            this.progressBar.Value = 50;
            // 
            // next
            // 
            this.next.AutoSize = true;
            this.next.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.next.BackColor = System.Drawing.Color.CadetBlue;
            this.next.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.next.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next.ForeColor = System.Drawing.Color.White;
            this.next.Location = new System.Drawing.Point(43, 466);
            this.next.Margin = new System.Windows.Forms.Padding(0);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(981, 49);
            this.next.TabIndex = 4;
            this.next.Text = "NEXT";
            this.next.UseVisualStyleBackColor = false;
            // 
            // subtitle
            // 
            this.subtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.subtitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitle.Location = new System.Drawing.Point(43, 78);
            this.subtitle.Margin = new System.Windows.Forms.Padding(32, 30, 32, 30);
            this.subtitle.MinimumSize = new System.Drawing.Size(533, 123);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(981, 123);
            this.subtitle.TabIndex = 6;
            this.subtitle.Text = "Loading Some Data";
            this.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadingData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.subtitle);
            this.Controls.Add(this.next);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoadingData";
            this.Padding = new System.Windows.Forms.Padding(43, 39, 43, 39);
            this.Text = "LoadingData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Label subtitle;
    }
}