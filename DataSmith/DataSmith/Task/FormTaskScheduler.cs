using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Util;

namespace DataSmith.Task
{
    public partial class FormTaskScheduler : BaseForm
    {
        public FormTaskScheduler()
        {
            InitializeComponent();
        }

        private void FormTaskScheduler_Load(object sender, EventArgs e)
        {
            InterfaceClassifyDal _icDal = Host.GetService<InterfaceClassifyDal>();
            TaskSchedulerDal taskSchedulerDal = Host.GetService<TaskSchedulerDal>();

            var ics = _icDal.GetModels(orderBy: "SortNo asc");
            c1InputPanel1.Items.Clear();
            foreach (var ic in ics)
            {
                var inputGroupHeader = new InputGroupHeader();
                inputGroupHeader.Text = ic.ClassifyName;
                c1InputPanel1.Items.Add(inputGroupHeader);

                var interfaces = taskSchedulerDal.GetModels(where:$"ClassifyID={ic.ID}",orderBy:"SortNo asc");
                foreach (var model in interfaces)
                {
                    var inputButton = new InputButton();
                    inputButton.Text = model.TaskName;
                    inputButton.Width = c1InputPanel1.Width - 20;
                    //inputButton.Click += InputButton_Click;
                    inputButton.Tag = model;
                    c1InputPanel1.Items.Add(inputButton);
                }
            }
            c1InputPanel1.SetSwitchToggle();
        }
    }
}
