﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLib.NetworkServices
{
    public interface IResponse
    {
        public NetworkResponseStatus Status { get; set; }
    }
}
