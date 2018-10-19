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


        /*
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        */
        public List<Object> GetEmployee(int id)
        {

            EmployeeLogic employeeLogic = new EmployeeLogic();
            Employee_Data employee = employeeLogic.GetEmployee(id);
            List<Object> list = new List<Object>();
            if (employee == null)
            {
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                list.Add(employee);
                return list;
            }
        }

        public List<Object> GetAllEmployee()
        {

            EmployeeLogic employeeLogic = new EmployeeLogic();
            List<Object> list = new List<Object>();
            list = employeeLogic.GetListEmployee();
            if (list == null)
            {
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                return list;
            }

        }



    }
}
