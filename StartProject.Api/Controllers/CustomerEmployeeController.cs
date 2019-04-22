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
    public class CustomerEmployeeController : ApiController
    {
        private CustomerEmployeeManager manager = new CustomerEmployeeManager();

        public IHttpActionResult GetProject()
        {
            List<CustomerEmployee> _object = manager.List();

            if (_object.Count > 0)
            {
                return Ok(_object);
            }
            return NotFound();
        }

        public IHttpActionResult GetProject(int id)
        {
            CustomerEmployee _object = manager.Find(x => x.ID == id);
            if (_object != null)
            {
                return Ok(_object);
            }
            return NotFound();
        }

        public IHttpActionResult PostProject(CustomerEmployee _object)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            manager.Insert(_object);

            return CreatedAtRoute("DefaultApi", new { id = _object.ID }, _object);
        }

        public IHttpActionResult PutProject(CustomerEmployee _object)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            manager.Update(_object);

            return Ok();
        }

        public IHttpActionResult DeleteProject(int id)
        {
            CustomerEmployee _object = manager.Find(x => x.ID == id);
            if (_object == null)
            {
                return NotFound();
            }

            manager.Delete(_object);
            return Ok(_object);
        }
    }
}
