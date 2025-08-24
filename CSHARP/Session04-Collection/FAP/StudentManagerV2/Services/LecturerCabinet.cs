using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagerV2.Entities;

namespace StudentManagerV2.Services
{
    public class LecturerCabinet
    {
        private Lecturer[] _arr;
        private int _count = 0 ;

        public LecturerCabinet(int size) => _arr = new Lecturer[size];

        public void PrinLectures()
        {
            if(_count <= 0)
            {
                Console.WriteLine("the cabinet is emty. Nothing to print");
                return;
            }
            Console.WriteLine($"There is/are {_count} lectures in the list ");
            for (int i = 0; i < _count; i++)
            {
                _arr[i].ShowProfile();
            }
        }
        public void AddALecturer(Lecturer x) => _arr[_count++] = x;
        
        

    }
}
