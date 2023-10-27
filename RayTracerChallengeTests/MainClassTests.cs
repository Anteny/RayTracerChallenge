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
            (float x, float y, float z, float w) tuple = ((float)4.3, (float)-4.2, (float)3.1, (float)0.0);
            string Expected = "vector";

            var Actual = MainClass.IdentifyTuple(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void IdentifyTuplePoint_Test()
        {
            (float x, float y, float z, float w) tuple = ((float)4.3, (float)-4.2, (float)3.1, (float)1.0);
            string Expected = "point";

            var Actual = MainClass.IdentifyTuple(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void CreatePointTuple_Test()
        {
            (float x, float y, float z) point = (4, -4, 3);
            float Expected = 1;

            var NewPoint = MainClass.CreatePointTuple(point);
            float Actual = NewPoint.w;

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void CreateVectorTuple_Test()
        {
            (float x, float y, float z) vector = (4, -4, 3);
            float Expected = 0;

            var NewVector = MainClass.CreateVectorTuple(vector);
            float Actual = NewVector.w;

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void AddTuples_Test()
        {
            (float x, float y, float z, float w) tuple1 = (3, -2, 5, 1);
            (float x, float y, float z, float w) tuple2 = (-2, 3, 1, 0);
            (float x, float y, float z, float w) Expected = (1, 1, 6, 1);

            (float x, float y, float z, float w)  Actual = MainClass.AddTuples(tuple1, tuple2);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void SubtractTwoPoints_Test()
        {
            (float x, float y, float z, float w) point1 = (3, 2, 1, 1);
            (float x, float y, float z, float w) point2 = (5, 6, 7, 1);
            (float x, float y, float z, float w) Expected = (-2, -4, -6, 0);

            (float x, float y, float z, float w) Actual = MainClass.SubtractTuples(point1, point2);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void SubtractVectorFromPoint_Test()
        {
            (float x, float y, float z, float w) point = (3, 2, 1, 1);
            (float x, float y, float z, float w) vector = (5, 6, 7, 0);
            (float x, float y, float z, float w) Expected = (-2, -4, -6, 1);

            (float x, float y, float z, float w) Actual = MainClass.SubtractTuples(point, vector);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void SubtractTwoVectors_Test()
        {
            (float x, float y, float z, float w) vector1 = (3, 2, 1, 0);
            (float x, float y, float z, float w) vector2 = (5, 6, 7, 0);
            (float x, float y, float z, float w) Expected = (-2, -4, -6, 0);

            (float x, float y, float z, float w) Actual = MainClass.SubtractTuples(vector1, vector2);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void SubtractVectorFromZeroVector_Test()
        {
            (float x, float y, float z, float w) zeroVector = (0, 0, 0, 0);
            (float x, float y, float z, float w) vector = (1, -2, 3, 0);
            (float x, float y, float z, float w) Expected = (-1, 2, -3, 0);

            (float x, float y, float z, float w) Actual = MainClass.SubtractTuples(zeroVector, vector);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void NegateVector_Test()
        {
            (float x, float y, float z, float w) vector = (1, -2, 3, -4);
            (float x, float y, float z, float w) Expected = (-1, 2, -3, 4);

            (float x, float y, float z, float w) Actual = MainClass.NegateTuple(vector);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void MultiplyTupleByScalar_Test()
        {
            float scalar = (float)3.5;
            (float x, float y, float z, float w) tuple = (1, -2, 3, -4);
            (float x, float y, float z, float w) Expected = ((float)3.5, -7, (float)10.5, -14);

            (float x, float y, float z, float w) Actual = MainClass.MultiplyTuple(tuple, scalar);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void MultiplyTupleByFraction_Test()
        {
            float scalar = (float)0.5;
            (float x, float y, float z, float w) tuple = (1, -2, 3, -4);
            (float x, float y, float z, float w) Expected = ((float)0.5, -1, (float)1.5, -2);

            (float x, float y, float z, float w) Actual = MainClass.MultiplyTuple(tuple, scalar);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void DivideTuple_Test()
        {
            float scalar = 2;
            (float x, float y, float z, float w) tuple = (1, -2, 3, -4);
            (float x, float y, float z, float w) Expected = ((float)0.5, -1, (float)1.5, -2);

            (float x, float y, float z, float w) Actual = MainClass.DivideTuple(tuple, scalar);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ComputeMagnitudeOfUnitVectorX_Test()
        {
            (float x, float y, float z, float w) tuple = (1, 0, 0, 0);
            float Expected = 1;

            float Actual = MainClass.ComputeMagnitudeOfVector(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ComputeMagnitudeOfUnitVectorY_Test()
        {
            (float x, float y, float z, float w) tuple = (0, 1, 0, 0);
            float Expected = 1;

            float Actual = MainClass.ComputeMagnitudeOfVector(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ComputeMagnitudeOfUnitVectorZ_Test()
        {
            (float x, float y, float z, float w) tuple = (0, 0, 1, 0);
            float Expected = 1;

            float Actual = MainClass.ComputeMagnitudeOfVector(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ComputeMagnitudeOfPositiveVector_Test()
        {
            (float x, float y, float z, float w) tuple = (1, 2, 3, 0);
            float Expected = (float)Math.Sqrt(14);

            float Actual = MainClass.ComputeMagnitudeOfVector(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ComputeMagnitudeOfNegativeVector_Test()
        {
            (float x, float y, float z, float w) tuple = (-1, -2, -3, 0);
            float Expected = (float)Math.Sqrt(14);

            float Actual = MainClass.ComputeMagnitudeOfVector(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void NormalizeUnitVector_Test()
        {
            (float x, float y, float z, float w) tuple = (4, 0, 0, 0);
            (float x, float y, float z, float w) Expected = (1, 0, 0, 0);

            (float x, float y, float z, float w) Actual = MainClass.NormalizeTuple(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void NormalizeVector_Test()
        {
            (float x, float y, float z, float w) tuple = (1, 2, 3, 0);
            (float x, float y, float z, float w) Expected = ((float)(1 / Math.Sqrt(14)), (float)(2 / Math.Sqrt(14)), (float)(3 / Math.Sqrt(14)), 0);

            (float x, float y, float z, float w) Actual = MainClass.NormalizeTuple(tuple);

            Assert.IsTrue(MainClass.CompareTuple(Expected, Actual));
        }

        [TestMethod]
        public void DotProductOfTwoTuples_Test()
        {
            (float x, float y, float z, float w) tuple1 = (1, 2, 3, 0);
            (float x, float y, float z, float w) tuple2 = (2, 3, 4, 0);
            float Expected = 20;

            float Actual = MainClass.DotProductOfTwoTuples(tuple1, tuple2);

            Assert.AreEqual(Expected, Actual);
        }
    }
}