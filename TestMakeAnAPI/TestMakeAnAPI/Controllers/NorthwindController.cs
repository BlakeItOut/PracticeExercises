using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestMakeAnAPI.Models;

namespace TestMakeAnAPI.Controllers
{
    public class NorthwindController : ApiController
    {
        private NorthwindEntities ORM = new NorthwindEntities();
        
        //GET all customers
        [HttpGet]
        public List<Customer> GetCustomers() => ORM.Customers.ToList();

        //GET subset customers by city
        [HttpGet]
        public List<Customer> GetCustomerByCity(string city) => ORM.Customers.Where(c => c.City == city).ToList();

        //GET subset customers by country
        [HttpGet]
        public List<Customer> GetCustomerByCountry(string country) => ORM.Customers.Where(c => c.Country == country).ToList();

        //PUT companyName
        [HttpPut]
        public void PutContactName (string id, string companyName)
        {
            var customer = ORM.Customers.Find(id);
            customer.CompanyName = companyName;
            ORM.Entry(customer).State = EntityState.Modified;
            ORM.SaveChanges();
        }

        //POST new customer
        [HttpPost]
        public void PostCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                ORM.Customers.Add(customer);
                ORM.SaveChanges();
            }    
        }

        //DELETE customer
        public void DeleteCustomer(string id) => ORM.Customers.Remove(ORM.Customers.Find(id));

    }
}
