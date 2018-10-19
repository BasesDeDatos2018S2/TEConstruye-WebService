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
    public class StageController : ApiController
    {

        public List<Object> GetStage(int id)
        {
            StageLogic stageLogic = new StageLogic();
            Stage_Data stage = stageLogic.GetStage(id);
            List<Object> list = new List<Object>();
            if (stage == null)
            {
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                list.Add(stage);
                return list;
            }
        }

        public List<Object> GetAllStage()
        {
            StageLogic stageLogic = new StageLogic();
            List<Object> list = new List<Object>();
            list = stageLogic.GetListStage();
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
