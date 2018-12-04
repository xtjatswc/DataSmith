namespace DataSmith
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFieldMapping));
            this.c1InputPanel2 = new C1.Win.C1InputPanel.C1InputPanel();
            this.inputComboBox1 = new C1.Win.C1InputPanel.InputComboBox();
            this.interfaceNav1 = new DataSmith.Interface.InterfaceNav();
            this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
            this.inputButton1 = new C1.Win.C1InputPanel.InputButton();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1InputPanel2
            // 
            this.c1InputPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1InputPanel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel2.Items.Add(this.inputComboBox1);
            this.c1InputPanel2.Location = new System.Drawing.Point(263, 82);
            this.c1InputPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.c1InputPanel2.MouseWheelEdit = false;
            this.c1InputPanel2.Name = "c1InputPanel2";
            this.c1InputPanel2.Size = new System.Drawing.Size(712, 522);
            this.c1InputPanel2.TabIndex = 1;
            this.c1InputPanel2.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            // 
            // inputComboBox1
            // 
            this.inputComboBox1.MaxDropDownItems = 50;
            this.inputComboBox1.Name = "inputComboBox1";
            // 
            // interfaceNav1
            // 
            this.interfaceNav1.Dock = System.Windows.Forms.DockStyle.Left;
            this.interfaceNav1.Location = new System.Drawing.Point(0, 0);
            this.interfaceNav1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.interfaceNav1.Name = "interfaceNav1";
            this.interfaceNav1.Size = new System.Drawing.Size(263, 604);
            this.interfaceNav1.TabIndex = 2;
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel1.Items.Add(this.inputButton1);
            this.c1InputPanel1.Location = new System.Drawing.Point(263, 0);
            this.c1InputPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(712, 82);
            this.c1InputPanel1.TabIndex = 3;
            this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            // 
            // inputButton1
            // 
            this.inputButton1.Image = ((System.Drawing.Image)(resources.GetObject("inputButton1.Image")));
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.Text = "保存";
            this.inputButton1.Click += new System.EventHandler(this.inputButton1_Click);
            // 
            // FormFieldMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 604);
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
        private C1.Win.C1InputPanel.InputComboBox inputComboBox1;
        private Interface.InterfaceNav interfaceNav1;
        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private C1.Win.C1InputPanel.InputButton inputButton1;
    }
}