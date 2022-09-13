
using CustomerRepositoryPattern.Entities;
using System.Collections.Generic;

namespace CustomerRepositoryPattern.Services
{
    public interface IAddressService
    {
        Address GetAddress(int id);
        Address Create(Address address);
        IReadOnlyCollection<Address> GetCustomerAddresses(int id);
        Address Update(Address address);
        void Delete(int id);
        IReadOnlyCollection<Address> GetAll();
    }
}
