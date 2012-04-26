using System.Linq;
using System.Collections.Generic;
using ProjectEulerCore.Infrastructure;

namespace ProjectEulerCSharp
{
    [Problem(2, "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.")]
    public class Solution2
    {
        private const int Max = 4000000;

        public object SolveSimple()
        {
            var sum = FibonacciNumbers()
                .TakeWhile(x => x <= Max)
                .Where(x => x % 2 == 0)
                .Sum(x => (long)x);

            return sum;
        }

        public object SolveAddEveryThirdTerm()
        {
            var sum = FibonacciNumbers()
                .Where((x, i) => i % 3 == 0)  // (every third Fibonacci number is even, proof below)
                .TakeWhile(x => x <= Max)
                .Sum(x => (long)x);
            
            return sum;
        }

        private static IEnumerable<ulong> FibonacciNumbers()
        {
            yield return 0;
            yield return 1;

            ulong previous = 0, current = 1;
            while (true)
            {
                ulong next = checked(previous + current);
                yield return next;
                previous = current;
                current = next;
            }
        }

        /*
            Every third Fibonacci number is even, proof by induction:
            - Suppose f(3k), every 3rd term, is even, for k = 1
            - f(3) = f(2) + f(1) = 1 + 1 = 2 is even
            - Now induce f[3(k+1)] is even:

            f[3(k+1)]
	            = f(3k+3)
	            = f(3k+2) + f(3k+1)
	            = f(3k+1) + f(3k) + f(3k+1)
	            = 2[f(3k+1)] + f(3k)
	            = (multiple of 2 => even) + (f(3k) => even) => even
        */
    }
}
