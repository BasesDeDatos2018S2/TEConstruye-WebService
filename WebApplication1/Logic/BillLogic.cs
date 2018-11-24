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
                    if (!this.existBill(ID))
                    {
                        result = null;
                        return result;
                    }
                    bill = construyeEntities.Bills.Find(ID);
                    result.id = bill.id;
                    result.id_material = bill.id_material;
                    result.id_provider = bill.id_provider;
                    result.id_stage = bill.id_stage;
                    result.price = bill.price;
                    result.serial = bill.serial;
                    result.date = bill.date;
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
                    var billList = construyeEntities.Bills.ToList();
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
                            data.id = billList.ElementAt(i).id;
                            data.id_material = billList.ElementAt(i).id_material;
                            data.id_provider = billList.ElementAt(i).id_provider;
                            data.id_stage = billList.ElementAt(i).id_stage;
                            data.price = billList.ElementAt(i).price;
                            data.serial = billList.ElementAt(i).serial;
                            data.date = billList.ElementAt(i).date;
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

        public bool existBill(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                var i = construyeEntities.Bills.Find(id);
                if (i == null) return false;
                else return true;

            }
        }

        public bool addBill(Bill_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {

                Bill bill = new Bill();
                bill.id = data.id;
                bill.id_material = data.id_material;
                bill.id_provider = data.id_provider;
                bill.id_stage = data.id_stage;
                bill.price = data.price;
                bill.serial = data.serial;
                bill.date = data.date;
                bill.Material = construyeEntities.Materials.Find(data.id_material);
                bill.Provider = construyeEntities.Providers.Find(data.id_provider);
                bill.Stage = construyeEntities.Stages.Find(data.id_stage);
                
                
                try
                {
                    construyeEntities.Bills.Add(bill);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }


            }
        }

        public bool eraseBill(int id)
        {

            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var ms = construyeEntities.Bills.Find(id);
                    construyeEntities.Bills.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }


            }

        }

        public bool updateBill(Bill_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {

                try
                {
                    var bill = construyeEntities.Bills.Find(data.id);
                    bill.id = data.id;
                    bill.id_material = data.id_material;
                    bill.id_provider = data.id_provider;
                    bill.id_stage = data.id_stage;
                    bill.price = data.price;
                    bill.serial = data.serial;
                    bill.date = data.date;
                    bill.Material = construyeEntities.Materials.Find(data.id_material);
                    bill.Provider = construyeEntities.Providers.Find(data.id_provider);
                    bill.Stage = construyeEntities.Stages.Find(data.id_stage);
                    construyeEntities.SaveChanges();
                    return true;


                }
                catch (Exception e)
                {

                    return false;

                }

            }

        }

    }
}