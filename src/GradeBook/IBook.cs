namespace GradeBook
{
    interface IBook
    {
        Statistics GetStatistics();
        void AddGrade(double grade);
        string Name{ get; }
        event GradeAddedDelegate GradeAdded;
    }
}