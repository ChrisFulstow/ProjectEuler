using System;
using System.Linq;
using MoreLinq;
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

            // max variable is captured by the sumDivisibleBy closure
            Func<int, int> sumDivisibleBy = divisor => Maths.ArithmeticSeries(divisor, divisor, (max / divisor));

            var sum = sumDivisibleBy(3) + sumDivisibleBy(5) - sumDivisibleBy(15);
            return sum.ToString();
        }

        public object SolveGenerateByIndex()
        {
            // using MoreLinq GenerateByIndex
            var sum = MoreEnumerable.GenerateByIndex(x => (x % 3 == 0) || (x % 5 == 0) ? x : 0).Take(1000).Sum();
            return sum;
        }
    }
}
