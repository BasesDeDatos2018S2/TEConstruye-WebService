﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Logic
{
    public class EmployeeLogic
    {
        public Employee_Data GetEmployee(int ID)
        {
            Employee_Data employee = new Employee_Data();
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    if (!this.existEmployee(ID))
                    {
                        employee = null;
                        return employee;
                    }
                    var emp = construyeEntities.Employees.Find(ID);
                    employee.id = emp.id;
                    employee.identification = emp.identification;
                    employee.name = emp.name;
                    employee.lastname1 = emp.lastname1;
                    employee.lastname2 = emp.lastname2;
                    employee.phone = emp.phone;
                    employee.hour_cost = emp.hour_cost;
                    return employee;

                }
                catch (Exception E)
                {
                    employee = null;
                    return employee;
                }
            }
        }

        public List<Object> GetListEmployee()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var employeeList = construyeEntities.Employees.ToList();
                    int n = employeeList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < employeeList.Count; ++i)
                        {
                            Employee_Data data = new Employee_Data();
                            data.id = employeeList.ElementAt(i).id;
                            data.identification = employeeList.ElementAt(i).identification;
                            data.name = employeeList.ElementAt(i).name;
                            data.lastname1 = employeeList.ElementAt(i).lastname1;
                            data.lastname2 = employeeList.ElementAt(i).lastname2;
                            data.phone = employeeList.ElementAt(i).phone;
                            data.hour_cost = employeeList.ElementAt(i).hour_cost;
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

        public bool existEmployee(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                var i = construyeEntities.Employees.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        public bool addEmployee(Employee_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                Employee newEmployee = new Employee();
                newEmployee.id = data.id;
                newEmployee.identification = data.identification;
                newEmployee.name = data.name;
                newEmployee.lastname1 = data.lastname1;
                newEmployee.lastname2 = data.lastname2;
                newEmployee.phone = data.phone;
                newEmployee.hour_cost = data.hour_cost;
                try
                {
                    construyeEntities.Employees.Add(newEmployee);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool eraseEmployee(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var ms = construyeEntities.Employees.Find(id);
                    construyeEntities.Employees.Remove(ms);
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool updateEmployee(Employee_Data data)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var employee = construyeEntities.Employees.Find(data.id);
                    employee.id = data.id;
                    employee.identification = data.identification;
                    employee.name = data.name;
                    employee.lastname1 = data.lastname1;
                    employee.lastname2 = data.lastname2;
                    employee.phone = data.phone;
                    employee.hour_cost = data.hour_cost;
                    construyeEntities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public List<Object> getRolesXEmployee(int id)
        {
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                List<Object> client = new List<Object>();
                try
                {
                    if (!this.existEmployee(id))
                    {
                        client = null;
                        return client;
                    }
                    var roles = construyeEntities.Roles.Where(e => e.id_employee == id).ToList();
                    for (int i = 0; i < roles.Count; ++i)
                    {
                        RoleSpecification_Data roleData = new RoleSpecification_Data();
                        roleData.id_role = roles.ElementAt(i).Role_specification.id;
                        roleData.specification = roles.ElementAt(i).Role_specification.specification;
                        client.Add(roleData);
                    }
                    return client;

                }
                catch (Exception E)
                {
                    client = null;
                    return client;
                }
            }
        }


        public List<Object> GetAllProjectManagers()
        {
            List<Object> dataList = new List<object>();
            using (TeConstruyeEntities1 construyeEntities = new TeConstruyeEntities1())
            {
                try
                {
                    var employeeList = construyeEntities.usp_posible_manager().ToList();
                    int n = employeeList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < employeeList.Count; ++i)
                        {
                            Employee_Data data = new Employee_Data();
                            data.id = employeeList.ElementAt(i).Id_Employee;
                            data.identification = employeeList.ElementAt(i).Identification;
                            data.name = employeeList.ElementAt(i).Name;
                            data.lastname1 = employeeList.ElementAt(i).Lastname1;
                            data.lastname2 = employeeList.ElementAt(i).Lastname2;
                            data.phone = employeeList.ElementAt(i).Phone;
                            data.hour_cost = employeeList.ElementAt(i).hour_cost;
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