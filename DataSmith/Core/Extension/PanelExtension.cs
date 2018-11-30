using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataSmith.Core.Context;

namespace DataSmith.Core.Extension
{
    public static class PanelExtension
    {
        public static void ShowForm(this Panel panel, Form frm)
        {
            if (!panel.Controls.Contains(frm))
            {
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                panel.Controls.Add(frm);
            }
        }
    }
}
