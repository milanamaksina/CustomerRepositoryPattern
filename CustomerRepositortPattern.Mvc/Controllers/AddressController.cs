using CustomerRepositoryPattern.Entities;
using CustomerRepositoryPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerRepositortPattern.Mvc.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly ICustomerService _customerService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public AddressController()
        {
            _addressService = new AddressService();
            _customerService = new CustomerService();   
        }

        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(int customerId, Address address)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    ViewBag.ErrorMessage = "Invalid value";
                    return View();
                }
                _addressService.Create(address);

                return RedirectToAction("Details", "Customer", new { id = customerId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult TheBad()
        {
            var model = _customerService.GetCustomers();
            ViewData["Customers"] = from customer in _customerService.GetCustomers()
                                    select new SelectListItem { Text = customer.LastName, Value = customer.CustomerId.ToString() };
            return View(model);
        }

        // GET: Address/Edit/5
        public ActionResult EditAddress(int id)
        {
            return View();
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult EditAddress(int id, int? customerId, Address address)
        {
            try
            {
                address.AddressId = id;
                if (!this.ModelState.IsValid)
                {
                    ViewBag.ErrorMessage = "Enter valid values!";
                    return View(address);
                }
                _addressService.Update(address);

                return RedirectToAction("Details", "Customer", new { id = customerId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult DeleteAddress(int id)
        {
            return View();
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult DeleteAddress(int id, int? customerId)
        {
            try
            {
                _addressService.Delete(id);

                if (customerId.HasValue)
                {
                    return RedirectToAction("Details", "Customer", new { id = customerId });
                }
                else return View(); ;
            }
            catch
            {
                return View();
            }
        }
    }
}
