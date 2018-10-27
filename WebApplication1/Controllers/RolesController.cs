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

    [Authorize(Roles = "Administrador")]
    public class RolesController : ApiController
    {

        private RoleLogic roleLogic= new RoleLogic();

        [Route("api/roles/{id}")]
        [HttpGet]
        public IHttpActionResult GetRoles(int id)
        {
            if (!roleLogic.existRoles(id))
            {

                //No se encontró el recurso code 404
                return NotFound();

            }
            Role_Data role = roleLogic.GetRoles(id);
            List<Object> list = new List<Object>();
            if (role != null)
            {

                list.Add(role);
                // ok code 200
                return Ok(list);

            }
            else
            {

                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();

            }
        }

        [Route("api/roles")]
        [HttpGet]
        public IHttpActionResult GetAllRoles()
        {
            List<Object> list = new List<Object>();
            list = roleLogic.GetListRoles();
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

        [Route("api/roles/add")]
        [HttpPost]
        public IHttpActionResult addRoles([FromBody] Role_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            /*
            if (roleLogic.existRoles(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            */
            if (roleLogic.addRoles(data))
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

        [Route("api/roles/update")]
        [HttpPut]
        public IHttpActionResult updateRoles([FromBody] Role_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!roleLogic.existRoles(data.id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (roleLogic.updateRoles(data))
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

        [Route("api/roles/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult deleteRoles(int id)
        {
            if (!roleLogic.existRoles(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (roleLogic.eraseRoles(id))
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
