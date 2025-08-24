using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buoi2_DataAccess.Models;
using Buoi2_Repositories;

namespace Buoi2_Service
{
    public class LoginServices
    {
        UserREpo _repo;
        public LoginServices() { 
            _repo = new UserREpo();
        }
        public UserAccount Login (string username, string password)
        {
            //Nếu như user null => return null
            //Nếu password null => return null
            if (username ==null || password == null)
            {
                return null;
            }
           UserAccount acc =  _repo.GetUserByUsernameAndPassword(username, password);
            return acc;
        }

    }

  
}
