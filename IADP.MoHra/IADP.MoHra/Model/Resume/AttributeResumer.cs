using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }
    }
}
