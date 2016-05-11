using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IADP.MoHra.Model.Result;

namespace IADP.MoHra.Model.Resume
{
    /// <summary>
    /// Класс, определяющий работу лингвистического резюмирования темпоральной классификации.
    /// </summary>
    class TimeResumer : IMultipleResumer
    {
        private List<KeyValuePair<string, RResult>> _results = new List<KeyValuePair<string, RResult>>();

        public string GetResult()
        {
            if (_results.Count == 0)
                throw new ArgumentException("Нет результатов");
            throw new NotImplementedException();
        }

        public void AddResult(string name, RResult result)
        {
            _results.Add(new KeyValuePair<string, RResult>(name, result));
        }
    }
}
