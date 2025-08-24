using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class StudentDTO
    {
        public string Mssv { get; set; } = null!;

        public string Fullname { get; set; } = null!;

        public DateTime Dob { get; set; }

        public string Major { get; set; } = null!;
    }
}
