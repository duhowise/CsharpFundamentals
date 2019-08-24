using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> _grades;

        public List<double> Grades => _grades;

        public string Name;

        public Book(string name)
        {
            Name = name;
            _grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            if (grade > 0&&grade <= 100)
            {
                _grades.Add(grade);

            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public void AddLetterGrade(char letterGrade)
        {
            switch (letterGrade)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public Statistics ShowStatistics()
        {
            var result = new Statistics { Average = 0.0, High = double.MinValue, Low = double.MaxValue };
            foreach (var number in _grades)
            {
                result.Low = Math.Min(result.Low, number);
                result.High = Math.Max(number, result.High);
                result.Average += number;
                result.Sum += number;
            }
            
            result.Average /= _grades.Count;
            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'c';
                    break;
                default:
                    result.Letter = 'D';
                    break;
            }
            return result;
        }
    }
}