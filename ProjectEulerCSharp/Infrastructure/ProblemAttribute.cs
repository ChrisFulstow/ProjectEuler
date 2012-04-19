using System;

namespace ProjectEulerCSharp.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ProblemAttribute : Attribute
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ProblemAttribute(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}