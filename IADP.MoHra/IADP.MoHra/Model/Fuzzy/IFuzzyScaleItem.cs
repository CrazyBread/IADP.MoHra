using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Fuzzy
{
    interface IFuzzyScaleItem
    {
        string Name { set; get; }
        decimal GetAccessory(decimal value);
        void Draw(System.Drawing.Graphics graphics);
    }
}
