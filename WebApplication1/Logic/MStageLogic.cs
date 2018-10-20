using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class MStageLogic
    {

        public List<Object> GetListMStage()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var mstageList = construyeEntities.MaterialsxStage.Where(e => e.id_material != null).ToList();
                    int n = mstageList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < mstageList.Count; ++i)
                        {
                            MStage_Data data = new MStage_Data();
                            data.id_material = mstageList.ElementAt(i).id_material;
                            data.id_stage = mstageList.ElementAt(i).id_stage;
                            data.price = mstageList.ElementAt(i).price;
                            data.quantity = mstageList.ElementAt(i).quantity;

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

        public MStage_Data GetMStage(int id_material, int id_stage)
        {
            MStage_Data result = new MStage_Data();
            MaterialsxStage materialsxStage;
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    int i = construyeEntities.MaterialsxStage.Where(e => e.id_material == id_material && e.id_stage == id_stage).ToList().Count;

                    if (i == 0)
                    {
                        result = null;
                        return result;
                    }
                    materialsxStage = construyeEntities.MaterialsxStage.Where(e => e.id_material == id_material && e.id_stage == id_stage).ToList().First();
                    result.id_material = materialsxStage.id_material;
                    result.id_stage = materialsxStage.id_stage;
                    result.price = materialsxStage.price;
                    result.quantity = materialsxStage.quantity;
                    return result;

                }
                catch (Exception E)
                {
                    result = null;
                    return result;
                }
            }
        }

        public bool existeMStage(int id_stage, int id_material)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                int i = construyeEntities.MaterialsxStage.Where(e => e.id_material == id_material && e.id_stage == id_stage).ToList().Count();
                if (i == 0) return false;
                else return true;

            }
        }

        public bool addMStage(MStage_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {

                MaterialsxStage newMs = new MaterialsxStage();
                newMs.id_material = data.id_material;
                newMs.id_stage = data.id_stage;
                newMs.price = data.price;
                newMs.quantity = data.quantity;
                newMs.Materials = construyeEntities.Materials.Where(e => e.id == newMs.id_material).ToList().First();
                newMs.Stage = construyeEntities.Stage.Where(e => e.id == newMs.id_stage).ToList().First();
                try
                {
                    construyeEntities.MaterialsxStage.Add(newMs);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }


            }
        }

        public bool eraseMStage(int id_stage, int id_material)
        {

            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var ms = construyeEntities.MaterialsxStage.Find(id_stage, id_material);
                    construyeEntities.MaterialsxStage.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
                

            }

        }

        public bool updateMStage(MStage_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {

                try
                {
                    var ms = construyeEntities.MaterialsxStage.Find(data.id_stage, data.id_material);
                    ms.price = data.price;
                    ms.quantity = data.quantity;
                    ms.Materials = construyeEntities.Materials.Find(data.id_material);
                    ms.Stage = construyeEntities.Stage.Find(data.id_stage);



                }
                catch (Exception e)
                {



                }

            }

        }

    }
}