//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public string serial { get; set; }
        public int price { get; set; }
        public int id_stage { get; set; }
        public int id_material { get; set; }
        public int id_provider { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual Stage Stage { get; set; }
    }
}
