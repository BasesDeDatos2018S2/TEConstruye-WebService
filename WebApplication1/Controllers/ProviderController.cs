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
    public class ProviderController : ApiController
    {

        public List<Object> GetProvider(int id)
        {
            ProviderLogic providerLogic = new ProviderLogic();
            Provider_Data provider = providerLogic.GetProvider(id);
            List<Object> list = new List<Object>();
            if (provider == null)
            {
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                list.Add(provider);
                return list;
            }
        }

        public List<Object> GetAllProvider()
        {
            ProviderLogic providerLogic = new ProviderLogic();
            List<Object> list = new List<Object>();
            list = providerLogic.GetListProvider();
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
