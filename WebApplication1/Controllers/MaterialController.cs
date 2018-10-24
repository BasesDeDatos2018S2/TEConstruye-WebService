﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Logic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MaterialController : ApiController
    {

        private MaterialLogic materialLogic = new MaterialLogic();


        [Route("api/materials")]
        [HttpGet]
        public IHttpActionResult GetAllMaterial()
        {
            List<Object> list = new List<Object>();
            list = materialLogic.GetListMaterial();
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

        [Route("api/materials/{id}")]
        [HttpGet]
        public IHttpActionResult GetMaterial(int id)
        {
            Material_Data materials = materialLogic.GetMaterial(id);
            List<Object> list = new List<Object>();
            if (materials == null)
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            else
            {
                list.Add(materials);
                // ok code 200
                return Ok(list);
            }
        }

        [Route("api/material/add")]
        [HttpPost]
        public IHttpActionResult addMaterial([FromBody] Material_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (materialLogic.existMaterial(data.id))
            {
                //petición correcta pero no pudo ser procesada porque ya existe el archivo code 202
                return StatusCode(HttpStatusCode.Accepted);
            }
            if (materialLogic.addMaterial(data))
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

        [Route("api/material/update")]
        [HttpPost]
        public IHttpActionResult updateMaterial([FromBody] Material_Data data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!materialLogic.existMaterial(data.id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (materialLogic.updateMaterial(data))
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

        [Route("api/material/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult deleteAnotation(int id)
        {
            if (!materialLogic.existMaterial(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (materialLogic.eraseEmployee(id))
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
