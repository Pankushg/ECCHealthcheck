using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using ECCHealthcheck.Models;

namespace ECCHealthcheck.Controllers
{
    public class monitorController : ApiController
    {
        // GET: api/monitor
        public IEnumerable<monitorModel> Get()
        {
            SqlConnection myCon = new SqlConnection("");

            try
            {
                myCon.Open();
                SqlCommand myCmd = new SqlCommand("", myCon);
                
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            List<monitorModel> lmm = new List<monitorModel>();
            monitorModel mm = new monitorModel { tableName = "", errorCountToday = 1, errorCountYesterday = 2 };
            lmm.Add(mm);
            return lmm;
        }

        // GET: api/monitor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/monitor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/monitor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/monitor/5
        public void Delete(int id)
        {
        }
    }
}
