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
    [RoutePrefix("api/Details")]
    public class DetailsController : ApiController
    {
        TeConstruyeEntities1 cX = new TeConstruyeEntities1();

        [AllowAnonymous]
        [Route("Report/SendReport/{id}")]
        [HttpPost]
        public HttpResponseMessage ExportReport(int id)
        {
            string Email = "mau18alvarez@gmail.com";
            string EmailTosend = WebUtility.UrlDecode(Email);
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
                 buget.ProyectoNombre = buget.ProyectoNombre;
                 buget.Total = buget.Total;
                 model.Add(buget);

             }

           
            rd.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Reports"), "Budget.rpt"));
            ConnectionInfo connectInfo = new ConnectionInfo()
            {
                ServerName = "CRISPTOFER"+"\\"+"SQLEXPRESS",
                DatabaseName = "TeConstruye",
                UserID = "crisptofer12ff",
                Password = "123456789"
            };
            rd.SetDatabaseLogon("crisptofer12ff", "123456789");
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
                var message = new System.Net.Mail.MailMessage("teconstruyecompany@gmail.com", EmailTosend, "Report", "Hi Please check your Mail  and find the report.");
                message.Attachments.Add(new Attachment(stream, "UsersRegistration.pdf"));

                smtp.Send(message);
            }

            var Message = string.Format("Report Created and sended to your Mail.");
            HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.OK, Message);
            return response1;
        }


    }
}
