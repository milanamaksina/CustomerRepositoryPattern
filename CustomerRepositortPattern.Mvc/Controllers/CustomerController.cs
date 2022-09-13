using CustomerRepositoryPattern.Entities;
using CustomerRepositoryPattern.Repositories;
using CustomerRepositoryPattern.Services;
using PagedList;
using System;
using System.Dynamic;
using System.Web.Mvc;
using System.Web.Mvc;


namespace CustomerRepositortPattern.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addressService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        public CustomerController()
        {
            _customerService = new CustomerService();
            _addressService = new AddressService();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _customerService.GetCustomers();
            return View(customers);
        }


        // GET: Customer/Details/5
        public ActionResult GetCustomerById(int id)
        {
            var addresses = _customerService.GetCustomerAddresses(id);
            return View(addresses);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var addresses = _customerService.GetCustomerAddresses(id);
            if (addresses == null) return View("Empty");
            return View(addresses);
        }


        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _customerService.Create(customer);
                return (RedirectToAction("Index"));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                _customerService.Update(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                _customerService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
