using CustomerRepositortPattern.Mvc.Controllers;
using CustomerRepositoryPattern.Entities;
using CustomerRepositoryPattern.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PagedList;
using System.Web.Mvc;

namespace CustomerRepositoryPattern.Mvc.Test
{
    [TestClass]
    public class ControllersTests
    {
        [TestMethod]
        public void ShouldCreateCustomerController()
        {
            var customerController = new CustomerController();
            Assert.IsNotNull(customerController);
        }

        [TestMethod]
        public void ShouldBeAbleToCreateAddressesController()
        {
            var controller = new AddressController();
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void ShouldAddNewCustomer()
        {
            var customersController = new CustomerController();
            var result = customersController.Create(new Customer()
            {
                FirstName = "Anton",
                LastName = "Shukin",
                Email = "anton@gmail.com",
                PhoneNumber = "+161232345432",
                Notes = "120",
                TotalPurchasesAmount = 100
            }) as RedirectToRouteResult;

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ShouldBeAbleToCreateAddress()
        {
            var addressServiceMock = new Mock<IAddressService>();
            var addressesController = new AddressController(addressServiceMock.Object);
            addressesController.Create();
            var address = new Address()
            {
                CustomerId = 2409,
                AddressLine = "Pearl Street ",
                AddressLine2 = "50/2",
                AddressType = "Shipping",
                City = "Oslo",
                PostalCode = "12345",
                State = "State",
                Country = "Canada"
            };
            addressesController.Create(2409, address);

            addressServiceMock.Verify(x => x.Create(address));
        }

        [TestMethod]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerControllerMock = new Mock<ICustomerService>();
            var customersController = new CustomerController(customerControllerMock.Object);
            Customer customer = new Customer();
            var result = customersController.Delete(2414, customer) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            customerControllerMock.Verify(x => x.Delete(2414));
        }

        [TestMethod]
        public void ShouldBeAbleToDeleteAddress()
        {
            var addressServiceMock = new Mock<IAddressService>();
            var addressesController = new AddressController(addressServiceMock.Object);

            addressesController.DeleteAddress(2382, 2409);
            var result = addressesController.DeleteAddress(2382, 2409) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            addressServiceMock.Verify(x => x.Delete(2382));
        }

        [TestMethod]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var customerControllerMock = new Mock<ICustomerService>();
            var customersController = new CustomerController(customerControllerMock.Object);
            var result = customersController.Edit(2410, new Customer()
            {
               CustomerId = 2410, 
               FirstName = "Anton", 
               LastName = "Test", 
               Email = "anton@mail.com", 
               PhoneNumber = "+161789234512",
               Notes = "note1", 
               TotalPurchasesAmount = 100
            });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToUpdateAddress()
        {
            var addressServiceMock = new Mock<IAddressService>();
            var addressesController = new AddressController(addressServiceMock.Object);

            var address = new Address()
            {
                CustomerId = 2409,
                AddressLine = "South street",
                AddressLine2 = "20-23",
                AddressType = "Shipping",
                City = "LosAngeles",
                PostalCode = "12341",
                State = "State",
                Country = "United States"
            };
            addressesController.EditAddress(2382);

            var result = addressesController.EditAddress(2382, 2409, address) as RedirectToRouteResult;
            Assert.IsNotNull(result);
        }
    }
}