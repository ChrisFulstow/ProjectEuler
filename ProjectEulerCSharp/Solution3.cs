using ProjectEulerCore.Infrastructure;

namespace ProjectEulerCSharp
{
    [Problem(3,
    @"The prime factors of 13195 are 5, 7, 13 and 29.
    What is the largest prime factor of the number 600851475143 ?")]
    public class Solution3
    {
        // A factor is a smaller number that divides exactly into a larger number.
        // e.g. 2, 3 and 4 are all factors of 12.

        // Prime factorization of 600851475143

        // There is only one unique set of prime factors for any number. (Fundamental Theorem of Arithmetic.)

        public object Solve()
        {
            return "Some value.";
        }
    }
}
