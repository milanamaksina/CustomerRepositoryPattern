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
    public partial class CustomerEdit : System.Web.UI.Page
    {
        public IRepository<Customer> _customerRepository;
        public CustomerEdit()
        {
            _customerRepository = new CustomerRepository();
        }
        public CustomerEdit(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var customerIDReq = Convert.ToInt32(Request["СustomerId"]);
                if (customerIDReq != 0)
                {
                    var customer = _customerRepository.Read(customerIDReq);
                    firstNameTextBox.Text = customer.FirstName;
                    lastNameTextBox.Text = customer.LastName;
                    phoneNumberTextBox.Text = customer.PhoneNumber;
                    emailTextBox.Text = customer.Email;
                    notesTextBox.Text = customer.Notes;
                    amountTextBox.Text = customer.TotalPurchasesAmount.ToString();
                }
            }
        }

        public void EditButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                FirstName = firstNameTextBox?.Text,
                LastName = lastNameTextBox?.Text,
                PhoneNumber = phoneNumberTextBox?.Text,
                Email = emailTextBox?.Text,
                Notes = notesTextBox?.Text,
                TotalPurchasesAmount = Convert.ToDecimal(amountTextBox?.Text)
            };
            if (Convert.ToInt32(Request.QueryString["СustomerId"]) == 0)
            {
                _customerRepository.Create(customer);
            }
            else
            {
                _customerRepository.Update(customer);
            }
            HttpContext.Current.Response.Redirect("CustomersList.aspx");
        }
    }
}