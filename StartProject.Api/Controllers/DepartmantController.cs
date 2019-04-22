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
    public class DepartmantController : ApiController
    {
        private DepartmantManager manager = new DepartmantManager();

        public IHttpActionResult GetProject()
        {
            List<Departmant> _object = manager.List();

            if (_object.Count > 0)
            {
                return Ok(_object);
            }
            return NotFound();
        }

        public IHttpActionResult GetProject(int id)
        {
            Departmant _object = manager.Find(x => x.ID == id);
            if (_object != null)
            {
                return Ok(_object);
            }
            return NotFound();
        }

        public IHttpActionResult PostProject(Departmant _object)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            manager.Insert(_object);

            return CreatedAtRoute("DefaultApi", new { id = _object.ID }, _object);
        }

        public IHttpActionResult PutProject(Departmant _object)
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
            Departmant _object = manager.Find(x => x.ID == id);
            if (_object == null)
            {
                return NotFound();
            }

            manager.Delete(_object);
            return Ok(_object);
        }
    }
}
