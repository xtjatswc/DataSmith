using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1InputPanel;

namespace DataSmith
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        //禁止通过拖动，双击标题栏改变窗体大小。
        public const int WM_NCLBUTTONDBLCLK = 0xA3;
        const int WM_NCLBUTTONDOWN = 0x00A1;
        const int HTCAPTION = 2;
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
            int width = 150;
            int bottomPadding = 5;

            c1InputPanel1.Items.Clear();
            InputButton inputButton = new InputButton();
            inputButton.Text = "数据源";
            inputButton.TabStop = false;
            inputButton.CheckOnClick = true;
            inputButton.Break = BreakType.None;
            inputButton.Width = width;
            inputButton.Height = c1InputPanel1.Height - bottomPadding;
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

        private void InputButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }


}
