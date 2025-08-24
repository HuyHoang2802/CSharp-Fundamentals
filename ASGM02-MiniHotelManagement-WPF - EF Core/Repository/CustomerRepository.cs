using BusinessObject;
using DataAcesssLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool AddCustomer(Customer customer)
        {
            using var _context = new FuminiHotelManagementContext();

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return true; // Assuming the operation is always successful
        }

        public bool DeleteCustomer(int id)
        {
            using var _context = new FuminiHotelManagementContext();
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                if(customer.CustomerStatus== 1)
                {
                    customer.CustomerStatus = 0;
                }
                else
                {
                    _context.Customers.Remove(customer);
                }
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Customer> GetAllCustomers()
        {
            using var _context = new FuminiHotelManagementContext();
            return _context.Customers.ToList();
        }

        public Customer? GetCustomerByEmail(string email)
        {
            using var _context = new FuminiHotelManagementContext();
            return _context.Customers.FirstOrDefault(c => c.EmailAddress == email);
        }

        public List<Customer> SearchCustomerByName(string name)
        {
            using var _context = new FuminiHotelManagementContext();
            return _context.Customers.Where(c => c.CustomerFullName.Contains(name)).ToList();
        }

        public bool UpdateCustomer(Customer customer)
        {
            using var _context = new FuminiHotelManagementContext();

            var existingCustomer = _context.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (existingCustomer == null)
            {
                return false; // Customer not found
            }

            existingCustomer.CustomerFullName = customer.CustomerFullName;
            existingCustomer.Telephone = customer.Telephone;
            existingCustomer.EmailAddress = customer.EmailAddress;
            existingCustomer.CustomerBirthday = customer.CustomerBirthday;
            existingCustomer.Password = customer.Password;
            existingCustomer.CustomerStatus = customer.CustomerStatus;

            _context.SaveChanges();
            return true;
        }
    }
}
