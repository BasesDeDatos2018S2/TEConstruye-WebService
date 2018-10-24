using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee_Data
    {
        public int id { get; set; }
        public string identification { get; set; }
        public string name { get; set; }
        public string lastname1 { get; set; }
        public string lastname2 { get; set; }
        public string phone { get; set; }
        public int hour_cost { get; set; }
    }
}