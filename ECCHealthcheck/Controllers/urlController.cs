using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ECCHealthcheck.Models;

namespace ECCHealthcheck.Controllers
{
    public class urlController : ApiController
    {
        // GET: api/url
        public IEnumerable<urlModel> Get()
        {
            List<urlModel> myUrlModList = new List<urlModel>();
            int urlCount = 10;
            string url = "";

            for (urlCount =   1; urlCount <= 10; urlCount++)
            {
                urlModel myUrlMod = new urlModel();
                switch (urlCount)
                {
                    case 1:
                        url = "http://eccservices.suntrust.com/CommonServices/CloseBatchService.svc";
                        break;
                    case 2:
                        url = "http://eccservices.suntrust.com/CommonServices/ECCOnPointeAPIService.svc";
                        break;
                    case 3:
                        url = "http://eccservices.suntrust.com/CommonServices/ECCOnPointeReleaseService.svc";
                        break;
                    case 4:
                        url = "http://eccservices.suntrust.com/CommonServices/LoadXMLBatch.svc";
                        break;
                    case 5:
                        url = "http://eccservices.suntrust.com/CommonServices/NotificationService.svc";
                        break;
                    case 6:
                        url = "http://eccservices.suntrust.com/CommonServices/PopulateTHORDocMsgDataService.svc";
                        break;
                    case 7:
                        url = "http://eccservices.suntrust.com/ECCDocumentIngestionService/DocumentIngestionService.svc";
                        break;
                    case 8:
                        url = "http://eccservices.suntrust.com/ECCRetentionPolicyLookupService/RetentionLookUpService.svc";
                        break;
                    case 9:
                        url = "http://eccservices.suntrust.com/ECMProviderService/ECMProviderService.svc";
                        break;
                    case 10:
                        url = "http://ecmservices.suntrust.com";
                        break;
                    default:
                        break;
                }

                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                    myUrlMod.url = url;
                    myUrlMod.responseCode = (int)myResp.StatusCode;
                    myUrlMod.responseDesc = myResp.StatusDescription;
                }
                catch (Exception e)
                {
                    myUrlMod.url = url;
                    myUrlMod.responseCode = 0;
                    myUrlMod.responseDesc = "Not Known";
                }

                myUrlModList.Add(myUrlMod);
            }

            return myUrlModList;
        }

        // GET: api/url/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/url
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/url/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/url/5
        public void Delete(int id)
        {
        }
    }
}


