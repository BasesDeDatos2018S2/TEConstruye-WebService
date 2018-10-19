using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class ClientLogic
    {


        public Client_Data GetClient(string ssn)
        {
            Client_Data client = new Client_Data();
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    int i = construyeEntities.Client.Where(e => e.identification == ssn).ToList().Count;

                    if (i == 0)
                    {
                        client = null;
                        return client;
                    }
                    var cli = construyeEntities.Client.Where(e => e.identification == ssn).ToList().First();
                    client.ssn = cli.identification;
                    client.fname = cli.name;
                    client.lname1 = cli.lastname1;
                    client.lname2 = cli.lastname2;
                    client.phone = cli.phone;
                    client.email = cli.email;
                    return client;

                }
                catch (Exception E)
                {
                    client = null;
                    return client;
                }
            }
        }

        public List<Object> GetListClient()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var clientList = construyeEntities.Client.Where(e => e.identification != null).ToList();
                    int n = clientList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < clientList.Count; ++i)
                        {
                            Client_Data data = new Client_Data();
                            data.ssn = clientList.ElementAt(i).identification;
                            data.fname = clientList.ElementAt(i).name;
                            data.lname1 = clientList.ElementAt(i).lastname1;
                            data.lname2 = clientList.ElementAt(i).lastname2;
                            data.phone = clientList.ElementAt(i).phone;
                            data.email = clientList.ElementAt(i).email;
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