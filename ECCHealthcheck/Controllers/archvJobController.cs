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
        public string Get()
        {
            return "Hello";
        }

        // GET: api/archvJob/5
        public IEnumerable<archvDbModel> Get(string id)
        {
            List<archvDbModel> myArchvDbList = new List<archvDbModel>();

            SqlConnection myMasterCon = new SqlConnection("Server=GA016VSQL0E7 ;Database = Master ; User Id = uzpisq1 ; password = imgwrite");
            try
            {
                myMasterCon.Open();
                string conStr = "";
                switch (id)
                {
                    case "Import":
                        conStr = "select COUNT(*),ARCHV_DTTM from[ECCImport_Data_HST].[dbo].[T_BAT] where ARCHV_DTTM > DATEADD(d, -4, getdate()) group by ARCHV_DTTM order by ARCHV_DTTM desc";
                        break;
                    case "Xport":
                        conStr = "select COUNT(*),ARCHV_DTTM from[ECCXport_Data_Hst].[dbo].[T_BAT] where ARCHV_DTTM > DATEADD(d, -5, getdate()) group by ARCHV_DTTM order by ARCHV_DTTM desc";
                        break;
                    default:
                        break;
                }

                SqlCommand myCmd = new SqlCommand(conStr, myMasterCon);

                SqlDataReader myRead = myCmd.ExecuteReader();

                while (myRead.Read())
                {
                    archvDbModel myArchvDbModel = new archvDbModel();
                    myArchvDbModel.archvDttm = myRead.GetDateTime(1);
                    myArchvDbModel.archvCnt = myRead.GetInt32(0);
                    myArchvDbList.Add(myArchvDbModel);
                }
                myRead.Close();
                myMasterCon.Close();
            }
            catch (Exception e)
            {
                myArchvDbList.Add(new archvDbModel { archvCnt = 0, archvDttm = System.DateTime.Now });
            }
            return myArchvDbList;
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
