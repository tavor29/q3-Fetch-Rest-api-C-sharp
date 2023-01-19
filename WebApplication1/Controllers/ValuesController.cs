using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    
    public class ValuesController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        [Route("api/values")]
        public HttpResponseMessage Get()
        {
          DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("SerialNumber");
            dt.Rows.Add("Hp printer", 69);
            dt.Rows.Add("Hp shredder", 96);

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // GET api/values/logger
        [HttpGet]
        [Route("api/values/logger")]
        public int Get2()
        {
            int res = 100 ;
            logger.Error("Get me home 2");
            return res / 0;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
