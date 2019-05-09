using StartProject.Entity;
using StartProject.Entity.ErrorModel;
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
            ServiceResult<Customer> serviceResult = customerManager.CustomerAdd(customer);
            if (serviceResult.Errors.Count > 0)
            {
                return BadRequest(serviceResult.Errors[0]);
            }

            return CreatedAtRoute("DefaultApi", new { id = customer.ID }, serviceResult.result);
        }

        public IHttpActionResult PutCustomer( Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Customer customer2=customerManager.Find(x => x.ID == customer.ID);
            customer2.name = customer.name;
            customer2.url = customer.url;
            customer2.email = customer.email;
            customer2.description = customer.description;
            customer2.competnent = customer.competnent;
            customer2.password = customer.password;
            
           
            customerManager.Update(customer2);

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
