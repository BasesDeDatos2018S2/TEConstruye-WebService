using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Logic;

namespace WebApplication1.Controllers
{
    public class AnotationsController : ApiController
    {

        public List<Object> GetAnotations(int id)
        {
            AnotationsLogic anotationsLogic = new AnotationsLogic();
            Anotations_Data anotations = anotationsLogic.GetAnotation(id);
            List<Object> list = new List<Object>();
            if (anotations == null)
            {
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                list.Add(anotations);
                return list;
            }
        }

        public List<Object> GetAllAnotations()
        {
            AnotationsLogic anotationsLogic = new AnotationsLogic();
            List<Object> list = new List<Object>();
            list = anotationsLogic.GetListAnotations();
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
