using CustomerRepositoryPattern.Entities;
using CustomerRepositoryPattern.Interfaces;
using CustomerRepositoryPattern.Repositories;
using System;
using System.Collections.Generic;

namespace CustomerRepositoryPattern.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;

        public AddressService()
        {
            _addressRepository = new AddressRepository();
        }

        public AddressService(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Address Create(Address address)
        {
            _addressRepository.Create(address);
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _addressRepository.Delete(id);
            throw new NotImplementedException();
        }

        public Address GetAddress(int id)
        {
            _addressRepository.Read(id);
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Address> GetCustomerAddresses(int id)
        {
           var addresses = _addressRepository.GetCustomerAddresses(id);

           return addresses.ToArray();
        }

        public Address Update(Address address)
        {
            _addressRepository.Update(address);
            throw new NotImplementedException();
        }
    }
}
