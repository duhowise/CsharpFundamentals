using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        List<double> grades;
        string name;

        public Book (string name)
        {
            this.name = name;
            grades = new List<double> ();
        }
        public void AddGrade (double grade)
        {
            grades.Add (grade);
        }

        public void ShowStats ()
        {
            var result = 0.0;

            var totalNumberOfGrades = grades.Count;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach (var number in grades)
            {
                lowGrade = Math.Min (number, lowGrade);
                highGrade = Math.Max (number, highGrade);
                result += number;
            }

            System.Console.WriteLine ($"The lowest grade is {lowGrade}");
            System.Console.WriteLine ($"The highest grade is {highGrade}");
            System.Console.WriteLine ($"the sum of the grades are {result:N3}");
            result /= totalNumberOfGrades;
            System.Console.WriteLine ($"the average grade is {result:N3}");
        }
    }
}