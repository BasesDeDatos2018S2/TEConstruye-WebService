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
    
    public partial class Roles
    {
        public int id { get; set; }
        public int id_role { get; set; }
        public int id_employee { get; set; }
        public System.DateTime start_date { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Role_specification Role_specification { get; set; }
    }
}
