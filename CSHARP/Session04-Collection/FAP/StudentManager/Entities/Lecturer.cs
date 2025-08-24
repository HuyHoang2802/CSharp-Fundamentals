using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Entities
{
    public class Lecturer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Yob { get; set; }
        public double Salary { get; set; }

        public void Input()
        {
            Console.WriteLine("Nhập ID: ");
            ID = Console.ReadLine();
            Console.WriteLine("Nhập name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Nhập Yob: "); 
            Yob = int.Parse (Console.ReadLine());
            Console.WriteLine("Nhập salary: ");
            Salary = double.Parse (Console.ReadLine());
        }

        public override string? ToString() => $"ID: {ID} | Name: {Name} || Yob: {Yob} || Salary: {Salary}";

        public void ShowProfile()
        {
            Console.WriteLine(ToString());
        }

    }
}
