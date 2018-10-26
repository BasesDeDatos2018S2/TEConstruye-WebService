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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                
                Passwords login = new Passwords();
                login.id_employee = data.id_employee;
                login.password = data.password;
                login.Employee = construyeEntities.Employee.Find(data.id_employee);
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

        public bool revokeRegister(int username)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var ms = construyeEntities.Passwords.Find(username);
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
            using ( TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                ResponseLoginObject response = new ResponseLoginObject();
                try
                {
                    var loginRequest = construyeEntities.Passwords.Find(log.id_employee);
                    if (!(loginRequest.id_employee == log.id_employee && loginRequest.password == log.password))
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
                            
                            if (temp.ElementAt(i).Role_specification.specification.Substring(0, 9).Equals("Ingeniero") || 
                                temp.ElementAt(i).Role_specification.specification.Equals("Arquitecto"))
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

        public bool existAccount(int id)
        {
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                var i = construyeEntities.Passwords.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

    }
}