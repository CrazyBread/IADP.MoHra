using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Classification
{
    public class CResolver
    {
        public CSpace Space { get; }

        public CResolver(CSpace space)
        {
            Space = space;
        }

        public CClass Resolve(CObject newObject)
        {
            Space.Check(newObject);
            throw new NotImplementedException();
        }
    }
}
