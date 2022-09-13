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
    public partial class AddressDelete : System.Web.UI.Page
    {
        public IRepository<Address> _addressRepository;
        public AddressDelete()
        {
            _addressRepository = new AddressRepository();
        }
        public AddressDelete(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var addressIDReq = Convert.ToInt32(Request.QueryString["addressId"]);
            _addressRepository.Delete(addressIDReq);
            Response.Redirect("AddressesList.aspx");
        }
    }
}