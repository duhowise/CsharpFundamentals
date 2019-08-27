using Xunit;
using GradeBook;
using System;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAverage()
        {


            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //When
            var result = book.GetStatistics();

            //Then

            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);

        }

        [Fact]
        public void AddGradeValidatesGrades()
        {
            //Given
            var book = new InMemoryBook("Book");
            var book1 = new InMemoryBook("Book 1");
            var book2 = new InMemoryBook("Book 2");

            //When

            book2.AddGrade(50);

            //Then
            Assert.Throws<ArgumentException>(() =>book1.AddGrade(101));
            var exception = Assert.Throws<ArgumentException>(() => book.AddGrade(-1));
            Assert.Equal($"Invalid grade", exception.Message);
            Assert.False(book.Grades.Count != 0);
            Assert.False(book1.Grades.Count != 0);
            Assert.Single(book2.Grades);
        }
    }
}