using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook:Book
    {
        public const string Category = "Science";
        public override event GradeAddedDelegate GradeAdded;
        public List<double> Grades => _grades;
        public InMemoryBook(string name):base(name)
        {
        }
        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 100)
            {
                _grades.Add(grade);
              GradeAdded?.Invoke(this,new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        
       

        
    }
}