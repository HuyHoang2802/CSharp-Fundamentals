using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV3Generic.Services
{
    public class CabinetFantasy<T> //Type: data, data type 
                                    //Sẽ bất kì Student, Lecturer 
                                    //Hoặc bất kfi class kahcs đưa vào 
                                    //Class, data type được đưa vào như 1 PARAM, GENERIC: TUi làm viẹc tổng quát với các data type vào khi dùng tui 
                                    //new CabinetFantansy<Student> 
    {
        private T[] _arr;  //Mảng bao nhiêu phần tử 
        private int _count =0;

        public CabinetFantasy(int size) => _arr = new T[size];
        //To do: Nếu size <= 0 hoặc size quá lớn, thì xử lí thế nào ???
         //CRUD method 

        public void AddAnItem(T x) => _arr[_count++] = x;
        //To do: Nếu kiểm tra full mảng_count == size ==_arr.length 

        public void PrintIems ()
        {
            if (_count <= 0)
            {
                Console.WriteLine(" There cabinet is emty ");
                return;
            }
            Console.WriteLine($" There is/are {_count} items(s) in the cabinet");
            for (int i = 0; i < _count; i++)
            
                Console.WriteLine(_arr[i]);
            
        }
       





    }
}
