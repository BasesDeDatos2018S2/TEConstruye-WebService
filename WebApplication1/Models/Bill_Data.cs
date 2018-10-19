using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Bill_Data
    {
        public int id { get; set; }
        public String serial { get; set; }
        public String provider { get; set; }
        public int price { get; set; }
        public DateTime date { get; set; }
    }

}