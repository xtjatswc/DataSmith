﻿/*
 * 用户： zxs
 * 日期: 2018/12/6
 * 时间: 10:00
 */
namespace DataSmith.CNIS.Plugin.Setting
{
	partial class Form0
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
		private C1.Win.C1InputPanel.InputButton inputButton1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
			this.inputButton1 = new C1.Win.C1InputPanel.InputButton();
			((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
			this.SuspendLayout();
			// 
			// c1InputPanel1
			// 
			this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
			this.c1InputPanel1.Items.Add(this.inputButton1);
			this.c1InputPanel1.Location = new System.Drawing.Point(0, 0);
			this.c1InputPanel1.Name = "c1InputPanel1";
			this.c1InputPanel1.Size = new System.Drawing.Size(649, 618);
			this.c1InputPanel1.TabIndex = 1;
			this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
			// 
			// inputButton1
			// 
			this.inputButton1.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.inputButton1.Name = "inputButton1";
			this.inputButton1.TabStop = false;
			this.inputButton1.Text = "导入";
			this.inputButton1.Width = 90;
			this.inputButton1.Click += new System.EventHandler(this.InputButton1Click);
			// 
			// Form0
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(649, 618);
			this.Controls.Add(this.c1InputPanel1);
			this.Name = "Form0";
			this.Text = "Form0";
			((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
