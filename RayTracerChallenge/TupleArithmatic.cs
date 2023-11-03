﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
    public class TupleArithmatic
    {
        public static MainClass.Tuple AddTuples(MainClass.Tuple Tuple1, MainClass.Tuple Tuple2)
        {
            MainClass.Tuple Sum;
            Sum.x = Tuple1.x + Tuple2.x;
            Sum.y = Tuple1.y + Tuple2.y;
            Sum.z = Tuple1.z + Tuple2.z;
            Sum.w = Tuple1.w + Tuple2.w;
            if (Sum.w == 2)
            {
                throw new ArgumentException();
            }
            return Sum;
        }

        public static MainClass.Tuple SubtractTuples(MainClass.Tuple Tuple1, MainClass.Tuple Tuple2)
        {
            MainClass.Tuple Sum;
            Sum.x = Tuple1.x - Tuple2.x;
            Sum.y = Tuple1.y - Tuple2.y;
            Sum.z = Tuple1.z - Tuple2.z;
            Sum.w = Tuple1.w - Tuple2.w;
            if (Sum.w == -1)
            {
                throw new ArgumentException();
            }
            return Sum;
        }

        public static MainClass.Tuple NegateTuple(MainClass.Tuple Tuple)
        {
            MainClass.Tuple Sum;
            Sum.x = 0 - Tuple.x;
            Sum.y = 0 - Tuple.y;
            Sum.z = 0 - Tuple.z;
            Sum.w = 0 - Tuple.w;
            if (Sum.w == -1)
            {
                throw new ArgumentException();
            }
            return Sum;
        }

        public static MainClass.Tuple MultiplyTuple(MainClass.Tuple Tuple, float scalar)
        {
            MainClass.Tuple Product;
            Product.x = scalar * Tuple.x;
            Product.y = scalar * Tuple.y;
            Product.z = scalar * Tuple.z;
            Product.w = scalar * Tuple.w;
            return Product;
        }

        public static MainClass.Tuple DivideTuple(MainClass.Tuple Tuple, float scalar)
        {
            MainClass.Tuple Product;
            Product.x = Tuple.x / scalar;
            Product.y = Tuple.y / scalar;
            Product.z = Tuple.z / scalar;
            Product.w = Tuple.w / scalar;
            return Product;
        }

        public static float ComputeMagnitudeOfVector(MainClass.Tuple Tuple)
        {
            if (Tuple.w == 1)
            {
                throw new ArgumentException();
            }
            return (float)Math.Sqrt((Tuple.x * Tuple.x) + (Tuple.y * Tuple.y) + (Tuple.z * Tuple.z) + (Tuple.w * Tuple.w));
        }

        public static MainClass.Tuple NormalizeTuple(MainClass.Tuple Tuple)
        {
            if (Tuple.w == 1)
            {
                throw new ArgumentException();
            }
            float Magnitude = ComputeMagnitudeOfVector(Tuple);
            return DivideTuple(Tuple, Magnitude);
        }

        public static float DotProductOfTwoTuples(MainClass.Tuple Tuple1, MainClass.Tuple Tuple2)
        {
            if (Tuple1.w == 1)
            {
                throw new ArgumentException();
            }
            return ((Tuple1.x * Tuple2.x) + (Tuple1.y * Tuple2.y) + (Tuple1.z * Tuple2.z) + (Tuple1.w * Tuple2.w));
        }

        public static MainClass.Tuple CrossProductOfTwoTuples(MainClass.Tuple Tuple1, MainClass.Tuple Tuple2)
        {
            if (Tuple1.w == 1)
            {
                throw new ArgumentException();
            }
            MainClass.Tuple Product;
            Product.x = ((Tuple1.y * Tuple2.z) - (Tuple1.z * Tuple2.y));
            Product.y = ((Tuple1.z * Tuple2.x) - (Tuple1.x * Tuple2.z));
            Product.z = ((Tuple1.x * Tuple2.y) - (Tuple1.y * Tuple2.x));
            Product.w = 0;
            return Product;
        }

        public static MainClass.Color AddColors(MainClass.Color Color1, MainClass.Color Color2)
        {
            MainClass.Color SumColor = new MainClass.Color
            {
                red = Color1.red + Color2.red,
                blue = Color1.blue + Color2.blue,
                green = Color1.green + Color2.green
            };
            return SumColor;
        }

        public static MainClass.Color SubtractColors(MainClass.Color Color1, MainClass.Color Color2)
        {
            MainClass.Color SumColor = new MainClass.Color
            {
                red = Color1.red - Color2.red,
                blue = Color1.blue - Color2.blue,
                green = Color1.green - Color2.green
            };
            return SumColor;
        }

        public static MainClass.Color MultiplyColorByScalar(MainClass.Color Color1, float Scalar)
        {
            MainClass.Color ProductColor = new MainClass.Color
            {
                red = Color1.red * Scalar,
                blue = Color1.blue * Scalar,
                green = Color1.green * Scalar
            };
            return ProductColor;
        }

        public static MainClass.Color MultiplyColors(MainClass.Color Color1, MainClass.Color Color2)
        {
            MainClass.Color ProductColor = new MainClass.Color
            {
                red = Color1.red * Color2.red,
                blue = Color1.blue * Color2.blue,
                green = Color1.green * Color2.green
            };
            return ProductColor;
        }
    }
}
