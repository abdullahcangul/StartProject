
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

        public IHttpActionResult PutProject( Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           Project project2=projectManager.Find(x => x.ID == project.ID);

            if (project2 != null)
            {
                project2.name = project.name;
                project2.description = project.description;
                projectManager.Update(project2);
                return Ok();
            }

            return BadRequest();
            
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
