using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Classification
{
    public class CObject
    {
        public CClass Class { set; get; }
        public Dictionary<string, decimal> AttributeValues { get; }
        public decimal[] Attributes { get { return AttributeValues.OrderBy(i => i.Key).Select(i => i.Value).ToArray(); } }

        public CObject()
        {
            AttributeValues = new Dictionary<string, decimal>();
        }

        public override string ToString()
        {
            return "Obj with Class " + (Class != null ? Class.ToString() : "null");
        }
    }
}
