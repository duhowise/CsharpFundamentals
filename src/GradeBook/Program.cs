using System;

namespace GradeBook
{
    class Program
    {
        private const string Quit = "Q";
        static void Main(string[] args)
        {
            var book = new DiskBook("Some Gradebook");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

        }

        private static void EnterGrades(IBook book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            string entry;
            do
            {
                Console.WriteLine("enter a number");
                entry = System.Console.ReadLine();
                try
                {
                    var number = double.Parse(entry);
                    book.AddGrade(number);
                }
                catch (ArgumentException exception)
                {

                    System.Console.WriteLine(exception.Message);
                }
                catch (FormatException exception)
                {

                    System.Console.WriteLine(exception.Message);
                }

            } while (entry != Quit);

            // book.AddGrade(90.3);
            // book.AddGrade(98.3);
            // book.AddGrade(12.3);
            // book.AddGrade(10.8);
            // book.AddGrade(1.4);
            // book.AddGrade(56.1);
            var result = book.GetStatistics();
            System.Console.WriteLine($"For the book named {book.Name}");
            System.Console.WriteLine($"The lowest grade is {result.Low}");
            System.Console.WriteLine($"The highest grade is {result.High}");
            System.Console.WriteLine($"the sum of the grades are {result.Sum:N3}");
            System.Console.WriteLine($"the average grade is {result.Average:N3}");
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            System.Console.WriteLine("A grade was added");
        }

    }
}