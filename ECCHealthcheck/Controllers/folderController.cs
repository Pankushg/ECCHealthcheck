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
        public List<string> Get()
        {
            folderModel fm = new folderModel();
            List<string> ls = new List<string>();
            string[] directories = Directory.GetDirectories(@"\\GA016VK001\DataTrans\Inbound\");
            foreach (string s in directories) //getting all folders
            {
                string[] f = Directory.GetFiles(s);
                if (Directory.GetFiles(s).Count() > 1)
                {
                    ls.Add(s.Substring(31));
                }
                else if (Directory.GetFiles(s).Count() == 1 && !Directory.EnumerateFiles(s).Any(af => af.Contains("Thumbs")))//&& !Directory.GetFiles(s,"Thumbs*.*"))
                {
                    ls.Add(s.Substring(31));
                }
            }
            
            

            //Console.WriteLine("--------------------------");

            //Console.WriteLine("Checking for GA016KVA027 : \n");

            //foreach (string s in Directory.GetDirectories(@"\\GA016KVA027\Inbound\"))
            //{
            //    string[] fileEntries = Directory.GetFiles(s);
            //    foreach (string g in fileEntries)
            //    {
            //        if (fileEntries.Count() > 1 || (fileEntries.Count() == 1 && !g.Contains("Thumbs.db")))
            //        {
            //            Console.WriteLine(s + "_____Count : " + fileEntries.Count());
            //            count = 2;
            //            break;
            //        }
            //    }
            //}
            //if (count != 2)
            //{
            //    Console.WriteLine("NO FILES PRESENT \n");
            //}
            //Console.WriteLine("\n_______________________________________________________________________");
            //Console.WriteLine("````````````````````````````````````````````````````````````````````````");
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
