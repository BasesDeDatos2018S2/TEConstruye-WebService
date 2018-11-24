using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class AnotationsLogic
    {


        public List<Object> GetListAnotations()
        {

            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var anotationsList = construyeEntities.Anotations.ToList();
                    int n = anotationsList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {
                        for (int i = 0; i < anotationsList.Count; ++i)
                        {
                            Anotations_Data data = new Anotations_Data();
                            data.id = anotationsList.ElementAt(i).id;
                            data.id_project = anotationsList.ElementAt(i).id_project;
                            data.date = anotationsList.ElementAt(i).date;
                            data.anotation = anotationsList.ElementAt(i).anotation1;
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



        public Anotations_Data GetAnotation(int ID)
        {
            Anotations_Data result = new Anotations_Data();
            Anotation anotations;
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    if (!this.existAnotation(ID))
                    {
                        result = null;
                        return result;
                    }
                    anotations = construyeEntities.Anotations.Find(ID);
                    result.id = anotations.id;
                    result.id_project = anotations.id_project;
                    result.date = anotations.date;
                    result.anotation = anotations.anotation1;
                    return result;

                }
                catch (Exception E)
                {
                    result = null;
                    return result;
                }
            }
        }


        public bool existAnotation(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                var i = construyeEntities.Anotations.Find(id);
                if (i == null) return false;
                else return true;
            }
        }



        public bool addAnotation(Anotations_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                Anotation newAnotation = new Anotation();
                newAnotation.id = data.id;
                newAnotation.id_project = data.id_project;
                newAnotation.anotation1 = data.anotation;
                newAnotation.date = data.date;
                newAnotation.Project = construyeEntities.Projects.Find(data.id_project);
                try
                {
                    construyeEntities.Anotations.Add(newAnotation);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }



        public bool eraseAnotation(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var ms = construyeEntities.Anotations.Find(id);
                    construyeEntities.Anotations.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }



        public bool updateAnotations(Anotations_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var anotation = construyeEntities.Anotations.Find(data.id);
                    anotation.id = data.id;
                    anotation.id_project = data.id_project;
                    anotation.anotation1 = data.anotation;
                    anotation.date = data.date;
                    anotation.Project = construyeEntities.Projects.Find(data.id_project);
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