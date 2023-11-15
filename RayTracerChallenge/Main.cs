using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RayTracerChallenge.MainClass;

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
            Tuple Start = CreatePointTuple((0, 1, 0));
            Tuple Velocity = TupleArithmatic.MultiplyTuple(TupleArithmatic.NormalizeTuple(CreateVectorTuple((1, (float)1.8, 0))), (float)11.25);
            Projectile p = new Projectile(Start, Velocity);

            Tuple Gravity = CreateVectorTuple((0, (float)-0.1, 0));
            Tuple Wind = CreateVectorTuple(((float)-0.01, 0, 0));
            Environment e = new Environment(Gravity, Wind);

            Canvas c = new Canvas(900, 550);
            Color White = CreateColor(1, 1, 1);

            while (p.Position.y > 0)
            {
                c = WritePixel(c, (int)p.Position.x, 550-(int)p.Position.y, White);
                p = Tick(e, p);
            }

            string ToSave = CanvasToPPM(c);

            using (StreamWriter OuputFile = new StreamWriter("Picture.txt"))
            {
                OuputFile.WriteLine(ToSave);
            }

        }

        // Returns the original vector with an additional element to identify it as a vector
        public static Tuple CreateVectorTuple((float x, float y, float z) vector)
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

        // Returns the original point with an additional element to identify it as a point
        public static Tuple CreatePointTuple((float x, float y, float z) point)
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

        // When given a tuple will return a string stating what the tuple is.
        public static string IdentifyTuple(Tuple ToIdentify)
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

        // Compares two tuples. If they are within .00001 on all elements returns true, otherwise returns false.
        public static bool CompareTuple(Tuple Tuple1,Tuple Tuple2)
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

        public static Color CreateColor(float Red, float Green, float Blue)
        {
            Color NewColor = new Color(Red, Green, Blue);
            return NewColor;
        }

        // Compares two tuples. If they are within .00001 on all elements returns true, otherwise returns false.
        public static bool CompareColor(Color Color1, Color Color2)
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

        public static int Clamp0255(float change)
        {
            int value = (int)(change * 255 + 0.5);
            if (value < 0)
            {
                value = 0;
            }
            if (value > 255)
            {
                value = 255;
            }
            return value;
        }

        public static string CanvasToPPM(Canvas canvas)
        {
            int width = canvas.Size.GetLength(0);
            int height = canvas.Size.GetLength(1);
            int ColorCount = 0;
            string ToPPM = "P3\n" + width + " " + height + "\n255\n";
            for (int i = 0; i < height; ++i)
            {
                for(int j = 0; j < width; ++j)
                {

                    ToPPM += Clamp0255(canvas.Size[j, i].red) + " ";
                    ++ColorCount;
                    if (ColorCount % 17 == 0)
                    {
                        ToPPM += "\n";
                    }
                    ToPPM += Clamp0255(canvas.Size[j, i].green) + " ";
                    ++ColorCount;
                    if (ColorCount % 17 == 0)
                    {
                        ToPPM += "\n";
                    }
                    ToPPM += Clamp0255(canvas.Size[j, i].blue) + " ";
                    ++ColorCount;
                    if (ColorCount % 17 == 0 )
                    {
                        ToPPM += "\n";
                    }
                }
                ToPPM += "\n";
                ColorCount = 0;
            }
            return ToPPM;
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
