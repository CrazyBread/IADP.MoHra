﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IADP.MoHra.Model.Classification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IADP.MoHra.Tests
{
    public class IrisItem
    {
        public decimal SepalLength { set; get; }
        public decimal SepalWidth { set; get; }
        public decimal PetalLength { set; get; }
        public decimal PetalWidth { set; get; }
        public string ClassName { set; get; }
    }

    [TestClass]
    public class ClassificationIris
    {
        [TestMethod]
        public void ClassificationIris_Test()
        {
            var cult = new CultureInfo("en-US");
            var lines = System.IO.File.ReadAllLines("iris.data");
            var irisList = lines.Select(i =>
            {
                var irisItem = i.Split(',');
                return new IrisItem()
                {
                    SepalLength = Convert.ToDecimal(irisItem[0], cult),
                    SepalWidth = Convert.ToDecimal(irisItem[1], cult),
                    PetalLength = Convert.ToDecimal(irisItem[2], cult),
                    PetalWidth = Convert.ToDecimal(irisItem[3], cult),
                    ClassName = irisItem[4]
                };
            }).ToList();

            var classes = irisList.Select(i => i.ClassName).Distinct().Select(i => new CClass() { Name = i }).ToList();

            var space = new CSpace();
            space.Classes.AddRange(classes);
            foreach (var irisItem in irisList)
            {
                var objCl = classes.First(i => i.Name == irisItem.ClassName);
                var obj = CObjectFactory.GetFromProperties(objCl, irisItem, "SepalLength", "SepalWidth", "PetalLength", "PetalWidth");
                space.Objects.Add(obj);
            }

            int validCnt = 0;
            var resolver = new CResolver(space);

            var newIris1 = new IrisItem() { SepalLength = 5, SepalWidth = 3.5m, PetalLength = 1.5m, PetalWidth = 0.2m };
            var result1 = resolver.Resolve(CObjectFactory.GetFromProperties(newIris1, "SepalLength", "SepalWidth", "PetalLength", "PetalWidth"));
            //Assert.AreEqual(result1.Name, "Iris-setosa");
            if (result1 != null && result1.Name == "Iris-setosa") validCnt++;

            var newIris2 = new IrisItem() { SepalLength = 6, SepalWidth = 2.7m, PetalLength = 4m, PetalWidth = 1.3m };
            var result2 = resolver.Resolve(CObjectFactory.GetFromProperties(newIris2, "SepalLength", "SepalWidth", "PetalLength", "PetalWidth"));
            //Assert.AreEqual(result2.Name, "Iris-versicolor");
            if (result2 != null && result2.Name == "Iris-versicolor") validCnt++;

            var newIris3 = new IrisItem() { SepalLength = 6.5m, SepalWidth = 3, PetalLength = 5.5m, PetalWidth = 2 };
            var result3 = resolver.Resolve(CObjectFactory.GetFromProperties(newIris3, "SepalLength", "SepalWidth", "PetalLength", "PetalWidth"));
            //Assert.AreEqual(result3.Name, "Iris-virginica");
            if(result3 != null && result3.Name == "Iris-virginica") validCnt++;

            Assert.IsTrue(validCnt > 0);
        }

        [TestMethod]
        public void ClassificationIris_Test2()
        {
            var cult = new CultureInfo("en-US");
            var lines = System.IO.File.ReadAllLines("iris.data");
            var irisList = lines.Select(i =>
            {
                var irisItem = i.Split(',');
                return new IrisItem()
                {
                    SepalLength = Convert.ToDecimal(irisItem[0], cult),
                    SepalWidth = Convert.ToDecimal(irisItem[1], cult),
                    PetalLength = Convert.ToDecimal(irisItem[2], cult),
                    PetalWidth = Convert.ToDecimal(irisItem[3], cult),
                    ClassName = irisItem[4]
                };
            }).ToList();

            var classes = irisList.Select(i => i.ClassName).Distinct().Select(i => new CClass() { Name = i }).ToList();

            var space = new CSpace();
            space.Classes.AddRange(classes);
            foreach (var irisItem in irisList)
            {
                var objCl = classes.First(i => i.Name == irisItem.ClassName);
                var obj = CObjectFactory.GetFromProperties(objCl, irisItem, "SepalLength", "SepalWidth", "PetalLength", "PetalWidth");
                space.Objects.Add(obj);
            }

            List<CObject> unknownObjects = new List<CObject>();
            foreach (var cl in space.Classes)
            {
                var objToRemove = space.Objects.Where(i => i.Class == cl).Take(10).ToList();
                unknownObjects.AddRange(objToRemove);
                foreach (var obj in objToRemove)
                    space.Objects.Remove(obj);
            }

            var resolver = new CResolver(space);

            int allCnt = unknownObjects.Count;
            int resolvedCnt = 0;

            foreach (var obj in unknownObjects)
            {
                var result = resolver.Resolve(obj);
                if (result == obj.Class)
                    resolvedCnt++;
            }
            Assert.IsTrue(resolvedCnt * 1.0 / allCnt > 0.1);
        }
    }
}
