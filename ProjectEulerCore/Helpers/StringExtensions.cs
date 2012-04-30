using System;

namespace ProjectEulerCore.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Reverses a string
        /// </summary>
        public static string Reverse(this string str)
        {
            var array = str.ToCharArray();
            Array.Reverse(array);
            return (new string(array));
        }
    }
}