using StudentManagerV2.Entities;
using StudentManagerV2.Services;

namespace StudentManagerV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentCabinet tuSEStudent = new StudentCabinet(30);
            //ram: có 30 biến sv nằm trong mảng _arr \
            tuSEStudent.AddStudent(new Student() { Id = "SE1", Name = "An" });//object inittializer 
            Student s = new Student() { Id = "SE2", Name = "Binh" };
            tuSEStudent.AddStudent(s);
            s.Gpa = 8.6;
            tuSEStudent.PrintStudent();

            //Tủ đựng hồ sơ giảng viên 
            LecturerCabinet tuSELecturer = new LecturerCabinet(30);
            tuSELecturer.AddALecturer(new Lecturer() { Id = "00012345", Name = "Cuong" });
            tuSELecturer.AddALecturer(new Lecturer() { Id = "00012346", Name = "Giang", Salary = 25000000 });
            tuSELecturer.AddALecturer(new Lecturer() { Id = "00012347", Name = "Huong", Salary = 26_000_000 });

            tuSELecturer.PrinLectures();
        }
    }
}
