using System.Drawing;

namespace Geometry.Planimetry
{
    public class Point : GeometryObject
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float value) : this(value, value) { }
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Point operator -(Point a)
        { return new Point(-a.X, -a.Y); }
        public static Point operator +(Point a, Point b)
        { return new Point(a.X + b.X, a.Y + b.Y); }
        public static Point operator -(Point a, Point b)
        { return a + (-b); }
        public static Point operator *(Point a, Point b)
        { return new Point(a.X * b.X, a.Y * b.Y); }
        public static Point operator /(Point a, Point b)
        { return new Point(a.X / b.X, a.Y / b.Y); }
        public static Point operator *(Point a, float b)
        { return new Point(a.X * b, a.Y * b); }
        public static Point operator /(Point a, float b)
        { return new Point(a.X / b, a.Y / b); }
        public static Point operator +(Point a, float b)
        { return new Point(a.X + b, a.Y + b); }
        public static Point operator -(Point a, float b)
        { return a + (-b); }

        public float Length => (float)Math.Sqrt(X * X + Y * Y);
        public float Distance(Point b)
        {
            return (float)Math.Sqrt(
                (float)Math.Pow((X - b.X), 2) +
                (float)Math.Pow((Y - b.Y), 2));
        }
        public static float Distance(Point a, Point b)
        {
            return (float)Math.Sqrt(
                (float)Math.Pow(a.X - b.X, 2) +
                (float)Math.Pow(a.Y - b.Y, 2));
        }
        public static Point Lerp(Point a, Point b, float t) => (a + (b - a)) * t;

        public override string ToString() => $"({X}, {Y})";
    }
}
