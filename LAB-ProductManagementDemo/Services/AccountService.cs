using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo iAcountRepo;

        public AccountService()
        {
            iAcountRepo = new AccountRepo();
        }
        public AccountMember GetAccountById(string accountId)
        {
            return iAcountRepo.GetAccountById(accountId);
        }
    }
}
