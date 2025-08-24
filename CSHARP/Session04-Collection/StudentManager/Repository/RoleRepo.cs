using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repository
{
    public class RoleRepo
    {
        StudentManagementContext _context;
        public RoleRepo()
        {
            _context = new StudentManagementContext();
        }
        public string GetNameRole(int roleId)
        {
            var res = _context.Roles.FirstOrDefault(r => r.Id == roleId);
            return res.NameRole;
        }

    }
}
