namespace DataSmith.Log
{
    partial class FormLog4net
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLog4net));
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
            this.c1InputPanel2 = new C1.Win.C1InputPanel.C1InputPanel();
            this.hdrLog = new C1.Win.C1InputPanel.InputGroupHeader();
            this.navLog = new C1.Win.C1InputPanel.InputDataNavigator();
            this.sepLine = new C1.Win.C1InputPanel.InputSeparator();
            this.lblDate = new C1.Win.C1InputPanel.InputLabel();
            this.txtDate = new C1.Win.C1InputPanel.InputTextBox();
            this.lblThread = new C1.Win.C1InputPanel.InputLabel();
            this.txtThread = new C1.Win.C1InputPanel.InputTextBox();
            this.lblLevel = new C1.Win.C1InputPanel.InputLabel();
            this.txtLevel = new C1.Win.C1InputPanel.InputTextBox();
            this.lblLogger = new C1.Win.C1InputPanel.InputLabel();
            this.txtLogger = new C1.Win.C1InputPanel.InputTextBox();
            this.lblMessage = new C1.Win.C1InputPanel.InputLabel();
            this.txtMessage = new C1.Win.C1InputPanel.InputTextBox();
            this.lblException = new C1.Win.C1InputPanel.InputLabel();
            this.txtException = new C1.Win.C1InputPanel.InputTextBox();
            this.inputButton1 = new C1.Win.C1InputPanel.InputButton();
            this.inputButton2 = new C1.Win.C1InputPanel.InputButton();
            this.logBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.inputLabel1 = new C1.Win.C1InputPanel.InputLabel();
            this.inputButton3 = new C1.Win.C1InputPanel.InputButton();
            this.inputComboBox1 = new C1.Win.C1InputPanel.InputComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.ColumnInfo = "10,1,0,0,0,120,Columns:";
            this.c1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid1.Location = new System.Drawing.Point(932, 87);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.DefaultSize = 24;
            this.c1FlexGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.c1FlexGrid1.Size = new System.Drawing.Size(595, 732);
            this.c1FlexGrid1.TabIndex = 0;
            this.c1FlexGrid1.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            this.c1FlexGrid1.SelChange += new System.EventHandler(this.c1FlexGrid1_SelChange);
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.DataSource = this.logBindingSource1;
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel1.Items.Add(this.hdrLog);
            this.c1InputPanel1.Items.Add(this.navLog);
            this.c1InputPanel1.Items.Add(this.sepLine);
            this.c1InputPanel1.Items.Add(this.lblDate);
            this.c1InputPanel1.Items.Add(this.txtDate);
            this.c1InputPanel1.Items.Add(this.lblThread);
            this.c1InputPanel1.Items.Add(this.txtThread);
            this.c1InputPanel1.Items.Add(this.lblLevel);
            this.c1InputPanel1.Items.Add(this.txtLevel);
            this.c1InputPanel1.Items.Add(this.lblLogger);
            this.c1InputPanel1.Items.Add(this.txtLogger);
            this.c1InputPanel1.Items.Add(this.lblMessage);
            this.c1InputPanel1.Items.Add(this.txtMessage);
            this.c1InputPanel1.Items.Add(this.lblException);
            this.c1InputPanel1.Items.Add(this.txtException);
            this.c1InputPanel1.Location = new System.Drawing.Point(0, 0);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(932, 819);
            this.c1InputPanel1.TabIndex = 1;
            this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            // 
            // c1InputPanel2
            // 
            this.c1InputPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1InputPanel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel2.Items.Add(this.inputComboBox1);
            this.c1InputPanel2.Items.Add(this.inputButton1);
            this.c1InputPanel2.Items.Add(this.inputLabel1);
            this.c1InputPanel2.Items.Add(this.inputButton2);
            this.c1InputPanel2.Items.Add(this.inputButton3);
            this.c1InputPanel2.Location = new System.Drawing.Point(932, 0);
            this.c1InputPanel2.Name = "c1InputPanel2";
            this.c1InputPanel2.Padding = new System.Windows.Forms.Padding(2, 30, 2, 2);
            this.c1InputPanel2.Size = new System.Drawing.Size(595, 87);
            this.c1InputPanel2.TabIndex = 2;
            this.c1InputPanel2.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2007Blue;
            // 
            // hdrLog
            // 
            this.hdrLog.Name = "hdrLog";
            this.hdrLog.Text = "&Log";
            // 
            // navLog
            // 
            this.navLog.AddNewImage = ((System.Drawing.Image)(resources.GetObject("navLog.AddNewImage")));
            this.navLog.AddNewToolTip = "Add New";
            this.navLog.ApplyImage = ((System.Drawing.Image)(resources.GetObject("navLog.ApplyImage")));
            this.navLog.ApplyToolTip = "Apply Changes";
            this.navLog.CancelImage = ((System.Drawing.Image)(resources.GetObject("navLog.CancelImage")));
            this.navLog.CancelToolTip = "Cancel Changes";
            this.navLog.DataSource = this.logBindingSource1;
            this.navLog.DeleteImage = ((System.Drawing.Image)(resources.GetObject("navLog.DeleteImage")));
            this.navLog.DeleteToolTip = "Delete";
            this.navLog.EditImage = ((System.Drawing.Image)(resources.GetObject("navLog.EditImage")));
            this.navLog.EditToolTip = "Edit";
            this.navLog.MoveFirstImage = ((System.Drawing.Image)(resources.GetObject("navLog.MoveFirstImage")));
            this.navLog.MoveFirstToolTip = "Move First";
            this.navLog.MoveLastImage = ((System.Drawing.Image)(resources.GetObject("navLog.MoveLastImage")));
            this.navLog.MoveLastToolTip = "Move Last";
            this.navLog.MoveNextImage = ((System.Drawing.Image)(resources.GetObject("navLog.MoveNextImage")));
            this.navLog.MoveNextToolTip = "Move Next";
            this.navLog.MovePreviousImage = ((System.Drawing.Image)(resources.GetObject("navLog.MovePreviousImage")));
            this.navLog.MovePreviousToolTip = "Move Previous";
            this.navLog.Name = "navLog";
            this.navLog.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.navLog.ReloadImage = ((System.Drawing.Image)(resources.GetObject("navLog.ReloadImage")));
            this.navLog.ReloadToolTip = "Reload Data";
            this.navLog.SaveImage = ((System.Drawing.Image)(resources.GetObject("navLog.SaveImage")));
            this.navLog.SaveToolTip = "Save Data";
            this.navLog.Visibility = C1.Win.C1InputPanel.Visibility.Collapsed;
            // 
            // sepLine
            // 
            this.sepLine.Height = 11;
            this.sepLine.Name = "sepLine";
            this.sepLine.Visibility = C1.Win.C1InputPanel.Visibility.Collapsed;
            this.sepLine.Width = 333;
            // 
            // lblDate
            // 
            this.lblDate.Name = "lblDate";
            this.lblDate.Text = "&Date:";
            this.lblDate.Width = 81;
            // 
            // txtDate
            // 
            this.txtDate.DataBindings.Add(new System.Windows.Forms.Binding("BoundValue", this.logBindingSource1, "Date", true));
            this.txtDate.Name = "txtDate";
            this.txtDate.Width = 581;
            // 
            // lblThread
            // 
            this.lblThread.Name = "lblThread";
            this.lblThread.Text = "&Thread:";
            this.lblThread.Width = 81;
            // 
            // txtThread
            // 
            this.txtThread.DataBindings.Add(new System.Windows.Forms.Binding("BoundValue", this.logBindingSource1, "Thread", true));
            this.txtThread.Name = "txtThread";
            this.txtThread.Width = 581;
            // 
            // lblLevel
            // 
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Text = "L&evel:";
            this.lblLevel.Width = 81;
            // 
            // txtLevel
            // 
            this.txtLevel.DataBindings.Add(new System.Windows.Forms.Binding("BoundValue", this.logBindingSource1, "Level", true));
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Width = 581;
            // 
            // lblLogger
            // 
            this.lblLogger.Name = "lblLogger";
            this.lblLogger.Text = "L&ogger:";
            this.lblLogger.Width = 81;
            // 
            // txtLogger
            // 
            this.txtLogger.DataBindings.Add(new System.Windows.Forms.Binding("BoundValue", this.logBindingSource1, "Logger", true));
            this.txtLogger.Name = "txtLogger";
            this.txtLogger.Width = 581;
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Text = "&Message:";
            this.lblMessage.Width = 81;
            // 
            // txtMessage
            // 
            this.txtMessage.DataBindings.Add(new System.Windows.Forms.Binding("BoundValue", this.logBindingSource1, "Message", true));
            this.txtMessage.Height = 95;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Spread;
            this.txtMessage.Width = 581;
            // 
            // lblException
            // 
            this.lblException.Name = "lblException";
            this.lblException.Text = "E&xception:";
            this.lblException.Width = 81;
            // 
            // txtException
            // 
            this.txtException.DataBindings.Add(new System.Windows.Forms.Binding("BoundValue", this.logBindingSource1, "Exception", true));
            this.txtException.Height = 429;
            this.txtException.Multiline = true;
            this.txtException.Name = "txtException";
            this.txtException.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Spread;
            this.txtException.Width = 581;
            // 
            // inputButton1
            // 
            this.inputButton1.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.TabStop = false;
            this.inputButton1.Text = "上一页";
            this.inputButton1.Width = 90;
            this.inputButton1.Click += new System.EventHandler(this.inputButton1_Click);
            // 
            // inputButton2
            // 
            this.inputButton2.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton2.Name = "inputButton2";
            this.inputButton2.TabStop = false;
            this.inputButton2.Text = "下一页";
            this.inputButton2.Width = 90;
            this.inputButton2.Click += new System.EventHandler(this.inputButton2_Click);
            // 
            // logBindingSource1
            // 
            this.logBindingSource1.DataSource = typeof(DataSmith.Core.Infrastructure.Model.Log);
            // 
            // inputLabel1
            // 
            this.inputLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputLabel1.Name = "inputLabel1";
            this.inputLabel1.Text = "第{0}页";
            // 
            // inputButton3
            // 
            this.inputButton3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputButton3.Name = "inputButton3";
            this.inputButton3.TabStop = false;
            this.inputButton3.Text = "清空";
            this.inputButton3.Width = 90;
            this.inputButton3.Click += new System.EventHandler(this.inputButton3_Click);
            // 
            // inputComboBox1
            // 
            this.inputComboBox1.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputComboBox1.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList;
            this.inputComboBox1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputComboBox1.Name = "inputComboBox1";
            this.inputComboBox1.TabStop = false;
            this.inputComboBox1.Width = 163;
            this.inputComboBox1.ChangeCommitted += new System.EventHandler(this.inputComboBox1_ChangeCommitted);
            // 
            // FormLog4net
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1527, 819);
            this.Controls.Add(this.c1FlexGrid1);
            this.Controls.Add(this.c1InputPanel2);
            this.Controls.Add(this.c1InputPanel1);
            this.Name = "FormLog4net";
            this.Text = "FormLog4net";
            this.Load += new System.EventHandler(this.FormLog4net_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel2;
        private System.Windows.Forms.BindingSource logBindingSource1;
        private C1.Win.C1InputPanel.InputGroupHeader hdrLog;
        private C1.Win.C1InputPanel.InputDataNavigator navLog;
        private C1.Win.C1InputPanel.InputSeparator sepLine;
        private C1.Win.C1InputPanel.InputLabel lblDate;
        private C1.Win.C1InputPanel.InputTextBox txtDate;
        private C1.Win.C1InputPanel.InputLabel lblThread;
        private C1.Win.C1InputPanel.InputTextBox txtThread;
        private C1.Win.C1InputPanel.InputLabel lblLevel;
        private C1.Win.C1InputPanel.InputTextBox txtLevel;
        private C1.Win.C1InputPanel.InputLabel lblLogger;
        private C1.Win.C1InputPanel.InputTextBox txtLogger;
        private C1.Win.C1InputPanel.InputLabel lblMessage;
        private C1.Win.C1InputPanel.InputTextBox txtMessage;
        private C1.Win.C1InputPanel.InputLabel lblException;
        private C1.Win.C1InputPanel.InputTextBox txtException;
        private C1.Win.C1InputPanel.InputButton inputButton1;
        private C1.Win.C1InputPanel.InputButton inputButton2;
        private C1.Win.C1InputPanel.InputLabel inputLabel1;
        private C1.Win.C1InputPanel.InputComboBox inputComboBox1;
        private C1.Win.C1InputPanel.InputButton inputButton3;
    }
}