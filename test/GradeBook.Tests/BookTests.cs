using Xunit;
using GradeBook;
namespace GradeBook.Tests
{
    public class BookTests
    {
       [Fact] public void BookCalculatesAverage(){


            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //When
            var result = book.ShowStatistics();

            //Then

            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);

        }
    }
}