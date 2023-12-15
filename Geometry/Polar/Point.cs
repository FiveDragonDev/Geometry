namespace Geometry.Polar
{
    public class Point : GeometryObject
    {
        public float X => Distance * (float)Math.Cos(Angle);
        public float Y => Distance * (float)Math.Sin(Angle);

        public float Distance { get; private set; }
        public float Angle { get; private set; }

        public Point(float amount): this(amount, amount) { }
        public Point(float distance, float angle)
        {
            Distance = distance;
            Angle = angle;
        }

        public static Point operator-(Point a)
        { return new(-a.Distance, 360 - a.Angle); }
        public static Point operator+(Point a, Point b)
        { return new(a.Distance + b.Distance, a.Angle + b.Angle); }
        public static Point operator-(Point a, Point b)
        { return a + (-b); }
        public static Point operator*(Point a, Point b)
        { return new(a.Distance * b.Distance, a.Angle * b.Angle); }
        public static Point operator/(Point a, Point b)
        { return new(a.Distance / b.Distance, a.Angle / b.Angle); }
        public static Point operator+(Point a, float b)
        { return a + new Point(b); }
        public static Point operator-(Point a, float b)
        { return a + (-b); }
        public static Point operator *(Point a, float b)
        { return a * new Point(b); }
        public static Point operator /(Point a, float b)
        { return a / new Point(b); }

        public override string ToString() => $"({Distance}, {Angle} Deg)";
    }
}
