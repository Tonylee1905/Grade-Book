using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return sum / count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'C';

                    default:
                        return 'F';

                }
            }
        }
        public double sum;
        public int count;

        public void Add(double number)
        {
            sum += number;
            count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);

        }

        public Statistics()
        {
            count = 0;
            sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }
}