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
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {  
                    if (!this.existClient(ssn))
                    {
                        client = null;
                        return client;
                    }
                    var cli = construyeEntities.Client.Find(ssn);
                    client.identification = cli.identification;
                    client.name = cli.name;
                    client.lastname1 = cli.lastname1;
                    client.lastname2 = cli.lastname2;
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
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var clientList = construyeEntities.Client.ToList();
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
                            data.identification = clientList.ElementAt(i).identification;
                            data.name = clientList.ElementAt(i).name;
                            data.lastname1 = clientList.ElementAt(i).lastname1;
                            data.lastname2 = clientList.ElementAt(i).lastname2;
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

        public bool existClient(string id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                var i = construyeEntities.Client.Find(id);
                if (i == null) return false;
                else return true;

            }
        }

        public bool addClient(Client_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {

                Client newClient = new Client();
                newClient.identification = data.identification;
                newClient.name = data.name;
                newClient.lastname1 = data.lastname1;
                newClient.lastname2 = data.lastname2;
                newClient.phone = data.phone;
                newClient.email = data.email;
                try
                {
                    construyeEntities.Client.Add(newClient);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }


            }
        }

        public bool eraseClient(string id)
        {

            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var ms = construyeEntities.Client.Find(id);
                    construyeEntities.Client.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }


            }

        }

        public bool updateClient(Client_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {

                try
                {
                    var client = construyeEntities.Client.Find(data.identification);
                    client.identification = data.identification;
                    client.name = data.name;
                    client.lastname1 = data.lastname1;
                    client.lastname2 = data.lastname2;
                    client.phone = data.phone;
                    client.email = data.email;
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