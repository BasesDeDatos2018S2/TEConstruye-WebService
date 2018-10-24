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

    public class EmployeeController : ApiController
    {

        private EmployeeLogic employeeLogic = new EmployeeLogic();


        [Route("api/employee/{id}")]
        [HttpGet]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee_Data employee = employeeLogic.GetEmployee(id);
            List<Object> list = new List<Object>();
            if (employee == null)
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            else
            {
                list.Add(employee);
                // ok code 200
                return Ok(list);
            }
        }


        [Route("api/employee")]
        [HttpGet]
        public IHttpActionResult GetAllEmployee()
        {
            List<Object> list = new List<Object>();
            list = employeeLogic.GetListEmployee();
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

        [Route("api/employee/add")]
        [HttpPost]
        public IHttpActionResult addEmployee([FromBody] Employee_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (employeeLogic.existEmployee(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            if (employeeLogic.addEmployee(data))
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

        [Route("api/employee/update")]
        [HttpPost]
        public IHttpActionResult updateEmployee([FromBody] Employee_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!employeeLogic.existEmployee(data.id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (employeeLogic.updateEmployee(data))
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

        [Route("api/employee/erase/{id}")]
        [HttpDelete]
        public IHttpActionResult eraseEmployee(int id)
        {
            if (!employeeLogic.existEmployee(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (employeeLogic.eraseEmployee(id))
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
