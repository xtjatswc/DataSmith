namespace DataSmith.Interface
{
    partial class FormInterfaceList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.interfaceNav1 = new DataSmith.Interface.InterfaceNav();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(285, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 721);
            this.panel1.TabIndex = 1;
            // 
            // interfaceNav1
            // 
            this.interfaceNav1.Dock = System.Windows.Forms.DockStyle.Left;
            this.interfaceNav1.Location = new System.Drawing.Point(0, 0);
            this.interfaceNav1.Margin = new System.Windows.Forms.Padding(5);
            this.interfaceNav1.Name = "interfaceNav1";
            this.interfaceNav1.Size = new System.Drawing.Size(285, 721);
            this.interfaceNav1.TabIndex = 2;
            // 
            // FormInterfaceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 721);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.interfaceNav1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormInterfaceList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataSmith";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private InterfaceNav interfaceNav1;
    }
}