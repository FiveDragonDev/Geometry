namespace Geometry.Planimetry
{
    public class Square : Quadrangle
    {
        public float SideSize { get; protected set; }

        public Square(float sideSize, Point origin) : base()
        {
            SideSize = sideSize;
            sideSize /= 2;
            var p1 = new Point(origin.X - sideSize, origin.Y + sideSize);
            var p2 = new Point(origin.X + sideSize, origin.Y + sideSize);
            var p3 = new Point(origin.X - sideSize, origin.Y - sideSize);
            var p4 = new Point(origin.X + sideSize, origin.Y - sideSize);

            Points = new(p1, p2, p4, p3);
            Origin = origin;

            sideSize *= 2;

            _area = sideSize * sideSize;
            _perimeter = sideSize * 4;
        }
    }
}
