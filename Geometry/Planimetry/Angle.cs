namespace Geometry.Planimetry
{
    public class Angle : GeometryObject
    {
        public Point Point1 { get; protected set; }
        public Point Point2 { get; protected set; }
        public Point Point3 { get; protected set; }

        public float AngleBetweenPoint { get; private set; }

        public Angle(Point p1, Point p2, Point p3)
        {
            Point1 = p1;
            Point2 = p2;
            Point3 = p3;

            var a = (float)Math.Sqrt(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p2.Y - p3.Y, 2));
            var b = (float)Math.Sqrt(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p1.Y - p3.Y, 2));
            var c = (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));

            float cosAngle = (b * b + a * a - c * c) / (2 * b * a);
            AngleBetweenPoint = (float)Math.Acos(cosAngle) * 2 * MathHelper.Rad2Deg;
        }

        public static explicit operator float(Angle angle) => angle.AngleBetweenPoint;
        public override string ToString() => $"{AngleBetweenPoint} Deg";

    }
}
