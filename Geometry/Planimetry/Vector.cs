namespace Geometry.Planimetry
{
    public class Vector : GeometryObject
    {
        public Point Start { get; private set; }
        public Point End { get; private set; }

        public Vector(Point origin) : this(origin, origin) { }
        public Vector(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Point Coordinates => End - Start;
        public float Length
        {
            get
            {
                float x = Coordinates.X;
                float y = Coordinates.Y;
                return (float)Math.Sqrt(x * x + y * y);
            }
        }

        public override string ToString()
        {
            return $"Start: {Start};\n" +
                $"End: {End};\n" +
                $"Coord: {Coordinates}\n" +
                $"Length: {Length}";
        }
    }
}
