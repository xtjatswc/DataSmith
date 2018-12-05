﻿namespace DataSmith.Util
{
    partial class FormCmd
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
            this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
            this.inputLabel1 = new C1.Win.C1InputPanel.InputLabel();
            this.txtCommand = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel2 = new C1.Win.C1InputPanel.InputLabel();
            this.txtParameter = new C1.Win.C1InputPanel.InputTextBox();
            this.inputButton1 = new C1.Win.C1InputPanel.InputButton();
            this.inputButton3 = new C1.Win.C1InputPanel.InputButton();
            this.inputButton4 = new C1.Win.C1InputPanel.InputButton();
            this.txtOutPutInfo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel1.Items.Add(this.inputLabel1);
            this.c1InputPanel1.Items.Add(this.txtCommand);
            this.c1InputPanel1.Items.Add(this.inputLabel2);
            this.c1InputPanel1.Items.Add(this.txtParameter);
            this.c1InputPanel1.Items.Add(this.inputButton1);
            this.c1InputPanel1.Items.Add(this.inputButton3);
            this.c1InputPanel1.Items.Add(this.inputButton4);
            this.c1InputPanel1.Location = new System.Drawing.Point(10, 10);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.c1InputPanel1.Size = new System.Drawing.Size(1182, 116);
            this.c1InputPanel1.TabIndex = 0;
            this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Black;
            // 
            // inputLabel1
            // 
            this.inputLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputLabel1.Name = "inputLabel1";
            this.inputLabel1.Text = "命令：";
            this.inputLabel1.Width = 85;
            // 
            // txtCommand
            // 
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.TabStop = false;
            this.txtCommand.Width = 680;
            // 
            // inputLabel2
            // 
            this.inputLabel2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputLabel2.Name = "inputLabel2";
            this.inputLabel2.Text = "参数：";
            this.inputLabel2.Width = 85;
            // 
            // txtParameter
            // 
            this.txtParameter.Break = C1.Win.C1InputPanel.BreakType.None;
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.TabStop = false;
            this.txtParameter.Width = 680;
            // 
            // inputButton1
            // 
            this.inputButton1.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.TabStop = false;
            this.inputButton1.Text = "开始执行";
            this.inputButton1.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // inputButton3
            // 
            this.inputButton3.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton3.Name = "inputButton3";
            this.inputButton3.TabStop = false;
            this.inputButton3.Text = "清空输出";
            this.inputButton3.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // inputButton4
            // 
            this.inputButton4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton4.Name = "inputButton4";
            this.inputButton4.TabStop = false;
            this.inputButton4.Text = "关闭窗口";
            this.inputButton4.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtOutPutInfo
            // 
            this.txtOutPutInfo.BackColor = System.Drawing.SystemColors.Menu;
            this.txtOutPutInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutPutInfo.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutPutInfo.ForeColor = System.Drawing.Color.Black;
            this.txtOutPutInfo.Location = new System.Drawing.Point(10, 126);
            this.txtOutPutInfo.Name = "txtOutPutInfo";
            this.txtOutPutInfo.ReadOnly = true;
            this.txtOutPutInfo.Size = new System.Drawing.Size(1182, 531);
            this.txtOutPutInfo.TabIndex = 1;
            this.txtOutPutInfo.Text = "";
            // 
            // FormCmd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 667);
            this.Controls.Add(this.txtOutPutInfo);
            this.Controls.Add(this.c1InputPanel1);
            this.Name = "FormCmd";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.Text = "命令窗口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCmd_FormClosing);
            this.Load += new System.EventHandler(this.FormCmd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private C1.Win.C1InputPanel.InputTextBox txtCommand;
        private C1.Win.C1InputPanel.InputButton inputButton1;
        private System.Windows.Forms.RichTextBox txtOutPutInfo;
        private C1.Win.C1InputPanel.InputLabel inputLabel1;
        private C1.Win.C1InputPanel.InputLabel inputLabel2;
        private C1.Win.C1InputPanel.InputTextBox txtParameter;
        private C1.Win.C1InputPanel.InputButton inputButton3;
        private C1.Win.C1InputPanel.InputButton inputButton4;
    }
}