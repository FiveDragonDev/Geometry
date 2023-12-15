using Color = System.Drawing.Color;

namespace Geometry.Planimetry.Test
{
    public class Program
    {
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
        }
        private static void VectorTests()
        {
            Vector a = new(new(0, 0), new(1, 0));
            Vector b = new(new(1, 0), new(2, 1));

            Console.WriteLine("\n-- Vectors --");
            Console.WriteLine(a);
            Console.WriteLine();
            Console.WriteLine(b);
        }
        private static void AngleTests()
        {
            Point a = new(-2, 0);
            Point b = new(0, 1);
            Point c = new(2, 0);

            Angle angle = new(a, b, c);

            Console.WriteLine("\n-- Angles --");
            Console.WriteLine($"A: {a}\nB: {b}\nC: {c}");
            Console.WriteLine($"ABC angle: {angle}");
        }
        private static void IntervalTests()
        {
            Interval a = new(new(-1, 0), new(1, 0));
            Interval b = new(new(0, -1), new(0, 1));
            Point abIntersection = a.Intersection(b);

            Console.WriteLine("\n-- Intervals --");
            Console.WriteLine($"IntervalA: {a}");
            Console.WriteLine($"IntervalA Lenth: {a.Length}");
            Console.WriteLine($"IntervalB: {b}");
            Console.WriteLine($"IntervalAB Intersection Point: {abIntersection}");
        }
        private static void CirclesTests()
        {
            Canvas canvas = new(800, 600);
            Circle circle = new(new(0))
            { Size = 75 };
            Console.WriteLine($"CircleA: {circle}");
            Console.WriteLine($"CircleA Perimetr: {circle.Perimeter}");
            Console.WriteLine($"CircleA Area: {circle.Area}");
            LogID(circle, "CircleA");
            canvas.SetObject(circle);
            canvas.Save("Results/Circle.png");
        }
        private static void QuadranglesTest()
        {
            Canvas canvas = new(800, 600);
            canvas.Fill(Color.White);
            Square square = new(1, new(0))
            { Size = 150 };
            Console.WriteLine($"SquareA: {square}");
            Console.WriteLine($"SquareA Side Size: {square.SideSize}");
            Console.WriteLine($"SquareA Perimetr: {square.Perimeter}");
            Console.WriteLine($"SquareA Area: {square.Area}");
            LogID(square, "SquareA");
            canvas.SetObject(square);
            canvas.Save($"Results/Square.png");
        }
        private static void TrianglesTest()
        {
            Canvas canvas = new(800, 600);
            Triangle triangle = new(new(-1, -0.5f), new(0, 0.5f), new(1, -0.5f))
            { Size = 150 };
            Console.WriteLine($"TriangleA: {triangle}");
            Console.WriteLine($"TriangleA Perimetr: {triangle.Perimeter}");
            Console.WriteLine($"TriangleA Area: {triangle.Area}");
            LogID(triangle, "TriangleA");
            canvas.SetObject(triangle);
            canvas.Save("Results/Triangle.png");
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
        private static void LogID(Shape shape, string shapeName = "") =>
            Console.WriteLine($"{shapeName} ID: {shape.Id}");
    }
}