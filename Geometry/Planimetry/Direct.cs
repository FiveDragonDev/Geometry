namespace Geometry.Planimetry
{
    public class Direct : GeometryObject
    {
        public Point Origin { get; set; }
        public Point Direction { get; set; }

        public Direct(Point origin, Point direction)
        {
            Origin = origin;
            Direction = direction;
        }
    }
}
