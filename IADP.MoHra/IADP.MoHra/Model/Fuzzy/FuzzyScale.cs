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

        public void Draw(System.Drawing.Graphics graphics)
        {
            foreach (var scaleItem in _items)
                scaleItem.Draw(graphics);

            var minX = _items.Min(d => 
                                    (d is FuzzyScaleTriangleItem) ? 
                                    ((d as FuzzyScaleTriangleItem).Begin < (d as FuzzyScaleTriangleItem).Top ? (d as FuzzyScaleTriangleItem).Begin : (d as FuzzyScaleTriangleItem).Top) : 
                                    ((d as FuzzyScaleBorderItem).Begin < (d as FuzzyScaleBorderItem).Top ? (d as FuzzyScaleBorderItem).Begin : (d as FuzzyScaleBorderItem).Top)
                                ) * Helpers.GraphSettings.scale;
            graphics.DrawLine(System.Drawing.Pens.Black, new System.Drawing.PointF(0, Helpers.GraphSettings.center_Y - Helpers.GraphSettings.scale), new System.Drawing.PointF((float)minX + Helpers.GraphSettings.center_X, Helpers.GraphSettings.center_Y - Helpers.GraphSettings.scale));

            var maxX = _items.Max(d =>
                                    (d is FuzzyScaleTriangleItem) ?
                                    ((d as FuzzyScaleTriangleItem).Top > (d as FuzzyScaleTriangleItem).End ? (d as FuzzyScaleTriangleItem).Top : (d as FuzzyScaleTriangleItem).End) :
                                    ((d as FuzzyScaleBorderItem).Begin > (d as FuzzyScaleBorderItem).Top ? (d as FuzzyScaleBorderItem).Begin : (d as FuzzyScaleBorderItem).Top)
                                ) * Helpers.GraphSettings.scale;
            graphics.DrawLine(System.Drawing.Pens.Black, new System.Drawing.PointF(Helpers.GraphSettings.center_X + (float)maxX, Helpers.GraphSettings.center_Y - Helpers.GraphSettings.scale), new System.Drawing.PointF(Helpers.GraphSettings.center_X * 2, Helpers.GraphSettings.center_Y - Helpers.GraphSettings.scale));
        }
    }
}
