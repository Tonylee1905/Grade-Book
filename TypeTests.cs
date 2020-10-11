using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
           var book1 = GetBook("Book 1");
           GetBookSetName(ref book1, "New Name");

           Assert.Equal("New Name", book1.Name);
           

        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
           var book1 = GetBook("Book 1");
           GetBookSetName(book1, "New Name");

           Assert.Equal("Book 1", book1.Name);
           

        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CanSetNameFromRefference()
        {
           var book1 = GetBook("Book 1");
           SetName(book1, "New Name");

           Assert.Equal("New Name", book1.Name);
           

        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObject()
        {
           var book1 = GetBook("Book 1");
           var book2 = GetBook("Book 2");

           Assert.Equal("Book 1", book1.Name);
           Assert.Equal("Book 2", book2.Name);
           Assert.NotEqual(book1, book2);

        }

        [Fact]
        public void TwovarsCanRefferenceSameObj()
        {
           var book1 = GetBook("Book 1");
           var book2 = book1;

           Assert.Same(book1, book2);
           Assert.True(Object.ReferenceEquals(book1, book2));

        }


        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
