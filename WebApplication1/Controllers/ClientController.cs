using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Logic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClientController : ApiController
    {
        [Route("api/client/{ssn}")]
        public List<Object> GetClient(string ssn)
        {

            ClientLogic clientLogic = new ClientLogic();
            Client_Data client = clientLogic.GetClient(ssn);
            List<Object> list = new List<Object>();
            if (client == null)
            {
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                list.Add(client);
                return list;
            }
        }

        public List<Object> GetAllClient()
        {

            ClientLogic clientLogic = new ClientLogic();
            List<Object> list = new List<Object>();
            list = clientLogic.GetListClient();
            if (list == null)
            {
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                return list;
            }

        }
    }
}
