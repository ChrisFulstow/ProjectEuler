using System;
using ProjectEulerCore.Helpers;
using ProjectEulerCore.Infrastructure;

namespace ProjectEulerCSharp
{
    [Problem(4,
    @"A palindromic number reads the same both ways.
    The largest palindrome made from the product of two 2-digit numbers is 9009 = 91  99.
    Find the largest palindrome made from the product of two 3-digit numbers.")]
    public class Solution4
    {
        // Answer: 906,609 (993 x 913)
        
        // max of 3 digit products is (999 * 999) 998,001
        // so largest possible palindrome is 997,799

        public object Solve()
        {
            for (var i = 997; i >= 1; i--)
            {
                var palindromicNumber = int.Parse(i + i.ToString().Reverse());
                if (IsProductOfTwo3DigitNumbers(palindromicNumber))
                    return palindromicNumber;
            }

            return null;
        }

        private static bool IsProductOfTwo3DigitNumbers(int num)
        {
            for (var i = 999; i >= 100; i--)
            for (var j = 999; j >= 100; j--)
            {
                var product = i * j;
                if (product < num || j < i) break;
                if (product != num) continue;
                return true;
            }

            return false;
        }
    }
}
