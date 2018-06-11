using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ECCHealthcheck.Models;

namespace ECCHealthcheck.Controllers
{
    public class taskController : ApiController
    {
        // GET: api/task
        public IEnumerable<tasksModel> Get()
        {
            List<tasksModel> tasksList = new List<tasksModel>();

            tasksModel foldChck = new tasksModel { id = 101, name = "Folder Checking"};
            tasksModel archvJbChck = new tasksModel { id = 102, name = "Check Archival Job"};
            tasksModel errBtch = new tasksModel { id = 103, name = "Monitoring Error Batches" };
            tasksModel urlChck = new tasksModel { id = 104, name = "URL Working/Not Working" };
            tasksModel dbJobChck = new tasksModel { id = 105, name = "Checking DB jobs" };

            tasksList.Add(foldChck);
            tasksList.Add(archvJbChck);
            tasksList.Add(errBtch);
            tasksList.Add(urlChck);
            tasksList.Add(dbJobChck);

            return tasksList;
        }

        // GET: api/task/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/task
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/task/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/task/5
        public void Delete(int id)
        {
        }
    }
}
