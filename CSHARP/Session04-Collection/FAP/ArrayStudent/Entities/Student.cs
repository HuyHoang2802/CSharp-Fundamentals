using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ArrayStudent.Entities
{
    public class Student
    {   
        public string Id { get; set; }
        public string Name { get; set; }
        public int Yob { get; set; }
        public double Gpa { get; set; }

        public override string ToString() => $"{Id} || {Name} || {Yob} || {Gpa}";

        public void ShowProfle ()
        {
            Console.WriteLine(ToString());
        }

        //New và gán property cùng lúc => object inittializer

    }
}
