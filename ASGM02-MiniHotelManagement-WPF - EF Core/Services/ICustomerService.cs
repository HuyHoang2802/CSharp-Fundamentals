using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        List<Customer> SearchCustomer(string name);
        Customer GetCustomerById(int id);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);

        Customer? AuthenticateCustomers(string email, string password);
    }
}
