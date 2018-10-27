using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Report_Project_Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string ubication { get; set; }
        public string id_client { get; set; }
        public int manager { get; set; }
        public int totalCost { get; set; }
        public int totalBudget { get; set; }
        public List<int> idStages { get; set; }
        public List<int> idAnotations { get; set; }

    }
}