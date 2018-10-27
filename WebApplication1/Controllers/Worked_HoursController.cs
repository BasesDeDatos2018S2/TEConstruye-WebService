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
    public class Worked_HoursController : ApiController
    {

        private  Worked_Hours_Logic worked_Hours_Logic = new Worked_Hours_Logic();

        [Route("api/worked_hours/{id}")]
        [HttpGet]
        public IHttpActionResult GetWorkedHours(int id)
        {
            if (!worked_Hours_Logic.existWorkedHours(id))
            {

                //No se encontró el recurso code 404
                return NotFound();

            }
            Worked_Hours_Data wh = worked_Hours_Logic.GetWorkedHours(id);
            List<Object> list = new List<Object>();
            if (wh != null)
            {

                list.Add(wh);
                // ok code 200
                return Ok(list);

            }
            else
            {

                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();

            }
        }
        [Route("api/worked_hours")]
        [HttpGet]
        public IHttpActionResult GetAllWorkedHours()
        {
            List<Object> list = new List<Object>();
            list = worked_Hours_Logic.GetListWorkedHours();
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

        [Route("api/worked_hours/add")]
        [HttpPost]
        public IHttpActionResult addWorkedHour([FromBody] Worked_Hours_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (worked_Hours_Logic.existWorkedHours(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            if (worked_Hours_Logic.addWorkedHours(data))
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

        [Route("api/worked_hours/update")]
        [HttpPut]
        public IHttpActionResult updateWorkedHours([FromBody] Worked_Hours_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!worked_Hours_Logic.existWorkedHours(data.id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (worked_Hours_Logic.updateWorkedHours(data))
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

        [Route("api/worked_hours/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult deleteWorkedHour(int id)
        {
            if (!worked_Hours_Logic.existWorkedHours(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (worked_Hours_Logic.eraseWorkedHours(id))
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
