using System;

namespace GradeBook
{
    class Program
    {
        private const string Q = "Q";

       static Book book = new Book("Some Gradebook");


        static void Main(string[] args)
        {
            string entry;
           
            do
            {
                Console.WriteLine("enter a number");
                entry = System.Console.ReadLine();
                if (entry==null)
                {
                   continue; 
                }
                double.TryParse(entry,out var number);
                book.AddGrade(number);

            } while (entry != Q);

            // book.AddGrade(90.3);
            // book.AddGrade(98.3);
            // book.AddGrade(12.3);
            // book.AddGrade(10.8);
            // book.AddGrade(1.4);
            // book.AddGrade(56.1);
            var result = book.ShowStatistics();
            System.Console.WriteLine($"The lowest grade is {result.Low}");
            System.Console.WriteLine($"The highest grade is {result.High}");
            System.Console.WriteLine($"the sum of the grades are {result.Sum:N3}");
            System.Console.WriteLine($"the average grade is {result.Average:N3}");

        }
    }
}