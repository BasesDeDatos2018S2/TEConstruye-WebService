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
        private AnotationsLogic anotationsLogic = new AnotationsLogic();

        [Route("api/anotations/{id}")]
        public IHttpActionResult GetAnotations(int id)
        {
            Anotations_Data anotations = anotationsLogic.GetAnotation(id);
            List<Object> list = new List<Object>();
            if (anotations == null)
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            else
            {
                list.Add(anotations);
                // ok code 200
                return Ok(list);
            }
        }
        [Route("api/anotations")]
        public IHttpActionResult GetAllAnotations()
        {
            List<Object> list = new List<Object>();
            list = anotationsLogic.GetListAnotations();
            if (list == null)
            {
                // recurso no encontrado code 404
                return NotFound();
            }
            else
            {
                // ok code 200
                return Ok(list);
            }

        }

        [Route("api/anotations/add")]
        public IHttpActionResult addAnotation([FromBody] Anotations_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (anotationsLogic.existAnotation(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
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
        public IHttpActionResult updateMxs([FromBody] Anotations_Data data)
        {
            if (data == null)
            {
                //Bad request
                return BadRequest();
            }
            if (!anotationsLogic.existAnotation(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo
                return NotFound();
            }
            if (anotationsLogic.updateAnotations(data))
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

        [Route("api/anotations/erase/{id}")]
        public IHttpActionResult eraseClient(int id)
        {
            if (!anotationsLogic.existAnotation(id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo
                return NotFound();
            }
            if (anotationsLogic.eraseAnotation(id))
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
