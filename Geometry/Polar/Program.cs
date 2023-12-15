using System.Drawing;

namespace Geometry.Polar.Tests
{
    public class Program
    {
        public static void Main()
        {
            Canvas canvas = new(1920 * 2, 1080 * 2);

            for (int t = 1; t <= 300; t++)
            {
                var start = DateTime.Now;
                canvas.Fill(Color.Black);
                for (int i = 0; i < 1000; i++)
                {
                    Point point = new(Random.Value * 10000, Random.Value * 360 * t)
                    { Size = 5, Color = Color.White };
                    canvas.SetObject(point);
                }
                for (int i = 0; i <= 100000 / 1.5; i++)
                {
                    Point point = new((float)i / 10 / (t),
                        (i * MathHelper.Deg2Rad) + (t * 3.6f))
                    {
                        Size = 50,
                        Color = Color.FromArgb(10, GetColor(Color.Red, Color.Yellow))
                    };
                    canvas.SetObject(point);
                }

                canvas.Save($"Results/Polar Anim/Frame {t}.png");
                var end = DateTime.Now;
                Console.WriteLine($"{t}/300; {start.ToLongTimeString()} start, " +
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
