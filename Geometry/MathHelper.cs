using System;

namespace Geometry
{
    public static class MathHelper
    {
        public static float Sqrt2 => (float)Math.Sqrt(2);
        public static float Deg2Rad => 180 / (float)Math.PI;
        public static float Rad2Deg => (float)Math.PI / 180;

        public static int Factorial(int n)
        {
            if (n <= 0) throw new ArgumentOutOfRangeException(n.ToString());
            int result = 1;
            for (int i = 1; i <= n; i++) result *= i;
            return result;
        }
        public static bool IsPrime(int n)
        {
            if (!GetPrimeNumbers(n).Contains(n)) return false;
            return true;
        }
        public static int[] GetPrimeNumbers(int n)
        {
            bool[] prime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
                prime[i] = true;

            for (int p = 2; p * p <= n; p++)
                if (prime[p] == true)
                    for (int i = p * 2; i <= n; i += p)
                        prime[i] = false;

            int count = 0;
            for (int i = 2; i <= n; i++)
                if (prime[i] == true)
                    count++;

            int[] primes = new int[count];
            int index = 0;
            for (int i = 2; i <= n; i++)
            {
                if (prime[i] == true)
                {
                    primes[index] = i;
                    index++;
                }
            }

            return primes;
        }
    }
}
