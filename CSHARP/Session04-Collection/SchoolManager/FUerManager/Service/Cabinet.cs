using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUerManager.Service
{
    public class Cabinet<T> //type tôi sẽ lưu trữ và sử lí 1 mảng t nào đó, list<T> nào đó
    {
        //private T[] _arr;
        //private int _count = 0;

        private List<T> arr = new(); //ko càn ctor để truyền size 
        //ko cần biến count mà vẫn co dãn thoải maí 

        public void PrintItem()
        {
            if ( arr.Count ==0)
            {
                Console.WriteLine("The list is empty, Nothing to print");
                return;
            }
            Console.WriteLine($"There is/are {arr.Count} items in the list:  ");
            foreach (T item in arr)  Console.WriteLine(item); 

        }
        public void AddItem(T x)
        {
            arr.Add(x);
        }
    }
}
