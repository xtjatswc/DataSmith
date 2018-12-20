namespace DataSmith.Setting
{
    partial class FormSetting1
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
            this.inputGroupHeader1 = new C1.Win.C1InputPanel.InputGroupHeader();
            this.inputLabel2 = new C1.Win.C1InputPanel.InputLabel();
            this.inputLabel3 = new C1.Win.C1InputPanel.InputLabel();
            this.inputTextBox1 = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel1 = new C1.Win.C1InputPanel.InputLabel();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.Location = new System.Drawing.Point(0, 172);
            this.c1InputPanel1.Size = new System.Drawing.Size(499, 55);
            // 
            // c1InputPanel2
            // 
            this.c1InputPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1InputPanel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel2.Items.Add(this.inputGroupHeader1);
            this.c1InputPanel2.Items.Add(this.inputLabel2);
            this.c1InputPanel2.Items.Add(this.inputLabel3);
            this.c1InputPanel2.Items.Add(this.inputTextBox1);
            this.c1InputPanel2.Items.Add(this.inputLabel1);
            this.c1InputPanel2.Location = new System.Drawing.Point(0, 0);
            this.c1InputPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.c1InputPanel2.Name = "c1InputPanel2";
            this.c1InputPanel2.Size = new System.Drawing.Size(499, 172);
            this.c1InputPanel2.TabIndex = 1;
            this.c1InputPanel2.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            this.c1InputPanel2.Click += new System.EventHandler(this.c1InputPanel2_Click);
            // 
            // inputGroupHeader1
            // 
            this.inputGroupHeader1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputGroupHeader1.Name = "inputGroupHeader1";
            this.inputGroupHeader1.Text = "字段名称";
            // 
            // inputLabel2
            // 
            this.inputLabel2.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.inputLabel2.Height = 32;
            this.inputLabel2.Name = "inputLabel2";
            this.inputLabel2.Text = "Label";
            this.inputLabel2.Visibility = C1.Win.C1InputPanel.Visibility.Hidden;
            this.inputLabel2.Width = 79;
            // 
            // inputLabel3
            // 
            this.inputLabel3.Break = C1.Win.C1InputPanel.BreakType.Column;
            this.inputLabel3.Height = 30;
            this.inputLabel3.Name = "inputLabel3";
            this.inputLabel3.Text = "Label";
            this.inputLabel3.Visibility = C1.Win.C1InputPanel.Visibility.Hidden;
            this.inputLabel3.Width = 39;
            // 
            // inputTextBox1
            // 
            this.inputTextBox1.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputTextBox1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputTextBox1.Name = "inputTextBox1";
            // 
            // inputLabel1
            // 
            this.inputLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputLabel1.Name = "inputLabel1";
            this.inputLabel1.Text = "Label";
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 227);
            this.Controls.Add(this.c1InputPanel2);
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "FormSetting";
            this.Text = "字段设置";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.Controls.SetChildIndex(this.c1InputPanel1, 0);
            this.Controls.SetChildIndex(this.c1InputPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel2;
        private C1.Win.C1InputPanel.InputGroupHeader inputGroupHeader1;
        private C1.Win.C1InputPanel.InputLabel inputLabel2;
        private C1.Win.C1InputPanel.InputLabel inputLabel3;
        private C1.Win.C1InputPanel.InputTextBox inputTextBox1;
        private C1.Win.C1InputPanel.InputLabel inputLabel1;
    }
}