using System.Collections;
using ListBasic.Entities;

namespace ListBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayWithListGenericV2();
        }

        static void PlayWithListGenericV2()
        {
            List<Student> arr = new List<Student>();
            arr.Add(new Student() {Id ="SE1", Name = "An" });
            arr.Add(new Student() { Id = "SE2", Name = "Binh" });
            arr.Add(new Student() { Id = "SE3", Name = "Cuong", Yob = 2004 });
            Console.WriteLine("The list of student:");
            foreach (Student student in arr)
            {
                student.ShowProfile();
            }
        }





        static void PlayWithListGenericV1()
        {
            List<int> arr = new List<int>();
            arr.Add(5);
            arr.Add(10);
            arr.Add(15);
            arr.Add(20);
            int sum = 0;
            //arr.Add(4.14);
            //arr.Add("PT"); //ko type safe - ko an toàn 
            //arr.Add(new Student() { Id = "SE1", Name = "AN" });
            foreach (int x in arr)
            {
                sum += x;
            }
            Console.WriteLine("sum: " + sum);
            Console.WriteLine("The list of number");
            for (int i = 0; i < arr.Count; i++)
            {
                //Console.WriteLine(arr[i]);
                Console.WriteLine(arr.ElementAt(i)); //Get vị trí thứ i bên java
            }
        }






        static void PlayWithIntegerList()
        {
            ArrayList arr = new ArrayList();//Là class thùng chứa tựa mảng,  co giãn và ko generic, ko generic thì 
            arr.Add(5);
            arr.Add(10);
            arr.Add(15);
            arr.Add(20);
            arr.Add(4.14);
            arr.Add("PT"); //ko type safe - ko an toàn 
            arr.Add(new Student() { Id = "SE1", Name = "AN" });
            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine("the array list ís printed by using for each ");
            foreach (var x in arr) Console.WriteLine(x);
            
                
            

        }
    }
}
