using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Fuzzy
{
    static class FuzzyScaleRepository
    {
        public static FuzzyScale ForA1()
        {
            var scale = new FuzzyScale();
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P11", Begin = 2, Top = 1 });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P12", Begin = 1, Top = 2, End = 3 });
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P13", Begin = 2, Top = 3 });
            return scale;
        }

        public static FuzzyScale ForA2()
        {
            var scale = new FuzzyScale();
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P21", Begin = 3, Top = 1 });
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P22", Begin = 1, Top = 3 });
            return scale;
        }

        public static FuzzyScale ForA3()
        {
            var scale = new FuzzyScale();
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P31", Begin = -1.0m, Top = -1.75m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P32", Begin = 0m, Top = -1.0m, End = -1.75m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P33", Begin = -1.0m, Top = 0, End = 1.0m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P34", Begin = 0m, Top = 1.0m, End = 1.75m });
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P35", Begin = 1.0m, Top = 1.75m });
            return scale;
        }

        public static FuzzyScale ForA4()
        {
            var scale = new FuzzyScale();
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P41", Begin = -1.5m, Top = -2.5m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P42", Begin = 0m, Top = -1.5m, End = -2.5m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P43", Begin = -1.5m, Top = 0, End = 1.5m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P44", Begin = 0m, Top = 1.5m, End = 2.5m });
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P45", Begin = 1.5m, Top = 2.5m });
            return scale;
        }

        public static FuzzyScale ForA5()
        {
            var scale = new FuzzyScale();
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P51", Begin = 0.5m, Top = -0.5m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P52", Begin = -0.5m, Top = 0.5m, End = 1.5m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P53", Begin = 0.5m, Top = 1.5m, End = 2.5m });
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P54", Begin = 1.5m, Top = 2.5m });
            return scale;
        }
    }
}
