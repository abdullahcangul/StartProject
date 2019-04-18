
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
    
    public class ProjectController :ApiController
    {
        private ProjectManager projectManager = new ProjectManager();

        public IHttpActionResult GetProject()
        {
            List<Project> project = projectManager.List();

            if (project.Count > 0)
            {
                return Ok(project);
            }
            return NotFound();
        }

        public IHttpActionResult GetProject(int id)
        {
            Project project = projectManager.Find(x => x.ID == id);
            if (project != null)
            {
                return Ok(project);
            }
            return NotFound();
        }

        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            projectManager.Insert(project);

            return CreatedAtRoute("DefaultApi", new { id = project.ID }, project);
        }

        public IHttpActionResult PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.ID)
            {
                return BadRequest();
            }

            projectManager.Update(project);

            return Ok();
        }

        public IHttpActionResult DeleteProject(int id)
        {
            Project project = projectManager.Find(x => x.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            projectManager.Delete(project);
            return Ok(project);
        }
    }
}
