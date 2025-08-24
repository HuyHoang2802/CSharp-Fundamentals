using System.Linq.Expressions;
using StudentManager.Entities;
using StudentManager.Services;

namespace StudentManager
{

    internal class Program
    {
        static List<Student> students = new List<Student>();
        static List<Lecturer> lecturers = new List<Lecturer>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=============MENU==========");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. In sinh viên theo tăng dần về điểm: ");
                Console.WriteLine("3. In sinh viên theo tăng dần về tên ");
                Console.WriteLine("4. Xóa sinh viên");
                Console.WriteLine("5. Update sinh viên");
                Console.WriteLine("6. Search sinh viên");
                Console.WriteLine("7. Exit");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        students.
                        break;
                       
                }
            }
        }
    }
}
//1. Hoàn thiện nốt bài Quản lí sv 
   // - In ra MENU 
   //   1. ADD Student - nhập từ bàn phím: Console.readline -> trả về chuỗi  -> cần số thì phải convert, integer.parseInt()
   //   2. Print Student - sort theo tăng dần về diểm 
   //   3. Print student - sort theo tăng dần về tên
   //   4. Xóa, sửa, search
   //   5. Exit!!
//2. Làm class LECTURER, Tủ đựng hồ sơ giảng viên: ADD(). Print()
//Thông tin giảng viên gồmL ID, Name, Yob, salary 

//Chuẩn bị cho bài generic <> List<student>
//Sort và in ra: vô số tiêu chí sort khác nhau 
//              Tên, năm sinh, điểm, cùng tên điểm giảm dần, gom nhóm theo tìnhs
//              Ai viết dở/ newbie: mõi tiêu chí sort là 1 hàm 
//              Mai môtts thêm kiểu sort khác là phải sửa code 
//              Viết ngon: chỉ 1 hàm sort, mà tiên đoán đc tương lai, ko sửa code mới 