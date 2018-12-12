using System;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Interface
{
    public partial class FormInterfaceList : Form
    {

        public FormInterfaceList()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            interfaceNav1.NavClick += InterfaceNav1_NavClick;
        }

        private void InterfaceNav1_NavClick(Interfaces e)
        {
            var frm = Host.GetService<FormSqlPreview>();
            panel1.ShowForm(frm);

            frm.InterfaceId = e.ID;
            frm.ChangeInterface();

            frm.AfterSaved -= Frm_AfterSaved;
            frm.AfterSaved += Frm_AfterSaved;
        }

        private void Frm_AfterSaved(object sender, EventArgs e)
        {
            interfaceNav1.RefreshPassed(sender as Interfaces);
        }
    }
}