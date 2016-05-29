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
        public static double GetValue(List<CObject> c1, List<CObject> c2, params decimal[] gens)
        {
            _Check(c1, c2, gens);
            //var c
            throw new NotImplementedException();
        }

        private static void _Check(List<CObject> c1, List<CObject> c2, params decimal[] gens)
        {
            var atrCount = c1.First().AttributeValues.Count;
            if (1 + gens.Length != atrCount)
                throw new Exception("Число генов должно быть как число атрибутов + 1");
        }
    }
}
