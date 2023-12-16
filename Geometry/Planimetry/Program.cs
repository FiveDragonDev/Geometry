using Color = System.Drawing.Color;

namespace Geometry.Planimetry.Test
{
    public class Program
    {
        private const string ResultsPath = "Results/Planimetry";

        public static void Main()
        {
            PointTests();
            VectorTests();
            AngleTests();
            IntervalTests();
            ShapesTests();
            Console.ReadKey();
        }

        private static void PointTests()
        {
            Canvas canvas = new(800, 600);
            Point a = new(3.5f, 2);
            Point b = new(-5, 2.5f);

            Console.WriteLine("-- Points --");

            Console.WriteLine($"A: {a}");
            Console.WriteLine($"B: {b}");

            Console.WriteLine();

            Console.WriteLine($"A+B: {a + b}");
            Console.WriteLine($"A-B: {a - b}");
            Console.WriteLine($"A*B: {a * b}");
            Console.WriteLine($"A/B: {a / b}");

            Console.WriteLine();

            Console.WriteLine($"A*2: {a * 2}");
            Console.WriteLine($"B/2: {b / 2}");

            canvas.SetObject(a);
            canvas.SetObject(b);
            canvas.SetObject(a + b);
            canvas.SetObject(a - b);
            canvas.SetObject(a * b);
            canvas.SetObject(a / b);
            canvas.SetObject(a * 2);
            canvas.SetObject(b / 2);

            canvas.Save($"{ResultsPath}/Points.png");
        }
        private static void VectorTests()
        {
            Canvas canvas = new(800, 600);

            Vector a = new(new(0, 0), new(1, 0));
            Vector b = new(new(1, 0), new(2, 1));

            a.Size = 150;
            b.Size = 150;

            Console.WriteLine("\n-- Vectors --");
            Console.WriteLine(a);
            Console.WriteLine();
            Console.WriteLine(b);

            canvas.SetObject(a);
            canvas.SetObject(b);
            canvas.Save($"{ResultsPath}/Vectors.png");
        }
        private static void AngleTests()
        {
            Canvas canvas = new(800, 600);

            Point a = new(-2, 0);
            Point b = new(0, 1);
            Point c = new(2, 0);

            Angle angle = new(a, b, c)
            { Size = 150 };

            Console.WriteLine("\n-- Angles --");
            Console.WriteLine($"A: {a}\nB: {b}\nC: {c}");
            Console.WriteLine($"ABC angle: {angle}");

            canvas.SetObject(angle);
            canvas.Save($"{ResultsPath}/Angle.png");
        }
        private static void IntervalTests()
        {
            Canvas canvas = new(800, 600);

            Interval a = new(new(-1, 0), new(1, 0));
            Interval b = new(new(0, -1), new(0, 1));
            Point abIntersection = a.Intersection(b);

            a.Size = 150;
            b.Size = 150;
            abIntersection.Color = Color.Aqua;

            Console.WriteLine("\n-- Intervals --");
            Console.WriteLine($"IntervalA: {a}");
            Console.WriteLine($"IntervalA Lenth: {a.Length}");
            Console.WriteLine($"IntervalB: {b}");
            Console.WriteLine($"IntervalAB Intersection Point: {abIntersection}");

            canvas.SetObject(a);
            canvas.SetObject(b);
            canvas.SetObject(abIntersection);
            canvas.Save($"{ResultsPath}/Intervals.png");
        }
        private static void CirclesTests()
        {
            Canvas canvas = new(800, 600);
            Circle circle = new(new(0))
            { Size = 75 };
            Console.WriteLine($"CircleA: {circle}");
            Console.WriteLine($"CircleA Perimetr: {circle.Perimeter}");
            Console.WriteLine($"CircleA Area: {circle.Area}");
            canvas.SetObject(circle);
            canvas.Save($"{ResultsPath}/Circle.png");
        }
        private static void QuadranglesTest()
        {
            Canvas canvas = new(800, 600);
            canvas.Clear(Color.White);
            Square square = new(1, new(0))
            { Size = 150 };
            Console.WriteLine($"SquareA: {square}");
            Console.WriteLine($"SquareA Side Size: {square.SideSize}");
            Console.WriteLine($"SquareA Perimetr: {square.Perimeter}");
            Console.WriteLine($"SquareA Area: {square.Area}");
            canvas.SetObject(square);
            canvas.Save($"{ResultsPath}/Square.png");
        }
        private static void TrianglesTest()
        {
            Canvas canvas = new(800, 600);
            Triangle triangle = new(new(-1, -0.5f), new(0, 0.5f), new(1, -0.5f))
            { Size = 150 };
            Console.WriteLine($"TriangleA: {triangle}");
            Console.WriteLine($"TriangleA Perimetr: {triangle.Perimeter}");
            Console.WriteLine($"TriangleA Area: {triangle.Area}");
            canvas.SetObject(triangle);
            canvas.Save($"{ResultsPath}/Triangle.png");
        }
        private static void ShapesTests()
        {
            Console.WriteLine("-- Shapes --\n");
            Console.WriteLine("-- Circles --");
            CirclesTests();
            Console.WriteLine("\n-- Quadrangles --");
            QuadranglesTest();
            Console.WriteLine("\n-- Triangles --");
            TrianglesTest();
        }
    }
}