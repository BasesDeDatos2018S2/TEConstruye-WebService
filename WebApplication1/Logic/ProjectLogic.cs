using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class ProjectLogic
    {

        public List<Object> GetListProject()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var projectList = construyeEntities.Project.Where(e => e.id != null).ToList();
                    int n = projectList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < projectList.Count; ++i)
                        {
                            Project_Data data = new Project_Data();
                            data.id = projectList.ElementAt(i).id;
                            data.id_client = projectList.ElementAt(i).id_client;
                            data.manager = projectList.ElementAt(i).manager;
                            data.name = projectList.ElementAt(i).name;
                            data.ubication = projectList.ElementAt(i).ubication;
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

        public Project_Data GetProject(int ID)
        {
            Project_Data result = new Project_Data();
            Project project;
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    int i = construyeEntities.Project.Where(e => e.id == ID).ToList().Count;

                    if (i == 0)
                    {
                        result = null;
                        return result;
                    }
                    project = construyeEntities.Project.Where(e => e.id == ID).ToList().First();
                    result.id = project.id;
                    result.id_client = project.id_client;
                    result.manager = project.manager;
                    result.name = project.name;
                    result.ubication = project.ubication;
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