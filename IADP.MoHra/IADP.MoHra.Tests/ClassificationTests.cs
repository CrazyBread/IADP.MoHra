using System;
using System.Collections.Generic;
using IADP.MoHra.Helpers;
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

        [TestMethod]
        public void Classification_Fitness_Test1()
        {
            var cl1 = new List<CObject>();
            var cl2 = new List<CObject>();

            cl1.Add(CObjectFactory.GetFromProperties(new { x = 1, y = 1 }, "x", "y"));
            cl1.Add(CObjectFactory.GetFromProperties(new { x = 1, y = 2 }, "x", "y"));
            cl1.Add(CObjectFactory.GetFromProperties(new { x = 2, y = 1 }, "x", "y"));
            cl1.Add(CObjectFactory.GetFromProperties(new { x = 2, y = 2 }, "x", "y"));
            cl1.Add(CObjectFactory.GetFromProperties(new { x = 3, y = 3 }, "x", "y"));

            cl2.Add(CObjectFactory.GetFromProperties(new { x = -1, y = -1 }, "x", "y"));
            cl2.Add(CObjectFactory.GetFromProperties(new { x = -1, y = -2 }, "x", "y"));
            cl2.Add(CObjectFactory.GetFromProperties(new { x = -2, y = -1 }, "x", "y"));
            cl2.Add(CObjectFactory.GetFromProperties(new { x = -2, y = -2 }, "x", "y"));
            cl2.Add(CObjectFactory.GetFromProperties(new { x = -3, y = -3 }, "x", "y"));

            var line1Attrs = new decimal[] { 1, 1, 0 };
            var line2Attrs = new decimal[] { 1, 1, 1 };
            var line3Attrs = new decimal[] { 1, -1, 0 };
            var line4Attrs = new decimal[] { 0, 1, -10 };

            var val1 = FitnessValueHelper.GetValue(cl1, cl2, line1Attrs);
            var val2 = FitnessValueHelper.GetValue(cl1, cl2, line2Attrs);
            var val3 = FitnessValueHelper.GetValue(cl1, cl2, line3Attrs);
            var val4 = FitnessValueHelper.GetValue(cl1, cl2, line4Attrs);

            Assert.IsTrue(val1 > val2);
            Assert.IsTrue(val2 > val3);
            Assert.IsTrue(val3 > val4);
        }

        [TestMethod]
        public void Classification_Resolver_2_3()
        {
            var space = new CSpace();
            var cl1 = new CClass() { Name = "Plus" };
            var cl2 = new CClass() { Name = "Minus" };
            var cl3 = new CClass() { Name = "AbsMinus" };

            space.Classes.Add(cl1);
            space.Classes.Add(cl2);
            space.Classes.Add(cl3);

            // 1 четверть
            space.Objects.Add(CObjectFactory.GetFromProperties(cl1, new { x = 1, y = 1 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl1, new { x = 1, y = 2 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl1, new { x = 2, y = 1 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl1, new { x = 2, y = 2 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl1, new { x = 3, y = 3 }, "x", "y"));

            // 2 четверть
            space.Objects.Add(CObjectFactory.GetFromProperties(cl2, new { x = -1, y = 1 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl2, new { x = -1, y = 2 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl2, new { x = -2, y = 1 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl2, new { x = -2, y = 2 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl2, new { x = -3, y = 3 }, "x", "y"));

            // 3 четверть
            space.Objects.Add(CObjectFactory.GetFromProperties(cl3, new { x = -1, y = -1 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl3, new { x = -1, y = -2 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl3, new { x = -2, y = -1 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl3, new { x = -2, y = -2 }, "x", "y"));
            space.Objects.Add(CObjectFactory.GetFromProperties(cl3, new { x = -3, y = -3 }, "x", "y"));

            var resolver = new CResolver(space);
            var objCl1 = resolver.Resolve(CObjectFactory.GetFromProperties(new { x = 4, y = 4 }, "x", "y"));
            var objCl2 = resolver.Resolve(CObjectFactory.GetFromProperties(new { x = -4, y = -4 }, "x", "y"));
            var objCl3 = resolver.Resolve(CObjectFactory.GetFromProperties(new { x = -4, y = 4 }, "x", "y"));

            Assert.IsNotNull(objCl1);
            Assert.IsNotNull(objCl2);
            Assert.IsNotNull(objCl3);
            Assert.AreEqual("Plus", objCl1.Name);
            Assert.AreEqual("AbsMinus", objCl2.Name);
            Assert.AreEqual("Minus", objCl3.Name);
        }

        [TestMethod]
        public void Classification_Resolver_2_4()
        {
            var space = new CSpace();

            var senior = new CClass() { Name = "Старший разработчик" };
            var middle = new CClass() { Name = "Средний разработчик" };
            var junior = new CClass() { Name = "Младший разработчик" };

            space.Classes.Add(senior);
            space.Classes.Add(middle);
            space.Classes.Add(junior);

            space.Objects.Add(CObjectFactory.GetFromProperties(senior, new { codePoints = 6, databasePoints = 5, experience = 21, education = 4 }, "codePoints", "databasePoints", "experience", "education"));

            space.Objects.Add(CObjectFactory.GetFromProperties(middle, new { codePoints = 5, databasePoints = 3, experience = 20, education = 4 }, "codePoints", "databasePoints", "experience", "education"));

            space.Objects.Add(CObjectFactory.GetFromProperties(junior, new { codePoints = 2, databasePoints = 1, experience = 9, education = 3 }, "codePoints", "databasePoints", "experience", "education"));

            List<CObject> unknownObjects = new List<CObject>();
            unknownObjects.Add(CObjectFactory.GetFromProperties(senior, new { codePoints = 7, databasePoints = 5, experience = 120, education = 5 }, "codePoints", "databasePoints", "experience", "education"));
            unknownObjects.Add(CObjectFactory.GetFromProperties(senior, new { codePoints = 6, databasePoints = 4, experience = 25, education = 4 }, "codePoints", "databasePoints", "experience", "education"));

            
            unknownObjects.Add(CObjectFactory.GetFromProperties(middle, new { codePoints = 4, databasePoints = 4, experience = 25, education = 4 }, "codePoints", "databasePoints", "experience", "education"));
            unknownObjects.Add(CObjectFactory.GetFromProperties(middle, new { codePoints = 3, databasePoints = 3, experience = 19, education = 3 }, "codePoints", "databasePoints", "experience", "education"));
            unknownObjects.Add(CObjectFactory.GetFromProperties(middle, new { codePoints = 5, databasePoints = 3, experience = 19, education = 3 }, "codePoints", "databasePoints", "experience", "education"));

            unknownObjects.Add(CObjectFactory.GetFromProperties(junior, new { codePoints = 4, databasePoints = 2, experience = 7, education = 4 }, "codePoints", "databasePoints", "experience", "education"));
            unknownObjects.Add(CObjectFactory.GetFromProperties(junior, new { codePoints = 2, databasePoints = 3, experience = 9, education = 3 }, "codePoints", "databasePoints", "experience", "education"));

            CResolver resolver = new CResolver(space);

            int verifiedCount = 0;
            foreach (var obj in unknownObjects)
            {
                var calcClass = resolver.Resolve(obj);
                if (calcClass != null && calcClass.Equals(obj.Class))
                    verifiedCount++;
            }

            Assert.IsTrue(verifiedCount * 1.0 / unknownObjects.Count > 0.5);
        }
    }
}
