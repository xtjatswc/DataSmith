namespace DataSmith.Util
{
    partial class AlertForm
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
            this.btnOK = new C1.Win.C1InputPanel.InputButton();
            this.btnCancel = new C1.Win.C1InputPanel.InputButton();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel1.Items.Add(this.btnOK);
            this.c1InputPanel1.Items.Add(this.btnCancel);
            this.c1InputPanel1.Location = new System.Drawing.Point(0, 372);
            this.c1InputPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Padding = new System.Windows.Forms.Padding(2, 10, 2, 2);
            this.c1InputPanel1.Size = new System.Drawing.Size(783, 55);
            this.c1InputPanel1.TabIndex = 0;
            this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            // 
            // btnOK
            // 
            this.btnOK.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ElementWidth = 90;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOK.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far;
            this.btnOK.Name = "btnOK";
            this.btnOK.TabStop = false;
            this.btnOK.Text = "确定";
            this.btnOK.Width = 124;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ElementWidth = 90;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Width = 106;
            // 
            // AlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 427);
            this.ControlBox = false;
            this.Controls.Add(this.c1InputPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AlertForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.ResizeBegin += new System.EventHandler(this.AlertForm_ResizeBegin);
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private C1.Win.C1InputPanel.InputButton btnCancel;
        protected C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        protected C1.Win.C1InputPanel.InputButton btnOK;
    }
}