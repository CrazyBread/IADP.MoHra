using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Fuzzy
{
    class FuzzyScaleTriangleItem : IFuzzyScaleItem
    {
        public decimal Begin { set; get; }
        public decimal Top { set; get; }
        public decimal End { set; get; }
        public string Name { get; set; }

        public decimal GetAccessory(decimal value)
        {
            _Check();

            decimal result = 0;
            if (value <= Begin || value >= End)
                result = 0;
            else if (value <= Top)
                result = (value - Begin) / (Top - Begin);
            else
                result = (End - value) / (End - Top);
            return result;
        }

        private void _Check()
        {
            if (Begin >= End)
                throw new ArgumentException();
            if (Top <= Begin)
                throw new ArgumentException();
            if (Top >= End)
                throw new ArgumentException();
        }
    }
}
