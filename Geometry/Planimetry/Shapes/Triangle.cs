namespace Geometry.Planimetry
{
    public class Triangle : Shape
    {
        public TrioPointArray Points { get; protected set; } = new();

        public override float Perimeter => _perimeter;
        public override float Area => _area;

        private readonly float _perimeter;
        private readonly float _area;

        public Triangle(Point p1, Point p2, Point p3) : base()
        {
            Points = new(p1, p2, p3);
            _perimeter = p1.Distance(p2) + p2.Distance(p3) + p3.Distance(p1);
        }

        public bool Similar(Triangle other)
        {
            var AngleBAC = new Angle(Points.Point2, Points.Point1, Points.Point3);
            var AngleABC = new Angle(Points.Point1, Points.Point2, Points.Point3);
            var AngleACB = new Angle(Points.Point1, Points.Point3, Points.Point2);
            var AngleBAC1 = new Angle(other.Points.Point2, other.Points.Point1, other.Points.Point3);
            var AngleABC1 = new Angle(other.Points.Point1, other.Points.Point2, other.Points.Point3);
            var AngleACB1 = new Angle(other.Points.Point1, other.Points.Point3, other.Points.Point2);

            if (AngleBAC == AngleBAC1 && AngleABC == AngleABC1 ||
                AngleABC == AngleABC1 && AngleACB == AngleACB1 ||
                AngleBAC == AngleBAC1 && AngleABC == AngleABC1) return true;

            return false;
        }
        public bool Similar(Triangle other, out float coefficient)
        {
            if (Similar(other))
            {
                coefficient = (float)(Points.Point1.Distance(Points.Point2) /
                    other.Points.Point1.Distance(other.Points.Point2));

                return true;
            }

            coefficient = 0;
            return false;
        }

        public static bool operator ==(Triangle t1, Triangle t2) => t1 == t2;
        public static bool operator !=(Triangle t1, Triangle t2) => t1 != t2;

        public override bool Equals(object? obj)
        {
            return obj is Triangle triangle &&
                   EqualityComparer<TrioPointArray>.Default.Equals(Points, triangle.Points);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Points);
        }

        public struct TrioPointArray
        {
            public Point Point1;
            public Point Point2;
            public Point Point3;

            public TrioPointArray(Point p1, Point p2, Point p3)
            {
                Point1 = p1;
                Point2 = p2;
                Point3 = p3;
            }
        }
    }
}
