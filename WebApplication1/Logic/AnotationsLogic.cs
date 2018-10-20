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
                    var anotationsList = construyeEntities.Anotations.Where(e => e.id != null).ToList();
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
                            data.anotation = anotationsList.ElementAt(i).anotation;
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
            Anotations anotations;
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    int i = construyeEntities.Anotations.Where(e => e.id == ID).ToList().Count;

                    if (i == 0)
                    {
                        result = null;
                        return result;
                    }
                    anotations = construyeEntities.Anotations.Where(e => e.id == ID).ToList().First();
                    result.id = anotations.id;
                    result.id_project = anotations.id_project;
                    result.date = anotations.date;
                    result.anotation = anotations.anotation;
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