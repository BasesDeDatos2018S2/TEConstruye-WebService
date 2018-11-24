using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class StageLogic
    {

        public List<Object> GetListStage()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var stageList = construyeEntities.Stages.ToList();
                    int n = stageList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < stageList.Count; ++i)
                        {
                            Report_Stage_Data data = new Report_Stage_Data();
                            data.id = stageList.ElementAt(i).id;
                            data.id_project = stageList.ElementAt(i).id_project;
                            data.name = stageList.ElementAt(i).name;
                            data.status = stageList.ElementAt(i).status;
                            data.description = stageList.ElementAt(i).description;
                            data.start_date = stageList.ElementAt(i).start_date;
                            data.end_date = stageList.ElementAt(i).end_date;


                            var costos = construyeEntities.usp_total_stage(data.id).First();
                            var idMaterials = construyeEntities.MaterialsxStages.Where(e => e.id_stage == data.id).ToList();
                            List<int> idmaterialList = new List<int>();
                            for (int j = 0; j < idMaterials.Count; ++j)
                            {
                                idmaterialList.Add(idMaterials.ElementAt(j).id_material);
                            }

                            var billList = stageList.ElementAt(i).Bills.ToList();
                            List<int> idbillList = new List<int>();
                            for (int j = 0; j < billList.Count; j++)
                            {
                                idbillList.Add(billList.ElementAt(j).id);
                            }

                            if (costos.TotalPresupuesto == null || costos.TotalReal == null)
                            {
                                data.totalCost = 0;
                                data.totalBudget = 0;
                                data.idMaterials = idmaterialList;
                                data.idBills = idbillList;
                                dataList.Add(data);
                                continue;

                            }
                            data.totalCost = (int)costos.TotalReal;
                            data.totalBudget = (int)costos.TotalPresupuesto;
                            data.idMaterials = idmaterialList;
                            data.idBills = idbillList;
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

        public Report_Stage_Data GetStage(int id)
        {
            Report_Stage_Data result = new Report_Stage_Data();
            Stage data = new Stage();
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    if (!this.existStage(id))
                    {
                        result = null;
                        return result;
                    }
                    data = construyeEntities.Stages.Find(id);
                    result.id = data.id;
                    result.id_project = data.id_project;
                    result.name = data.name;
                    result.start_date = data.start_date;
                    result.status = data.status;
                    result.end_date = data.end_date;
                    result.description = data.description;

                    var costos = construyeEntities.usp_total_stage(id).First();
                    var idMaterials = construyeEntities.MaterialsxStages.Where(e => e.id_stage == id).ToList();
                    List<int> idmaterialList = new List<int>();
                    for (int i = 0; i < idMaterials.Count; ++i)
                    {
                        idmaterialList.Add(idMaterials.ElementAt(i).id_material);
                    }

                    var billList = data.Bills.ToList();
                    List<int> idbillList = new List<int>();
                    for (int i = 0; i < billList.Count; ++i)
                    {
                        idbillList.Add(billList.ElementAt(i).id);
                    }

                    if (costos.TotalPresupuesto == null || costos.TotalReal == null)
                    {
                        result.totalCost = 0;
                        result.totalBudget = 0;
                        result.idMaterials = idmaterialList;
                        result.idBills = idbillList;
                        return result;
 
                    }

                    result.totalCost = (int)costos.TotalReal;
                    result.totalBudget = (int)costos.TotalPresupuesto;
                    result.idMaterials = idmaterialList;
                    result.idBills = idbillList;
                    
                    return result;

                }
                catch (Exception E)
                {
                    result = null;
                    return result;
                }
            }
        }

        public bool existStage(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                var i = construyeEntities.Stages.Find(id);
                if (i == null) return false;
                else return true;
            }
        }



        public bool addStage(Stage_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                Stage newStage = new Stage();
                newStage.id = data.id;
                newStage.id_project = data.id_project;
                newStage.name = data.name;
                newStage.start_date = data.start_date;
                newStage.status = data.status;
                newStage.end_date = data.end_date;
                newStage.description = data.description;
                newStage.Project = construyeEntities.Projects.Find(data.id_project);
                
                try
                {
                    construyeEntities.Stages.Add(newStage);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }



        public bool eraseStage(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var ms = construyeEntities.Stages.Find(id);
                    construyeEntities.Stages.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }



        public bool updateStage(Stage_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var stage = construyeEntities.Stages.Find(data.id);
                    stage.id = data.id;
                    stage.id_project = data.id_project;
                    stage.name = data.name;
                    stage.start_date = data.start_date;
                    stage.status = data.status;
                    stage.end_date = data.end_date;
                    stage.description = data.description;
                    stage.Project = construyeEntities.Projects.Find(data.id_project);
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