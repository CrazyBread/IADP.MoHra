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
            result += "<p><em>\"С.и.\" в таблице обозначает \"степень истинности\".</em></p>";
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
                               , A3_Values = g.Select(i => (double)i.Value).ToList()
                               , A4_Values = g.Select(i => (double)i.Value).ToList()
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

            var scale = FuzzyScaleRepository.ForA3();
            
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

                    int cValueCount = 0, allCnt = 0;
                    for (int i = 0; i < item.value.A3_Values.Count(); i++)
                    {
                        try
                        {
                            var cValue = item.value.A3_Values[i] - beforeItem.A3_Values[i];
                            var csacleValue = scale.GetAccessory((decimal)cValue);
                            if (scaleValue.Name == csacleValue.Name)
                                cValueCount++;
                            allCnt++;
                        }
                        catch 
                        {
                        }
                    }
                    var tendation = "распределено равномерно";
                    if (1.0*cValueCount/allCnt > 0.5)
                        tendation = "типичная тенденция";

                    result += $"<td>{stringValue}<br/><small>(с.и.: {scaleValue.Value:0.00})<br/>{tendation}</small></td>";
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

            var scale = FuzzyScaleRepository.ForA4();

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

                    //int cValueCount = 0;
                    //for (int i = 0; i < item.value.A4_Values.Count(); i++)
                    //{
                    //    var cValue = item.value.A4_Values[i] - beforeItem.A4_Values[i];
                    //    var csacleValue = scale.GetAccessory((decimal)cValue);
                    //    if (scaleValue.Name == csacleValue.Name)
                    //        cValueCount++;
                    //}
                    //var tendation = "распределено равномерно";
                    //if (1.0 * cValueCount / item.value.A4_Values.Count() > 0.6)
                    //    tendation = "типичная тенденция";

                    result += $"<td>{stringValue}<br/><small>(с.и.: {scaleValue.Value:0.00})</small></td>";
                }
                result += "</tr>";
            }

            result += "</table>";
            return result;
        }
    }
}
 