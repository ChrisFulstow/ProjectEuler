using System;

namespace ProjectEulerRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var problem = Problem.GetLatest();
            Console.WriteLine(problem.Id + ": " + problem.Description);

            var solutions = problem.CalculateSolutions();
            foreach (var solution in solutions)
            {
                Console.WriteLine("{0} {1} {2}ms = {3}",
                    solution.Language, solution.MethodName, solution.DurationMs, solution.Result);
            }

            Console.Read();
        }
    }
}
