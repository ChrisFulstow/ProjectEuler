using System.Linq;
using ProjectEulerCSharp.Helpers;
using ProjectEulerCSharp.Infrastructure;

namespace ProjectEulerCSharp.Solution
{
    [Problem(1, "Add all the natural numbers below one thousand that are multiples of 3 or 5.")]
    class Solution1 : ISolution
    {
        public string Solve()
        {
            // brute force O(n) technique
            var sum = Maths.IntegerSequence(0, 999)
                .Where(x => x % 3 == 0 || x % 5 == 0)
                .Sum();

            return sum.ToString();
        }

        public string Solve2()
        {
            // efficient O(1) technique
            const int max = 999;
            var sum = SumDivisibleBy(3, max) + SumDivisibleBy(5, max) - SumDivisibleBy(15, max);
            return sum.ToString();
        }

        private static int SumDivisibleBy(int divisor, int max)
        {
            return Maths.ArithmeticSeries(divisor, divisor, (max / divisor));
        }
    }
}
