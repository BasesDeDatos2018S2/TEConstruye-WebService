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
    public class MaterialsxStageController : ApiController
    {


        [Route("api/client/{id_material}/{id_stage}")]
        public List<Object> GetClient(int id_material, int id_stage)
        {

            MStageLogic logic = new MStageLogic();
            MStage_Data data = logic.GetMStage(id_material, id_stage);
            List<Object> list = new List<Object>();
            if (data == null)
            {
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                list.Add(data);
                return list;
            }
        }

        public List<Object> GetAllClient()
        {

            MStageLogic logic = new MStageLogic();
            List<Object> list = new List<Object>();
            list = logic.GetListMStage();
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
