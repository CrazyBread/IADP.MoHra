using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IADP.MoHra.Helpers;
using IADP.MoHra.Model.Result;

namespace IADP.MoHra.Model.Resume
{
    /// <summary>
    /// Класс, определяющий работу лингвистического резюмирования признаковой классификации.
    /// </summary>
    class AttributeResumer : SingleResumer
    {
        public override string GetResult()
        {
            if (_result == null)
                throw new ArgumentException("Нет результатов");
            var result = "<h1>Резюмирование кластеризации по признакам</h1>";
            result += _GetInitialSummary();
            return result;
        }

        private string _GetInitialSummary()
        {
            string result = "";
            var clastResult = _result.GetResult();

            var objects = clastResult.Count;
            var clasters = clastResult.Select(i => i.Value.Claster).Distinct().Count();
            result += $"<p>Всего было кластеризовано {objects} объект(ов) на {clasters} кластер(ов).</p>";

            var objectsInClasters = clastResult.Select(i => i.Value.Claster).GroupBy(i => i, (i, j) => new { Claster = i, Count = j.Count() }).ToList();
            var minObjects = objectsInClasters.Min(i => i.Count);
            var maxObjects = objectsInClasters.Max(i => i.Count);
            if (objectsInClasters.First(i => i.Count == minObjects) == objectsInClasters.Last(i => i.Count == minObjects))
            {
                // минимальный кластер один
                var claster = objectsInClasters.First(i => i.Count == minObjects);
                result += $"<p>Кластер с наименьшим числом элементов: {ClasterHelper.GetFullName(claster.Claster)}. Число элементов: {claster.Count}.</p>";

            }
            if (objectsInClasters.First(i => i.Count == maxObjects) == objectsInClasters.Last(i => i.Count == maxObjects))
            {
                // максимальный кластер один
                var claster = objectsInClasters.First(i => i.Count == maxObjects);
                result += $"<p>Кластер с наибольшим числом элементов: {ClasterHelper.GetFullName(claster.Claster)}. Число элементов: {claster.Count}.</p>";
            }

            return result;
        }
    }
}
