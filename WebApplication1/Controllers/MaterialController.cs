using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Logic;

namespace WebApplication1.Controllers
{
    public class MaterialController : ApiController
    {

        public List<Object> GetAllMaterial()
        {

            MaterialLogic materialLogic = new MaterialLogic();
            List<Object> list = new List<Object>();
            list = materialLogic.GetListMaterial();
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
