using Geometry.Planimetry;
using System.Drawing;

namespace Geometry.Polar
{
    public class Canvas
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private readonly Bitmap _bitmap;
        private readonly Graphics _graphics;

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            _bitmap = new(width, height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
        }

        public void Clear(Color color) => _graphics.Clear(color);

        public void SetObject(Point point)
        {
            Point p1 = new(Width / 2 - point.X, Height / 2 - point.Y);
            _graphics.FillEllipse(new SolidBrush(point.Color), p1.Distance, p1.Angle,
                point.Size, point.Size);
        }
        public void DrawLine(Point point1, Point point2, Color color)
        {
            PointF p1 = new(point1.X, point1.Y);
            PointF p2 = new(point2.X, point2.Y);
            _graphics.DrawLine(new(color), p1, p2);
        }

        public void Save(string fileName) => _bitmap.Save(fileName);
    }
}
