using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Inquba.Databases;
using Inquba.Databases.Models;
using System.Text;

namespace Inquba.WebAPI.Controllers
{
    //Suppose this was intended for Microservices
    public class MailController : ApiController
    {
        // GET: api/Mail
        public JsonResult Get()
        {
            EmailContext context = new EmailContext();
            return new JsonResult()
            {
                Data = context.Emails,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

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
