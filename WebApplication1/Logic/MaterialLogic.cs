﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class MaterialLogic
    {

        public Material_Data GetMaterial(int id)
        {
            Material_Data material = new Material_Data();
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    if (!this.existMaterial(id))
                    {
                        material = null;
                        return material;
                    }
                    var mat = construyeEntities.Materials.Find(id);
                    material.id = mat.id;
                    material.name = mat.name;
                    material.price = mat.price;
                    material.description = mat.description;
                    return material;

                }
                catch (Exception E)
                {
                    material = null;
                    return material;
                }
            }
        }

        public List<Object> GetListMaterial()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var materialList = construyeEntities.Materials.ToList();
                    int n = materialList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < materialList.Count; ++i)
                        {
                            Material_Data data = new Material_Data();
                            data.id = materialList.ElementAt(i).id;
                            data.name = materialList.ElementAt(i).name;
                            data.price = materialList.ElementAt(i).price;
                            data.description = materialList.ElementAt(i).description;
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

        public bool existMaterial(int id)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                var i = construyeEntities.Materials.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        public bool addMaterial(Material_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                Materials material = new Materials();
                material.id = data.id;
                material.name = data.name;
                material.price = data.price;
                material.description = data.description;
                try
                {
                    construyeEntities.Materials.Add(material);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool eraseEmployee(int id)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var ms = construyeEntities.Employee.Find(id);
                    construyeEntities.Employee.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool updateMaterial(Material_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var material = construyeEntities.Materials.Find(data.id);
                    material.id = data.id;
                    material.name = data.name;
                    material.price = data.price;
                    material.description = data.description;
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