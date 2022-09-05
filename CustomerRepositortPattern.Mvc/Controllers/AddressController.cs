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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Address address)
        {
            try
            {
                _addressService.Update(address);

                return RedirectToAction("Index", "Customer");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
               _addressService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
