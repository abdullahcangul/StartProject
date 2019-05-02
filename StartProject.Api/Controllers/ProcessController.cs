﻿using StartProject.Entity;
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
        //Projenin processlerini döner
        [Route("api/process/projects/{id}")]
        public IHttpActionResult GetProcessOfProject(int id)
        {
            List<Process> process = processManager.List(x => x.ProjectID == id);
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

        public IHttpActionResult PutProcess( Process process)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Process process1 = processManager.Find(x => x.ID == process.ID);
            process1.priority = process.priority;
            process1.status = process.status;
            process1.projectedFinishDate = process.projectedFinishDate;
            
            processManager.Update(process1);

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
