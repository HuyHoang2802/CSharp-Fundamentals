using FUerManager.Entities;
using FUerManager.Service;

namespace FUerManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PlayWithIntegerCabinet();
            PlayWithStudentCabinet();
        }
        static void PlayWithStudentCabinet()
        {
            Cabinet<Student> tuSE = new Cabinet<Student>();
            tuSE.AddItem(new Student() {Id = "SE1", Name = "AN" });
            tuSE.AddItem(new Student() { Id = "SE2", Name = "Binh" });
            tuSE.AddItem(new Student() { Id = "SE3", Name = "Cuong" });
            tuSE.PrintItem();
        }
        static void PlayWithIntegerCabinet()
        {
            Cabinet<int> tuInt = new Cabinet<int>();
            tuInt.AddItem(5);
            tuInt.AddItem(10);
            tuInt.AddItem(15);
            tuInt.AddItem(20);
            tuInt.PrintItem();

        }
    }
}
