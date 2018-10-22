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


        [Route("api/materialsxstage/{id_stage}/{id_material}")]
        public List<Object> GetClient(int id_stage, int id_material)
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
        [Route("api/materialsxstage/")]
        public List<Object> GetAllClient()
        {

            MStageLogic logic = new MStageLogic();
            List<Object> list = new List<Object>();
            list = logic.GetListMStage();
            if (list == null)
            {
                //File not found
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                return list;
            }

        }

        [Route("api/materialsxstage/add")]
        public HttpStatusCode addMxS([FromBody] MStage_Data data)
        {
            MStageLogic ms = new MStageLogic();
            List<Object> result = new List<Object>();
            if (data == null)
            {
                //Bad request
             
                return HttpStatusCode.BadRequest;
            }
            if (ms.existMStage(data.id_stage, data.id_material))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo
                
                return HttpStatusCode.Accepted;
            }
            if (ms.addMStage(data))
            {
                //petición correcta y se ha creado un nuevo recurso
                
                return HttpStatusCode.Created;
            }
            else
            {
                //No se pudo crear el recurso por un error interno
               
                return HttpStatusCode.InternalServerError;
            }

        }


    }
}
