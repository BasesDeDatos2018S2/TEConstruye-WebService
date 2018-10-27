using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [RoutePrefix("api/detail")]
    public class DetailsController : ApiController
    {
        TeConstruyeEntities1 cX = new TeConstruyeEntities1();

        [AllowAnonymous]
        [Route("report/budget/{id}")]
        [HttpPost]
        public HttpResponseMessage BudgetReport(int id, [FromBody] Email email)
        {
            string EmailTosend = WebUtility.UrlDecode(email.email);
            var data = cX.usp_budget(id);
            var rd = new ReportDocument();
         
             List<Object> model = new List<Object>();
             foreach (var details in data)
             {
                BugetClass_Data buget = new BugetClass_Data();
                buget.Cantidad = details.Cantidad;
                buget.Costo = details.Costo;
                buget.Etapa = details.Etapa;
                buget.Material = details.Material;
                buget.Nombre = details.Nombre;
                buget.ProyectoNombre = details.ProyectoNombre;
                buget.Total = (int)details.Total;
                buget.Detalle = details.Detalle;
                 model.Add(buget);

             }

           
            rd.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Reports"), "Budget.rpt"));
            ConnectionInfo connectInfo = new ConnectionInfo()
            {
                ServerName = "CRISPTOFER\\SQLEXPRESS",
                DatabaseName = "TeConstruye",
                UserID = "crisptofer12ff",
                Password = "123456789"
            };
            rd.SetDatabaseLogon(connectInfo.UserID, connectInfo.Password, connectInfo.ServerName,connectInfo.DatabaseName);
            foreach (Table tbl in rd.Database.Tables)
            {
                tbl.LogOnInfo.ConnectionInfo = connectInfo;
                tbl.ApplyLogOnInfo(tbl.LogOnInfo);
            }
            rd.SetDataSource(model);
            using (var stream = rd.ExportToStream(ExportFormatType.PortableDocFormat))
            {
                SmtpClient smtp = new SmtpClient
                {
                    Port = 587,
                    UseDefaultCredentials = true,
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("teconstruyecompany@gmail.com", "teconstruye");
                var message = new System.Net.Mail.MailMessage("teconstruyecompany@gmail.com", EmailTosend, "Reporte Presupuesto", "Se adjunta el reporte de Presupuesto.");
                message.Attachments.Add(new Attachment(stream, "Presupuesto.pdf"));

                smtp.Send(message);
            }

            var Message = string.Format("Report Created and sended to your Mail.");
            HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.OK, Message);
            return response1;
        }


        [AllowAnonymous]
        [Route("report/employeepayment")]
        [HttpPost]
        public HttpResponseMessage employeePayment([FromBody] Email email)
        {
            string EmailTosend = WebUtility.UrlDecode(email.email);
            var data = cX.usp_employee_payment((DateTime?)email.date1, (DateTime?)email.date2);
            var rd = new ReportDocument();

            List<Object> model = new List<Object>();
            foreach (var details in data)
            {
                Employee_Payment_Data employee = new Employee_Payment_Data();
                employee.Costo = details.Costo;
                employee.Horas = details.Horas;
                employee.Nombre = details.Nombre;
                employee.Proyecto = details.Proyecto;
                employee.Total = (int)details.Total;
                model.Add(employee);

            }


            rd.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Reports"), "employee_payment.rpt"));
            ConnectionInfo connectInfo = new ConnectionInfo()
            {
                ServerName = "CRISPTOFER\\SQLEXPRESS",
                DatabaseName = "TeConstruye",
                UserID = "crisptofer12ff",
                Password = "123456789"
            };
            rd.SetDatabaseLogon(connectInfo.UserID, connectInfo.Password, connectInfo.ServerName, connectInfo.DatabaseName);
            foreach (Table tbl in rd.Database.Tables)
            {
                tbl.LogOnInfo.ConnectionInfo = connectInfo;
                tbl.ApplyLogOnInfo(tbl.LogOnInfo);
            }
            
            rd.SetDataSource(model);
            using (var stream = rd.ExportToStream(ExportFormatType.PortableDocFormat))
            {
                SmtpClient smtp = new SmtpClient
                {
                    Port = 587,
                    UseDefaultCredentials = true,
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("teconstruyecompany@gmail.com", "teconstruye");
                var message = new System.Net.Mail.MailMessage("teconstruyecompany@gmail.com", EmailTosend, "Reporte Planilla", "Se adjunta reporte de planilla.");
                message.Attachments.Add(new Attachment(stream, "Planilla.pdf"));

                smtp.Send(message);
            }

            var Message = string.Format("Report Created and sended to your Mail.");
            HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.OK, Message);
            return response1;
        }


        [AllowAnonymous]
        [Route("report/status/{id}")]
        [HttpPost]
        public HttpResponseMessage status([FromBody] Email email, int id)
        {
            string EmailTosend = WebUtility.UrlDecode(email.email);
            var data = cX.usp_status(id);
            var rd = new ReportDocument();

            List<Object> model = new List<Object>();
            foreach (var details in data)
            {
                Status_Data status = new Status_Data();
                status.Diferencia = (int)details.Diferencia;
                status.Etapa = details.Etapa;
                status.Proyecto = details.Proyecto;
                status.TotalPresupuesto = (int)details.TotalPresupuesto;
                status.TotalReal = (int)details.TotalReal;
                model.Add(status);

            }


            rd.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Reports"), "status.rpt"));
            ConnectionInfo connectInfo = new ConnectionInfo()
            {
                ServerName = "CRISPTOFER\\SQLEXPRESS",
                DatabaseName = "TeConstruye",
                UserID = "crisptofer12ff",
                Password = "123456789"
            };
            rd.SetDatabaseLogon(connectInfo.UserID, connectInfo.Password, connectInfo.ServerName, connectInfo.DatabaseName);
            foreach (Table tbl in rd.Database.Tables)
            {
                tbl.LogOnInfo.ConnectionInfo = connectInfo;
                tbl.ApplyLogOnInfo(tbl.LogOnInfo);
            }

            rd.SetDataSource(model);
            using (var stream = rd.ExportToStream(ExportFormatType.PortableDocFormat))
            {
                SmtpClient smtp = new SmtpClient
                {
                    Port = 587,
                    UseDefaultCredentials = true,
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("teconstruyecompany@gmail.com", "teconstruye");
                var message = new System.Net.Mail.MailMessage("teconstruyecompany@gmail.com", EmailTosend, "Reporte de Estado", "Se adjunta el reporte de estado.");
                message.Attachments.Add(new Attachment(stream, "Status.pdf"));

                smtp.Send(message);
            }

            var Message = string.Format("Report Created and sended to your Mail.");
            HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.OK, Message);
            return response1;
        }


    }
}
