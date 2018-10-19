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
    public class RoleController : ApiController
    {

        public List<Object> GetRole(int id)
        {
            RoleSpecificationLogic roleSpecification = new RoleSpecificationLogic();
            RoleSpecification_Data role = roleSpecification.GetRole(id);
            List<Object> list = new List<Object>();
            if (role == null)
            {
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                list.Add(role);
                return list;
            }
        }

        public List<Object> GetAllRole()
        {
            RoleSpecificationLogic roleSpecification = new RoleSpecificationLogic();
            List<Object> list = new List<Object>();
            list = roleSpecification.GetListRole();
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
