using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Classification
{
    public class CResolver
    {
        public CSpace Space { get; }

        public CResolver(CSpace space)
        {
            Space = space;
        }

        public CClass Resolve(CObject newObject)
        {
            Space.Check(newObject);

            var newObjIncludes = new Dictionary<CClass, byte>();
            var classesBorder = new Dictionary<CClassPair, decimal[]>();
            var classesCentres = new Dictionary<CClass, decimal[]>();

            int dimensions = Space.Objects.First().Attributes.Length;
            
            foreach (var cls in Space.Classes)
            {
                newObjIncludes.Add(cls, 0);

                var attrs = Space.Objects.Where(i => i.Class == cls).Select(i => i.Attributes).ToList();
                var clsCentreAttr = new decimal[dimensions];
                for (int i = 0; i < clsCentreAttr.Length; i++)
                    clsCentreAttr[i] = attrs.Average(j => j[i]);
                classesCentres.Add(cls, clsCentreAttr);
            }

            var classesOrdered = Space.Classes.OrderBy(i => i.Name).ToList();
            for (int i = 0; i < classesOrdered.Count - 1; i++)
            {
                for (int j = i + 1; j < classesOrdered.Count; j++)
                {
                    var resultVal = GeneticAlgorithm.StartAlgorithm(Space, classesOrdered[i], classesOrdered[j]);
                    classesBorder.Add(new CClassPair(classesOrdered[i], classesOrdered[j]), resultVal);
                }
            }

            CClass result = null;

            foreach (var clBorder in classesBorder)
            {
                decimal c1Value = 0;
                for (int i = 0; i < dimensions; i++)
                    c1Value += classesCentres[clBorder.Key.C1][i] * clBorder.Value[i];
                c1Value += clBorder.Value[dimensions];

                var newObjAttrs = newObject.Attributes;
                decimal newObjValue = 0;
                for (int i = 0; i < dimensions; i++)
                    newObjValue += newObjAttrs[i] * clBorder.Value[i];
                newObjValue += clBorder.Value[dimensions];

                ++newObjIncludes[c1Value*newObjValue > 0 ? clBorder.Key.C1 : clBorder.Key.C2];
            }

            var maxIncMaxVal = newObjIncludes.Max(i => i.Value);
            if (newObjIncludes.Count(i => i.Value == maxIncMaxVal) == 1)
                result = newObjIncludes.Single(i => i.Value == maxIncMaxVal).Key;

            return result;
        }

        private class CClassPair
        {
            public CClassPair(CClass c1, CClass c2)
            {
                C1 = c1;
                C2 = c2;
            }

            public CClass C1 { set; get; }
            public CClass C2 { set; get; }
        }
    }
}
