﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IADP.MoHra.Helpers;
using IADP.MoHra.Model.Fuzzy;
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
            result += _GetResultForA1();
            result += _GetResultForA2();
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

        private string _GetResultForA1()
        {
            var result = "";
            var clastResult = _result.GetResult();

            var objectsInClasters = clastResult.Select(i => i.Value.Claster).GroupBy(i => i, (i, j) => (double)j.Count()).ToList();
            double resultValue = objectsInClasters.StdDev();

            var scale = FuzzyScaleRepository.ForA1();
            var scaleValue = scale.GetAccessory((decimal)resultValue);

            if (scaleValue.Name == "P13")
                result += "<p>По числу элементов кластеры отличаются сильно.</p>";
            else if (scaleValue.Name == "P12")
                result += "<p>По числу элементов кластеры различаются не сильно.</p>";
            else if (scaleValue.Name == "P11")
                result += "<p>По числу элементов кластеры практически одинаковы.</p>";
            else throw new ArgumentException();

            return result;
        }

        private string _GetResultForA2()
        {
            var result = "<h2>Подробная характеристика кластеров</h2>";
            result += "<p><em>Собранность кластера означает, что значения объектов не выходят за пределы удвоенного среднеквадратического отклонения.</em></p>";
            var clastResult = _result.GetResult();

            var scale = FuzzyScaleRepository.ForA2();

            result += "<ul>";
            var clasters = clastResult.Select(i => i.Value.Claster).Distinct().ToList();
            foreach (var claster in clasters)
            {
                var clastName = ClasterHelper.GetFullName(claster);
                var clastNum = clastResult.Count(i => i.Value.Claster == claster);

                var clastValue = clastResult.Where(i => i.Value.Claster == claster).Select(i => (double)i.Value.Points).ToList().StdDev();
                var scaleValue = scale.GetAccessory((decimal)clastValue);

                var clastValueResult = (scaleValue.Name == "P21") ? "собранный" : "разрозненный";

                result += $"<li><strong>Кластер {clastName}</strong>. Элементов: {clastNum}, {clastValueResult}.</li>";
            }

            result += "</ul>";
            return result;
        }
    }
}
