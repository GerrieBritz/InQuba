using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Inquba.Databases;
using Inquba.Databases.Models;

namespace Inquba.WebAPI.Controllers
{
    public class MailController : ApiController
    {
        // GET: api/Mail
        public JsonResult Get()
        {
            EmailContext context = new EmailContext();
            Email mail = new Email();

            context.Emails.Add(mail);
            context.SaveChanges();

            return new JsonResult();
        }

        // GET: api/Mail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mail
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mail/5
        public void Delete(int id)
        {
        }
    }
}
