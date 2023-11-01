using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracerChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RayTracerChallenge.Tests
{
    [TestClass()]
    public class MainClassTests
    {
        [TestMethod]
        public void IdentifyTupleVector_Test()
        {
            MainClass.Tuple tuple = new MainClass.Tuple((float)4.3, (float)-4.2, (float)3.1, (float)0.0);
            string Expected = "vector";

            var Actual = MainClass.IdentifyTuple(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void IdentifyTuplePoint_Test()
        {
            MainClass.Tuple tuple = new MainClass.Tuple((float)4.3, (float)-4.2, (float)3.1, (float)1.0);
            string Expected = "point";

            var Actual = MainClass.IdentifyTuple(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void CreatePointTuple_Test()
        {
            (float x, float y, float z) point = (4, -4, 3);
            float Expected = 1;

            MainClass.Tuple NewPoint = MainClass.CreatePointTuple(point);
            float Actual = NewPoint.w;

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void CreateVectorTuple_Test()
        {
            (float x, float y, float z) vector = (4, -4, 3);
            float Expected = 0;

            MainClass.Tuple NewVector = MainClass.CreateVectorTuple(vector);
            float Actual = NewVector.w;

            Assert.AreEqual(Expected, Actual);
        }
    }
}