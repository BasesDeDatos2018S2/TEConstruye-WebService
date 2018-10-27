using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class ClientLogic
    {


        public ProjectsxClient_Data GetClient(string ssn)
        {
            ProjectsxClient_Data client = new ProjectsxClient_Data();
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
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
                    var projects = construyeEntities.Project.Where(e => e.id_client == ssn).ToList();
                    List<Object> lis = new List<Object>();
                    for (int j = 0; j < projects.Count; ++j)
                    {
                        lis.Add(projects.ElementAt(j).id);
                    }
                    client.projects = lis;
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
                            ProjectsxClient_Data data = new ProjectsxClient_Data();
                            data.identification = clientList.ElementAt(i).identification;
                            data.name = clientList.ElementAt(i).name;
                            data.lastname1 = clientList.ElementAt(i).lastname1;
                            data.lastname2 = clientList.ElementAt(i).lastname2;
                            data.phone = clientList.ElementAt(i).phone;
                            data.email = clientList.ElementAt(i).email;
                            var projects = construyeEntities.Project.Where(e => e.id_client == data.identification).ToList();
                            List<Object> lis = new List<Object>();
                            for (int j = 0; j < projects.Count; ++j)
                            {
                                lis.Add(projects.ElementAt(j).id);
                            }
                            data.projects = lis;
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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                var i = construyeEntities.Client.Find(id);
                if (i == null) return false;
                else return true;

            }
        }

        public bool addClient(Client_Data data)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
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

            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
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

        /*
        public List<Object> getProjectsxClient(string id)
        {
            List<Object> list = new List<Object>();
            List<Object> lis = new List<Object>();
            ProjectsxClient_Data newPxC = new ProjectsxClient_Data();
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {

                try
                {
                    var data = construyeEntities.Client.Find(id);
                    newPxC.identification = data.identification;
                    newPxC.name = data.name;
                    newPxC.lastname1 = data.lastname1;
                    newPxC.lastname2 = data.lastname2;
                    newPxC.phone = data.phone;
                    newPxC.email = data.email;
                    var projects = construyeEntities.Project.Where(e => e.id_client == id).ToList();
                    for (int i = 0; i < projects.Count; ++i)
                    {
                        int ident = projects.ElementAt(i).id;
                        lis.Add(ident);
                        
                    }
                    newPxC.projects = lis;
                    list.Add(newPxC);
                    return list;


                }
                catch (Exception e)
                {

                    return null;

                }

            }

        }
        */



    }
}