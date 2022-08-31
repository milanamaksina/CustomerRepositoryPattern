using CustomerRepositoryPattern.Entities;
using CustomerRepositoryPattern.Repositories;
using System.Web.Mvc;

namespace CustomerRepositortPattern.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _customerRepository.GetAll();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult GetCustomerById(int id)
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _customerRepository.Create(customer);
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
               _customerRepository.Update(customer);
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
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
