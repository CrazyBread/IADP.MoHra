using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IADP.MoHra.Model.Fuzzy;
using IADP.MoHra.Model.Result;

namespace IADP.MoHra.Model.Resume
{
    /// <summary>
    /// Класс, определяющий работу лингвистического резюмирования темпоральной классификации.
    /// </summary>
    class TimeResumer : IMultipleResumer
    {
        private List<KeyValuePair<DateTime, RResult>> _results = new List<KeyValuePair<DateTime, RResult>>();
        private List<KeyValuePair<char, List<RTemporaryResultValue>>> _temporaryResults;

        public string GetResult()
        {
            if (_results.Count == 0)
                throw new ArgumentException("Нет результатов");
            _FillResults();
            var result = "<h1>Резюмирование темпоральной кластеризации</h1>";
            result += _GetResultForA3();
            result += _GetResultForA4();
            return result;
        }

        public void AddResult(DateTime month, RResult result)
        {
            _results.Add(new KeyValuePair<DateTime, RResult>(month, result));
        }

        private void _FillResults()
        {
            List<RTemporaryResultValue> resultList = new List<RTemporaryResultValue>();
            foreach (var pair in _results)
            {
                var pairKey = pair.Key;

                var clasterResult = pair.Value.GetResult();
                var list = from r in clasterResult.Select(d => new { ClasterName = d.Value.Claster, Value = d.Value.Points })
                           group r by r.ClasterName into g
                           select new RTemporaryResultValue()
                           {
                               Month = pairKey
                               , Claster = g.Key
                               , A3_Value = g.Select(i => (double)i.Value).Average()
                               , A4_Value = g.Count()
                           };
                resultList = resultList.Union(list).ToList();
            }
            _temporaryResults = resultList.GroupBy(g => g.Claster).Select(d => new KeyValuePair<char, List<RTemporaryResultValue>>(d.Key, d.ToList())).ToList();
        }

        private string _GetResultForA3()
        {
            string result = "<h2>Уровень разработки в кластере</h2><table border=\"1\"><tr><th>Кластер</th>";
            foreach (var key in _results.Select(d => d.Key).Distinct().OrderBy(d => d).Skip(1))
                result += $"<th>{key.ToString("MMMM yyyy")}</th>";
            result += "</tr>";

            var scale = new FuzzyScale();
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P31", Begin = -0.5m, Top = -1.5m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P32", Begin = -0.25m, Top = -0.75m, End = -1.25m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P33", Begin = -1.0m, Top = 0, End = 1.0m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P34", Begin = 0.25m, Top = 0.75m, End = 1.25m });
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P35", Begin = 0.5m, Top = 1.5m });
            
            foreach (var pair in _temporaryResults)
            {
                result += $"<tr><td>{Helpers.ClasterHelper.GetFullName(pair.Key)}</td>";
                foreach (var item in pair.Value.OrderBy(d => d.Month).Skip(1).Select((value, index) => new { index, value }))
                {
                    var beforeItem = pair.Value[item.index];

                    var value = item.value.A3_Value - beforeItem.A3_Value;
                    var absValue = Math.Abs(value);

                    var stringValue = string.Empty;

                    var scaleValue = scale.GetAccessory((decimal)value);

                    if (scaleValue.Name == "P33")
                        stringValue = "стабильность";
                    else if (scaleValue.Name == "P35")
                        stringValue = "сильный рост";
                    else if (scaleValue.Name == "P31")
                        stringValue = "сильное падение";
                    else if (scaleValue.Name == "P34")
                        stringValue = "слабый рост";
                    else if (scaleValue.Name == "P32")
                        stringValue = "слабое падение";
                    else throw new ArgumentException();

                    result += $"<td>{stringValue}</td>";
                }
                result += "</tr>";
            }

            result += "</table>";
            return result;
        }

        private string _GetResultForA4()
        {
            string result = "<h2>Число разработчиков в кластере</h2><table border=\"1\"><tr><th>Кластер</th>";
            foreach (var key in _results.Select(d => d.Key).Distinct().OrderBy(d => d).Skip(1))
                result += $"<th>{key.ToString("MMMM yyyy")}</th>";
            result += "</tr>";

            var scale = new FuzzyScale();
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P41", Begin = -1.5m, Top = -2.5m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P42", Begin = -0.5m, Top = -1, End = -1.5m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P43", Begin = -2.0m, Top = 0, End = 2.0m });
            scale.AddItem(new FuzzyScaleTriangleItem() { Name = "P44", Begin = 0.5m, Top = 1, End = 1.5m });
            scale.AddItem(new FuzzyScaleBorderItem() { Name = "P45", Begin = 1.5m, Top = 2.5m });

            foreach (var pair in _temporaryResults)
            {
                result += $"<tr><td>{Helpers.ClasterHelper.GetFullName(pair.Key)}</td>";
                foreach (var item in pair.Value.OrderBy(d => d.Month).Skip(1).Select((value, index) => new { index, value }))
                {
                    var beforeItem = pair.Value[item.index];

                    var value = item.value.A4_Value - beforeItem.A4_Value;
                    var absValue = Math.Abs(value);

                    var stringValue = string.Empty;

                    var scaleValue = scale.GetAccessory((decimal)value);

                    if (scaleValue.Name == "P43")
                        stringValue = "стабильность";
                    else if (scaleValue.Name == "P45")
                        stringValue = "сильный рост";
                    else if (scaleValue.Name == "P41")
                        stringValue = "сильное падение";
                    else if (scaleValue.Name == "P44")
                        stringValue = "слабый рост";
                    else if (scaleValue.Name == "P42")
                        stringValue = "слабое падение";
                    else throw new ArgumentException();

                    result += $"<td>{stringValue}</td>";
                }
                result += "</tr>";
            }

            result += "</table>";
            return result;
        }
    }
}
