namespace DataSmith.Interface
{
    partial class FormFieldMapping
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
            this.c1InputPanel2 = new C1.Win.C1InputPanel.C1InputPanel();
            this.interfaceNav1 = new DataSmith.Interface.InterfaceNav();
            this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
            this.inputButton1 = new C1.Win.C1InputPanel.InputButton();
            this.inputGroupHeader1 = new C1.Win.C1InputPanel.InputGroupHeader();
            this.inputLabel1 = new C1.Win.C1InputPanel.InputLabel();
            this.inputLabel2 = new C1.Win.C1InputPanel.InputLabel();
            this.inputLabel3 = new C1.Win.C1InputPanel.InputLabel();
            this.inputLabel4 = new C1.Win.C1InputPanel.InputLabel();
            this.inputSeparator1 = new C1.Win.C1InputPanel.InputSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1InputPanel2
            // 
            this.c1InputPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1InputPanel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel2.Location = new System.Drawing.Point(285, 120);
            this.c1InputPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.c1InputPanel2.MouseWheelEdit = false;
            this.c1InputPanel2.Name = "c1InputPanel2";
            this.c1InputPanel2.Size = new System.Drawing.Size(1338, 484);
            this.c1InputPanel2.TabIndex = 1;
            this.c1InputPanel2.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            // 
            // interfaceNav1
            // 
            this.interfaceNav1.Dock = System.Windows.Forms.DockStyle.Left;
            this.interfaceNav1.Location = new System.Drawing.Point(0, 0);
            this.interfaceNav1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.interfaceNav1.Name = "interfaceNav1";
            this.interfaceNav1.Size = new System.Drawing.Size(285, 604);
            this.interfaceNav1.TabIndex = 2;
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel1.Items.Add(this.inputButton1);
            this.c1InputPanel1.Items.Add(this.inputGroupHeader1);
            this.c1InputPanel1.Items.Add(this.inputLabel1);
            this.c1InputPanel1.Items.Add(this.inputLabel2);
            this.c1InputPanel1.Items.Add(this.inputLabel3);
            this.c1InputPanel1.Items.Add(this.inputLabel4);
            this.c1InputPanel1.Items.Add(this.inputSeparator1);
            this.c1InputPanel1.Location = new System.Drawing.Point(285, 0);
            this.c1InputPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(1338, 120);
            this.c1InputPanel1.TabIndex = 3;
            this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            // 
            // inputButton1
            // 
            this.inputButton1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.TabStop = false;
            this.inputButton1.Text = "保存";
            this.inputButton1.Width = 90;
            this.inputButton1.Click += new System.EventHandler(this.inputButton1_Click);
            // 
            // inputGroupHeader1
            // 
            this.inputGroupHeader1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputGroupHeader1.Name = "inputGroupHeader1";
            // 
            // inputLabel1
            // 
            this.inputLabel1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.inputLabel1.Name = "inputLabel1";
            this.inputLabel1.Text = "字段名";
            this.inputLabel1.Width = 200;
            // 
            // inputLabel2
            // 
            this.inputLabel2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.inputLabel2.Name = "inputLabel2";
            this.inputLabel2.Text = "中文字段名";
            this.inputLabel2.Width = 200;
            // 
            // inputLabel3
            // 
            this.inputLabel3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.inputLabel3.Name = "inputLabel3";
            this.inputLabel3.Text = "字段备注";
            this.inputLabel3.Width = 300;
            // 
            // inputLabel4
            // 
            this.inputLabel4.Break = C1.Win.C1InputPanel.BreakType.Row;
            this.inputLabel4.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.inputLabel4.Name = "inputLabel4";
            this.inputLabel4.Text = "视图字段名";
            this.inputLabel4.Width = 200;
            // 
            // inputSeparator1
            // 
            this.inputSeparator1.Name = "inputSeparator1";
            this.inputSeparator1.Width = 1200;
            // 
            // FormFieldMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1623, 604);
            this.Controls.Add(this.c1InputPanel2);
            this.Controls.Add(this.c1InputPanel1);
            this.Controls.Add(this.interfaceNav1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormFieldMapping";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel2;
        private Interface.InterfaceNav interfaceNav1;
        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private C1.Win.C1InputPanel.InputButton inputButton1;
        private C1.Win.C1InputPanel.InputGroupHeader inputGroupHeader1;
        private C1.Win.C1InputPanel.InputLabel inputLabel1;
        private C1.Win.C1InputPanel.InputLabel inputLabel2;
        private C1.Win.C1InputPanel.InputLabel inputLabel3;
        private C1.Win.C1InputPanel.InputLabel inputLabel4;
        private C1.Win.C1InputPanel.InputSeparator inputSeparator1;
    }
}