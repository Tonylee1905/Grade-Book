using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTest
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(97.0);
            book.AddGrade(77.5);
            book.AddGrade(67.9);

            // act
            var result = book.GetStatistics();


            //assert
            //Assert.Equal(80.8, result.Average, 1);
            Assert.Equal(97.0, result.High, 1);
            Assert.Equal(67.9, result.Low, 1);
            Assert.Equal('B', result.Letter);

        }
    }
}
