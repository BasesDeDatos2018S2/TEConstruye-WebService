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
                    var mstageList = construyeEntities.MaterialsxStages.ToList();
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
                    if (!this.existMStage(id_stage, id_material))
                    {
                        result = null;
                        return result;
                    }
                    materialsxStage = construyeEntities.MaterialsxStages.Find(id_stage, id_material);
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

        public bool existMStage(int id_stage, int id_material)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                var i = construyeEntities.MaterialsxStages.Find(id_stage, id_material);
                if (i == null) return false;
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
                newMs.Material = construyeEntities.Materials.Find(data.id_material);
                newMs.Stage = construyeEntities.Stages.Find(data.id_stage);
                try
                {
                    construyeEntities.MaterialsxStages.Add(newMs);
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
                    var ms = construyeEntities.MaterialsxStages.Find(id_stage, id_material);
                    construyeEntities.MaterialsxStages.Remove(ms);
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
                    var ms = construyeEntities.MaterialsxStages.Find(data.id_stage, data.id_material);
                    ms.id_material = data.id_material;
                    ms.id_stage = data.id_stage;
                    ms.price = data.price;
                    ms.quantity = data.quantity;
                    ms.Material = construyeEntities.Materials.Find(data.id_material);
                    ms.Stage = construyeEntities.Stages.Find(data.id_stage);
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