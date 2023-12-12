using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RayTracerChallenge.MainClass;

namespace RayTracerChallenge
{
    public class MainClass
    {
        //Projectile stores information about a single pixel.
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

        //Environment stores information that is applicable to all projectiles.
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

        //Tuples are either vectors or points.
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

        //Stores color information between 0 and 1.
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

        //2 dimension array of colors. inilialized as all black.
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

        //Used to create a matrix of a given size using an array of floats
        public struct Matrix
        {
            public float[,] Data;

            public Matrix(int Rows, int Columns, float[] ToAssign)
            {
                if(Rows * Columns != ToAssign.Length)
                {
                    throw new ArgumentException();
                }

                Data = new float[Rows, Columns];
                int Count = 0;
                for (int i = 0; i < Rows; ++i)
                {
                    for (int j = 0; j < Columns; ++j)
                    {
                        Data[i, j] = ToAssign[Count];
                        ++Count;
                    }
                }
            }
        }

        //current task creates a projectile and updates the canvas along its path.
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

        //initializes a color.
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

        //updates the color at a specified location.
        public static Canvas WritePixel(Canvas canvas, int width, int height, Color color)
        {
            canvas.Size[width, height] = color;
            return canvas;
        }

        //takes a number and multiplies it by 255, then keeps the number between 0 and 255.
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

        //changes the canvas to a single string.
        public static string CanvasToPPM(Canvas canvas)
        {
            int width = canvas.Size.GetLength(0);
            int height = canvas.Size.GetLength(1);
            int ColorCount = 0;
            StringBuilder ToPPM = new StringBuilder();
            ToPPM.Append("P3\n" + width + " " + height + "\n255\n");
            for (int i = 0; i < height; ++i)
            {
                for(int j = 0; j < width; ++j)
                {

                    ToPPM.Append(Clamp0255(canvas.Size[j, i].red) + " ");
                    ++ColorCount;
                    if (ColorCount % 17 == 0)
                    {
                        ToPPM.Append("\n");
                    }
                    ToPPM.Append(Clamp0255(canvas.Size[j, i].green) + " ");
                    ++ColorCount;
                    if (ColorCount % 17 == 0)
                    {
                        ToPPM.Append("\n");
                    }
                    ToPPM.Append(Clamp0255(canvas.Size[j, i].blue) + " ");
                    ++ColorCount;
                    if (ColorCount % 17 == 0 )
                    {
                        ToPPM.Append("\n");
                    }
                }
                ToPPM.Append("\n");
                ColorCount = 0;
            }
            return ToPPM.ToString();
        }
        
        //Takes a pixel and updates its location based on the motion acting on it.
        public static Projectile Tick(Environment Env, Projectile Proj) 
        {
            Projectile Sum = new Projectile
            {
                Position = TupleArithmatic.AddTuples(Proj.Position, Proj.Velocity),
                Velocity = TupleArithmatic.AddTuples(TupleArithmatic.AddTuples(Proj.Velocity, Env.Gravity), Env.Wind)
            };
            return Sum;
        }

        public static bool CompareMatrix(Matrix Matrix1, Matrix Matrix2)
        {
            if (Matrix1.Data.GetLength(0) != Matrix2.Data.GetLength(0))
            {
                return false;
            }
            if (Matrix1.Data.GetLength(1) != Matrix2.Data.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < Matrix1.Data.GetLength(0); ++i)
            {
                for (int j = 0; j < Matrix1.Data.GetLength(1);  ++j)
                {
                    if (Matrix1.Data[i,j] - Matrix2.Data[i,j] > 0.00001)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //returns a matrix with row and column of the original matrix removed
        public static Matrix GetSubmatrix(Matrix Original, int Row, int Column)
        {
            int x = 0;
            Matrix New;
            New.Data = new float[Original.Data.GetLength(0)-1, Original.Data.GetLength(1)-1];
            
            for (int i = 0; i < Original.Data.GetLength(0); ++i)
            {
                int y = 0;
                if (i == Row)
                {
                    continue;
                }
                for (int j = 0; j < Original.Data.GetLength(1); ++j)
                {
                    if (j == Column)
                    {
                        continue;
                    }
                    else
                    {
                        New.Data[x, y] = Original.Data[i, j];
                    }  
                    ++y;
                }
                ++x;
            }
            return New;
        }

        //returns the determinant of 3x3 matrix
        public static float FindMinor(Matrix Original, int Row, int Column)
        {
            Matrix SubMatrix = GetSubmatrix(Original, Row, Column);
            return TupleArithmatic.FindDeterminant(SubMatrix);
        }

        //returns the Cofactor of 3x3 matrix
        public static float FindCofactor(Matrix Original, int Row, int Column)
        {
            Matrix SubMatrix = GetSubmatrix(Original, Row, Column);
            if ((Row + Column) % 2 == 0)
            {
                return TupleArithmatic.FindDeterminant(SubMatrix);
            }
            else
            {
                return -(TupleArithmatic.FindDeterminant(SubMatrix));
            }
        }
    }
}
