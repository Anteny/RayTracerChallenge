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
            Actual = MainClass.WritePixel(Actual, 2, 3, Red);
            Assert.AreEqual(Actual.Size[2, 3], Red);
        }

        [TestMethod]
        public void CanvasToPPMLine123_Test()
        {
            string Expected = "P3\n5 3\n255";
            MainClass.Canvas ToPass = new MainClass.Canvas(5, 3);

            string Actual = MainClass.CanvasToPPM(ToPass);

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
            ToPass = MainClass.WritePixel(ToPass, 0, 0, C1);
            ToPass = MainClass.WritePixel(ToPass, 2, 1, C2);
            ToPass = MainClass.WritePixel(ToPass, 4, 2, C3);

            string Actual = MainClass.CanvasToPPM(ToPass);

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
                    ToPass = MainClass.WritePixel(ToPass, i, j, C1);
                }
            }

            string Actual = MainClass.CanvasToPPM(ToPass);

            Assert.IsTrue(Actual.Contains(Expected));
        }

        [TestMethod]
        public void CreateFBFMatrix_Test()
        {
            float[] ToAssign = { 1, 2, 3, 4, (float)5.5, (float)6.5, (float)7.5, (float)8.5, 9, 10, 11, 12, (float)13.5, (float)14.5, (float)15.5, (float)16.5 };
            float Expected00 = 1;
            float Expected03 = 4;
            float Expected10 = (float)5.5;
            float Expected12 = (float)7.5;
            float Expected22 = 11;
            float Expected30 = (float)13.5;
            float Expected32 = (float)15.5;

            MainClass.Matrix Actual = new MainClass.Matrix(4, 4, ToAssign);

            Assert.AreEqual(Actual.Data[0, 0], Expected00);
            Assert.AreEqual(Actual.Data[0, 3], Expected03);
            Assert.AreEqual(Actual.Data[1, 0], Expected10);
            Assert.AreEqual(Actual.Data[1, 2], Expected12);
            Assert.AreEqual(Actual.Data[2, 2], Expected22);
            Assert.AreEqual(Actual.Data[3, 0], Expected30);
            Assert.AreEqual(Actual.Data[3, 2], Expected32);
        }

        [TestMethod]
        public void CreateTHBTHMatrix_Test()
        {
            float[] ToAssign = { -3, 5, 0, 1, -2, -7, 0, 1, 1 };
            float Expected00 = -3;
            float Expected11 = -2;
            float Expected22 = 1;

            MainClass.Matrix Actual = new MainClass.Matrix(3, 3, ToAssign);

            Assert.AreEqual(Actual.Data[0, 0], Expected00);
            Assert.AreEqual(Actual.Data[1, 1], Expected11);
            Assert.AreEqual(Actual.Data[2, 2], Expected22);
        }

        [TestMethod]
        public void CreateTWBTWMatrix_Test()
        {
            float[] ToAssign = { -3, 5, 1, -2 };
            float Expected00 = -3;
            float Expected01 = 5;
            float Expected10 = 1;
            float Expected11 = -2;

            MainClass.Matrix Actual = new MainClass.Matrix(2, 2, ToAssign);

            Assert.AreEqual(Actual.Data[0, 0], Expected00);
            Assert.AreEqual(Actual.Data[0, 1], Expected01);
            Assert.AreEqual(Actual.Data[1, 0], Expected10);
            Assert.AreEqual(Actual.Data[1, 1], Expected11);
        }

        [TestMethod]
        public void CompareSameMatrices_Test()
        {
            float[] ToAssign = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2 };
            MainClass.Matrix ToCompareA = new MainClass.Matrix(4, 4, ToAssign);
            MainClass.Matrix ToCompareB = new MainClass.Matrix(4, 4, ToAssign);

            bool Actual = MainClass.CompareMatrix(ToCompareA, ToCompareB);

            Assert.IsTrue(Actual);
        }

        [TestMethod]
        public void CompareDifferentMatrices_Test()
        {
            float[] Assign1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2 };
            float[] Assign2 = { 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            MainClass.Matrix ToCompareA = new MainClass.Matrix(4, 4, Assign1);
            MainClass.Matrix ToCompareB = new MainClass.Matrix(4, 4, Assign2);

            bool Actual = MainClass.CompareMatrix(ToCompareA, ToCompareB);

            Assert.IsFalse(Actual);
        }

        [TestMethod]
        public void GetSmallSubmatrix_Test()
        {
            float[] FullMatrixData = { 1, 5, 0, -3, 2, 7, 0, 6, -3 };
            float[] SubMatrixData = { -3, 2, 0, 6 };
            MainClass.Matrix FullMatrix = new MainClass.Matrix(3, 3, FullMatrixData);
            MainClass.Matrix Expected = new MainClass.Matrix(2, 2, SubMatrixData);

            MainClass.Matrix Actual = MainClass.GetSubmatrix(FullMatrix, 0, 2);

            Assert.IsTrue(MainClass.CompareMatrix(Actual, Expected));
        }

        [TestMethod]
        public void GetLargeSubmatrix_Test()
        {
            float[] FullMatrixData = { -6, 1, 1, 6, -8, 5, 8, 6, -1, 0, 8, 2, -7, 1, -1, 1 };
            float[] SubMatrixData = { -6, 1, 6, -8, 8, 6, -7, -1, 1 };
            MainClass.Matrix FullMatrix = new MainClass.Matrix(4, 4, FullMatrixData);
            MainClass.Matrix Expected = new MainClass.Matrix(3, 3, SubMatrixData);

            MainClass.Matrix Actual = MainClass.GetSubmatrix(FullMatrix, 2, 1);

            Assert.IsTrue(MainClass.CompareMatrix(Actual, Expected));
        }

        [TestMethod]
        public void FindMinor_Test()
        {
            float[] FullMatrixData = { 3, 5, 0, 2, -1, -7, 6, -1, 5 };
            MainClass.Matrix FullMatrix = new MainClass.Matrix(3, 3, FullMatrixData);
            float Expected = 25;

            float Actual = MainClass.FindMinor(FullMatrix, 1, 0);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void FindCofactor_Test()
        {
            float[] FullMatrixData = { 3, 5, 0, 2, -1, -7, 6, -1, 5 };
            MainClass.Matrix FullMatrix = new MainClass.Matrix(3, 3, FullMatrixData);
            float Expected1 = -12;
            float Expected2 = -12;
            float Expected3 = 25;
            float Expected4 = -25;

            float Actual1 = MainClass.FindMinor(FullMatrix, 0, 0);
            float Actual2 = MainClass.FindCofactor(FullMatrix, 0, 0);
            float Actual3 = MainClass.FindMinor(FullMatrix, 1, 0);
            float Actual4 = MainClass.FindCofactor(FullMatrix, 1, 0);

            Assert.AreEqual(Expected1, Actual1);
            Assert.AreEqual(Expected2, Actual2);
            Assert.AreEqual(Expected3, Actual3);
            Assert.AreEqual(Expected4, Actual4);
        }

        [TestMethod]
        public void FindDeterminant3x3_Test()
        {
            float[] FullMatrixData = { 1, 2, 6, -5, 8, -4, 2, 6, 4 };
            MainClass.Matrix FullMatrix = new MainClass.Matrix(3, 3, FullMatrixData);
            float Expected1 = 56;
            float Expected2 = 12;
            float Expected3 = -46;
            float Expected4 = -196;

            float Actual1 = MainClass.FindCofactor(FullMatrix, 0, 0);
            float Actual2 = MainClass.FindCofactor(FullMatrix, 0, 1);
            float Actual3 = MainClass.FindCofactor(FullMatrix, 0, 2);
            float Actual4 = MainClass.FindDeterminant(FullMatrix);

            Assert.AreEqual(Expected1, Actual1);
            Assert.AreEqual(Expected2, Actual2);
            Assert.AreEqual(Expected3, Actual3);
            Assert.AreEqual(Expected4, Actual4);
        }
    }
}