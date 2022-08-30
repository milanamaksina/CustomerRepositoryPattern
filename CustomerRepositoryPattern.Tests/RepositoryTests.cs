using CustomerRepositoryPattern.Entities;
using CustomerRepositoryPattern.Repositories;
using Xunit;

namespace CustomerRepositoryPattern.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateRepository()
        {
            var addressRepository = new AddressRepository();
            Assert.NotNull(addressRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var addressRepository = new AddressRepository();
            addressRepository.DeleteAll();

            var address = CreateMockAddress();
        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            var addressRepository = new AddressRepository();
            addressRepository.DeleteAll();
            var address = CreateMockAddress();
            int adressId = addressRepository.Create(address);
            var createdAddress = addressRepository.Read(adressId);

            Assert.NotNull(createdAddress);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var addressRepository = new AddressRepository();
            addressRepository.DeleteAll();

            var address = CreateMockAddress();

            int addressId = addressRepository.Create(address);

            address.City = "Moscow";
            addressRepository.Update(address);

            var createdAddress = addressRepository.Read(addressId);

            Assert.NotNull(createdAddress);
            Assert.Equal("Moscow", address.City);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var addressRepository = new AddressRepository();
            var address = CreateMockAddress();

            int addressId = addressRepository.Create(address);

            var createdAddress = addressRepository.Read(addressId);
            Assert.NotNull(createdAddress);

            addressRepository.Delete(addressId);
            var deletedAddress = addressRepository.Read(addressId);
            Assert.Null(deletedAddress);
        }

        private Address CreateMockAddress()
        {
            var address = new Address();
            address.CustomerId = 78;
            address.AddressLine = "Street 1";
            address.AddressLine2 = "House 3";
            address.AddressType = "Billing";
            address.City = "Los Angeles";
            address.PostalCode = "303000";
            address.State = "LA";
            address.Country = "Canada";

            return address;
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var customerRepository = new CustomerRepository();
            Assert.NotNull(customerRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customerRepository = new CustomerRepository();
            var customer = CreateMockCustomer();

            customerRepository.Create(customer);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var customerRepository = new CustomerRepository();
            var addressRepository = new AddressRepository();
            addressRepository.DeleteAll();
            customerRepository.DeleteAll();

            var customer = CreateMockCustomer();

            int customerId = customerRepository.Create(customer);

            var createdCustomer = customerRepository.Read(customerId);

            Assert.NotNull(createdCustomer);
            Assert.Equal(customer.FirstName, createdCustomer.FirstName);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var customerRepository = new CustomerRepository();
            var customer = CreateMockCustomer();

            int customerId = customerRepository.Create(customer);
            customer.FirstName = "Ivan";
            customerRepository.Update(customer);

            var createdCustomer = customerRepository.Read(customerId);

            Assert.NotNull(createdCustomer);
            Assert.Equal("Ivan", customer.FirstName);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerRepository = new CustomerRepository();
            var customer = CreateMockCustomer();

            int customerId = customerRepository.Create(customer);

            var createdCustomer = customerRepository.Read(customerId);
            Assert.NotNull(createdCustomer);

            customerRepository.Delete(customerId);
            var deletedCustomer = customerRepository.Read(customerId);
            Assert.Null(deletedCustomer);
        }





        private Customer CreateMockCustomer()
        {
            var customer = new Customer();
            customer.FirstName = "Evgeniy";
            customer.LastName = "Grishin";
            customer.PhoneNumber = "89993425453";
            customer.Email = "grishin@mail.com";
            customer.Notes = "Note1";
            customer.TotalPurchasesAmount = 100;

            return customer;
        }
    }
}