using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
    public class MainClass
    {
        public struct Projectile
        {
            public Tuple Position;
            public Tuple Velocity;

            public Projectile(Tuple position, Tuple velocity)
            {
                Position = position;
                Velocity = velocity;
            }
        }

        public struct Environment
        {
            public Tuple Gravity;
            public Tuple Wind;

            public Environment(Tuple gravity, Tuple wind)
            {
                Gravity = gravity;
                Wind = wind;
            }
        }

        public struct Tuple
        {
            public float x;
            public float y;
            public float z;
            public float w;

            public Tuple(float X, float Y, float Z, float W)
            {
                x = X;
                y = Y;
                z = Z;
                w = W;
            }
        }

        public struct Color
        {
            public float red;
            public float green;
            public float blue;

            public Color(float Red, float Green, float Blue)
            {
                red = Red;
                green = Green;
                blue = Blue;
            }
        }

        public struct Canvas
        {
            public Color[,] Size;

            public Canvas(int width, int height)
            {
                Size = new Color[width, height];
                for (int i = 0; i < width; ++i)
                {
                    for (int j = 0; j < height; ++j)
                    {
                        Size[i, j] = new Color(0, 0, 0);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
        }

        public static Tuple CreateVectorTuple((float x, float y, float z) vector)
        // Returns the original vector with an additional element to identify it as a vector
        {
            Tuple NewVector = new Tuple
            {
                x = vector.x,
                y = vector.y,
                z = vector.z,
                w = 0
            };
            return NewVector;
        }

        public static Tuple CreatePointTuple((float x, float y, float z) point)
        // Returns the original point with an additional element to identify it as a point
        {
            Tuple NewPoint = new Tuple
            {
                x = point.x,
                y = point.y,
                z = point.z,
                w = 1
            };
            return NewPoint;
        }

        public static string IdentifyTuple(Tuple ToIdentify)
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
                throw new ArgumentException();
            }
        }

        public static bool CompareTuple(Tuple Tuple1,Tuple Tuple2)
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

        public static bool CompareColor(MainClass.Color Color1, MainClass.Color Color2)
        // Compares two tuples. If they are within .00001 on all elements returns true, otherwise returns false.
        {
            if (Math.Abs(Color1.red - Color2.red) > 0.00001)
            {
                return false;
            }
            else if (Math.Abs(Color1.green - Color2.green) > 0.00001)
            {
                return false;
            }
            else if (Math.Abs(Color1.blue - Color2.blue) > 0.00001)
            {
                return false;
            }
            return true;
        }

        public static Canvas WritePixel(Canvas canvas, int width, int height, Color color)
        {
            canvas.Size[width, height] = color;
            return canvas;
        }

        public static Projectile Tick(Environment Env, Projectile Proj) 
        {
            Projectile Sum = new Projectile
            {
                Position = TupleArithmatic.AddTuples(Proj.Position, Proj.Velocity),
                Velocity = TupleArithmatic.AddTuples(TupleArithmatic.AddTuples(Proj.Velocity, Env.Gravity), Env.Wind)
            };
            return Sum;
        }

    }
}
