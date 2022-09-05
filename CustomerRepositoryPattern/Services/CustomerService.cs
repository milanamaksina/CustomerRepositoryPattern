using CustomerRepositoryPattern.Entities;
using CustomerRepositoryPattern.Interfaces;
using CustomerRepositoryPattern.Repositories;
using System;
using System.Collections.Generic;

namespace CustomerRepositoryPattern.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Address> _addressRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
            _addressRepository = new AddressRepository();
        }

        public CustomerService(IRepository<Customer> customerRepository, IRepository<Address> addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository ?? new AddressRepository();
        }

        public Customer Create(Customer customer)
        {
            _customerRepository.Create(customer);

            return customer;
        }


        public Customer GetCustomer(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            Customer customer;
            int tries = 0;

            while (true)
            {
                try
                {
                    customer = _customerRepository.Read(id);
                    break;
                }
                catch (TimeoutException e)
                {
                    tries++;

                    if (tries > 3)
                    {
                        throw e;
                    }
                }
            }

            if (customer == null)
                throw new KeyNotFoundException();

            return customer;
        }

        public IReadOnlyCollection<Customer> GetCustomers()
        {
            var customers = _customerRepository.GetAll();

            return customers.ToArray();
        }

        public Customer Update(Customer customer)
        {
            _customerRepository.Update(customer);

            return customer;
        }

        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }

        public IReadOnlyCollection<Address> GetCustomerAddresses(int id)
        {
            var addresses = _addressRepository.GetCustomerAddresses(id);
            return addresses;
        }

    }
}
