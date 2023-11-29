﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void CreateColor_Test()
        {
            float Red = (float)-0.5;
            float Green = (float)0.4;
            float Blue = (float)1.7;
            MainClass.Color Expected = new MainClass.Color((float)-0.5, (float)0.4, (float)1.7);

            MainClass.Color Actual = MainClass.CreateColor(Red, Green, Blue);

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

        [TestMethod]
        public void CreateFBFMatrix()
        {
            float[] ToAssign = { 1, 2, 3, 4, (float)5.5, (float)6.5, (float)7.5, (float)8.5, 9, 10, 11, 12, (float)13.5, (float)14.5, (float)15.5, (float)16.5 };

            MainClass.FBFMatrix Actual = new MainClass.FBFMatrix(ToAssign);

            Assert.AreEqual(Actual.Data[0, 0], 1);
            Assert.AreEqual(Actual.Data[0, 3], 4);
            Assert.AreEqual(Actual.Data[1, 0], (float)5.5);
            Assert.AreEqual(Actual.Data[1, 2], (float)7.5);
            Assert.AreEqual(Actual.Data[2, 2], 11);
            Assert.AreEqual(Actual.Data[3, 0], (float)13.5);
            Assert.AreEqual(Actual.Data[3, 2], (float)15.5);
        }

        [TestMethod]
        public void CreateTHBTHMatrix()
        {
            float[] ToAssign = { -3, 5, 0, 1, -2, -7, 0, 1, 1 };

            MainClass.THBTHMatrix Actual = new MainClass.THBTHMatrix(ToAssign);

            Assert.AreEqual(Actual.Data[0, 0], -3);
            Assert.AreEqual(Actual.Data[1, 1], -2);
            Assert.AreEqual(Actual.Data[2, 2], 1);
        }

        [TestMethod]
        public void CreateTWBTWMatrix()
        {
            float[] ToAssign = { -3, 5, 1, -2 };

            MainClass.TWBTWMatrix Actual = new MainClass.TWBTWMatrix(ToAssign);

            Assert.AreEqual(Actual.Data[0, 0], -3);
            Assert.AreEqual(Actual.Data[0, 1], 5);
            Assert.AreEqual(Actual.Data[1, 0], 1);
            Assert.AreEqual(Actual.Data[1, 1], -2);
        }
    }
}