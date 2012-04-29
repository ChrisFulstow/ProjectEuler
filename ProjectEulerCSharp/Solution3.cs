using System;
using ProjectEulerCore.Infrastructure;

namespace ProjectEulerCSharp
{
    [Problem(3,
    @"The prime factors of 13195 are 5, 7, 13 and 29.
    What is the largest prime factor of the number 600851475143 ?")]
    public class Solution3
    {
        // Answer: 6857

        private const long TargetNumber = 600851475143;

        public object Solve()
        {
            var n = LargestFactor(TargetNumber);

            while (!IsPrime(n))
            {
                n = LargestFactor(n);
            }
            return n;
        }


        public object Solve2()
        {
            var num = TargetNumber;
            var factor = 2;
            while (true)
            {
                if (num % factor == 0) num = num / factor;
                if (num == 1) break;
                factor = (factor == 2) ? factor + 1 : factor + 2;
            }
            return factor;
        }


        private static long LargestFactor(long num)
        {
            for (var i = 2; i < num; i++)
            {
                if (num % i != 0) continue;
                return num / i;
            }
            return num;
        }


        private static bool IsPrime(long n)
        {
            // note: this function can be optimised further

            if (n < 2) return false;

            var max = Math.Sqrt(n);

            for (var f = 2; f < max; f++)
            {
                if (n % f == 0) return false;
            }
            return true;
        }
    }
}
