using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.Context;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Core.Extension
{
    public static class FieldSetExtensions
    {
        public static FieldProperties GetFieldProperties(this FieldSet fieldSet)
        {
            var fieldPropertiesDal = Host.GetService<FieldPropertiesDal>();
            return fieldPropertiesDal.GetModel(fieldSet.ID);
        }
    }
}
