using BusinessObject;
using Microsoft.VisualBasic;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }
        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public bool DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }

        public List<Customer> GetAllCustomers()
        {
            
            return _customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer? AuthenticateCustomers(string email, string password)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Email and password cannot be null or empty.");
            }
           
            var customer = _customerRepository.GetCustomerByEmail(email);
            if (customer == null || customer.Password != password)
            {
                return null;
            }
            return customer;
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }

        public List<Customer> SearchCustomer(string name)
        {
            return _customerRepository.SearchCustomerByName(name);
        }
    }
}
