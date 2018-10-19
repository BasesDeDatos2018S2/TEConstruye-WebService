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
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var providerList = construyeEntities.Provider.Where(e => e.id != null).ToList();
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
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    int i = construyeEntities.Bill.Where(e => e.id == ID).ToList().Count;

                    if (i == 0)
                    {
                        result = null;
                        return result;
                    }
                    provider = construyeEntities.Provider.Where(e => e.id == ID).ToList().First();
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


    }
}