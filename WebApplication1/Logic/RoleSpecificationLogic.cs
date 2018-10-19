using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class RoleSpecificationLogic
    {

        public List<Object> GetListRole()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var providerList = construyeEntities.Role_specification.Where(e => e.id != null).ToList();
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
                            RoleSpecification_Data data = new RoleSpecification_Data();
                            data.id_role = providerList.ElementAt(i).id;
                            data.specification = providerList.ElementAt(i).specification;
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

        public RoleSpecification_Data GetRole(int ID)
        {
            RoleSpecification_Data result = new RoleSpecification_Data();
            Role_specification role_Specification;
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    int i = construyeEntities.Role_specification.Where(e => e.id == ID).ToList().Count;

                    if (i == 0)
                    {
                        result = null;
                        return result;
                    }
                    role_Specification = construyeEntities.Role_specification.Where(e => e.id == ID).ToList().First();
                    result.id_role = role_Specification.id;
                    result.specification = role_Specification.specification;
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