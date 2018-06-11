using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECCHealthcheck.Models
{
    public class urlModel
    {
        public string url { get; set; }
        public int responseCode { get; set; }
        public string responseDesc { get; set; }
    }
}