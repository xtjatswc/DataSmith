﻿using DataSmith.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSmith.Core.Infrastructure
{
    public interface IBaseDAL
    {
        Host host { get; set; }
    }
}
