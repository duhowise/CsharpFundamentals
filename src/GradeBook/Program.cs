using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {

        static void Main (string[] args)
        {
            var book = new Book ();
            book.AddGrade (12.3);

            var grades = new List<double> { 12.3, 10.8, 1.4 };
            grades.Add (56.1);
            var result = 0.0;
            var totalNumberOfGrades = grades.Count;

            foreach (var grade in grades)
            {
                result += grade;
            }

            System.Console.WriteLine ($"the sum of the grades are {result:N3}");
            result /= totalNumberOfGrades;
            System.Console.WriteLine ($"the average grade is {result:N3}");

        }
    }
}