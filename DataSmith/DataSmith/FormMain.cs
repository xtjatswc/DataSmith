using System;
using System.Diagnostics;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Util;
using DataSmith.DbSource;
using DataSmith.Interface;
using DataSmith.Task;
using DataSmith.Util;

namespace DataSmith
{
    public partial class FormMain : Form
    {
        //禁止通过拖动，双击标题栏改变窗体大小。
        public const int WM_NCLBUTTONDBLCLK = 0xA3;
        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HTCAPTION = 2;

        public FormMain()
        {
            InitializeComponent();
            Text += string.Format("{0, 5}v{1}", "", Host.Version);
            inputButton1.Image = DataSmith.Res.Resource48.cylinder_database_48px_13406_easyicon_net;
            inputButton2.Image = DataSmith.Res.Resource48.SQL_File_Extension_48px_1140212_easyicon_net;
            inputButton3.Image = DataSmith.Res.Resource48.table_relationship_48px_527120_easyicon_net;
            inputButton4.Image = DataSmith.Res.Resource128.transfer;
            inputButton5.Image = DataSmith.Res.Resource48.close_48px_1175541_easyicon_net;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTCAPTION)
                return;
            if (m.Msg == WM_NCLBUTTONDBLCLK)
                return;

            base.WndProc(ref m);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            c1InputPanel1.SetSwitchToggle();
        }

        private void InputButton_Click4(object sender, EventArgs e)
        {
            FormTaskScheduler frm = Host.GetService<FormTaskScheduler>();
            panel1.ShowForm(frm);
        }

        private void InputButton_Click3(object sender, EventArgs e)
        {
            FormFieldMapping frm = Host.GetService<FormFieldMapping>();
            panel1.ShowForm(frm);
        }

        private void InputButton_Click2(object sender, EventArgs e)
        {
            FormInterfaceList frm = Host.GetService<FormInterfaceList>();
            panel1.ShowForm(frm);
        }

        private void InputButton_Click1(object sender, EventArgs e)
        {
            FormDataSourceList frm = Host.GetService<FormDataSourceList>();
            panel1.ShowForm(frm);
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            //Environment.Exit(Environment.ExitCode);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}