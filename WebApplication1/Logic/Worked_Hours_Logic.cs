using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class Worked_Hours_Logic
    {


        public List<Object> GetListWorkedHours()
        {

            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var whList = construyeEntities.Worked_hours.ToList();
                    int n = whList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {
                        for (int i = 0; i < whList.Count; ++i)
                        {
                            Worked_Hours_Data data = new Worked_Hours_Data();
                            data.id = whList.ElementAt(i).id;
                            data.id_employee = whList.ElementAt(i).id_employee;
                            data.id_project = whList.ElementAt(i).id_project;
                            data.hours = whList.ElementAt(i).hours;
                            data.date = whList.ElementAt(i).date;
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



        public Worked_Hours_Data GetWorkedHours(int ID)
        {
            Worked_Hours_Data result = new Worked_Hours_Data();
            Worked_hours wh;
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    if (!this.existWorkedHours(ID))
                    {
                        result = null;
                        return result;
                    }
                    wh = construyeEntities.Worked_hours.Find(ID);
                    result.id = wh.id;
                    result.id_employee = wh.id_employee;
                    result.id_project = wh.id_project;
                    result.hours = wh.hours;
                    result.date = wh.date;
                    return result;

                }
                catch (Exception E)
                {
                    result = null;
                    return result;
                }
            }
        }


        public bool existWorkedHours(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                var i = construyeEntities.Worked_hours.Find(id);
                if (i == null) return false;
                else return true;
            }
        }



        public bool addWorkedHours(Worked_Hours_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                Worked_hours newwh = new Worked_hours();
                newwh.id = data.id;
                newwh.id_employee = data.id_employee;
                newwh.id_project = data.id_project;
                newwh.hours = data.hours;
                newwh.date = data.date;
                newwh.Project = construyeEntities.Projects.Find(data.id_project);
                newwh.Employee = construyeEntities.Employees.Find(data.id_employee);
                
                try
                {
                    construyeEntities.Worked_hours.Add(newwh);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }



        public bool eraseWorkedHours(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var ms = construyeEntities.Worked_hours.Find(id);
                    construyeEntities.Worked_hours.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }



        public bool updateWorkedHours(Worked_Hours_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var wh = construyeEntities.Worked_hours.Find(data.id);
                    wh.id = data.id;
                    wh.id_employee = data.id_employee;
                    wh.id_project = data.id_project;
                    wh.hours = data.hours;
                    wh.date = data.date;
                    wh.Project = construyeEntities.Projects.Find(data.id_project);
                    wh.Employee = construyeEntities.Employees.Find(data.id_employee);
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