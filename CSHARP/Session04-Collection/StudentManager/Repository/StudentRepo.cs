using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Repository.DTO;

namespace Repository
{
    public class StudentRepo
    {
        StudentManagementContext _context;
        public StudentRepo()
        {
            _context = new StudentManagementContext();
        }
        public List<StudentDTO> GetAll()
        {
           List<StudentDTO> res = new List<StudentDTO>();
            var  liststudent = new List<StudentDTO>();
            liststudent.ForEach(student =>
            {
                StudentDTO studentDTO = new StudentDTO();
                studentDTO.Mssv = student.Mssv;
                studentDTO.Fullname = student.Fullname;
                studentDTO.Major = student.Major;
                studentDTO.Dob = student.Dob;
                res.Add(studentDTO);

            });
            return res;
            
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void Update(Student studentUpdate)
        {
            _context.Students.Update(studentUpdate);
            _context.SaveChanges();
        }
        public void Delete(Student studentRemove)
        {
            _context.Students.Remove(studentRemove);
            _context.SaveChanges();
        }
        public List<StudentDTO> Search(int mssv, string name)
        {
            
        } 

    }

}
