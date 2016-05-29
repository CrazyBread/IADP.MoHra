using System;
using System.Collections.Generic;
using System.Linq;
using IADP.MoHra.Model.Classification;

namespace IADP.MoHra.Helpers
{
    public static class FitnessValueHelper
    {
        /// <summary>
        /// Высчитывает значение приспособленности для прямой.
        /// </summary>
        /// <param name="c1">Объекты класса 1.</param>
        /// <param name="c2">Объекты класса 2.</param>
        /// <param name="gens">Набор генов (значений коэффициентов) прямой.</param>
        /// <returns></returns>
        public static decimal GetValue(List<CObject> c1, List<CObject> c2, params decimal[] gens)
        {
            _Check(c1, c2, gens);

            var c1Elems = new int[2];
            var c2Elems = new int[2];
            #region Sorry...
            foreach (var c1Elem in c1)
            {
                var attrs = c1Elem.Attributes;
                decimal value = 0;
                for (int i = 0; i < attrs.Length; i++)
                    value += attrs[i] * gens[i];
                value += gens[gens.Length - 1];
                if (value > 0)
                    ++c1Elems[0];
                else
                    ++c1Elems[1];
            }
            foreach (var c2Elem in c2)
            {
                var attrs = c2Elem.Attributes;
                decimal value = 0;
                for (int i = 0; i < attrs.Length; i++)
                    value += attrs[i] * gens[i];
                value += gens[gens.Length - 1];
                if (value > 0)
                    ++c2Elems[0];
                else
                    ++c2Elems[1];
            }
            #endregion

            bool isDirect = c1Elems[0] >= c1Elems[1];
            var c1Total = c1.Count;
            var c1Miss = isDirect ? c1Elems[1] : c1Elems[0];
            var c2Total = c2.Count;
            var c2Miss = isDirect ? c2Elems[0] : c2Elems[1];

            var componentFirst = _GetValueFirstComponent(c1Total, c2Total, c1Total - c1Miss, c2Total - c2Miss);

            var c1Clean = new List<CObject>();
            var c2Clean = new List<CObject>();
            #region Sorry [2]...
            foreach (var c1Elem in c1)
            {
                var attrs = c1Elem.Attributes;
                decimal value = 0;
                for (int i = 0; i < attrs.Length; i++)
                    value += attrs[i] * gens[i];
                value += gens[gens.Length - 1];
                if ((value >= 0 && isDirect) || (value < 0 && !isDirect))
                    c1Clean.Add(c1Elem);
            }
            foreach (var c2Elem in c2)
            {
                var attrs = c2Elem.Attributes;
                decimal value = 0;
                for (int i = 0; i < attrs.Length; i++)
                    value += attrs[i] * gens[i];
                value += gens[gens.Length - 1];
                if ((value >= 0 && !isDirect) || (value < 0 && isDirect))
                    c2Clean.Add(c2Elem);
            }
            #endregion

            decimal componentSecond = 0;
            if (componentFirst > 0)
            {
                var minDistanceBetweenClasses = _GetMinDistanceBetweenClasses(c1Clean, c2Clean);
                var minDistanceFromC1 = _GetMinDistanceFromClassToLine(c1Clean, gens);
                var minDistanceFromC2 = _GetMinDistanceFromClassToLine(c2Clean, gens);
                componentSecond = _GetValueSecondComponent(minDistanceBetweenClasses, minDistanceFromC1, minDistanceFromC2);
            }

            return componentFirst + componentSecond;
        }

        private static void _Check(List<CObject> c1, List<CObject> c2, params decimal[] gens)
        {
            var atrCount = c1.First().AttributeValues.Count;
            if (gens.Length != atrCount + 1)
                throw new Exception("Число генов должно быть как число атрибутов + 1");
        }

        /// <summary>
        /// Возвращает минимальне расстояние между элементами противоволожных классов.
        /// </summary>
        private static decimal _GetMinDistanceBetweenClasses(List<CObject> c1, List<CObject> c2)
        {
            decimal value = decimal.MaxValue;
            foreach (var c1Elem in c1)
            {
                var c1Attr = c1Elem.Attributes;
                foreach (var c2Elem in c2)
                {
                    decimal currentValue = 0;
                    var c2Attr = c2Elem.Attributes;
                    for (int i = 0; i < c2Attr.Length; i++)
                        currentValue += (c2Attr[i] - c1Attr[i]) * (c2Attr[i] - c1Attr[i]);
                    if (currentValue < value)
                        value = currentValue;
                }
            }
            return (decimal)Math.Sqrt((double)value);
        }

        /// <summary>
        /// Возвращает расстояние от точки до прямой.
        /// </summary>
        /// <param name="obj">"Точка".</param>
        /// <param name="gens">"Прямая".</param>
        private static decimal _GetDistanceFromObjectToLine(CObject obj, params decimal[] gens)
        {
            // ref: http://youclever.org/book/koordinaty-i-vektory-3

            decimal value = 0;
            var objAttrs = obj.Attributes;
            for (int i = 0; i < objAttrs.Length; i++)
                value += gens[i] * objAttrs[i];
            value += gens[gens.Length - 1];

            decimal denom = 0;
            for (int i = 0; i < objAttrs.Length; i++)
                denom += gens[i] * gens[i];

            return Math.Abs(value) / (decimal)Math.Sqrt((double)denom);
        }

        private static decimal _GetMinDistanceFromClassToLine(List<CObject> objs, params decimal[] gens)
        {
            decimal result = decimal.MaxValue;
            foreach (var obj in objs)
            {
                var value = +_GetDistanceFromObjectToLine(obj, gens);
                if (value < result)
                    result = value;
            }
            return result;
        }

        private static decimal _GetValueFirstComponent(int c1Cnt, int c2Cnt, int c1ClearCnt, int c2ClearCnt)
        {
            var c1Val = (decimal)c1ClearCnt / c1Cnt;
            var c2Val = (decimal)c2ClearCnt / c2Cnt;

            return c1Val < c2Val ? c1Val : c2Val;
        }

        private static decimal _GetValueSecondComponent(decimal distBetweenClasses, decimal minDistance1, decimal minDistance2)
        {
            var minDistance = minDistance1 < minDistance2 ? minDistance1 : minDistance2;
            return 2 * minDistance / distBetweenClasses;
        }
    }
}
