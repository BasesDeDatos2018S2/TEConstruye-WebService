﻿using System;
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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var stageList = construyeEntities.Stage.ToList();
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
                            Stage_Data data = new Stage_Data();
                            data.id = stageList.ElementAt(i).id;
                            data.id_project = stageList.ElementAt(i).id_project;
                            data.name = stageList.ElementAt(i).name;
                            data.status = stageList.ElementAt(i).status;
                            data.description = stageList.ElementAt(i).description;
                            data.start_date = stageList.ElementAt(i).start_date;
                            data.end_date = stageList.ElementAt(i).end_date;
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

        public Stage_Data GetStage(int ID)
        {
            Stage_Data result = new Stage_Data();
            Stage data = new Stage();
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    if (!this.existStage(ID))
                    {
                        result = null;
                        return result;
                    }
                    data = construyeEntities.Stage.Find(ID);
                    result.id = data.id;
                    result.id_project = data.id_project;
                    result.name = data.name;
                    result.start_date = data.start_date;
                    result.status = data.status;
                    result.end_date = data.end_date;
                    result.description = data.description;
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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                var i = construyeEntities.Stage.Find(id);
                if (i == null) return false;
                else return true;
            }
        }



        public bool addStage(Stage_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                Stage newStage = new Stage();
                newStage.id = data.id;
                newStage.id_project = data.id_project;
                newStage.name = data.name;
                newStage.start_date = data.start_date;
                newStage.status = data.status;
                newStage.end_date = data.end_date;
                newStage.description = data.description;
                newStage.Project = construyeEntities.Project.Find(data.id_project);
                
                try
                {
                    construyeEntities.Stage.Add(newStage);
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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var ms = construyeEntities.Stage.Find(id);
                    construyeEntities.Stage.Remove(ms);
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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var stage = construyeEntities.Stage.Find(data.id);
                    stage.id = data.id;
                    stage.id_project = data.id_project;
                    stage.name = data.name;
                    stage.start_date = data.start_date;
                    stage.status = data.status;
                    stage.end_date = data.end_date;
                    stage.description = data.description;
                    stage.Project = construyeEntities.Project.Find(data.id_project);
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