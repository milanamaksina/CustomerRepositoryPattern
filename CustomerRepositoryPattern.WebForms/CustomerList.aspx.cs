using CustomerRepositoryPattern.Entities;
using CustomerRepositoryPattern.Interfaces;
using CustomerRepositoryPattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerRepositoryPattern.WebForms
{
    public partial class CustomerList : System.Web.UI.Page
    {
        private IRepository<Customer> _customerRepository;
        public List<Customer> Customers { get; set; }
        public CustomerList()
        {
            _customerRepository = new CustomerRepository();
        }
        public CustomerList(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Customers = _customerRepository.GetAll();
            if (!IsPostBack)
            {
                var customerId = Convert.ToInt32(Request.QueryString["customerId"]);
                _customerRepository.Delete(customerId);
            }

        }
    }
}