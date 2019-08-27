using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            //Given
            WriteLogDelegate log = ReturnMessage;
            //When
            log += ReturnMessage;
            log += IncrementCount;
            var result = log("Hello");
            //Then
            Assert.Equal(3, count);
        }

        string ReturnMessage(string message)
        {
            count += 1;
            return message.ToLower();
        }
        string IncrementCount(string message)
        {
            count += 1;
            return message;
        }

        [Fact]
        public void StringBehavesLikeValueTypes()
        {
            string name = "scott";
            name = MakeUpperCase(name);
            Assert.Equal("SCOTT", name);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }


        [Fact]
        public void TestName()
        {
            //Given
            var x = GetInt();
            SetInt(ref x);
            //When
            var expected = 42;
            //Then
            Assert.Equal(expected, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CsharpCanPassByRef()
        {
            //Given
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            //When
            var expected = "New Name";
            var actual = book1.Name;
            //Then
            Assert.Equal(expected, actual);
            Assert.NotEqual("Book 1", actual);
        }

        private void GetBookSetName(ref InMemoryBook book, string bookName)
        {
            book = new InMemoryBook(bookName);
        }

        [Fact]
        public void CsharpIsByValue()
        {
            //Given
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            //When
            var expected = "New Name";
            var actual = book1.Name;
            //Then
            Assert.NotEqual(expected, actual);
            Assert.Equal("Book 1", actual);
        }

        private void GetBookSetName(InMemoryBook book, string bookName)
        {
            book = new InMemoryBook(bookName);
        }


        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //Given
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            //When

            //Then

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //Given
            var book1 = GetBook("Book 1");
            book1 = setName(book1, "New Name");
            //When

            //Then21
            Assert.NotEqual(book1.Name, "Book 1");
            Assert.Equal(book1.Name, "New Name");
        }

        private InMemoryBook setName(InMemoryBook book1, string bookName)
        {
            return new InMemoryBook(bookName);
        }

        [Fact]
        public void TwoVariablesCanReferenceTheSameObject()
        {
            //Given
            var book1 = GetBook("Book 1");
            var book2 = book1;
            //When

            //Then

            // Assert.Equal("Book 1", book1.Name);
            // Assert.Equal("Book 2", book2.Name);
            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string bookName)
        {
            return new InMemoryBook(bookName);
        }
    }
}