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
            Departmant departmant2 = manager.Find(x => x.ID == _object.ID);
            if (departmant2!=null)
            {
                departmant2.name = _object.name;
                departmant2.description = _object.description;
                manager.Update(_object);
                return Ok();
            }
            return BadRequest();
        }

        public IHttpActionResult DeleteProject(int id)
        {
            ServiceResult<Departmant> resultService = new ServiceResult<Departmant>();
            resultService = manager.DeleteBy(id);
            if (resultService.Errors.Count() > 0)
            {

                return BadRequest(resultService.Errors[0]);
            }

            return Ok(resultService.result);
        }
    }
}
