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
    public partial class AddressList : System.Web.UI.Page
    {
        private readonly IRepository<Address> _addressRepository;
        public List<Address> Addresses { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAddressesFromDatabase();
        }
        public AddressList()
        {
            _addressRepository = new AddressRepository();
        }
        public AddressList(IRepository<Address> addressesRepository)
        {
            _addressRepository = addressesRepository;
        }
        public void LoadAddressesFromDatabase()
        {
            Addresses = _addressRepository.GetAll();
        }
    }
}