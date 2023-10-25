using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
    public class MainClass
    {
        static void Main(string[] args)
        {
        }

        public static (float x, float y, float z, float w) CreateVectorTuple((float x, float y, float z) vector)
        // Returns the original vector with an additional element to identify it as a vector
        {
            return (vector.x, vector.y, vector.z, 0);
        }

        public static (float x, float y, float z, float w) CreatePointTuple((float x, float y, float z) point)
        // Returns the original point with an additional element to identify it as a point
        {
            return (point.x, point.y, point.z, 1);
        }

        public static string IdentifyTuple((float x, float y, float z, float w) ToIdentify)
        // When given a tuple will return a string stating what the tuple is.
        {
            if (ToIdentify.w == 0)
            {
                return "vector";
            }
            else if (ToIdentify.w == 1)
            {
                return "point";
            }
            else
            {
                return "Not Defined";
            }
        }

        public static bool CompareTuple((float x, float y, float z, float w) Tuple1,(float x, float y, float z, float w) Tuple2)
        // Compares two tuples. If they are within .00001 on all elements returns true, otherwise returns false.
        {
            if (Math.Abs(Tuple1.x - Tuple2.x) > 0.00001)
            {
                return false;
            }
            else if (Math.Abs(Tuple1.y - Tuple2.y) > 0.00001)
            {
                return false;
            }
            else if (Math.Abs(Tuple1.z - Tuple2.z) > 0.00001)
            {
                return false;
            }
            else if (Math.Abs(Tuple1.w - Tuple2.w) > 0.00001)
            {
                return false;
            }
            return true;
        }

        public static (float x, float y, float z, float w) AddTuples((float x, float y, float z, float w) Tuple1, (float x, float y, float z, float w) Tuple2)
        {
            (float x, float y, float z, float w) Sum;
            Sum.x = Tuple1.x + Tuple2.x;
            Sum.y = Tuple1.y + Tuple2.y;
            Sum.z = Tuple1.z + Tuple2.z;
            Sum.w = Tuple1.w + Tuple2.w;
            return Sum;
        }

        public static (float x, float y, float z, float w) SubtractTuples((float x, float y, float z, float w) Tuple1, (float x, float y, float z, float w) Tuple2)
        {
            (float x, float y, float z, float w) Sum;
            Sum.x = Tuple1.x - Tuple2.x;
            Sum.y = Tuple1.y - Tuple2.y;
            Sum.z = Tuple1.z - Tuple2.z;
            Sum.w = Tuple1.w - Tuple2.w;
            return Sum;
        }

        public static (float x, float y, float z, float w) NegateTuple((float x, float y, float z, float w) Tuple)
        {
            (float x, float y, float z, float w) Sum;
            Sum.x = 0 - Tuple.x;
            Sum.y = 0 - Tuple.y;
            Sum.z = 0 - Tuple.z;
            Sum.w = 0 - Tuple.w;
            return Sum;
        }

        public static (float x, float y, float z, float w) MultiplyTuple((float x, float y, float z, float w) Tuple, float scalar)
        {
            (float x, float y, float z, float w) Product;
            Product.x = scalar * Tuple.x;
            Product.y = scalar * Tuple.y;
            Product.z = scalar * Tuple.z;
            Product.w = scalar * Tuple.w;
            return Product;
        }

        public static (float x, float y, float z, float w) DivideTuple((float x, float y, float z, float w) Tuple, float scalar)
        {
            (float x, float y, float z, float w) Product;
            Product.x = Tuple.x / scalar;
            Product.y = Tuple.y / scalar;
            Product.z = Tuple.z / scalar;
            Product.w = Tuple.w / scalar;
            return Product;
        }

        public static float ComputeMagnitudeOfVector((float x, float y, float z, float w) Tuple)
        {
            return (float)Math.Sqrt((Tuple.x * Tuple.x) + (Tuple.y * Tuple.y) + (Tuple.z * Tuple.z) + (Tuple.w * Tuple.w));
        }

        public static (float x, float y, float z, float w) NormalizeTuple((float x, float y, float z, float w) Tuple)
        {
            float Magnitude = ComputeMagnitudeOfVector(Tuple);
            return DivideTuple(Tuple, Magnitude);
        }
    }
}
