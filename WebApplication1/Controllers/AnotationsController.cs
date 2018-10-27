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
    public class AnotationsController : ApiController
    {
        private AnotationsLogic anotationsLogic = new AnotationsLogic();

        [Route("api/anotations/{id}")]
        [HttpGet]
        public IHttpActionResult GetAnotations(int id)
        {
            if (!anotationsLogic.existAnotation(id))
            {

                //No se encontró el recurso code 404
                return NotFound();

            }
            Anotations_Data anotations = anotationsLogic.GetAnotation(id);
            List<Object> list = new List<Object>();
            if (anotations != null)
            {

                list.Add(anotations);
                // ok code 200
                return Ok(list);

            }
            else
            {

                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();

            }
        }
        [Route("api/anotations")]
        [HttpGet]
        public IHttpActionResult GetAllAnotations()
        {
            List<Object> list = new List<Object>();
            list = anotationsLogic.GetListAnotations();
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

        [Route("api/anotations/add")]
        [HttpPost]
        public IHttpActionResult addAnotation([FromBody] Anotations_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            /*
            if (anotationsLogic.existAnotation(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            */
            if (anotationsLogic.addAnotation(data))
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

        [Route("api/anotations/update")]
        [HttpPut]
        public IHttpActionResult updateAnotation([FromBody] Anotations_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!anotationsLogic.existAnotation(data.id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (anotationsLogic.updateAnotations(data))
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

        [Route("api/anotations/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult deleteAnotation(int id)
        {
            if (!anotationsLogic.existAnotation(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (anotationsLogic.eraseAnotation(id))
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
