using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class BillLogic
    {

        public Bill_Data GetBill(int ID)
        {
            Bill_Data result = new Bill_Data();
            Bill bill;
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    int  i = construyeEntities.Bill.Where(e => e.id == ID).ToList().Count;

                    if (i == 0)
                    {
                        result = null;
                        return result;
                    }
                    bill = construyeEntities.Bill.Where(e => e.id == ID).ToList().First();
                    result.date = bill.date;
                    result.id = bill.id;
                    result.price = bill.price;
                    result.serial = bill.serial;
                    result.provider = bill.Provider.name;
                    return result;

                }
                catch (Exception E)
                {
                    result = null;
                    return result;
                }
            }
        }

        public List<Object> GetListBill()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var billList = construyeEntities.Bill.ToList();
                    int n = billList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i<billList.Count; ++i)
                        {
                            Bill_Data data = new Bill_Data();
                            data.date = billList.ElementAt(i).date;
                            data.id = billList.ElementAt(i).id;
                            data.price = billList.ElementAt(i).price;
                            data.serial = billList.ElementAt(i).serial;
                            data.provider = billList.ElementAt(i).Provider.name;
                            dataList.Add(data);
                        }
                        return dataList;
                    }
                }
                catch
                {

                    dataList = null;
                    return dataList;

                }
                
                


            }

        }

    }
}