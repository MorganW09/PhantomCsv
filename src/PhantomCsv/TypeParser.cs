using System;
using System.Collections.Generic;
using System.Text;

namespace PhantomCsv
{
    public class TypeParser<T> where T : class
    {
        public (Type,string)[] GetTypes()
        {
            var examinedType = typeof(T);
            var properties = examinedType.GetProperties();
            var types = new (Type,string)[properties.Length];
            for(int i = 0; i < types.Length; i++)
            {
                types[i] = (properties[i].PropertyType, properties[i].Name);
            }
            return types;
        }
    }
}
