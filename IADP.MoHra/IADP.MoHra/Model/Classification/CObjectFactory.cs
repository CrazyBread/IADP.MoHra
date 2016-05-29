using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Classification
{
    public static class CObjectFactory
    {
        public static CObject GetFromProperties(object source, params string[] properties)
        {
            if (source == null)
                throw new ArgumentOutOfRangeException(nameof(source));
            if (properties == null)
                throw new ArgumentOutOfRangeException(nameof(properties));
            if (properties.Length < 1)
                throw new ArgumentOutOfRangeException(nameof(properties));

            var sourceType = source.GetType();
            var result = new CObject();
            foreach (var propName in properties)
            {
                var getProp = sourceType.GetProperty(propName);
                if (getProp == null)
                    throw new ArgumentException(propName);
                var value = getProp.GetValue(source);
                decimal decValue = Convert.ToDecimal(value);
                result.AttributeValues.Add(propName, decValue);
            }
            return result;
        }
    }
}
