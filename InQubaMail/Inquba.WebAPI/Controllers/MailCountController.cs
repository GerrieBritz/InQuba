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
    public class MailCountController : ApiController
    {
        // GET: api/MailCount/{param}
        public JsonResult Get(string locationname)
        {
            EmailContext context = new EmailContext();
            int? locationID = context.Locations.FirstOrDefault(x => x.LocationName == locationname).Id;
            if (locationID != null)
            {
                int emailCount = context.Emails.Count(x => x.locationId == locationID);
                return new JsonResult()
                {
                    Data = emailCount.ToString(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            return new JsonResult()
            {
                Data = "0",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        // POST: api/MailCount
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MailCount/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MailCount/5
        public void Delete(int id)
        {
        }
    }
}
