namespace Geometry.Planimetry
{
    public abstract class Shape : GeometryObject
    {
        public Point Origin { get; protected set; }

        public virtual float Area { get; }
        public virtual float Perimeter { get; }
    }
}
