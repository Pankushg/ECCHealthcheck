using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ECCHealthcheck.Models;


namespace ECCHealthcheck.Controllers
{
    public class folderController : ApiController
    {
        // GET: api/folder
        public IEnumerable<folderModel> Get()
        {
            List<folderModel> ls = new List<folderModel>();
            string[] directories = Directory.GetDirectories(@"\\GA016VAA32\DataTrans\Inbound");
            foreach (string dir in directories) //getting all folders
            {
                folderModel foldMod = new folderModel();
                if (Directory.GetFiles(dir).Count() > 1)
                {
                    foldMod.name = dir.Substring(31);
                    foldMod.count = Directory.GetFiles(dir).Count();
                    ls.Add(foldMod);
                }
                else if (Directory.GetFiles(dir).Count() == 1 && !Directory.EnumerateFiles(dir).Any(af => af.Contains("Thumbs")))//&& !Directory.GetFiles(s,"Thumbs*.*"))
                {
                    foldMod.name = dir.Substring(31);
                    foldMod.count = Directory.GetFiles(dir).Count();
                    ls.Add(foldMod);
                }
            }
            return ls;
        }

        // GET: api/folder/5
        public string Get(int id)
        {
            if (id == 1)
                return "value";
            else
                return "val";
        }

        // POST: api/folder
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/folder/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/folder/5
        public void Delete(int id)
        {
        }
    }
}
