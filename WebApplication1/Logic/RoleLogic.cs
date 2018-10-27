﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class RoleLogic
    {

        public List<Object> GetListRoles()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var providerList = construyeEntities.Roles.ToList();
                    int n = providerList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < providerList.Count; ++i)
                        {
                            Role_Data data = new Role_Data();
                            data.id_employee = providerList.ElementAt(i).id_employee;
                            data.id_role = providerList.ElementAt(i).id_role;
                            data.start_date = providerList.ElementAt(i).start_date;
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

        public Role_Data GetRoles(int ID)
        {
            Role_Data result = new Role_Data();
            Roles role;
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    if (!this.existRoles(ID))
                    {
                        result = null;
                        return result;
                    }
                    role = construyeEntities.Roles.Find(ID);
                    result.id_employee = role.id_employee;
                    result.id_role = role.id_role;
                    result.start_date = role.start_date;
                    return result;

                }
                catch (Exception E)
                {
                    result = null;
                    return result;
                }
            }
        }

        public bool existRoles(int id)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                var i = construyeEntities.Roles.Find(id);
                if (i == null) return false;
                else return true;
            }
        }


        public bool addRoles(Role_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                Roles role = new Roles();
                role.id_employee = data.id_employee;
                role.id_role = data.id_role;
                role.start_date = data.start_date;
                role.Role_specification = construyeEntities.Role_specification.Find(data.id_role);
                role.Employee = construyeEntities.Employee.Find(data.id_employee);
                try
                {
                    construyeEntities.Roles.Add(role);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }



        public bool eraseRoles(int id)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var ms = construyeEntities.Roles.Find(id);
                    construyeEntities.Roles.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }



        public bool updateRoles(Role_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var role = construyeEntities.Roles.Find(data.id_role);
                    role.id_role = data.id_role;
                    role.id_employee = data.id_employee;
                    role.start_date = data.start_date;
                    role.Role_specification = construyeEntities.Role_specification.Find(data.id_role);
                    role.Employee = construyeEntities.Employee.Find(data.id_employee);
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