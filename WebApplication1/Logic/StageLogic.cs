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
                    var stageList = construyeEntities.Stage.Where(e => e.id != null).ToList();
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
                            data.projectName = stageList.ElementAt(i).Project.name;
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
            Stage stage;
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    int i = construyeEntities.Stage.Where(e => e.id == ID).ToList().Count;

                    if (i == 0)
                    {
                        result = null;
                        return result;
                    }
                    stage = construyeEntities.Stage.Where(e => e.id == ID).ToList().First();
                    result.id = stage.id;
                    result.projectName = stage.Project.name;
                    result.name = stage.name;
                    result.status = stage.status;
                    result.description = stage.description;
                    result.start_date = stage.start_date;
                    result.end_date = stage.end_date;
                    return result;

                }
                catch (Exception E)
                {
                    result = null;
                    return result;
                }
            }
        }

    }
}