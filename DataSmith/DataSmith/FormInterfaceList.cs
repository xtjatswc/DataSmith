using System;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using DataSmith.Core.Context;
using DataSmith.Core.Infrastructure.DAL;

namespace DataSmith
{
    public partial class FormInterfaceList : Form
    {
        private readonly InterfaceClassifyDal _icDal = Host.GetService<InterfaceClassifyDal>();
        private readonly InterfacesDal _interfacesDal = Host.GetService<InterfacesDal>();

        public FormInterfaceList()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var ics = _icDal.GetModels(orderBy: "SortNo asc");
            c1InputPanel1.Items.Clear();
            foreach (var ic in ics)
            {
                var inputGroupHeader = new InputGroupHeader();
                inputGroupHeader.Text = ic.ClassifyName;
                c1InputPanel1.Items.Add(inputGroupHeader);

                var interfaces = _interfacesDal.GetModels($"ClassifyID={ic.ID}");
                foreach (var model in interfaces)
                {
                    var inputButton = new InputButton();
                    inputButton.Text = model.InterfaceName;
                    inputButton.Width = c1InputPanel1.Width - 20;
                    inputButton.TabStop = false;
                    inputButton.CheckOnClick = true;
                    c1InputPanel1.Items.Add(inputButton);
                }
            }
        }
    }
}