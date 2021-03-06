﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Fuzzy
{
    class FuzzyScaleBorderItem : IFuzzyScaleItem
    {
        public decimal Begin { set; get; }
        public decimal Top { set; get; }
        public string Name { get; set; }

        public decimal GetAccessory(decimal value)
        {
            _Check();

            decimal result = 0;
            bool direction = (Top > Begin);

            if (direction)
            {
                if (value < Begin)
                    result = 0;
                else if (value >= Top)
                    result = 1;
                else
                    result = (value - Begin) / (Top - Begin);
            }
            else
            {
                if (value > Begin)
                    result = 0;
                else if (value <= Top)
                    result = 1;
                else
                    result = (Begin - value) / (Begin - Top);
            }

            return result;
        }

        public void Draw(System.Drawing.Graphics graphics)
        {
            graphics.DrawLines(System.Drawing.Pens.Black, new[] 
            {
                new System.Drawing.PointF((float)Begin * Helpers.GraphSettings.scale + Helpers.GraphSettings.center_X, Helpers.GraphSettings.center_Y)
                , new System.Drawing.PointF((float)Top * Helpers.GraphSettings.scale + Helpers.GraphSettings.center_X, Helpers.GraphSettings.center_Y - Helpers.GraphSettings.scale)
            });
        }

        private void _Check()
        {
            if (Begin == Top)
                throw new ArgumentException();
        }
    }
}
