using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Report_Stage_Data
    {
        public int id { get; set; }
        public int id_project { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public int totalCost { get; set; }
        public int totalBudget { get; set; }
        public List<int> idMaterials { get; set; }
        public List<int> idBills { get; set; }
    }
}