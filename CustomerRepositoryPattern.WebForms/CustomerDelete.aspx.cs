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
    public partial class CustomerDelete : System.Web.UI.Page
    {
        public IRepository<Customer> _customerRepository;
        public CustomerDelete()
        {
            _customerRepository = new CustomerRepository();
        }
        public CustomerDelete(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var customerId = Convert.ToInt32(Request.QueryString["customerID"]);
            _customerRepository.Delete(customerId);
            Response.Redirect("CustomersList.aspx");
        }
    }
}