using System.Drawing;

namespace Geometry.Planimetry
{
    public class Canvas
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private readonly Bitmap _bitmap;
        private readonly Graphics _graphics;

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            _bitmap = new Bitmap(Width, Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
        }

        public void Save(string path) => _bitmap.Save(path);

        public void Fill(Color color)
        {
            _graphics.Clear(color);
        }
        public void SetObject(Point point)
        {
            Point p1 = new Point(Width / 2, Height / 2) - point * point.Size;
            _graphics.FillEllipse(new SolidBrush(point.Color),
                p1.X, p1.Y, point.Size, point.Size);
        }
        public void SetObject(Interval interval)
        {
            Point p1 = new Point(Width / 2, Height / 2)
                - interval.Point0 * interval.Size;
            Point p2 = new Point(Width / 2, Height / 2)
                - interval.Point1 * interval.Size;
            _graphics.DrawLine(new(interval.Color), p1.X, p1.Y, p2.X, p2.Y);
        }
        public void SetObject(Angle angle)
        {
            Point p1 = new Point(Width / 2, Height / 2) - angle.Point1 * angle.Size;
            Point p2 = new Point(Width / 2, Height / 2) - angle.Point2 * angle.Size;
            Point p3 = new Point(Width / 2, Height / 2) - angle.Point3 * angle.Size;

            PointF[] path = new PointF[]
            {
                new(p1.X, p1.Y),
                new(p2.X, p2.Y),
                new(p3.X, p3.Y)
            };

            _graphics.DrawLines(new(angle.Color), path);
        }
        public void SetObject(Quadrangle quadrangle)
        {
            Point p1 = new Point(Width / 2, Height / 2)
                - quadrangle.Points.Point1 * quadrangle.Size;
            Point p2 = new Point(Width / 2, Height / 2)
                - quadrangle.Points.Point2 * quadrangle.Size;
            Point p3 = new Point(Width / 2, Height / 2)
                - quadrangle.Points.Point3 * quadrangle.Size;
            Point p4 = new Point(Width / 2, Height / 2)
                - quadrangle.Points.Point4 * quadrangle.Size;

            PointF[] path = new PointF[]
            {
                new(p1.X, p1.Y),
                new(p2.X, p2.Y),
                new(p3.X, p3.Y),
                new(p4.X, p4.Y),
                new(p1.X, p1.Y)
            };
            _graphics.FillPolygon(new SolidBrush(quadrangle.Color), path);
        }
        public void SetObject(Triangle triangle)
        {
            Point p1 = new Point(Width / 2, Height / 2)
                - triangle.Points.Point1 * triangle.Size;
            Point p2 = new Point(Width / 2, Height / 2)
                - triangle.Points.Point2 * triangle.Size;
            Point p3 = new Point(Width / 2, Height / 2)
                - triangle.Points.Point3 * triangle.Size;

            PointF[] path = new PointF[]
            {
                new(p1.X, p1.Y),
                new(p2.X, p2.Y),
                new(p3.X, p3.Y),
                new(p1.X, p1.Y)
            };
            _graphics.FillPolygon(new SolidBrush(triangle.Color), path);
        }
        public void SetObject(Circle circle)
        {
            Point origin = new Point(Width / 2, Height / 2) - circle.Origin;
            _graphics.FillEllipse(new SolidBrush(circle.Color),
                origin.X, origin.Y, circle.Diameter * circle.Size,
                circle.Diameter * circle.Size);
        }
    }
}
