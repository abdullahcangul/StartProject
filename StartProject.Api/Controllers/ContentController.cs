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
    public class ContentController : ApiController
    {
        private ContentManager manager = new ContentManager();
      
        public  IHttpActionResult Get()
        {
            List<Content> _object = manager.List();

            if (_object.Count > 0)
            {
                return Ok(_object);
            }
            return NotFound();
        }

        public IHttpActionResult Get(int id)
        {
            Content _object = manager.Find(x => x.ID == id);
            if (_object != null)
            {
                return Ok(_object);
            }
            return NotFound();
        }
        //process in contentlerini döner
        [Route("api/content/process/{id}")]
        public IHttpActionResult GetContentProject(int id)
        {
           List<Content> _object = manager.List(x => x.ProcessID == id);
            if (_object != null)
            {
                return Ok(_object);
            }
            return NotFound();
        }

        public IHttpActionResult PostProject(Content _object)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            manager.Insert(_object);

            return CreatedAtRoute("DefaultApi", new { id = _object.ID }, _object);
        }

        public IHttpActionResult PutProject(Content _object)
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
            Content _object = manager.Find(x => x.ID == id);
            if (_object == null)
            {
                return NotFound();
            }

            manager.Delete(_object);
            return Ok(_object);
        }
    }
}
