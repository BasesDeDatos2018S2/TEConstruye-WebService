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

    [Authorize(Roles = "mediumAccess")]
    public class ProjectController : ApiController
    {
        private ProjectLogic projectLogic = new ProjectLogic();


        [Route("api/project/{id}")]
        [HttpGet]
        public IHttpActionResult GetProject(int id)
        {
            
            if (!projectLogic.existProject(id))
            {

                //No se encontró el recurso code 404
                return NotFound();

            }
            Report_Project_Data project = projectLogic.GetProject(id);
            List<Object> list = new List<Object>();
            if (project != null)
            {

                list.Add(project);
                // ok code 200
                return Ok(list);

            }
            else
            {

                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();

            }
        }


        [Route("api/project")]
        [HttpGet]
        public IHttpActionResult GetAllProject()
        {
            List<Object> list = new List<Object>();
            list = projectLogic.GetListProject();
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

        [Route("api/project/add")]
        [HttpPost]
        public IHttpActionResult addProject([FromBody] Project_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (projectLogic.existProject(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            if (projectLogic.addProject(data))
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


        [Route("api/project/update")]
        [HttpPut]
        public IHttpActionResult updateProject([FromBody] Project_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!projectLogic.existProject(data.id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (projectLogic.updateProject(data))
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

        [Route("api/project/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult deleteProject(int id)
        {
            if (!projectLogic.existProject(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (projectLogic.eraseProject(id))
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
        [Route("api/projectReport/{id}")]
        [HttpGet]
        public IHttpActionResult GetProjectReport(int id)
        {

            if (!projectLogic.existProject(id))
            {

                //No se encontró el recurso code 404
                return NotFound();

            }
            Report_Project_Data project = projectLogic.(id);
            List<Object> list = new List<Object>();
            if (project != null)
            {

                list.Add(project);
                // ok code 200
                return Ok(list);

            }
            else
            {

                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();

            }
        }
        */

    }
}
