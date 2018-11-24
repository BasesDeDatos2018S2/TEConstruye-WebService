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

    //[Authorize(Roles = "Administrador")]
    public class ClientController : ApiController
    {
        private ClientLogic clientLogic = new ClientLogic();

        [Route("api/tavo")]
        [HttpGet]
        public IHttpActionResult GetResult()
        {
            return Ok("nanitos123");
        }

        [Route("api/client/{ssn}")]
        [HttpGet]
        public IHttpActionResult GetClient(string ssn)
        {
            System.Diagnostics.Debug.WriteLine("GetClient");
            
            if (!clientLogic.existClient(ssn))
            {

                //No se encontró el recurso code 404
                return NotFound();

            }
            ProjectsxClient_Data client = clientLogic.GetClient(ssn);
            
            if (client != null)
            {
                // ok code 200
                return Ok(client);

            }
            else
            {

                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();

            }
        }

        [Route("api/client")]
        [HttpGet]
        public IHttpActionResult GetAllClient()
        {
            System.Diagnostics.Debug.WriteLine("GetAllClients");
            List<Object> list = new List<Object>();
            list = clientLogic.GetListClient();
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

        [Route("api/client/add")]
        [HttpPost]
        public IHttpActionResult addClient([FromBody] Client_Data data)
        {
            System.Diagnostics.Debug.WriteLine("AddClient");
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            /*
            if (clientLogic.existClient(data.identification))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            */
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
        [HttpPut]
        public IHttpActionResult updateClient([FromBody] Client_Data data)
        {
            System.Diagnostics.Debug.WriteLine("UpdateClient");
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

        [Route("api/client/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult deleteClient(string id)
        {
            System.Diagnostics.Debug.WriteLine("EraseClient");
            Console.WriteLine("Si lo borra");
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


        /*
        [Route("api/client/getpxc/{id}")]
        [HttpGet]
        public IHttpActionResult GetProjectxClient(string id)
        {
            System.Diagnostics.Debug.WriteLine("GetProjectsxClient");
            List<Object> list = new List<Object>();
            list = clientLogic.getProjectsxClient(id);
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

    */

    }
}
