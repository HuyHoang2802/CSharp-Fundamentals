using DataAccess;
using DataAccess.Models;
using Repository.DTO;

namespace Repository
{
    public class AccountRepo
    {
        StudentManagementContext _context;

        public AccountRepo()
        {
            _context = new StudentManagementContext();
        }
        //CRUD
        public AccountDTO GetAccount(string username, string password) { 
            AccountDTO account = new AccountDTO();
            var finded = _context.Accounts.FirstOrDefault(a => a.Username.Equals(username) && a.Password == password);
            if (finded != null)
            {
             
                account.Username = finded.Username;
                account.RoleId = finded.RoleId;
            }
            return account;
        }
    }
}
