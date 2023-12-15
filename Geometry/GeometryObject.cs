using System.Drawing;

namespace Geometry
{
    public abstract class GeometryObject
    {
        public Color Color { get; set; } = Color.Red;
        public float Size { get; set; } = 5;
        public int Id { get; private set; }

        private static int _id;

        protected GeometryObject() => Id = _id++;

        public override string ToString() => $"ID: {Id}";
    }
}
