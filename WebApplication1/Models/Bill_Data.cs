using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Bill_Data
    {
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public string serial { get; set; }
        public int price { get; set; }
        public int id_stage { get; set; }
        public int id_material { get; set; }
        public int id_provider { get; set; }
    }

}