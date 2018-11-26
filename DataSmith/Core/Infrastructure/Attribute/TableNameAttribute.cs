using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DataSmith.Core.Infrastructure.Attribute
{
    public class TableNameAttribute : DescriptionAttribute
    {
        public TableNameAttribute(string description) : base(description)
        { }
    }
}
