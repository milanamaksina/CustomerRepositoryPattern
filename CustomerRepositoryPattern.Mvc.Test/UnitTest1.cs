using CustomerRepositortPattern.Mvc.Controllers;
using CustomerRepositoryPattern.Entities;
using CustomerRepositoryPattern.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagedList;
using System.Web.Mvc;

namespace CustomerRepositoryPattern.Mvc.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldCreateCustomerController()
        {
            var customerController = new CustomerController();
            Assert.IsNotNull(customerController);
        }


    }
}