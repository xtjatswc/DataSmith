namespace DataSmith
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputButton1 = new C1.Win.C1InputPanel.InputButton();
            this.inputButton2 = new C1.Win.C1InputPanel.InputButton();
            this.inputButton3 = new C1.Win.C1InputPanel.InputButton();
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
            this.c1InputPanel1.Location = new System.Drawing.Point(0, 0);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(908, 99);
            this.c1InputPanel1.TabIndex = 0;
            this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 537);
            this.panel1.TabIndex = 1;
            // 
            // inputButton1
            // 
            this.inputButton1.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.inputButton1.Height = 73;
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.TabStop = false;
            this.inputButton1.Text = "数据源";
            this.inputButton1.Width = 174;
            // 
            // inputButton2
            // 
            this.inputButton2.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton2.Image = ((System.Drawing.Image)(resources.GetObject("inputButton2.Image")));
            this.inputButton2.Name = "inputButton2";
            this.inputButton2.Text = "Button";
            // 
            // inputButton3
            // 
            this.inputButton3.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton3.Image = ((System.Drawing.Image)(resources.GetObject("inputButton3.Image")));
            this.inputButton3.Name = "inputButton3";
            this.inputButton3.Text = "Button";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 636);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c1InputPanel1);
            this.Name = "Form5";
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
    }
}