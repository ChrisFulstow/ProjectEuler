using System;
using ProjectEulerCSharp.Infrastructure;

namespace ProjectEulerCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var problem = Problem.GetLatest();

            Console.WriteLine(problem.Id + ": " + problem.Description);
            Console.WriteLine(problem.GetSolution());

            Console.Read();
        }
    }
}
