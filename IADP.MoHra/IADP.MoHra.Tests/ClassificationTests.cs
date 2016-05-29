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
    }
}
