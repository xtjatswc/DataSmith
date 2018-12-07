namespace DataSmith.DbSource
{
    partial class FormDataSourceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataSourceList));
            this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
            this.inputButton1 = new C1.Win.C1InputPanel.InputButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.c1InputPanel2 = new C1.Win.C1InputPanel.C1InputPanel();
            this.inputButton2 = new C1.Win.C1InputPanel.InputButton();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel1.Items.Add(this.inputButton1);
            this.c1InputPanel1.Location = new System.Drawing.Point(0, 62);
            this.c1InputPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(192, 498);
            this.c1InputPanel1.TabIndex = 0;
            this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            // 
            // inputButton1
            // 
            this.inputButton1.Image = ((System.Drawing.Image)(resources.GetObject("inputButton1.Image")));
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.Text = "Button2222";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(192, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 560);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.c1InputPanel1);
            this.panel2.Controls.Add(this.c1InputPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 560);
            this.panel2.TabIndex = 2;
            // 
            // c1InputPanel2
            // 
            this.c1InputPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1InputPanel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel2.Items.Add(this.inputButton2);
            this.c1InputPanel2.Location = new System.Drawing.Point(0, 0);
            this.c1InputPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.c1InputPanel2.Name = "c1InputPanel2";
            this.c1InputPanel2.Size = new System.Drawing.Size(192, 62);
            this.c1InputPanel2.TabIndex = 0;
            this.c1InputPanel2.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            // 
            // inputButton2
            // 
            this.inputButton2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton2.Name = "inputButton2";
            this.inputButton2.TabStop = false;
            this.inputButton2.Text = "添加数据源";
            this.inputButton2.Width = 172;
            this.inputButton2.Click += new System.EventHandler(this.inputButton2_Click);
            // 
            // FormDataSourceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 560);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDataSourceList";
            this.Text = "FormDataSourceList";
            this.Load += new System.EventHandler(this.FormDataSourceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1InputPanel.InputButton inputButton1;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel2;
        private C1.Win.C1InputPanel.InputButton inputButton2;
    }
}