﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TeConstruyeEntities1 : DbContext
    {
        public TeConstruyeEntities1()
            : base("name=TeConstruyeEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Anotations> Anotations { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<MaterialsxStage> MaterialsxStage { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<Role_specification> Role_specification { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }
        public virtual DbSet<Worked_hours> Worked_hours { get; set; }
    
        public virtual ObjectResult<usp_budget_Result> usp_budget(Nullable<int> idProject)
        {
            var idProjectParameter = idProject.HasValue ?
                new ObjectParameter("idProject", idProject) :
                new ObjectParameter("idProject", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_budget_Result>("usp_budget", idProjectParameter);
        }
    
        public virtual ObjectResult<usp_employee_payment_Result> usp_employee_payment(Nullable<System.DateTime> first_date, Nullable<System.DateTime> second_date)
        {
            var first_dateParameter = first_date.HasValue ?
                new ObjectParameter("first_date", first_date) :
                new ObjectParameter("first_date", typeof(System.DateTime));
    
            var second_dateParameter = second_date.HasValue ?
                new ObjectParameter("second_date", second_date) :
                new ObjectParameter("second_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_employee_payment_Result>("usp_employee_payment", first_dateParameter, second_dateParameter);
        }
    
        public virtual ObjectResult<usp_expenses_Result> usp_expenses(Nullable<System.DateTime> first_date, Nullable<System.DateTime> second_date, Nullable<int> id_proj)
        {
            var first_dateParameter = first_date.HasValue ?
                new ObjectParameter("first_date", first_date) :
                new ObjectParameter("first_date", typeof(System.DateTime));
    
            var second_dateParameter = second_date.HasValue ?
                new ObjectParameter("second_date", second_date) :
                new ObjectParameter("second_date", typeof(System.DateTime));
    
            var id_projParameter = id_proj.HasValue ?
                new ObjectParameter("id_proj", id_proj) :
                new ObjectParameter("id_proj", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_expenses_Result>("usp_expenses", first_dateParameter, second_dateParameter, id_projParameter);
        }
    
        public virtual ObjectResult<usp_project_client_Result> usp_project_client()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_project_client_Result>("usp_project_client");
        }
    
        public virtual ObjectResult<usp_status_Result> usp_status(Nullable<int> id_proj)
        {
            var id_projParameter = id_proj.HasValue ?
                new ObjectParameter("id_proj", id_proj) :
                new ObjectParameter("id_proj", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_status_Result>("usp_status", id_projParameter);
        }
    }
}