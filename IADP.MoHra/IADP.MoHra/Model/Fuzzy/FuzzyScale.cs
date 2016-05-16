using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Fuzzy
{
    class FuzzyScale
    {
        private List<IFuzzyScaleItem> _items = new List<IFuzzyScaleItem>();

        public void AddItem(IFuzzyScaleItem item)
        {
            _items.Add(item);
        }

        public FuzzyAccessoryResult GetAccessory(decimal value)
        {
            if (_items.Count == 0)
                throw new ArgumentNullException("item");
            var result = new FuzzyAccessoryResult() { Name = "", Value = -1 };
            foreach (var item in _items)
            {
                var itemValue = item.GetAccessory(value);
                if (itemValue > result.Value)
                    result = new FuzzyAccessoryResult() { Name = item.Name, Value = itemValue };
            }
            return result;
        }

        public void Draw(System.Windows.Forms.Control control)
        {
            foreach (var scaleItem in _items)
                scaleItem.Draw(control);
        }
    }
}
