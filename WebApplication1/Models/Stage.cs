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
    
    public partial class Stage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stage()
        {
            this.Bill = new HashSet<Bill>();
            this.MaterialsxStage = new HashSet<MaterialsxStage>();
        }
    
        public int id { get; set; }
        public int id_project { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialsxStage> MaterialsxStage { get; set; }
        public virtual Project Project { get; set; }
    }
}
