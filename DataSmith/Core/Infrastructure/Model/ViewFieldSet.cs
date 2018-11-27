﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.Infrastructure.Attribute;
using DataSmith.Core.Infrastructure.Base;

namespace DataSmith.Core.Infrastructure.Model
{
    public class ViewFieldSet : BaseModel
    {
        public Int64 InterfaceID { get; set; }
        public String FieldName { get; set; }
        public String FieldAlias { get; set; }
    }
}