using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C1.Win.C1InputPanel;

namespace DataSmith.Core.Extension
{
    public static class InputComboBoxExtension
    {
        //初始化赋值，不区分大小写，如果值赋不上，则把值赋给Text属性
        public static void SetInitValue(this InputComboBox inputComboBox, string value, bool setTextWhenValueNull = false)
        {
            foreach (InputOption inputOption in inputComboBox.Items)
            {
                if (inputOption.BoundValue.ToString().ToUpper() == value.ToUpper())
                {
                    inputComboBox.SelectedOption = inputOption;
                    break;
                }
            }

            if (inputComboBox.SelectedValue == "" && setTextWhenValueNull)
            { 
                inputComboBox.Text = value;
                inputComboBox.ErrorText = string.Format(inputComboBox.MismatchValueErrorText, value);
            }
        }
    }
}
