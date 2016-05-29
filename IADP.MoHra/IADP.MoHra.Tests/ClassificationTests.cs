using System;
using IADP.MoHra.Model.Classification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IADP.MoHra.Tests
{
    [TestClass]
    public class ClassificationTests
    {
        [TestMethod]
        public void Classification_ObjectFactory_Test1()
        {
            var obj = CObjectFactory.GetFromProperties(new { A = 1, B = 2.0m, C = -1.5 }, "A", "B", "C");
            Assert.IsNotNull(obj);
            Assert.AreEqual(3, obj.AttributeValues.Count);
            Assert.AreEqual((decimal)-1.5, obj.AttributeValues["C"]);
        }

        [TestMethod]
        public void Classification_ObjectFactory_Test2()
        {
            var obj = CObjectFactory.GetFromProperties(new { A = 1, B = 2.0m, C = -1.5 }, "A", "B", "C");
            var attrs = obj.Attributes;
            Assert.IsNotNull(attrs);
            Assert.AreEqual(3, attrs.Length);
            Assert.AreEqual((decimal)-1.5, attrs[2]);
        }

        [TestMethod]
        public void Classification_Resolver_2_2()
        {
            var space = new CSpace();
            var cl1 = new CClass() { Name = "Plus" };
            var cl2 = new CClass() { Name = "Minus" };

            space.Classes.Add(cl1);
            space.Classes.Add(cl2);

            space.Objects.Add(CObjectFactory.GetFromProperties(cl1, new { x = 1, y = 1 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl1, new { x = 1, y = 2 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl1, new { x = 2, y = 1 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl1, new { x = 2, y = 2 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl1, new { x = 3, y = 3 }, "x", "y"));

            space.Objects.Add(CObjectFactory.GetFromProperties(cl2, new { x = -1, y = -1 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl2, new { x = -1, y = -2 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl2, new { x = -2, y = -1 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl2, new { x = -2, y = -2 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl2, new { x = -3, y = -3 }, "x", "y"));

            var resolver = new CResolver(space);
            var objCl1 = resolver.Resolve(CObjectFactory.GetFromProperties(cl1, new { x = 4, y = 4 }, "x", "y"));
            var objCl2 = resolver.Resolve(CObjectFactory.GetFromProperties(cl1, new { x = -4, y = -4 }, "x", "y"));

            Assert.IsNotNull(objCl1);
            Assert.IsNotNull(objCl2);
            Assert.AreEqual("Plus", objCl1.Name);
            Assert.AreEqual("Minus", objCl2.Name);
        }
    }
}
