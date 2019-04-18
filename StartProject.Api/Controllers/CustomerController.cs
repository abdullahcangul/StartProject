using StartProject.Entity;
using StartProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StartProject.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private CustomerManager customerManager = new CustomerManager();

        public IHttpActionResult GetCustomers()
        {
            List<Customer> customers = customerManager.List();

            if (customers.Count>0)
            {
                return Ok(customers);
            }
            return NotFound();
        }

        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = customerManager.Find(x => x.ID == id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound();
        }

        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            customerManager.Insert(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.ID }, customer);
        }

        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.ID)
            {
                return BadRequest();
            }

            customerManager.Update(customer);

            return Ok();
        }

        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = customerManager.Find(x => x.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            customerManager.Delete(customer);
            return Ok(customer);
        }

    }
}
