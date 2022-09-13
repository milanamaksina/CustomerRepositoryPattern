using CustomerRepositoryPattern.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerRepositoryPattern.Tests.Mvc.Tests
{
    [TestClass]
    public class CustomerController
    {
        [TestMethod]
        public void ShouldCreateCustomerController()
        {
            var customerService = new CustomerService();
            Assert.IsNotNull(customerService);
        }
    }
}
