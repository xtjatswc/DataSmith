using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith
{
    public partial class FormFieldMapping : Form
    {
        private readonly FieldSetDal _fieldSetDal = Host.GetService<FieldSetDal>();
        private readonly ViewFieldSetDal _viewFieldSetDal = Host.GetService<ViewFieldSetDal>();

        private Dictionary<FieldSet, dynamic> _dictForm = new Dictionary<FieldSet, dynamic>();

        public FormFieldMapping()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            interfaceNav1.NavClick += InterfaceNav1_NavClick;            
        }

        private void InterfaceNav1_NavClick(Interfaces e)
        {
            var fieldSets = _fieldSetDal.GetModels($"InterfaceID={e.ID}", "SortNo");

            c1InputPanel2.Items.Clear();
            _dictForm.Clear();

            foreach (var fieldSet in fieldSets)
            {
                dynamic controls = new ExpandoObject();
                _dictForm.Add(fieldSet, controls);

                //接口字段
                var inputLabelFieldName2 = new InputLabel();
                inputLabelFieldName2.Text = fieldSet.FieldName;
                inputLabelFieldName2.Width = 200;
                c1InputPanel2.Items.Add(inputLabelFieldName2);

                //接口字段描述
                var inputLabelFieldDescribe = new InputLabel();
                inputLabelFieldDescribe.Text = fieldSet.FieldDescribe;
                inputLabelFieldDescribe.Width = 200;
                c1InputPanel2.Items.Add(inputLabelFieldDescribe);

                //接口字段备注
                var inputLabelRemark = new InputLabel();
                inputLabelRemark.Text = fieldSet.Remark;
                inputLabelRemark.Width = 300;
                c1InputPanel2.Items.Add(inputLabelRemark);

                //视图字段别名
                var viewFieldSets = _viewFieldSetDal.GetModels("InterfaceID=1");
                viewFieldSets.Insert(0, new ViewFieldSet { FieldName = "" });
                var inputComboBoxFieldAlias = new InputComboBox();
                inputComboBoxFieldAlias.MismatchValueErrorText = "值“{0}”不匹配任何可用选项";
                c1InputPanel2.Items.Add(inputComboBoxFieldAlias);
                inputComboBoxFieldAlias.DataSource = viewFieldSets;
                inputComboBoxFieldAlias.DisplayMember = "FieldName";
                inputComboBoxFieldAlias.ValueMember = "FieldName";
                //inputComboBoxFieldAlias.SelectedValue = fieldSet.FieldName;
                if (string.IsNullOrWhiteSpace(fieldSet.FieldAlias))
                {
                    inputComboBoxFieldAlias.SetInitValue(fieldSet.FieldName);
                }
                else
                {
                    inputComboBoxFieldAlias.SetInitValue(fieldSet.FieldAlias, true);
                }
                inputComboBoxFieldAlias.Width = 200;
                inputComboBoxFieldAlias.Break = BreakType.Row;
                inputComboBoxFieldAlias.MaxDropDownItems = 50;
                inputComboBoxFieldAlias.SelectedValueChanged += InputComboBoxFieldAlias_SelectedValueChanged; ;
                controls.inputComboBoxFieldAlias = inputComboBoxFieldAlias;

                //分隔线
                var inputSeparator = new InputSeparator();
                inputSeparator.Width = 1200;
                c1InputPanel2.Items.Add(inputSeparator);
            }
        }

        private void InputComboBoxFieldAlias_SelectedValueChanged(object sender, EventArgs e)
        {           
            InputComboBox inputComboBox = sender as InputComboBox;
            inputComboBox.ErrorText = "";
        }

        private void inputButton1_Click(object sender, EventArgs e)
        {
            foreach (var o in _dictForm)
            {
                FieldSet fieldSet = o.Key;
                InputComboBox inputComboBoxFieldAlias = o.Value.inputComboBoxFieldAlias;

                if (inputComboBoxFieldAlias.ErrorText != "")
                {
                    MessageBox.Show(inputComboBoxFieldAlias.ErrorText);
                    inputComboBoxFieldAlias.Focus();
                    return;
                }

                fieldSet.FieldAlias = inputComboBoxFieldAlias.SelectedValue.ToString();
                _fieldSetDal.Update(fieldSet, x => x.ID);
            }

            MessageBox.Show("保存成功!");
        }
    }
}