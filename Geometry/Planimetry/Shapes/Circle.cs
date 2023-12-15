namespace Geometry.Planimetry
{
    public class Circle : Shape
    {
        public float Radius { get; private set; }
        public float Diameter => Radius * 2;

        public Circle(Point origin) : this(origin, 1) { }
        public Circle(Point origin, float radius) : base()
        {
            Origin = origin;
            Radius = radius;
        }

        public override float Area => MathF.PI * Radius * Radius;
        public override float Perimeter => 2 * (float)Math.PI * Radius;
        public override string ToString()
        {
            return $"({Origin}, {Radius})";
        }
    }
}
