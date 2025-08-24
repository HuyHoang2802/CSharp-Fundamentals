using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buoi2_DataAccess.Models;

namespace Buoi2_Repositories
{
    public class UserREpo
    {
        Prn212DatabaseFirstContext context;
        public UserREpo()
        {
            context = new Prn212DatabaseFirstContext();

        }
        public List<UserAccount> ReadData()//trả về dữ liệu có trong bảng product 

        {
            return context.UserAccounts.ToList();
        }

        public void CreateData(UserAccount u)
        {
            context.UserAccounts.Add(u);
            context.SaveChanges();
        }

        //login lụm cái bảng trong db 
        public UserAccount GetUserByUsernameAndPassword(string username, string password)
        {
            return context.UserAccounts.FirstOrDefault(x => x.Username ==  username && x.Password == password);
        }

        
        
       
    }
}
