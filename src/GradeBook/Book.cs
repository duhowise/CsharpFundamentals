using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public abstract class Book : NamedObject, IBook
    {
        internal List<double> _grades;

        public Book(string name) : base(name)
        {
            _grades = new List<double>();

        }
        public abstract void AddGrade(double grade);
     
        public abstract event GradeAddedDelegate GradeAdded;
        public virtual Statistics GetStatistics(){
            var result = new Statistics();
            foreach (var number in _grades)
            {
                result.Add(number);
               
            }
            
            return result;
        }

        public void AddGrade(char letterGrade)
        {
            switch (letterGrade)
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
                default:
                    AddGrade(0);
                    break;
            }
        }


    }
}