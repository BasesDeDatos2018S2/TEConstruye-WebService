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

    [Authorize(Roles = "Administrador, mediumAccess")]
    public class StageController : ApiController
    {
        private StageLogic stageLogic = new StageLogic();

        [Route("api/stage/{id}")]
        [HttpGet]
        public IHttpActionResult GetStage(int id)
        {
            if (!stageLogic.existStage(id))
            {

                //No se encontró el recurso code 404
                return NotFound();

            }
            Report_Stage_Data stage = stageLogic.GetStage(id);
            List<Object> list = new List<Object>();
            if (stage != null)
            {

                list.Add(stage);
                // ok code 200
                return Ok(list);

            }
            else
            {

                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();

            }
        }
        [Route("api/stage")]
        [HttpGet]
        public IHttpActionResult GetAllStage()
        {
            List<Object> list = new List<Object>();
            list = stageLogic.GetListStage();
            if (list == null)
            {
                //La respuesta no tiene contenido code 204
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                // ok code 200
                return Ok(list);
            }

        }

        [Route("api/stage/add")]
        [HttpPost]
        public IHttpActionResult addStage([FromBody] Stage_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            /*
            if (stageLogic.existStage(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            */
            if (stageLogic.addStage(data))
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

        [Route("api/stage/update")]
        [HttpPut]
        public IHttpActionResult updateStage([FromBody] Stage_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!stageLogic.existStage(data.id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (stageLogic.updateStage(data))
            {
                //petición correcta y se ha creado un nuevo recurso code 200 ok
                return Ok();
            }
            else
            {
                //No se pudo crear el recurso por un error  code 500
                return InternalServerError();
            }

        }

        [Route("api/stage/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult deleteStage(int id)
        {
            if (!stageLogic.existStage(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (stageLogic.eraseStage(id))
            {
                //Se completó la solicitud con exito code 200 ok
                return Ok();
            }
            else
            {
                //No se completó la solicitud por un error interno code 500
                return InternalServerError();
            }

        }
    }
}
