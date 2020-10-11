using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
           get;
           set;
        }
    }

    public interface IBook 
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        String Name{get;}
    }

    public abstract class Book: NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
       
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            writer.WriteLine(grade);
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
    public class InMemoryBook: Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
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

                case 'D':
                    AddGrade(60);
                    break;

                case 'F':
                    AddGrade(50);
                    break;

                default: 
                    AddGrade(0);
                    break;
            }
        }
        public override void AddGrade(double grade)
        {
            if(grade>=0 && grade <=100)
            {
                grades.Add(grade);
            }
            
            else
            {
                Console.WriteLine("Invalid grade input");
            }

        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            
            foreach(var grade in grades)
            {
                result.Add(grade);
                
            }
                        
            return result;
        }
        private List<double> grades;  
        //private string name;
    }
}