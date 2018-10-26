using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Worked_Hours_Data
    {
        public int id { get; set; }
        public int id_project { get; set; }
        public int id_employee { get; set; }
        public System.DateTime date { get; set; }
        public int hours { get; set; }
    }
}