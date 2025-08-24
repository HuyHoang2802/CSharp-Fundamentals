using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagerV2.Entities;

namespace StudentManagerV2.Services
{
    public class StudentCabinet
    {
        private Student[] _arr; // = new Student[30];
        //đằng nào cũng phải new, từ từ new, đóng cái tủ theo nhu cầu của mỗi nhà 
        private int _count = 0; // tủ ban đầu chưa có món đồ mảng chủa có value cho các biến cho các phần tử ở đây chính là phần [i] = new Studetn() sẽ là 1 value cho phần tử/ biêsn thứ [i] của mảng 

        //tủ độ đóng theo yêu cầu gia chủ, số ngăn tùy chọn 
        public StudentCabinet(int size) =>_arr = new Student[size];
         //câc hàm CRUD, cho từng món đồ trong tủ, từng biêns thứ [i]
         //Xử lí info, xử lí các object từ entity student
         public void PrintStudent()
        {
            if (_count < 0)
            {
                Console.WriteLine("There cabinet is empty. Nothing to print ");
                return;//thoát hàm luôn  
            }
            //KO in đến hết mảng coi chừng null reference exception. chỉ for đến count, hocặ for hết thì phải check null 
            Console.WriteLine($"There is/are {_count} student in the cabinet");
            for (int i = 0; i < _count; i++)
                _arr[i].ShowProfile();

        }
        public void AddStudent(Student x ) =>   _arr[_count++] = x;
    }
}
