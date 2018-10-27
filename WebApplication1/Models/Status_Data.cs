using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Status_Data
    {
        public string Etapa { get; set; }
        public int TotalPresupuesto { get; set; }
        public int TotalReal { get; set; }
        public int Diferencia { get; set; }
        public string Proyecto { get; set; }
    }
}