using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using C1.Win.C1InputPanel;

namespace DataSmith.Core.Extension
{
    public static class C1InputPanelExtension
    {
        #region 单选按钮组
        public static void SetSwitchToggle(this C1InputPanel c1InputPanel)
        {
            foreach (InputComponent inputComponent in c1InputPanel.Items)
            {               
                InputButton inputButton = inputComponent as InputButton;
                if (inputButton != null)
                {
                    inputButton.CheckOnClick = true;
                    inputButton.TabStop = false;
                    inputButton.Click += InputButton_Click;
                }
            }
        }

        private static void InputButton_Click(object sender, EventArgs e)
        {
            InputButton inputButton = sender as InputButton;
            inputButton.Pressed = true;
            dynamic obj = null;
            if (inputButton.InputPanel.Tag == null)
            {
                obj = new ExpandoObject();
                inputButton.InputPanel.Tag = obj;
            }
            else
            {
                obj = inputButton.InputPanel.Tag;
                if (obj.PressedButton != null && obj.PressedButton != inputButton)
                {
                    obj.PressedButton.Pressed = false;
                }
            }
            obj.PressedButton = inputButton;
        }
        #endregion

        public static void FormReset(this C1InputPanel c1InputPanel)
        {
            foreach (InputComponent inputComponent in c1InputPanel.Items)
            {
                if (inputComponent is InputTextBox || inputComponent is InputNumericBox)
                {
                    inputComponent.Text = "";
                }
            }
        }
    }
}
