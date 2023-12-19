using System.Drawing;

namespace Geometry.Planimetry.Polar.Tests
{
    public class Program
    {
        private const int Width = 1920;
        private const int Height = 1080;
        private const int CanvasSize = 2;
        private const int FrameAmount = 520;

        public static void Main()
        {
            Canvas canvas = new(Width * CanvasSize, Height * CanvasSize);
            float aspect = (float)canvas.Width / canvas.Height / 2 * CanvasSize;

            for (int t = 1; t <= FrameAmount; t++)
            {
                canvas.Clear(Color.Black);
                var start = DateTime.Now;
                for (int i = 0; i <= 100000 / 10 * CanvasSize; i++)
                {
                    Point point = new((float)i / 5,
                        (i * MathHelper.Deg2Rad) + t)
                    {
                        Size = 50 * aspect,
                        Color = Color.FromArgb(15, GetColor(Color.IndianRed, Color.Purple))
                    };
                    canvas.SetObject(point);
                }

                canvas.Save($"Results/Polar Anim/Frame {t}.png");
                var end = DateTime.Now;
                Console.WriteLine($"{t}/{FrameAmount}; {start.ToLongTimeString()} start, " +
                    $"{end.ToLongTimeString()} end" +
                    $"({(end - start).TotalMilliseconds / 1000})");
            }
            Console.ReadKey();
        }
        private static Color GetColor(Color a, Color b)
        {
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * Random.Value),
                (int)(a.G + (b.G - a.G) * Random.Value),
                (int)(a.B + (b.B - a.B) * Random.Value));
        }
    }
}
