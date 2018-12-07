namespace DataSmith
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
            this.inputButton1 = new C1.Win.C1InputPanel.InputButton();
            this.inputButton2 = new C1.Win.C1InputPanel.InputButton();
            this.inputButton3 = new C1.Win.C1InputPanel.InputButton();
            this.inputButton4 = new C1.Win.C1InputPanel.InputButton();
            this.inputButton5 = new C1.Win.C1InputPanel.InputButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel1.Items.Add(this.inputButton1);
            this.c1InputPanel1.Items.Add(this.inputButton2);
            this.c1InputPanel1.Items.Add(this.inputButton3);
            this.c1InputPanel1.Items.Add(this.inputButton4);
            this.c1InputPanel1.Items.Add(this.inputButton5);
            this.c1InputPanel1.Location = new System.Drawing.Point(0, 0);
            this.c1InputPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(936, 66);
            this.c1InputPanel1.TabIndex = 0;
            this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            // 
            // inputButton1
            // 
            this.inputButton1.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton1.Height = 60;
            this.inputButton1.ImageSize = new System.Drawing.Size(32, 32);
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.TabStop = false;
            this.inputButton1.Text = "数据源";
            this.inputButton1.Width = 180;
            this.inputButton1.Click += new System.EventHandler(this.InputButton_Click1);
            // 
            // inputButton2
            // 
            this.inputButton2.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton2.Height = 60;
            this.inputButton2.ImageSize = new System.Drawing.Size(32, 32);
            this.inputButton2.Name = "inputButton2";
            this.inputButton2.TabStop = false;
            this.inputButton2.Text = "视图定义";
            this.inputButton2.Width = 180;
            this.inputButton2.Click += new System.EventHandler(this.InputButton_Click2);
            // 
            // inputButton3
            // 
            this.inputButton3.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton3.Height = 60;
            this.inputButton3.ImageSize = new System.Drawing.Size(32, 32);
            this.inputButton3.Name = "inputButton3";
            this.inputButton3.TabStop = false;
            this.inputButton3.Text = "字段映射";
            this.inputButton3.Width = 180;
            this.inputButton3.Click += new System.EventHandler(this.InputButton_Click3);
            // 
            // inputButton4
            // 
            this.inputButton4.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton4.Height = 60;
            this.inputButton4.ImageSize = new System.Drawing.Size(32, 32);
            this.inputButton4.Name = "inputButton4";
            this.inputButton4.TabStop = false;
            this.inputButton4.Text = "接口调试";
            this.inputButton4.Width = 180;
            this.inputButton4.Click += new System.EventHandler(this.InputButton_Click4);
            // 
            // inputButton5
            // 
            this.inputButton5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton5.Height = 60;
            this.inputButton5.ImageSize = new System.Drawing.Size(32, 32);
            this.inputButton5.Name = "inputButton5";
            this.inputButton5.TabStop = false;
            this.inputButton5.Text = "退出系统";
            this.inputButton5.Width = 180;
            this.inputButton5.Click += new System.EventHandler(this.InputButton_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 485);
            this.panel1.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 551);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c1InputPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataSmith";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1InputPanel.InputButton inputButton1;
        private C1.Win.C1InputPanel.InputButton inputButton2;
        private C1.Win.C1InputPanel.InputButton inputButton3;
        private C1.Win.C1InputPanel.InputButton inputButton4;
        private C1.Win.C1InputPanel.InputButton inputButton5;
    }
}