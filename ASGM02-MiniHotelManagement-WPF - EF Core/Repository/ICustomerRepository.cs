using BusinessObject;
using DataAcesssLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICustomerRepository
    {
        Customer? GetCustomerByEmail(string email);
        List<Customer> GetAllCustomers();
        List<Customer> SearchCustomerByName(string name);
        bool AddCustomer(Customer customer);
        bool DeleteCustomer(int id);
        bool UpdateCustomer(Customer customer);
    }
}
