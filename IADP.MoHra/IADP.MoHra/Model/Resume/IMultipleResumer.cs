using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IADP.MoHra.Model.Result;

namespace IADP.MoHra.Model.Resume
{
    interface IMultipleResumer : IResumer
    {
        string AddResult(string name, RResult result);
    }
}
