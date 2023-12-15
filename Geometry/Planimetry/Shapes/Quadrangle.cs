namespace Geometry.Planimetry
{
    public class Quadrangle : Shape
    {
        public QuadPointArray Points { get; protected set; } = new();

        public override float Perimeter => _perimeter;
        public override float Area => _area;

        protected float _perimeter;
        protected float _area;

        public Quadrangle(Point p1, Point p2, Point p3, Point p4) : this()
        {
            Points = new(p1, p2, p3, p4);
            Origin = (p1 + p2 + p3 + p4) / 4;
            _perimeter = p1.Distance(p2) + p2.Distance(p3) + p3.Distance(p4) + p4.Distance(p1);
            _area = (1f / 2f) * p1.Distance(p3) * p2.Distance(p4);
        }
        protected Quadrangle() : base() { }

        public override string ToString() => $"({Points.Point1}, {Points.Point2}, " +
            $"{Points.Point3}, {Points.Point4})";

        public struct QuadPointArray
        {
            public Point Point1;
            public Point Point2;
            public Point Point3;
            public Point Point4;

            public QuadPointArray(Point p1, Point p2, Point p3, Point p4)
            {
                Point1 = p1;
                Point2 = p2;
                Point3 = p3;
                Point4 = p4;
            }
        }
    }
}
