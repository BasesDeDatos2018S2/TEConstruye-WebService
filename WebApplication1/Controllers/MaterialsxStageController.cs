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

        private MStageLogic ms = new MStageLogic();

        [Route("api/materialsxstage/get/{id_stage}/{id_material}")]
        public IHttpActionResult GetClient(int id_stage, int id_material)
        {

            MStage_Data data = ms.GetMStage(id_material, id_stage);
            List<Object> list = new List<Object>();
            if (data == null)
            {
                // Recurso no encontrado code 404
                return NotFound();
            }
            else
            {
                list.Add(data);
                //ok code 200
                return Ok(list);
            }
        }
        [Route("api/materialsxstage/")]
        public IHttpActionResult GetAllClient()
        {
            List<Object> list = new List<Object>();
            list = ms.GetListMStage();
            if (list == null)
            {
                //File not found   
                return NotFound();
            }
            else
            {
                //Return list of objects
                return Ok(list);
            }

        }

        [Route("api/materialsxstage/add")]
        public IHttpActionResult addMxS([FromBody] MStage_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (ms.existMStage(data.id_stage, data.id_material))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            if (ms.addMStage(data))
            {
                //petición correcta y se ha creado un nuevo recurso code 201
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();
            }

        }

        [Route("api/materialsxstage/update")]
        public IHttpActionResult updateMxs([FromBody] MStage_Data data)
        {
            if (data == null)
            {
                //Bad request
                return BadRequest();
            }
            if (!ms.existMStage(data.id_stage, data.id_material))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo
                return NotFound();
            }
            if (ms.updateMStage(data))
            {
                //petición correcta y se ha creado un nuevo recurso
                return Ok();
            }
            else
            {
                //No se pudo crear el recurso por un error interno
                return InternalServerError();
            }

        }

        [Route("api/materialsxstage/erase/{id_stage}/{id_material}")]
        public IHttpActionResult eraseClient(int id_stage, int id_material)
        {
            if (!ms.existMStage(id_stage, id_material))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo
                return NotFound();
            }
            if (ms.eraseMStage(id_stage, id_material))
            {
                //Se completó la solicitud con exito
                return Ok();
            }
            else
            {
                return InternalServerError();
            }

        }

    }
}
