using System;
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
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    int i = construyeEntities.Materials.Where(e => e.id == id).ToList().Count;

                    if (i == 0)
                    {
                        material = null;
                        return material;
                    }
                    var mat = construyeEntities.Materials.Where(e => e.id == id).ToList().First();
                    material.id = mat.id;
                    material.name = mat.name;
                    material.price = mat.price;
                    material.detail = mat.description;
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
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var materialList = construyeEntities.Materials.Where(e => e.id != null).ToList();
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
                            data.detail = materialList.ElementAt(i).description;
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

    }
}