namespace Geometry
{
    public static class Random
    {
        public static float Value => (float)new System.Random(
            (int)DateTime.Now.Ticks * DateTime.Now.Minute + DateTime.Now.Hour)
            .Next(0, 100000) / 100000;
    }
}
