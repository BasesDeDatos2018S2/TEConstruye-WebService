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
    public class ClientController : ApiController
    {
        private ClientLogic clientLogic = new ClientLogic();

        [Route("api/client/{ssn}")]
        [HttpGet]
        public IHttpActionResult GetClient(string ssn)
        {
            Client_Data client = clientLogic.GetClient(ssn);
            List<Object> list = new List<Object>();
            if (client == null)
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            else
            {
                list.Add(client);
                // ok code 200
                return Ok(list);
            }
        }

        [Route("api/client")]
        [HttpGet]
        public IHttpActionResult GetAllClient()
        {
            List<Object> list = new List<Object>();
            list = clientLogic.GetListClient();
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

        [Route("api/client/add")]
        [HttpPost]
        public IHttpActionResult addClient([FromBody] Client_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (clientLogic.existClient(data.identification))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            if (clientLogic.addClient(data))
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

        [Route("api/client/update")]
        [HttpPost]
        public IHttpActionResult updateClient([FromBody] Client_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!clientLogic.existClient(data.identification))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (clientLogic.updateClient(data))
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

        [Route("api/client/erase/{id}")]
        [HttpDelete]
        public IHttpActionResult eraseClient(string id)
        {
            if (!clientLogic.existClient(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (clientLogic.eraseClient(id))
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
