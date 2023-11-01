using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracerChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge.Tests
{
    [TestClass()]
    public class TupleArithmaticClassTests
    {
        [TestMethod]
        public void AddTuples_Test()
        {
            MainClass.Tuple tuple1 = new MainClass.Tuple(3, -2, 5, 1);
            MainClass.Tuple tuple2 = new MainClass.Tuple(-2, 3, 1, 0);
            MainClass.Tuple Expected = new MainClass.Tuple(1, 1, 6, 1);

            MainClass.Tuple Actual = TupleArithmatic.AddTuples(tuple1, tuple2);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void SubtractTwoPoints_Test()
        {
            MainClass.Tuple point1 = new MainClass.Tuple(3, 2, 1, 1);
            MainClass.Tuple point2 = new MainClass.Tuple(5, 6, 7, 1);
            MainClass.Tuple Expected = new MainClass.Tuple(-2, -4, -6, 0);

            MainClass.Tuple Actual = TupleArithmatic.SubtractTuples(point1, point2);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void SubtractVectorFromPoint_Test()
        {
            MainClass.Tuple point = new MainClass.Tuple(3, 2, 1, 1);
            MainClass.Tuple vector = new MainClass.Tuple(5, 6, 7, 0);
            MainClass.Tuple Expected = new MainClass.Tuple(-2, -4, -6, 1);

            MainClass.Tuple Actual = TupleArithmatic.SubtractTuples(point, vector);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void SubtractTwoVectors_Test()
        {
            MainClass.Tuple vector1 = new MainClass.Tuple(3, 2, 1, 0);
            MainClass.Tuple vector2 = new MainClass.Tuple(5, 6, 7, 0);
            MainClass.Tuple Expected = new MainClass.Tuple(-2, -4, -6, 0);

            MainClass.Tuple Actual = TupleArithmatic.SubtractTuples(vector1, vector2);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void SubtractVectorFromZeroVector_Test()
        {
            MainClass.Tuple zeroVector = new MainClass.Tuple(0, 0, 0, 0);
            MainClass.Tuple vector = new MainClass.Tuple(1, -2, 3, 0);
            MainClass.Tuple Expected = new MainClass.Tuple(-1, 2, -3, 0);

            MainClass.Tuple Actual = TupleArithmatic.SubtractTuples(zeroVector, vector);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void NegateVector_Test()
        {
            MainClass.Tuple vector = new MainClass.Tuple(1, -2, 3, -4);
            MainClass.Tuple Expected = new MainClass.Tuple(-1, 2, -3, 4);

            MainClass.Tuple Actual = TupleArithmatic.NegateTuple(vector);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void MultiplyTupleByScalar_Test()
        {
            float scalar = (float)3.5;
            MainClass.Tuple tuple = new MainClass.Tuple(1, -2, 3, -4);
            MainClass.Tuple Expected = new MainClass.Tuple((float)3.5, -7, (float)10.5, -14);

            MainClass.Tuple Actual = TupleArithmatic.MultiplyTuple(tuple, scalar);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void MultiplyTupleByFraction_Test()
        {
            float scalar = (float)0.5;
            MainClass.Tuple tuple = new MainClass.Tuple(1, -2, 3, -4);
            MainClass.Tuple Expected = new MainClass.Tuple((float)0.5, -1, (float)1.5, -2);

            MainClass.Tuple Actual = TupleArithmatic.MultiplyTuple(tuple, scalar);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void DivideTuple_Test()
        {
            float scalar = 2;
            MainClass.Tuple tuple = new MainClass.Tuple(1, -2, 3, -4);
            MainClass.Tuple Expected = new MainClass.Tuple((float)0.5, -1, (float)1.5, -2);

            MainClass.Tuple Actual = TupleArithmatic.DivideTuple(tuple, scalar);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ComputeMagnitudeOfUnitVectorX_Test()
        {
            MainClass.Tuple tuple = new MainClass.Tuple(1, 0, 0, 0);
            float Expected = 1;

            float Actual = TupleArithmatic.ComputeMagnitudeOfVector(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ComputeMagnitudeOfUnitVectorY_Test()
        {
            MainClass.Tuple tuple = new MainClass.Tuple(0, 1, 0, 0);
            float Expected = 1;

            float Actual = TupleArithmatic.ComputeMagnitudeOfVector(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ComputeMagnitudeOfUnitVectorZ_Test()
        {
            MainClass.Tuple tuple = new MainClass.Tuple(0, 0, 1, 0);
            float Expected = 1;

            float Actual = TupleArithmatic.ComputeMagnitudeOfVector(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ComputeMagnitudeOfPositiveVector_Test()
        {
            MainClass.Tuple tuple = new MainClass.Tuple(1, 2, 3, 0);
            float Expected = (float)Math.Sqrt(14);

            float Actual = TupleArithmatic.ComputeMagnitudeOfVector(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ComputeMagnitudeOfNegativeVector_Test()
        {
            MainClass.Tuple tuple = new MainClass.Tuple(-1, -2, -3, 0);
            float Expected = (float)Math.Sqrt(14);

            float Actual = TupleArithmatic.ComputeMagnitudeOfVector(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void NormalizeUnitVector_Test()
        {
            MainClass.Tuple tuple = new MainClass.Tuple(4, 0, 0, 0);
            MainClass.Tuple Expected = new MainClass.Tuple(1, 0, 0, 0);

            MainClass.Tuple Actual = TupleArithmatic.NormalizeTuple(tuple);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void NormalizeVector_Test()
        {
            MainClass.Tuple tuple = new MainClass.Tuple(1, 2, 3, 0);
            MainClass.Tuple Expected = new MainClass.Tuple((float)(1 / Math.Sqrt(14)), (float)(2 / Math.Sqrt(14)), (float)(3 / Math.Sqrt(14)), 0);

            MainClass.Tuple Actual = TupleArithmatic.NormalizeTuple(tuple);

            Assert.IsTrue(MainClass.CompareTuple(Expected, Actual));
        }

        [TestMethod]
        public void DotProductOfTwoTuples_Test()
        {
            MainClass.Tuple tuple1 = new MainClass.Tuple(1, 2, 3, 0);
            MainClass.Tuple tuple2 = new MainClass.Tuple(2, 3, 4, 0);
            float Expected = 20;

            float Actual = TupleArithmatic.DotProductOfTwoTuples(tuple1, tuple2);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void CrossProductOfTwoTuplesAB_Test()
        {
            MainClass.Tuple tuple1 = new MainClass.Tuple(1, 2, 3, 0);
            MainClass.Tuple tuple2 = new MainClass.Tuple(2, 3, 4, 0);
            MainClass.Tuple Expected = new MainClass.Tuple(-1, 2, -1, 0);

            MainClass.Tuple Actual = TupleArithmatic.CrossProductOfTwoTuples(tuple1, tuple2);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void CrossProductOfTwoTuplesBA_Test()
        {
            MainClass.Tuple tuple1 = new MainClass.Tuple(1, 2, 3, 0);
            MainClass.Tuple tuple2 = new MainClass.Tuple(2, 3, 4, 0);
            MainClass.Tuple Expected = new MainClass.Tuple(1, -2, 1, 0);

            MainClass.Tuple Actual = TupleArithmatic.CrossProductOfTwoTuples(tuple2, tuple1);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void CreateColor_Test()
        {
            float Red = (float)-0.5;
            float Green = (float)0.4;
            float Blue = (float)1.7;
            MainClass.Color Expected = new MainClass.Color((float)-0.5, (float)0.4, (float)1.7);

            MainClass.Color Actual = TupleArithmatic.CreateColor(Red, Green, Blue);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void AddingColors_Test()
        {
            MainClass.Color Color1 = new MainClass.Color((float)0.9, (float)0.6, (float)0.75);
            MainClass.Color Color2 = new MainClass.Color((float)0.7, (float)0.1, (float)0.25);
            MainClass.Color Expected = new MainClass.Color((float)1.6, (float)0.7, (float)1.0);

            MainClass.Color Actual = TupleArithmatic.AddColors(Color1, Color2);

            Assert.IsTrue(MainClass.CompareColor(Expected, Actual));
        }

        [TestMethod]
        public void SubtractingColors_Test()
        {
            MainClass.Color Color1 = new MainClass.Color((float)0.9, (float)0.6, (float)0.75);
            MainClass.Color Color2 = new MainClass.Color((float)0.7, (float)0.1, (float)0.25);
            MainClass.Color Expected = new MainClass.Color((float)0.2, (float)0.5, (float)0.5);

            MainClass.Color Actual = TupleArithmatic.SubtractColors(Color1, Color2);

            Assert.IsTrue(MainClass.CompareColor(Expected, Actual));
        }

        [TestMethod]
        public void MultiplyColorByScalar_Test()
        {
            MainClass.Color Color1 = new MainClass.Color((float)0.2, (float)0.3, (float)0.4);
            MainClass.Color Expected = new MainClass.Color((float)0.4, (float)0.6, (float)0.8);
            float Scalar = 2;

            MainClass.Color Actual = TupleArithmatic.MultiplyColorByScalar(Color1, Scalar);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void MultiplyColors_Test()
        {
            MainClass.Color Color1 = new MainClass.Color(1, (float)0.2, (float)0.4);
            MainClass.Color Color2 = new MainClass.Color((float)0.9, 1, (float)0.1);
            MainClass.Color Expected = new MainClass.Color((float)0.9, (float)0.2, (float)0.04);

            MainClass.Color Actual = TupleArithmatic.MultiplyColors(Color1, Color2);

            Assert.IsTrue(MainClass.CompareColor(Expected, Actual));
        }
    }
}
