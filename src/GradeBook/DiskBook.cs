using System.Security.AccessControl;
using System.IO;
using System;

namespace GradeBook
{
    internal class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 100)
            {
                var path = $"{Name}.txt";
                using (var writer = File.AppendText(path))
                {
                    writer.WriteLine(grade);
                    GradeAdded?.Invoke(this, new System.EventArgs());
                    return;
                }

            }else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");

            }
            


        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            var path = $"{Name}.txt";

            using (var reader = File.OpenText(path))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}