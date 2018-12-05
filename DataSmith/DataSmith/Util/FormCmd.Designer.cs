namespace DataSmith.Util
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
            this.btnExec = new C1.Win.C1InputPanel.InputButton();
            this.btnClear = new C1.Win.C1InputPanel.InputButton();
            this.btnClose = new C1.Win.C1InputPanel.InputButton();
            this.txtOutPutInfo = new System.Windows.Forms.RichTextBox();
            this.btnAbort = new C1.Win.C1InputPanel.InputButton();
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
            this.c1InputPanel1.Items.Add(this.btnExec);
            this.c1InputPanel1.Items.Add(this.btnAbort);
            this.c1InputPanel1.Items.Add(this.btnClear);
            this.c1InputPanel1.Items.Add(this.btnClose);
            this.c1InputPanel1.Location = new System.Drawing.Point(8, 8);
            this.c1InputPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.c1InputPanel1.Size = new System.Drawing.Size(1207, 93);
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
            // btnExec
            // 
            this.btnExec.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnExec.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExec.Name = "btnExec";
            this.btnExec.TabStop = false;
            this.btnExec.Text = "开始执行";
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // btnClear
            // 
            this.btnClear.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClear.Name = "btnClear";
            this.btnClear.TabStop = false;
            this.btnClear.Text = "清空输出";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Name = "btnClose";
            this.btnClose.TabStop = false;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtOutPutInfo
            // 
            this.txtOutPutInfo.BackColor = System.Drawing.SystemColors.Menu;
            this.txtOutPutInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutPutInfo.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutPutInfo.ForeColor = System.Drawing.Color.Black;
            this.txtOutPutInfo.Location = new System.Drawing.Point(8, 101);
            this.txtOutPutInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOutPutInfo.Name = "txtOutPutInfo";
            this.txtOutPutInfo.ReadOnly = true;
            this.txtOutPutInfo.Size = new System.Drawing.Size(1207, 470);
            this.txtOutPutInfo.TabIndex = 1;
            this.txtOutPutInfo.Text = "";
            // 
            // btnAbort
            // 
            this.btnAbort.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnAbort.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.TabStop = false;
            this.btnAbort.Text = "结束进程";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // FormCmd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 579);
            this.Controls.Add(this.txtOutPutInfo);
            this.Controls.Add(this.c1InputPanel1);
            this.Name = "FormCmd";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.ShowInTaskbar = false;
            this.Text = "命令窗口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormCmd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private C1.Win.C1InputPanel.InputTextBox txtCommand;
        private C1.Win.C1InputPanel.InputButton btnExec;
        private System.Windows.Forms.RichTextBox txtOutPutInfo;
        private C1.Win.C1InputPanel.InputLabel inputLabel1;
        private C1.Win.C1InputPanel.InputLabel inputLabel2;
        private C1.Win.C1InputPanel.InputTextBox txtParameter;
        private C1.Win.C1InputPanel.InputButton btnClear;
        private C1.Win.C1InputPanel.InputButton btnClose;
        private C1.Win.C1InputPanel.InputButton btnAbort;
    }
}