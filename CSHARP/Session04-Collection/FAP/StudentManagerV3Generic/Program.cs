using StudentManagerV2.Entities;
using StudentManagerV3Generic.Services;

namespace StudentManagerV3Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PlayWithInCabinet();
            PlayWithStudentAndLecturerCabinet();
        }

        static void PlayWithStudentAndLecturerCabinet()
        {
            CabinetFantasy<Student> tuSEStudent = new(10);
            tuSEStudent.AddAnItem(new Student() { Id = "SE1", Name = "AN" }); //object initializer 
            tuSEStudent.AddAnItem(new Student() { Id = "SE2", Name = "Binh" });
            CabinetFantasy<Lecturer> tuSELecturer = new(10);
            tuSELecturer.AddAnItem(new Lecturer() { Id = "00012345", Name = "Cuong", Salary = 25_000_000 });
            tuSELecturer.AddAnItem(new Lecturer() { Id = "00012346", Name = "Binh", Salary = 25_000_000 });

            tuSELecturer.PrintIems();
            tuSEStudent.PrintIems();

            CabinetFantasy<double> tuDouble = new(10);
            tuDouble.PrintIems();
        }



        static void PlayWithInCabinet()
        {
            CabinetFantasy<int> tuInt = new CabinetFantasy<int>(10);
            tuInt.AddAnItem(5);
            tuInt.AddAnItem(10);
            tuInt.AddAnItem(15);
            tuInt.AddAnItem(20);

            tuInt.PrintIems();
        }
    }
}
