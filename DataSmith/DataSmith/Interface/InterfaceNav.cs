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

                var interfaces = _interfacesDal.GetModels(where:$"ClassifyID={ic.ID} and IsDeleted = 0");
                foreach (var model in interfaces)
                {
                    //状态图标
                    InputImage inputImage = new InputImage();
                    if (this.Parent.GetType() == typeof(FormInterfaceList))
                    {
                        inputImage.Image = model.ViewPassed == 1 ? DataSmith.Res.Resource72.bulb_green_72px_12741_easyicon_net : DataSmith.Res.Resource72.bulb_72px_28127_easyicon_net;
                    }
                    else if (this.Parent.GetType() == typeof(FormFieldMapping))
                    {
                        inputImage.Image = model.FieldPassed == 1 ? DataSmith.Res.Resource72.bulb_green_72px_12741_easyicon_net : DataSmith.Res.Resource72.bulb_72px_28127_easyicon_net;
                    }
                    inputImage.Width = 32;
                    inputImage.Height = 32;
                    inputImage.Break = BreakType.None;
                    inputImage.Tag = model;
                    c1InputPanel1.Items.Add(inputImage);

                    var inputButton = new InputButton();
                    inputButton.Font = new System.Drawing.Font("微软雅黑", 10F);
                    inputButton.Text = model.InterfaceName;
                    inputButton.Width = c1InputPanel1.Width - 60;
                    inputButton.Click += InputButton_Click;
                    inputButton.Tag = model;
                    c1InputPanel1.Items.Add(inputButton);
                }
            }
            c1InputPanel1.SetSwitchToggle();

        }

        public void RefreshPassed(Interfaces ds1)
        {
            foreach (InputComponent inputComponent in c1InputPanel1.Items)
            {
                InputImage inputImage = inputComponent as InputImage;
                if (inputImage != null)
                {
                    var ds2 = inputImage.Tag as Interfaces;
                    if (ds1.ID == ds2.ID)
                    {
                        if (this.Parent.GetType() == typeof(FormInterfaceList))
                        {
                            inputImage.Image = ds1.ViewPassed == 1 ? DataSmith.Res.Resource72.bulb_green_72px_12741_easyicon_net : DataSmith.Res.Resource72.bulb_72px_28127_easyicon_net;
                        }
                        else if (this.Parent.GetType() == typeof(FormFieldMapping))
                        {
                            inputImage.Image = ds1.FieldPassed == 1 ? DataSmith.Res.Resource72.bulb_green_72px_12741_easyicon_net : DataSmith.Res.Resource72.bulb_72px_28127_easyicon_net;
                        }
                    }
                }

            }
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            var interfaces = (sender as InputButton).Tag as Interfaces;
            NavClick?.Invoke(interfaces);
        }
    }
}
