using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ECCHealthcheck.Models;
using System.Data.SqlClient;

namespace ECCHealthcheck.Controllers
{
    public class archvJobController : ApiController
    {
        // GET: api/archvJob
        public IEnumerable<archvJbModel> Get()
        {
            List<archvDbModel> myArchvDbImpList = new List<archvDbModel>();
            List<archvDbModel> myArchvDbXpList = new List<archvDbModel>();
            List<archvDbModel> myArchvDbList = new List<archvDbModel>();

            SqlConnection myMasterCon = new SqlConnection("Server=GA016VSQL0E7 ;Database = Master ; User Id = uzpisq1 ; password = imgwrite");
            try
            {
                myMasterCon.Open();
                SqlCommand myCmdXp = new SqlCommand("select COUNT(*),ARCHV_DTTM from[ECCXport_Data_Hst].[dbo].[T_BAT] where ARCHV_DTTM > DATEADD(d, -5, getdate()) group by ARCHV_DTTM order by ARCHV_DTTM desc", myMasterCon);
                SqlCommand myCmdImp = new SqlCommand("select COUNT(*),ARCHV_DTTM from[ECCImport_Data_HST].[dbo].[T_BAT] where ARCHV_DTTM > DATEADD(d, -4, getdate()) group by ARCHV_DTTM order by ARCHV_DTTM desc", myMasterCon);

                SqlDataReader myReadImp = myCmdImp.ExecuteReader();

                while (myReadImp.Read())
                {
                    archvDbModel myArchvDbModel = new archvDbModel();
                    myArchvDbModel.importDb.archvDttm = myReadImp.GetDateTime(1);
                    myArchvDbModel.importDb.archvCnt = myReadImp.GetInt32(0);
                    myArchvDbList.Add(myArchvDbModel);
                }
                myReadImp.Close();

                SqlDataReader myReadXp = myCmdXp.ExecuteReader();

                Console.WriteLine("\n---------XPORT----------\nCount \t\t Archival Dttm\n");

                while (myReadXp.Read())
                {
                    Console.WriteLine(myReadXp.GetInt32(0).ToString() + "\t\t" + myReadXp.GetDateTime(1));
                }

                myReadXp.Close();
                myMasterCon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        // GET: api/archvJob/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/archvJob
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/archvJob/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/archvJob/5
        public void Delete(int id)
        {
        }
    }
}
