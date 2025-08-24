using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repository.DTO;

namespace Repository.Helper
{
    public  class TransferModelsDTO
    {
        public static CustomerDTO MappCustomerDTO(Customer cus)
        {
            CustomerDTO customerDTO = new CustomerDTO();
            customerDTO.CustomerId = cus.CustomerId;
            customerDTO.CustomerFullName = cus.CustomerFullName;
            customerDTO.CustomerBirthday = cus.CustomerBirthday;
            customerDTO.EmailAddress = cus.EmailAddress;
            customerDTO.Telephone = cus.Telephone;
            customerDTO.CustomerStatus = cus.CustomerStatus;
            customerDTO.Password = cus.Password;
            return customerDTO;
        }

        public static Customer MappCustomer(CustomerDTO customerDTO)
        {
            Customer customer = new Customer();
            customer.CustomerId = customerDTO.CustomerId;
            customer.CustomerFullName = customerDTO.CustomerFullName;
            customer.CustomerBirthday= customerDTO.CustomerBirthday; 
            customer.EmailAddress = customerDTO.EmailAddress;
            customer.Telephone = customerDTO.Telephone;
            customer.CustomerStatus = customerDTO.CustomerStatus; 
            customer.Password = customerDTO.Password;
            return customer;


        }
    }
}
