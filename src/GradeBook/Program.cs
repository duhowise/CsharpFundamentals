using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {

        static void Main (string[] args)
        {
            var book = new Book ("Some Gradebook");
            book.AddGrade (12.3);
            book.AddGrade (90.3);
            book.AddGrade (98.3);
            book.AddGrade (12.3);
            book.AddGrade (10.8);
            book.AddGrade (1.4);
            book.AddGrade (56.1);
            book.ShowStatistics ();         

        }
    }
}