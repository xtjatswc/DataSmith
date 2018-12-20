using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using DataSmith.Core.Config;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;
using DataSmith.Setting;

namespace DataSmith.Interface
{
    public partial class FormFieldMapping : Form
    {
        private readonly FieldSetDal _fieldSetDal = Host.GetService<FieldSetDal>();
        private readonly ViewFieldSetDal _viewFieldSetDal = Host.GetService<ViewFieldSetDal>();
        private readonly InterfacesDal _interfacesDal = Host.GetService<InterfacesDal>();

        private Dictionary<FieldSet, dynamic> _dictForm = new Dictionary<FieldSet, dynamic>();
        private Int64 _interfaceID;

        public event EventHandler AfterSaved;

        public FormFieldMapping()
        {
            InitializeComponent();
            AfterSaved += FormFieldMapping_AfterSaved;
        }

        private void FormFieldMapping_AfterSaved(object sender, EventArgs e)
        {
            interfaceNav1.RefreshPassed(sender as Interfaces);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            inputButton1.Visibility = Visibility.Hidden;
            interfaceNav1.NavClick += InterfaceNav1_NavClick;
        }

        private void InterfaceNav1_NavClick(Interfaces e)
        {
            _interfaceID = e.ID;
            var fieldSets = _fieldSetDal.GetModels($"InterfaceID={_interfaceID}", "SortNo");
            inputGroupHeader1.Text = e.InterfaceName;

            c1InputPanel2.Items.Clear();
            _dictForm.Clear();

            if (fieldSets.Count > 0)
            {
                inputButton1.Visibility = Visibility.Visible;
            }

            for (var i = 0; i < fieldSets.Count; i++)
            {
                var fieldSet = fieldSets[i];
                dynamic controls = new ExpandoObject();
                _dictForm.Add(fieldSet, controls);

                //序号
                var inputLabelSn = new InputLabel();
                inputLabelSn.Font = LessConfig.SysFont;
                inputLabelSn.Text = (i + 1).ToString();
                inputLabelSn.Width = 50;
                c1InputPanel2.Items.Add(inputLabelSn);

                //接口字段
                var inputLabelFieldName2 = new InputLabel();
                inputLabelFieldName2.Font = LessConfig.SysFont;
                inputLabelFieldName2.Text = fieldSet.FieldName;
                inputLabelFieldName2.Width = 200;
                c1InputPanel2.Items.Add(inputLabelFieldName2);

                //接口字段描述
                var inputLabelFieldDescribe = new InputLabel();
                inputLabelFieldDescribe.Font = LessConfig.SysFont;
                inputLabelFieldDescribe.Text = fieldSet.FieldDescribe;
                inputLabelFieldDescribe.Width = 200;
                c1InputPanel2.Items.Add(inputLabelFieldDescribe);

                //接口字段备注
                var inputLabelRemark = new InputLabel();
                inputLabelRemark.Font = LessConfig.SysFont;
                inputLabelRemark.Text = fieldSet.Remark;
                inputLabelRemark.Width = 300;
                c1InputPanel2.Items.Add(inputLabelRemark);

                //视图字段别名
                var viewFieldSets = _viewFieldSetDal.GetModels("InterfaceID=" + e.ID);
                viewFieldSets.Insert(0, new ViewFieldSet { FieldName = "" });
                var inputComboBoxFieldAlias = new InputComboBox();
                inputComboBoxFieldAlias.Font = LessConfig.SysFont;
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
                inputComboBoxFieldAlias.Break = BreakType.None;
                inputComboBoxFieldAlias.Width = 200;
                inputComboBoxFieldAlias.MaxDropDownItems = 50;
                inputComboBoxFieldAlias.SelectedValueChanged += InputComboBoxFieldAlias_SelectedValueChanged; ;
                controls.inputComboBoxFieldAlias = inputComboBoxFieldAlias;

                InputLabel inputLabel = new InputLabel();
                inputLabel.Font = LessConfig.SysFont;
                inputLabel.ForeColor = Color.Red;
                inputLabel.Width = 50;
                if (fieldSet.Required == 1)
                {
                    inputLabel.Text = "(必填)";
                }
                c1InputPanel2.Items.Add(inputLabel);

                var fieldProperties = fieldSet.GetFieldProperties();
                if (fieldProperties == null)
                {
                    inputLabel.Break = BreakType.Row;
                }
                else
                {
                    InputButton inputButton = new InputButton();
                    inputButton.Text = "设置";
                    inputButton.Width = 90;
                    inputButton.TabStop = false;
                    inputButton.Font = LessConfig.SysFont;
                    inputButton.Click += InputButton_Click;
                    inputButton.Tag = fieldSet;
                    c1InputPanel2.Items.Add(inputButton);
                }

                //分隔线
                var inputSeparator = new InputSeparator();
                inputSeparator.Width = 1200;
                c1InputPanel2.Items.Add(inputSeparator);
            }
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            var button = sender as InputButton;
            button.Focus();
            var form = Host.GetService<FormSetting1>();
            form.FieldSet = button.Tag as FieldSet;            
            form.ShowDialog();
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

                if (fieldSet.Required == 1 && inputComboBoxFieldAlias.SelectedValue == "")
                {
                    inputComboBoxFieldAlias.ErrorText = $"栏目\"{fieldSet.FieldDescribe}\"为必填项！";
                    MessageBox.Show(inputComboBoxFieldAlias.ErrorText);
                    inputComboBoxFieldAlias.Focus();
                    return;
                }
                else
                {
                    inputComboBoxFieldAlias.ErrorText = "";
                }

                fieldSet.FieldAlias = inputComboBoxFieldAlias.SelectedValue.ToString();
                _fieldSetDal.Update(fieldSet, x => x.ID);
            }

            var interfaces = _interfacesDal.GetModel(_interfaceID);
            interfaces.FieldPassed = 1;
            _interfacesDal.Update(interfaces, x => x.ID);
            AfterSaved?.Invoke(interfaces, new EventArgs());

            MessageBox.Show("保存成功!");
        }
    }
}