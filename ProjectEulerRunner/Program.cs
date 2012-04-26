using System;
using System.Text.RegularExpressions;

namespace ProjectEulerRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            //var problem = Problem.GetLatest();
            var problem = Problem.GetId(2);

            var line = Environment.NewLine;
            var desc = Regex.Replace(problem.Description, line + @"\s+", line);
            Console.WriteLine(line + "Problem " + problem.Id + ": " + line + line + desc + line);

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
