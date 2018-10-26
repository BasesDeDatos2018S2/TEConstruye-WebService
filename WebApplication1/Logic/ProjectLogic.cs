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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var projectList = construyeEntities.Project.ToList();
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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    if (!this.existProject(ID))
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


        public bool existProject(int id)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                var i = construyeEntities.Project.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        public bool addProject(Project_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                Project newProject = new Project();
                newProject.id = data.id;
                newProject.id_client = data.id_client;
                newProject.manager = data.manager;
                newProject.name = data.name;
                newProject.ubication = data.ubication;
                newProject.Client = construyeEntities.Client.Find(data.id_client);
                try
                {
                    construyeEntities.Project.Add(newProject);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool eraseProject(int id)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var ms = construyeEntities.Project.Find(id);
                    construyeEntities.Project.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool updateProject(Project_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var project = construyeEntities.Project.Find(data.id);
                    project.id = data.id;
                    project.id_client = data.id_client;
                    project.manager = data.manager;
                    project.name = data.name;
                    project.ubication = data.ubication;
                    project.Client = construyeEntities.Client.Find(data.id_client);
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