using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Logic;
using WebApplication1.Models;
using System.Web.Http.Cors;


namespace WebApplication1.Controllers
{
    public class BillController : ApiController
    {

        private BillLogic billLogic = new BillLogic();

        [Route("api/bill/{id}")]
        [HttpGet]
        public IHttpActionResult GetBill(int id)
        {
            Bill_Data bill = billLogic.GetBill(id);
            List<Object> list = new List<Object>();
            if (bill == null)
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            else
            {
                list.Add(bill);
                // ok code 200
                return Ok(list);
            }
        }

        [Route("api/bill")]
        [HttpGet]
        public IHttpActionResult GetAllBill()
        {
            List<Object> list = new List<Object>();
            list = billLogic.GetListBill();
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

        
        [Route("api/bill/add")]
        [HttpPost]
        public IHttpActionResult addBill([FromBody] Bill_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (billLogic.existBill(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            if (billLogic.addBill(data))
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

        [Route("api/bill/update")]
        [HttpPost]
        public IHttpActionResult updateBill([FromBody] Bill_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!billLogic.existBill(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return NotFound();
            }
            if (billLogic.updateBill(data))
            {
                //petición correcta code 200
                return Ok();
            }
            else
            {
                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();
            }

        }

        [Route("api/bill/erase/{id}")]
        [HttpDelete]
        public IHttpActionResult eraseBill(int id)
        {
            if (!billLogic.existBill(id))
            {
                //petición correcta pero no pudo ser procesada porque no se encontró el archivo code 404
                return NotFound();
            }
            if (billLogic.eraseBill(id))
            {
                //Se completó la solicitud con exito code 200 ok
                return Ok();
            }
            else
            {
                //No se pudo realizar la solicitud con exito por un error interno code 500
                return InternalServerError();
            }

        }



    }

}
