using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using MoreLinq;
using ProjectEulerCore.Infrastructure;

namespace ProjectEulerRunner
{
    public class Problem
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public IList<SolutionsClass> SolutionClasses { get; set; }

        public Problem(int id, string description, IList<SolutionsClass> solutionClasses)
        {
            Id = id;
            Description = description;
            SolutionClasses = solutionClasses;
        }

        public IEnumerable<Solution> CalculateSolutions()
        {
            var stopwatch = new Stopwatch();
            var solutions = new List<Solution>();

            foreach (var solutionClass in SolutionClasses.OrderBy(sc => sc.Language))
            {
                var solutionsObject = Activator.CreateInstance(solutionClass.ClassType);
                var methods = solutionClass.ClassType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (var methodInfo in methods)
                {
                    stopwatch.Restart();
                    var result = methodInfo.Invoke(solutionsObject, null);
                    stopwatch.Stop();

                    solutions.Add(new Solution(methodInfo.Name, solutionClass.Language, stopwatch.ElapsedMilliseconds, result.ToString()));
                }
            }

            return solutions;
        }

        public static IEnumerable<Problem> GetAll()
        {
            var csharpAssembly = Assembly.Load("ProjectEulerCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            var fsharpAssembly = Assembly.Load("ProjectEulerFSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");

            var csharpClasses = SolutionsClass.Scan(csharpAssembly);
            var fsharpClasses = SolutionsClass.Scan(fsharpAssembly);

            var problemRunners =
                csharpClasses.Concat(fsharpClasses)
                    .GroupBy(c => c.Id).Select(classes => new Problem(
                        id: classes.Key,
                        description: classes.First().Description,
                        solutionClasses: classes.ToList()));

            return problemRunners;
        }

        public static Problem GetLatest()
        {
            return GetAll().MaxBy(p => p.Id);
        }

        public static Problem GetId(int id)
        {
            try
            {
                return GetAll().Single(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Problem with ID " + id + " not found.", ex);
            }
        }

        public class SolutionsClass
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public Type ClassType { get; set; }
            public string Language { get; set; }

            public SolutionsClass(int id, string description, string language, Type classType)
            {
                if (!classType.IsClass)
                    throw new ArgumentException("classType must be a class", "classType");

                Id = id;
                Description = description;
                Language = language;
                ClassType = classType;
            }

            public static IEnumerable<SolutionsClass> Scan(Assembly assembly)
            {
                var language = assembly.FullName.Contains("CSharp") ? "C#"
                    : assembly.FullName.Contains("FSharp") ? "F#" : "Unknown";

                var solutionClasses = assembly
                    .GetTypes()
                    .Where(type => Attribute.IsDefined(type, typeof(ProblemAttribute)))
                    .Select(type =>
                    {
                        var a = (ProblemAttribute)type.GetCustomAttributes(typeof(ProblemAttribute), false).First();
                        return new SolutionsClass(a.Id, a.Description, language, type);
                    });

                return solutionClasses;
            }
        }

        public class Solution
        {
            public Solution(string methodName, string language, long durationMs, string result)
            {
                MethodName = methodName;
                Language = language;
                DurationMs = durationMs;
                Result = result;
            }

            public string MethodName { get; set; }
            public string Language { get; set; }
            public long DurationMs { get; set; }
            public string Result { get; set; }
        }
    }
}