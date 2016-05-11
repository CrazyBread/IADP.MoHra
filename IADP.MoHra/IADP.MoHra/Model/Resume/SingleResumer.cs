using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IADP.MoHra.Model.Result;

namespace IADP.MoHra.Model.Resume
{
    abstract class SingleResumer : ISingleResumer
    {
        protected RResult _result;

        public void AddResult(RResult result)
        {
            _result = result;
        }

        public virtual string GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
