using System;
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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    int i = construyeEntities.Employee.Where(e => e.id == ID).ToList().Count;

                    if (i == 0)
                    {
                        employee = null;
                        return employee;
                    }
                    var emp = construyeEntities.Employee.Where(e => e.id == ID).ToList().First();
                    employee.id = emp.id;
                    employee.ssn = emp.identification;
                    employee.fname = emp.name;
                    employee.lname1 = emp.lastname1;
                    employee.lname2 = emp.lastname2;
                    employee.phone = emp.phone;
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
            using (TeConstruyeEntities construyeEntities = new TeConstruyeEntities())
            {
                try
                {
                    var employeeList = construyeEntities.Employee.Where(e => e.id != null).ToList();
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
                            data.ssn = employeeList.ElementAt(i).identification;
                            data.fname = employeeList.ElementAt(i).name;
                            data.lname1 = employeeList.ElementAt(i).lastname1;
                            data.lname2 = employeeList.ElementAt(i).lastname2;
                            data.phone = employeeList.ElementAt(i).phone;
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