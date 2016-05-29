using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Classification
{
    public class CSpace
    {
        public List<CClass> Classes { get; }
        public List<CObject> Objects { get; }

        public CSpace()
        {
            Classes = new List<CClass>();
            Objects = new List<CObject>();
        }

        public void Check(CObject newObject)
        {
            if (Classes.Count <= 1)
                throw new Exception("Классов должно быть больше одного.");
            if (Objects.Count < 2)
                throw new Exception("Объектов должно быть не менее двух.");

            foreach (var obj in Objects)
            {
                if (obj.Class == null)
                    throw new Exception("Существует объект с пустым классом.");
                if (!Classes.Contains(obj.Class))
                    throw new Exception("Существует объект с классом, которого нет в списке классов.");
            }

            foreach (var cl in Classes)
            {
                if (Objects.All(i => i.Class != cl))
                    throw new Exception($"В классе {cl.Name} нет объектов.");
            }

            // smart attributes compartion
            var eKeys = Objects[0].AttributeValues.Keys.OrderBy(i => i).ToList();
            foreach (var obj in Objects)
            {
                var keys = obj.AttributeValues.Keys.OrderBy(i => i).ToList();
                if (keys.Except(eKeys).Count() != 0 || eKeys.Except(keys).Count() != 0)
                    throw new Exception("Несходняк атрибутов в объектах (по числу и по имени).");
            }
            if (newObject != null)
            {
                var newKeys = newObject.AttributeValues.Keys.OrderBy(i => i).ToList();
                if (newKeys.Except(eKeys).Count() != 0 || eKeys.Except(newKeys).Count() != 0)
                    throw new Exception("Несходняк атрибутов в новом объекте.");
            }
        }
    }
}
