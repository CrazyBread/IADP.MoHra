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

        public void Draw(System.Windows.Forms.Control control)
        {
            using (var graphics = control.CreateGraphics())
            {
                Random rnd = new Random();
                var rndColor = System.Drawing.Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                var pen = new System.Drawing.Pen(rndColor);
                graphics.DrawLines(pen, new[]
                {
                    new System.Drawing.PointF((float)Begin * 100, 0)
                    , new System.Drawing.PointF((float)Top * 100, 100)
                    , new System.Drawing.PointF((float)End * 100, 0)
                });
            }
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
