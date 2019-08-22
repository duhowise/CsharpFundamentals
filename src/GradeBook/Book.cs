using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        List<double> _grades;
       public string Name;

        public Book(string name)
        {
            Name = name;
            _grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            _grades.Add(grade);
        }

        public Statistics ShowStatistics()
        {
            var result = new Statistics {Average = 0.0, High = double.MinValue, Low = double.MaxValue};
            foreach (var number in _grades)
            {
                result.Low = Math.Min(number, result.Low);
                result.High = Math.Max(number, result.High);
                result.Average += number;
            }

            // System.Console.WriteLine($"The lowest grade is {result.Low}");
            // System.Console.WriteLine($"The highest grade is {result.High}");
            // System.Console.WriteLine($"the sum of the grades are {result:N3}");
            result.Average /= _grades.Count;
            // System.Console.WriteLine($"the average grade is {result.Average:N3}");
            return result;
        }
    }
}