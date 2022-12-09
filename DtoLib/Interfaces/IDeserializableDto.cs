﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLib.Interfaces
{
    public interface IDeserializableDto
    {
        public IDeserializableDto Deserialize(byte[] buffer);
    }



    //public abstract class IDeserializableDto<T>
    //where T : Serializable
    //{
    //    public static abstract T Deserialize(byte[] buffer);
    //}

}