using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;
using DataSmith.Util;

namespace DataSmith.Setting
{
    public partial class FormSetting1 : AlertForm
    {
        public FieldSet FieldSet { get; set; }
        private FieldProperties _fieldProperties;
        private FieldPropertiesDal _fieldPropertiesDal;

        public FormSetting1()
        {
            InitializeComponent();
            _fieldPropertiesDal = Host.GetService<FieldPropertiesDal>();
            btnOK.Click += BtnOK_Click;
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            _fieldProperties = FieldSet.GetFieldProperties();
            inputTextBox1.Text = _fieldProperties.Property2;
            inputLabel1.Text = _fieldProperties.Property3;
            inputGroupHeader1.Text = string.Format("字段名称：{0}{1, 3}{2}", FieldSet.FieldName, "", FieldSet.FieldDescribe);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            _fieldProperties.Property2 = inputTextBox1.Text;
            _fieldPropertiesDal.Update(_fieldProperties, x => x.FieldSetID);
        }

        private void c1InputPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
