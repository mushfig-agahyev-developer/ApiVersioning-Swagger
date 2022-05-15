﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProjectModul.Exteensions
{
    public static class ToExpandObject
    {
        public static dynamic ToDynamic(this object value)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
            {
                expando.Add(property.Name, property.GetValue(value));
            }

            return expando as ExpandoObject;
        }
    }
}