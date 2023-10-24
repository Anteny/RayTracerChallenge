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

        public static bool CompareTuple((float x, float y, float z, float w) TupleA,(float x, float y, float z, float w) TupleB)
        // Compares two tuples. If they are within .00001 on all elements returns true, otherwise returns false.
        {
            if (Math.Abs(TupleA.x - TupleB.x) > 0.00001)
            {
                return false;
            }
            else if (Math.Abs(TupleA.y - TupleB.y) > 0.00001)
            {
                return false;
            }
            else if (Math.Abs(TupleA.z - TupleB.z) > 0.00001)
            {
                return false;
            }
            else if (Math.Abs(TupleA.w - TupleB.w) > 0.00001)
            {
                return false;
            }
            return true;
        }

        public static (float x, float y, float z, float w) AddTuples((float x, float y, float z, float w) TupleA, (float x, float y, float z, float w) TupleB)
        {
            (float x, float y, float z, float w) Sum;
            Sum.x = TupleA.x + TupleB.x;
            Sum.y = TupleA.y + TupleB.y;
            Sum.z = TupleA.z + TupleB.z;
            Sum.w = TupleA.w + TupleB.w;
            return Sum;
        }
    }
}
