﻿using System;
using System.Windows.Forms;
using C1.Win.C1InputPanel;

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
            var width = 150;
            var bottomPadding = 5;

            c1InputPanel1.Items.Clear();
            var inputButton = new InputButton();
            inputButton.Text = "数据源";
            inputButton.TabStop = false;
            inputButton.CheckOnClick = true;
            inputButton.Break = BreakType.None;
            inputButton.Width = width;
            inputButton.Height = c1InputPanel1.Height - bottomPadding;
            inputButton.Click += InputButton_Click1;
            c1InputPanel1.Items.Add(inputButton);

            inputButton = new InputButton();
            inputButton.Text = "接口定义";
            inputButton.TabStop = false;
            inputButton.CheckOnClick = true;
            inputButton.Break = BreakType.None;
            inputButton.Width = width;
            inputButton.Height = c1InputPanel1.Height - bottomPadding;
            c1InputPanel1.Items.Add(inputButton);

            inputButton = new InputButton();
            inputButton.Text = "退出";
            inputButton.TabStop = false;
            inputButton.Break = BreakType.None;
            inputButton.Width = width;
            inputButton.Height = c1InputPanel1.Height - bottomPadding;
            inputButton.Click += InputButton_Click;
            c1InputPanel1.Items.Add(inputButton);
        }

        private void InputButton_Click1(object sender, EventArgs e)
        {
            FormDataSourceList frm = new FormDataSourceList();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            panel1.Controls.Add(frm);
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}