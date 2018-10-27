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
    //[Authorize(Roles = "Administrador")]
    public class RoleController : ApiController
    {
        RoleSpecificationLogic roleSpecificationLogic = new RoleSpecificationLogic();

        [Route("api/role/{id}")]
        [HttpGet]
        public IHttpActionResult GetRole(int id)
        {
            if (!roleSpecificationLogic.existRole(id))
            {

                //No se encontró el recurso code 404
                return NotFound();

            }
            RoleSpecification_Data role = roleSpecificationLogic.GetRole(id);
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

        [Route("api/role")]
        [HttpGet]
        public IHttpActionResult GetAllRole()
        {
            List<Object> list = new List<Object>();
            list = roleSpecificationLogic.GetListRole();
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

        [Route("api/role/add")]
        [HttpPost]
        public IHttpActionResult addRole([FromBody] RoleSpecification_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
           /*
            if (roleSpecificationLogic.existRole(data.id_role))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            */
            if (roleSpecificationLogic.addRole(data))
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

        [Route("api/role/update")]
        [HttpPut]
        public IHttpActionResult updateRole([FromBody] RoleSpecification_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!roleSpecificationLogic.existRole(data.id_role))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (roleSpecificationLogic.updateRole(data))
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

        [Route("api/role/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult deleteRole(int id)
        {
            if (!roleSpecificationLogic.existRole(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (roleSpecificationLogic.eraseRole(id))
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
