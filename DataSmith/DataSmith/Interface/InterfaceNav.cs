using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Interface
{
    public partial class InterfaceNav : UserControl
    {

        public delegate void InterfaceNavClick(Interfaces e);
        public event InterfaceNavClick NavClick;

        public InterfaceNav()
        {
            InitializeComponent();
        }

        private void InterfaceNav_Load(object sender, EventArgs e)
        {
            if(this.DesignMode)
                return;            

            InterfaceClassifyDal _icDal = Host.GetService<InterfaceClassifyDal>();
            InterfacesDal _interfacesDal = Host.GetService<InterfacesDal>();

            var ics = _icDal.GetModels(orderBy: "SortNo asc");
            c1InputPanel1.Items.Clear();
            foreach (var ic in ics)
            {
                var inputGroupHeader = new InputGroupHeader();
                inputGroupHeader.Font = new System.Drawing.Font("微软雅黑", 10F);
                inputGroupHeader.Text = ic.ClassifyName;
                c1InputPanel1.Items.Add(inputGroupHeader);

                var interfaces = _interfacesDal.GetModels($"ClassifyID={ic.ID}");
                foreach (var model in interfaces)
                {
                    var inputButton = new InputButton();
                    inputButton.Font = new System.Drawing.Font("微软雅黑", 10F);
                    inputButton.Text = model.InterfaceName;
                    inputButton.Width = c1InputPanel1.Width - 20;
                    inputButton.Click += InputButton_Click;
                    inputButton.Tag = model;
                    c1InputPanel1.Items.Add(inputButton);
                }
            }
            c1InputPanel1.SetSwitchToggle();

        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            var interfaces = (sender as InputButton).Tag as Interfaces;
            NavClick?.Invoke(interfaces);
        }
    }
}
