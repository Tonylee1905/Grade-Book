using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new InMemoryBook("JSS 3B");
            EnterGrades(book);
            var stats = book.GetStatistics();


            Console.WriteLine($"For the book nameed {book.Name} ");
            Console.WriteLine($"The Highest grade is {stats.High:N1} ");
            Console.WriteLine($"The Lowest grade is {stats.Low:N1} ");
            Console.WriteLine($"The Average grade is {stats.Average:N1} ");
            Console.WriteLine($"The letter grade for the Average grade is {stats.Letter} ");
        }
        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter the grade for each student and hit letter Q when done");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
