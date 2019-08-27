using System;

namespace GradeBook
{
    public class Statistics
    {



        public double Average => Sum / Count;

        public double Low;
        public double High;
        public int Count;
        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(Low, number);
            High = Math.Max(number, High);
        }
        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;

        }

        
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
                        return 'c';
                    default:
                        return 'D';
                }

            }
        }
        public double Sum;
    }

}


