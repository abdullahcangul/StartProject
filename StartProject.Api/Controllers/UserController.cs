using StartProject.Entity;
using StartProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace StartProject.Api.Controllers
{
    public class UserController : ApiController
    {
        private UserManager userManager = new UserManager();

        public IHttpActionResult GetUsers()
        {
            List<User> users = userManager.List();
            if (users.Count > 0)
            {
                return Ok(userManager.List());
            }
            return NotFound();
        }

        public IHttpActionResult GetUser(int id)
        {
           User user= userManager.Find(x => x.ID == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userManager.Insert(user);

            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.ID)
            {
                return BadRequest();
            }
            
            userManager.Update(user);
            
            return Ok();
        }

        public IHttpActionResult DeleteUser(int id)
        {
            User user = userManager.Find(x=>x.ID==id);
            if (user == null)
            {
                return NotFound();
            }

            userManager.Delete(user);

            return Ok(user);
        }


    }
}
