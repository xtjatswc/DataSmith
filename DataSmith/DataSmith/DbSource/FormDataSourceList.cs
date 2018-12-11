using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.Base;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.DbSource
{
    public partial class FormDataSourceList : Form
    {
        private readonly DataSourceDal _dataSourceDal = Host.GetService<DataSourceDal>();

        public FormDataSourceList()
        {
            InitializeComponent();
        }

        private void FormDataSourceList_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            var models = _dataSourceDal.GetModels(where: "IsDeleted=0");
            c1InputPanel1.Items.Clear();

            //源
            var source = models.Where(o => o.SourceType == 1).ToList();
            InputGroupHeader groupHeader = new InputGroupHeader();
            groupHeader.Font = new System.Drawing.Font("微软雅黑", 10F);
            groupHeader.Text = "[数据源]";
            c1InputPanel1.Items.Add(groupHeader);
            LoadItems(source);

            //目标
            var target = models.Where(o => o.SourceType == 2).ToList();
            groupHeader = new InputGroupHeader();
            groupHeader.Font = new System.Drawing.Font("微软雅黑", 10F);
            groupHeader.Padding = new Padding(2, 15, 2, 2);
            groupHeader.Text = "[目标数据源]";
            c1InputPanel1.Items.Add(groupHeader);
            LoadItems(target);

            c1InputPanel1.SetSwitchToggle();
        }

        private void LoadItems(List<DataSource> models)
        {
            foreach (var model in models)
            {
                //状态图标
                InputImage inputImage = new InputImage();
                if (model.Passed == 1)
                {
                    inputImage.Image = DataSmith.Res.Resource72.bulb_green_72px_12741_easyicon_net;
                }
                else
                {
                    inputImage.Image = DataSmith.Res.Resource72.bulb_72px_28127_easyicon_net;
                }
                inputImage.Width = 32;
                inputImage.Height = 32;
                inputImage.Break = BreakType.None;
                inputImage.Tag = model;
                c1InputPanel1.Items.Add(inputImage);

                InputButton inputButton = new InputButton();
                inputButton.Font = new System.Drawing.Font("微软雅黑", 10F);
                inputButton.Text = model.SourceName;
                inputButton.Width = c1InputPanel1.Width - 58;
                inputButton.Click += InputButton_Click;
                inputButton.Tag = model;
                c1InputPanel1.Items.Add(inputButton);
            }
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            var frm = Host.GetService<FormDataSourceEdit>();
            frm.OperateType = OperateType.Modify;
            frm.DataSourceId = ((sender as InputButton).Tag as DataSource).ID;
            frm.ChangeDataSource();
            panel1.ShowForm(frm);

            frm.AfterTestConn -= Frm_AfterTestConn;
            frm.AfterTestConn += Frm_AfterTestConn;

            frm.AfterSaved -= Frm_AfterSaved;
            frm.AfterSaved += Frm_AfterSaved;
        }

        private void Frm_AfterSaved(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void Frm_AfterTestConn(object sender, EventArgs e)
        {
            foreach (InputComponent inputComponent in c1InputPanel1.Items)
            {
                InputImage inputImage = inputComponent as InputImage;
                if (inputImage != null)
                {
                    var ds1 = sender as DataSource;
                    var ds2 = inputImage.Tag as DataSource;
                    if (ds1.ID == ds2.ID)
                    {
                        if (ds1.Passed == 1)
                        {
                            inputImage.Image = DataSmith.Res.Resource72.bulb_green_72px_12741_easyicon_net;
                        }
                        else
                        {
                            inputImage.Image = DataSmith.Res.Resource72.bulb_72px_28127_easyicon_net;
                        }
                    }
                }
            }
        }

        //添加数据源
        private void inputButton2_Click(object sender, EventArgs e)
        {
            var frm = Host.GetService<FormDataSourceEdit>();
            frm.OperateType = OperateType.New;
            frm.ChangeDataSource();
            panel1.ShowForm(frm);
            frm.AfterSaved += Frm_AfterSaved;

            c1InputPanel1.ClearSwitchToggle();
        }
    }
}
