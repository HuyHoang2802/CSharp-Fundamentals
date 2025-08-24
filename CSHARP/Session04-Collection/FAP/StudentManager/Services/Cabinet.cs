using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManager.Entities;

namespace StudentManager.Services
{
    public class Cabinet
    {
        private Student[] _arr = new Student[30];
        private int _count = 0;

        public Cabinet(int size) // Tủ đóng theo yêu cầu 
        {
            _arr = new Student[size];
        }
        public Cabinet()
        {

        }
        public void PrintStudentList()
        {
            //for hếtt hay for count, for hết phải kiểm tra null. ArrayLíst khỏi lo 
            Console.WriteLine($"There is/are {_count} student(s) in the cabinet");
            for (int i = 0; i < _count; i++)
            {
                _arr[i].ShowProfile();
            }

        }
        public void AddStudent()

        {
            Student s = new Student();
            s.Input();
            Student.Add( s );
            //phải có lệnh để nhập id, name, yob, gpa, của từng sv đâu
            //arr[_count] = new Student() {....}
            //_count++ 

            //Lệnh nhập data phải phụ thuộc vào UI: console, web, form 
        }
        public void AddStudent(string id, string name, int yob, double gpa)
        {

        }

        public void AddStudent(Student s)
        {
            //phải có lệnh để nhập id, name, yob, gpa, của từng sv đâu
            //arr[_count] = new Student() {....}
            //_count++ 

            //Lệnh nhập data phải phụ thuộc vào UI: console, web, form 
            if (_count < 30)
            {
                _arr[_count] = s;
                _count++;
            }
        }        ////    private Student[] _arr = new Student[30];


     

    }
}
