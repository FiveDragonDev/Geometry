namespace Geometry.Planimetry
{
    public class Ray : GeometryObject
    {
        public Point Origin { get; set; }
        public Point Direction { get; set; }

        public Ray(Point origin, Point direction)
        {
            Origin = origin;
            Direction = direction;
        }
    }
}
