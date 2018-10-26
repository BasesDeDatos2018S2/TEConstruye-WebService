using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class ProviderLogic
    {

        public List<Object> GetListProvider()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var providerList = construyeEntities.Provider.ToList();
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
                            Provider_Data data = new Provider_Data();
                            data.id = providerList.ElementAt(i).id;
                            data.name = providerList.ElementAt(i).name;
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

        public Provider_Data GetProvider(int ID)
        {
            Provider_Data result = new Provider_Data();
            Provider provider;
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                { 
                    if (!this.existProvider(ID))
                    {
                        result = null;
                        return result;
                    }
                    provider = construyeEntities.Provider.Find(ID);
                    result.id = provider.id;
                    result.name = provider.name;
                    return result;

                }
                catch (Exception E)
                {
                    result = null;
                    return result;
                }
            }
        }

        public bool existProvider(int id)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                var i = construyeEntities.Provider.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        public bool addProvider(Provider_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                Provider newProvider = new Provider();
                newProvider.id = data.id;
                newProvider.name = data.name;
                try
                {
                    construyeEntities.Provider.Add(newProvider);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool eraseProvider(int id)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var ms = construyeEntities.Provider.Find(id);
                    construyeEntities.Provider.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool updateProvider(Provider_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var provider = construyeEntities.Provider.Find(data.id);
                    provider.id = data.id;
                    provider.name = data.name;
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