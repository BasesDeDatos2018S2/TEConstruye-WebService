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
   [Authorize(Roles = "Administrador")]
    public class ProviderController : ApiController
    {

        private ProviderLogic providerLogic = new ProviderLogic();


        [Route("api/provider/{id}")]
        [HttpGet]
        public IHttpActionResult GetProvider(int id)
        {
            if (!providerLogic.existProvider(id))
            {

                //No se encontró el recurso code 404
                return NotFound();

            }
            Provider_Data provider = providerLogic.GetProvider(id);
            List<Object> list = new List<Object>();
            if (provider != null)
            {

                list.Add(provider);
                // ok code 200
                return Ok(list);

            }
            else
            {

                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();

            }
        }


        [Route("api/provider")]
        [HttpGet]
        public IHttpActionResult GetAllProvider()
        {
            List<Object> list = new List<Object>();
            list = providerLogic.GetListProvider();
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

        [Route("api/provider/add")]
        [HttpPost]
        public IHttpActionResult addProvider([FromBody] Provider_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            /*
            if (providerLogic.existProvider(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            */
            if (providerLogic.addProvider(data))
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


        [Route("api/provider/update")]
        [HttpPut]
        public IHttpActionResult updateAnotation([FromBody] Provider_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!providerLogic.existProvider(data.id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (providerLogic.updateProvider(data))
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

        [Route("api/provider/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult deleteProvider(int id)
        {
            if (!providerLogic.existProvider(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (providerLogic.eraseProvider(id))
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
