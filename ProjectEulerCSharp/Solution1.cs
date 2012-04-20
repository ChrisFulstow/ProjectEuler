using System.Linq;
using ProjectEulerCore.Helpers;
using ProjectEulerCore.Infrastructure;

namespace ProjectEulerCSharp
{
    [Problem(1, "Add all the natural numbers below one thousand that are multiples of 3 or 5.")]
    public class Solution1
    {
        public string SolveBruteForce()
        {
            // brute force O(n) technique
            var sum = Enumerable.Range(1, 999)
                .Where(x => x % 3 == 0 || x % 5 == 0)
                .Sum();

            return sum.ToString();
        }

        public string SolveEfficient()
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
