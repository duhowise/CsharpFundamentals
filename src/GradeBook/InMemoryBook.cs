using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook:Book
    {
        private List<double> _grades;
        public List<double> Grades => _grades;
        public const string Category = "Science";
        public override event GradeAddedDelegate GradeAdded;

        public InMemoryBook(string name):base(name)
        {
            _grades = new List<double>();
        }
        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 100)
            {
                _grades.Add(grade);
                if (GradeAdded == null)
                {
                    return;
                }
                GradeAdded(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        
       

        
    }
}