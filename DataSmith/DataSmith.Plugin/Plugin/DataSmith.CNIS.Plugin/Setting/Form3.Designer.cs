﻿/*
 * 用户： zxs
 * 日期: 2018/12/6
 * 时间: 10:00
 */
namespace DataSmith.CNIS.Plugin.Setting
{
	partial class Form3
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
		private C1.Win.C1InputPanel.InputLabel inputLabel1;
		private C1.Win.C1InputPanel.InputButton inputButton1;
		private C1.Win.C1InputPanel.InputLabel inputLabel2;
		private C1.Win.C1InputPanel.InputDatePicker inputDatePicker1;
		private C1.Win.C1InputPanel.InputDatePicker inputDatePicker2;
		private C1.Win.C1InputPanel.InputLabel inputLabel3;
		
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
			this.inputLabel1 = new C1.Win.C1InputPanel.InputLabel();
			this.inputDatePicker1 = new C1.Win.C1InputPanel.InputDatePicker();
			this.inputLabel3 = new C1.Win.C1InputPanel.InputLabel();
			this.inputDatePicker2 = new C1.Win.C1InputPanel.InputDatePicker();
			this.inputButton1 = new C1.Win.C1InputPanel.InputButton();
			this.inputLabel2 = new C1.Win.C1InputPanel.InputLabel();
			((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
			this.SuspendLayout();
			// 
			// c1InputPanel1
			// 
			this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
			this.c1InputPanel1.Items.Add(this.inputLabel1);
			this.c1InputPanel1.Items.Add(this.inputDatePicker1);
			this.c1InputPanel1.Items.Add(this.inputLabel3);
			this.c1InputPanel1.Items.Add(this.inputDatePicker2);
			this.c1InputPanel1.Items.Add(this.inputButton1);
			this.c1InputPanel1.Items.Add(this.inputLabel2);
			this.c1InputPanel1.Location = new System.Drawing.Point(0, 0);
			this.c1InputPanel1.Name = "c1InputPanel1";
			this.c1InputPanel1.Size = new System.Drawing.Size(649, 618);
			this.c1InputPanel1.TabIndex = 1;
			this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
			// 
			// inputLabel1
			// 
			this.inputLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.inputLabel1.Name = "inputLabel1";
			this.inputLabel1.Text = "时间范围：";
			// 
			// inputDatePicker1
			// 
			this.inputDatePicker1.Break = C1.Win.C1InputPanel.BreakType.None;
			this.inputDatePicker1.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.inputDatePicker1.Format = "yyyy-MM-dd";
			this.inputDatePicker1.Name = "inputDatePicker1";
			this.inputDatePicker1.Value = new System.DateTime(2018, 12, 6, 0, 0, 0, 0);
			this.inputDatePicker1.Width = 135;
			// 
			// inputLabel3
			// 
			this.inputLabel3.Name = "inputLabel3";
			this.inputLabel3.Text = "到";
			// 
			// inputDatePicker2
			// 
			this.inputDatePicker2.Break = C1.Win.C1InputPanel.BreakType.None;
			this.inputDatePicker2.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.inputDatePicker2.Format = "yyyy-MM-dd";
			this.inputDatePicker2.Name = "inputDatePicker2";
			this.inputDatePicker2.Value = new System.DateTime(2018, 12, 6, 0, 0, 0, 0);
			this.inputDatePicker2.Width = 135;
			// 
			// inputButton1
			// 
			this.inputButton1.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.inputButton1.Name = "inputButton1";
			this.inputButton1.TabStop = false;
			this.inputButton1.Text = "导入";
			this.inputButton1.Click += new System.EventHandler(this.InputButton1Click);
			// 
			// inputLabel2
			// 
			this.inputLabel2.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.inputLabel2.Name = "inputLabel2";
			this.inputLabel2.Text = "备注：导入时间范围内入院或出院的患者。";
			// 
			// Form3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(649, 618);
			this.Controls.Add(this.c1InputPanel1);
			this.Name = "Form3";
			this.Text = "Form3";
			((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
			this.ResumeLayout(false);

		}
	}
}