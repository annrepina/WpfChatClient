﻿using DtoLib.Dto;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLib
{
    public class Deserializer<T>
        where T : Serializable
    {
        public T Deserialize(byte[] data)
        {
            try
            {
                using (var stream = new MemoryStream(data))
                {
                    T obj = Serializer.Deserialize<T>(stream);
                    return obj;
                }
            }
            catch (Exception)
            {
                //
                throw;
            }
        }
    }
}