using C1.Win.C1InputPanel;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;
using DataSmith.Core.Plugins;
using DataSmith.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DataSmith.Task
{
    public partial class FormTaskScheduler : Form
    {
        readonly IEnumerable<IPluginSetting> _iSettings = Host.GetServices<IPluginSetting>();

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
                inputGroupHeader.Font = new System.Drawing.Font("微软雅黑", 10F);
                inputGroupHeader.Text = ic.ClassifyName;
                c1InputPanel1.Items.Add(inputGroupHeader);

                var interfaces = taskSchedulerDal.GetModels(where:$"ClassifyID={ic.ID}",orderBy:"SortNo asc");
                foreach (var model in interfaces)
                {
                    var inputButton = new InputButton();
                    inputButton.Font = new System.Drawing.Font("微软雅黑", 10F);
                    inputButton.Text = model.TaskName;
                    inputButton.Width = c1InputPanel1.Width - 20;
                    inputButton.Click += InputButton_Click; ;
                    inputButton.Tag = model;
                    c1InputPanel1.Items.Add(inputButton);
                }
            }
            c1InputPanel1.SetSwitchToggle();
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            TaskScheduler taskScheduler = (sender as InputButton).Tag as TaskScheduler;
            var setting = _iSettings.FirstOrDefault(o => o.TaskSchedulerID == taskScheduler.ID);
            if (setting == null)
            {
                setting = _iSettings.FirstOrDefault(o => o.TaskSchedulerID == 0);
            }
            setting.SetTaskScheduler(taskScheduler);

            panel1.ShowForm(setting.FormInstance);
        }

        private void inputButton1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "taskschd.msc"
            };
            process.StartInfo = processInfo;
            process.Start();
        }
    }
}
