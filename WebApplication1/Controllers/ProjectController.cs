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
    public class ProjectController : ApiController
    {


        public List<Object> GetProject(int id)
        {
            ProjectLogic projectLogic = new ProjectLogic();
            Project_Data project = projectLogic.GetProject(id);
            List<Object> list = new List<Object>();
            if (project == null)
            {
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                list.Add(project);
                return list;
            }
        }

        public List<Object> GetAllProject()
        {
            ProjectLogic projectLogic = new ProjectLogic();
            List<Object> list = new List<Object>();
            list = projectLogic.GetListProject();
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
