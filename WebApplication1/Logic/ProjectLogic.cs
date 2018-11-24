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
                    var projectList = construyeEntities.Projects.ToList();
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
                            Report_Project_Data project = new Report_Project_Data();
                            Project pr;
                            pr = projectList.ElementAt(i);
                            project.id = pr.id;
                            project.id_client = pr.id_client;
                            project.manager = pr.manager;
                            project.name = pr.name;
                            project.ubication = pr.ubication;


                            var costos = construyeEntities.usp_total_bills(pr.id).First();
                            var etapasList = construyeEntities.Stages.Where(e => e.id_project == pr.id).ToList();
                            List<int> idStageList = new List<int>();
                            for (int j = 0; j < etapasList.Count; ++j)
                            {
                                idStageList.Add(etapasList.ElementAt(j).id);
                            }

                            var anotationsList = construyeEntities.Anotations.Where(e => e.id_project == pr.id).ToList();
                            List<int> idAnotationList = new List<int>();
                            for (int j = 0; j < anotationsList.Count; ++j)
                            {
                                idAnotationList.Add(anotationsList.ElementAt(j).id);
                            }

                            if (costos.TotalPresupuesto == null || costos.TotalReal == null)
                            {
                                project.totalCost = 0;
                                project.totalBudget = 0;
                                project.idAnotations = idAnotationList;
                                project.idStages = idStageList;
                                dataList.Add(project);
                                continue;
                            }
                            project.totalCost = (int)costos.TotalReal;
                            project.totalBudget = (int)costos.TotalPresupuesto;
                            project.idAnotations = idAnotationList;
                            project.idStages = idStageList;
                            dataList.Add(project);
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

        public Report_Project_Data GetProject(int id)
        {
            Report_Project_Data project = new Report_Project_Data();
            Project pr;
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    if (!this.existProject(id))
                    {
                        project = null;
                        return project;
                    }
                    pr = construyeEntities.Projects.Where(e => e.id == id).ToList().First();
                    project.id = pr.id;
                    project.id_client = pr.id_client;
                    project.manager = pr.manager;
                    project.name = pr.name;
                    project.ubication = pr.ubication;


                    var costos = construyeEntities.usp_total_bills(id).First();
                    var etapasList = construyeEntities.Stages.Where(e => e.id_project == id).ToList();
                    List<int> idStageList = new List<int>();
                    for (int i = 0; i < etapasList.Count; ++i)
                    {
                        idStageList.Add(etapasList.ElementAt(i).id);
                    }

                    var anotationsList = construyeEntities.Anotations.Where(e => e.id_project == id).ToList();
                    List<int> idAnotationList = new List<int>();
                    for (int i = 0; i < anotationsList.Count; ++i)
                    {
                        idAnotationList.Add(anotationsList.ElementAt(i).id);
                    }

                    project.totalCost = (int)costos.TotalReal;
                    project.totalBudget = (int)costos.TotalPresupuesto;
                    project.idAnotations = idAnotationList;
                    project.idStages = idStageList;

                    return project;

                }
                catch (Exception E)
                {
                    project = null;
                    return project;
                }
            }
        }


        public bool existProject(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                var i = construyeEntities.Projects.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        public bool addProject(Project_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                Project newProject = new Project();
                newProject.id = data.id;
                newProject.id_client = data.id_client;
                newProject.manager = data.manager;
                newProject.name = data.name;
                newProject.ubication = data.ubication;
                newProject.Client = construyeEntities.Clients.Find(data.id_client);
                try
                {
                    construyeEntities.Projects.Add(newProject);
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
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var ms = construyeEntities.Projects.Find(id);
                    construyeEntities.Projects.Remove(ms);
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
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var project = construyeEntities.Projects.Find(data.id);
                    project.id = data.id;
                    project.id_client = data.id_client;
                    project.manager = data.manager;
                    project.name = data.name;
                    project.ubication = data.ubication;
                    project.Client = construyeEntities.Clients.Find(data.id_client);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /*

        public Report_Project_Data getInformeProjectoData(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var costos = construyeEntities.usp_total_bills(id).First();
                    var etapasList = construyeEntities.Stage.Where(e => e.id_project == id).ToList();
                    List<int> idStageList = new List<int>();
                    for (int i = 0; i < etapasList.Count; ++i)
                    {
                        idStageList.Add(etapasList.ElementAt(i).id);
                    }

                    var anotationsList = construyeEntities.Anotations.Where(e => e.id_project == id).ToList();
                    List<int> idAnotationList = new List<int>();
                    for (int i = 0; i < anotationsList.Count; ++i)
                    {
                        idAnotationList.Add(anotationsList.ElementAt(i).id);
                    }
                    Report_Project_Data project = new Report_Project_Data();
                    project.totalCost = (int)costos.TotalReal;
                    project.totalBudget = (int)costos.TotalPresupuesto;
                    project.idAnotations = idAnotationList;
                    project.idStages = idStageList;
                    return project;


                }
                catch (Exception e)
                {
                    return null;
                }
            }
            
        }
        */

    }
}