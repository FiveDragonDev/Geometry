namespace Geometry
{
    public static class Random
    {
        public static float Value => (float)random.Next(0, 100000) / 100000;

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        private static System.Random random => new((int)DateTime.Now.Ticks *
            DateTime.Now.Minute + DateTime.Now.Hour);

        public static int Range(int start, int end) => random.Next(start, end);
    }
}
