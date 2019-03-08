using Inquba.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Inquba.WebAPI.Controllers
{
    //Suppose this was intended for Microservices
    public class MailPerLocationController : ApiController
    {
        // GET: api/MailPerLocation/{param}
        public JsonResult Get(string locationname, string args)
        {
            EmailContext context = new EmailContext();
            int? locationID = context.Locations.FirstOrDefault(x => x.LocationName == locationname).Id;
            if (locationID != null)
            {
                var emails = context.Emails.Where(x => x.locationId == locationID);
                return new JsonResult()
                {
                    Data = emails,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
                return new JsonResult()
                {
                    Data = null,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
        }

        // POST: api/MailPerLocation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MailPerLocation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MailPerLocation/5
        public void Delete(int id)
        {
        }
    }
}
