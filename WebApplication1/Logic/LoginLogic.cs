using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class LoginLogic
    {

        public bool register(LoginRequest data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                
                Password login = new Password();
                int id = construyeEntities.Employees.Where(e => e.identification == data.ssn).ToList().First().id;
                login.id_employee = id;
                login.password1 = data.password;
                login.Employee = construyeEntities.Employees.Find(id);
                try
                {
                    construyeEntities.Passwords.Add(login);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool revokeRegister(string username)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {

                    var ms = construyeEntities.Passwords.Find(
                        construyeEntities.Employees.Where(e => e.identification == username).ToList().First().id);
                    construyeEntities.Passwords.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public ResponseLoginObject logValidation(LoginRequest log)
        {
            using ( TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                ResponseLoginObject response = new ResponseLoginObject();
                try
                {
                    int id = construyeEntities.Employees.Where(e => e.identification == log.ssn).ToList().First().id;
                    var loginRequest = construyeEntities.Passwords.Find(id);
                    if (!(loginRequest.id_employee == id && loginRequest.password1 == log.password))
                    {
                        response.status = false;
                        response.role = null;
                        return response;
                    }
                    if (loginRequest == null)
                    {
                        response.status = false;
                        response.role = null;
                        return response;
                    }
                    else
                    {
                        var temp = construyeEntities.Roles.Where(e => e.id_employee == loginRequest.id_employee).ToList();
                        if (temp == null)
                        {
                            return null;
                        }
                        for (int j = 0; j < temp.Count; ++j)
                        {
                            if (temp.ElementAt(j).Role_specification.specification.Equals("Administrador"))
                            {
                                response.status = true;
                                response.role = "Administrador";
                                return response;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        for (int i = 0; i < temp.Count; ++i)
                        {
                            string ab = temp.ElementAt(i).Role_specification.specification;
                            string ac = temp.ElementAt(i).Role_specification.specification;
                            bool a = ab.Substring(0,3).Equals("Ing");
                            bool b = ac.Equals("Arquitecto");

                            if (a ||  b)
                            {
                                response.status = true;
                                response.role = "mediumAccess";
                                return response;
                            }
                          
                            else {
                                response.status = false;
                                response.role = temp.ElementAt(i).Role_specification.specification;
                                continue;
                            }
                        }
                        return response;
                    }
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public bool existAccount(string ids)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                if (ids.Equals(""))
                {
                    return false;
                }
                int id = construyeEntities.Employees.Where(e => e.identification == ids).ToList().First().id;
                var i = construyeEntities.Passwords.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

    }
}