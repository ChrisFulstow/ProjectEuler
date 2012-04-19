using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MoreLinq;

namespace ProjectEulerCSharp.Infrastructure
{
    public class Problem
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public Type Solution { get; private set; }

        public Problem(int id, string description, Type solutionType)
        {
            Id = id;
            Description = description;
            Solution = solutionType;
        }

        public string GetSolution()
        {
            var instance = (ISolution)Activator.CreateInstance(Solution);
            return instance.Solve();
        }

        public static IEnumerable<Problem> GetAll()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => Attribute.IsDefined(type, typeof(ProblemAttribute)))
                .Select(type =>
                {
                    var a = (ProblemAttribute)type.GetCustomAttributes(typeof(ProblemAttribute), false).First();
                    return new Problem(a.Id, a.Description, type);
                });
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
    }
}