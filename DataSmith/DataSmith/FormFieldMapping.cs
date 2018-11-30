using System;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using DataSmith.Core.Context;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith
{
    public partial class FormFieldMapping : Form
    {
        private readonly FieldSetDal _fieldSetDal = Host.GetService<FieldSetDal>();
        private readonly ViewFieldSetDal _viewFieldSetDal = Host.GetService<ViewFieldSetDal>();

        public FormFieldMapping()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var fieldSets = _fieldSetDal.GetModels("InterfaceID=1", "SortNo");

            c1InputPanel2.Items.Clear();

            foreach (var fieldSet in fieldSets)
            {
                ////视图字段
                //InputLabel inputLabelFieldName1 = new InputLabel();
                //inputLabelFieldName1.Text = fieldName1;
                //inputLabelFieldName1.Width = 200;
                //c1InputPanel2.Items.Add(inputLabelFieldName1);

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
                viewFieldSets.Insert(0, new ViewFieldSet {FieldName = ""});
                var inputComboBoxFieldAlias = new InputComboBox();
                c1InputPanel2.Items.Add(inputComboBoxFieldAlias);
                inputComboBoxFieldAlias.DataSource = viewFieldSets;
                inputComboBoxFieldAlias.DisplayMember = "FieldName";
                inputComboBoxFieldAlias.ValueMember = "FieldName";
                inputComboBoxFieldAlias.SelectedValue = fieldSet.FieldName;
                inputComboBoxFieldAlias.Width = 200;
                inputComboBoxFieldAlias.Break = BreakType.Row;
                inputComboBoxFieldAlias.MismatchValueErrorText = "值“{0}”不匹配任何可用选项";
                inputComboBoxFieldAlias.MaxDropDownItems = 50;

                //分隔线
                var inputSeparator = new InputSeparator();
                inputSeparator.Width = 1200;
                c1InputPanel2.Items.Add(inputSeparator);
            }
        }
    }
}