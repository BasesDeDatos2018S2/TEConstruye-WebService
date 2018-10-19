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
    public class BillController : ApiController
    {

       
        public List<Object> GetBill(int id)
        {
            BillLogic billLogic = new BillLogic();
            Bill_Data bill = billLogic.GetBill(id);
            List<Object> list = new List<Object>();
            if (bill == null)
            {
                list.Add(new { status = "404" });
                return list;
            }
            else
            {
                list.Add(bill);
                return list;
            }
        }

        public List<Object> GetAllBill()
        {
            BillLogic billLogic = new BillLogic();
            List<Object> list = new List<Object>();
            list = billLogic.GetListBill();
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
