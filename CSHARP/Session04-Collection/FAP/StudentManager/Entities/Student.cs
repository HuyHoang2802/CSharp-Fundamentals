using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Entities
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
            
        public int Yob { get; set; }
        public double Gpa { get; set; }

        public void Input()
        {
            Console.WriteLine("Nhập id: ");
            Id = Console.ReadLine();
            Console.WriteLine("Nhâp name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Nhập yob: ");
            Yob = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập Gpa: ");
            Gpa = double.Parse(Console.ReadLine());
        }

        public override string? ToString() => $"{Id} | {Name} | {Yob} | {Gpa}";

        public void ShowProfile() => Console.WriteLine(ToString());

        internal static void Add(Student s)
        {
            throw new NotImplementedException();
        }
    }
}
