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
    public class ProcessController : ApiController
    {
        private ProcessManager processManager = new ProcessManager();

        public IHttpActionResult GetProcesses()
        {
            List<Process> process = processManager.List();

            if (process.Count > 0)
            {
                return Ok(process);
            }
            return NotFound();
        }

        public IHttpActionResult GetProcess(int id)
        {
            Process process = processManager.Find(x => x.ID == id);
            if (process != null)
            {
                return Ok(process);
            }
            return NotFound();
        }

        public IHttpActionResult PostProcess(Process process)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            processManager.Insert(process);

            return CreatedAtRoute("DefaultApi", new { id = process.ID }, process);
        }

        public IHttpActionResult PutProcess(int id, Process process)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != process.ID)
            {
                return BadRequest();
            }

            processManager.Update(process);

            return Ok();
        }

        public IHttpActionResult DeleteProcess(int id)
        {
            Process process = processManager.Find(x => x.ID == id);
            if (process == null)
            {
                return NotFound();
            }

            processManager.Delete(process);
            return Ok(process);
        }
    }
}
