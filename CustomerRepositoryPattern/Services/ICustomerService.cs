
using CustomerRepositoryPattern.Entities;
using System.Collections.Generic;

namespace CustomerRepositoryPattern.Services
{
    public interface ICustomerService
    {
        Customer GetCustomer(int id);
        Customer Create(Customer customer);
        IReadOnlyCollection<Customer> GetCustomers();
        Customer Update(Customer customer);
        void Delete(int id);
        IReadOnlyCollection<Address> GetCustomerAddresses(int id);
    }
}
