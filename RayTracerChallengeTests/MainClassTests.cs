using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracerChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static RayTracerChallenge.MainClass;

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

        [TestMethod]
        public void CreateCanvas_Test()
        {
            MainClass.Color Black = new MainClass.Color(0, 0, 0);

            MainClass.Canvas Actual = new MainClass.Canvas(10, 20);

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 20; ++j)
                {
                    MainClass.Color Temp = Actual.Size[i, j];
                    Assert.AreEqual(Temp, Black);
                }
            }
        }

        [TestMethod]
        public void WritePixel_Test()
        {
            MainClass.Color Red = new MainClass.Color(1, 0, 0);

            MainClass.Canvas Actual = new MainClass.Canvas(10, 20);
            Actual = WritePixel(Actual, 2, 3, Red);
            Assert.AreEqual(Actual.Size[2, 3], Red);
        }

        [TestMethod]
        public void CanvasToPPMLine123_Test()
        {
            string Expected = "P3\n5 3\n255";
            MainClass.Canvas ToPass = new MainClass.Canvas(5, 3);

            string Actual = CanvasToPPM(ToPass);

            Assert.IsTrue(Actual.Contains(Expected));
        }

        [TestMethod]
        public void CanvasToPPMLine456_Test()
        {
            string Expected = "255 0 0 0 0 0 0 0 0 0 0 0 0 0 0 \n";
            Expected += "0 0 0 0 0 0 0 128 0 0 0 0 0 0 0 \n";
            Expected += "0 0 0 0 0 0 0 0 0 0 0 0 0 0 255 \n";
            MainClass.Canvas ToPass = new MainClass.Canvas(5, 3);
            MainClass.Color C1 = new Color((float)1.5, 0, 0);
            MainClass.Color C2 = new Color(0, (float)0.5, 0);
            MainClass.Color C3 = new Color((float)-0.5, 0, 1);
            ToPass = WritePixel(ToPass, 0, 0, C1);
            ToPass = WritePixel(ToPass, 2, 1, C2);
            ToPass = WritePixel(ToPass, 4, 2, C3);

            string Actual = CanvasToPPM(ToPass);

            Assert.IsTrue(Actual.Contains(Expected));
        }

        [TestMethod]
        public void CanvasToPPMToLong_Test()
        {
            string Expected = "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 \n";
            Expected += "153 255 204 153 255 204 153 255 204 153 255 204 153 \n";
            Expected += "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 \n";
            Expected += "153 255 204 153 255 204 153 255 204 153 255 204 153 \n";
            MainClass.Canvas ToPass = new MainClass.Canvas(10, 2);
            MainClass.Color C1 = new Color(1, (float)0.8, (float)0.6);
            for(int i = 0; i < 10; ++i)
            {
                for(int j = 0; j < 2; ++j)
                {
                    ToPass = WritePixel(ToPass, i, j, C1);
                }
            }

            string Actual = CanvasToPPM(ToPass);

            Assert.IsTrue(Actual.Contains(Expected));
        }
    }
}