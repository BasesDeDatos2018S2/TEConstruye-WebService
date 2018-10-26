using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    //TODO: AGREGAR A EMPLOYEE EL ID ROLE
    public class RoleSpecificationLogic
    {

        public List<Object> GetListRole()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var providerList = construyeEntities.Role_specification.ToList();
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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    if (!this.existRole(ID))
                    {
                        result = null;
                        return result;
                    }
                    role_Specification = construyeEntities.Role_specification.Find(ID); 
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

        public bool existRole(int id)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                var i = construyeEntities.Role_specification.Find(id);
                if (i == null) return false;
                else return true;
            }
        }


        public bool addRole(RoleSpecification_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                Role_specification role = new Role_specification();
                role.id = data.id_role;
                role.specification = data.specification;

                try
                {
                    construyeEntities.Role_specification.Add(role);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }



        public bool eraseRole(int id)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var ms = construyeEntities.Role_specification.Find(id);
                    construyeEntities.Role_specification.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }



        public bool updateRole(RoleSpecification_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var role = construyeEntities.Role_specification.Find(data.id_role);
                    role.id = data.id_role;
                    role.specification = data.specification;
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