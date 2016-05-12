using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Result
{
    struct RResultValue
    {
        public char Claster { set; get; }
        public int Points { set; get; }
    }

    struct RTemporaryResultValue
    {
        public DateTime Month { set; get; }
        public char Claster { set; get; }
        public double A3_Value { set; get; }
        public int A4_Value { set; get; }
    }

    class RResult
    {
        public Dictionary<KeyValuePair<RObject, RAttribute>, decimal?> Values;
        private List<RObject> _objects;
        private List<RAttribute> _attributes;

        public RResult(List<RObject> objects, List<RAttribute> attributes)
        {
            _objects = objects;
            _attributes = attributes;
            Values = new Dictionary<KeyValuePair<RObject, RAttribute>, decimal?>();
            foreach (var robject in objects)
            {
                foreach (var rattribute in attributes)
                {
                    Values[new KeyValuePair<RObject, RAttribute>(robject, rattribute)] = null;
                }
            }
        }

        public void FillValue(RObject robject, RAttribute rattribute, decimal value)
        {
            if (!Values.ContainsKey(new KeyValuePair<RObject, RAttribute>(robject, rattribute)))
                throw new ArgumentException();
            Values[new KeyValuePair<RObject, RAttribute>(robject, rattribute)] = value;
        }

        public Dictionary<RObject, RResultValue> GetResult()
        {
            var result = new Dictionary<RObject, RResultValue>();
            foreach (var robject in _objects)
            {
                int points = 0;
                foreach (var rattribute in _attributes)
                {
                    var value = Values[new KeyValuePair<RObject, RAttribute>(robject, rattribute)];
                    if (!value.HasValue) continue;
                    var tempRes = rattribute.GetClaster(value.Value);
                    if (tempRes == 'J')
                        points += 1;
                    else if (tempRes == 'M')
                        points += 2;
                    else
                        points += 4;
                }
                if (points >= 15)
                    result[robject] = new RResultValue { Claster = 'S', Points = points };
                else if (points >= 10)
                    result[robject] = new RResultValue { Claster = 'M', Points = points };
                else
                    result[robject] = new RResultValue { Claster = 'J', Points = points };
            }
            return result;
        }
    }
}
