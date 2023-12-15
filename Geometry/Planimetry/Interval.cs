namespace Geometry.Planimetry
{
    public class Interval : GeometryObject
    {
        public Point Point0 { get; private set; }
        public Point Point1 { get; private set; }

        public float Length => Point0.Distance(Point1);
        public Point Median => (Point0 + Point1) / 2;

        public Interval(Point point1, Point point2)
        {
            Point0 = point1;
            Point1 = point2;
        }

        public Point Intersection(Interval other)
        {
            float slopeA = (Point1.Y - Point0.Y) / (Point1.X - Point0.X);
            float yInterceptA = Point0.Y - slopeA * Point0.X;
            float slopeB = (other.Point1.Y - other.Point0.Y) / (other.Point1.X - other.Point0.X);
            float yInterceptB = other.Point0.Y - slopeB * other.Point0.X;

            if (slopeA == slopeB)
                return new(float.NaN, float.NaN);

            float x = (yInterceptB - yInterceptA) / (slopeA - slopeB);

            if (x < Math.Min(Point0.X, Point1.X) || x > Math.Max(Point0.X, Point1.X) ||
                x < Math.Min(other.Point0.X, other.Point1.X) ||
                x > Math.Max(other.Point0.X, other.Point1.X))
                return new(float.NaN, float.NaN);

            float y = slopeA * x + yInterceptA;

            return new(x, y);
        }

        public override string ToString() => $"({Point0}, {Point1})";
    }
}
