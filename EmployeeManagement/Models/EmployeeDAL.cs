using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EmployeeManagement.Models
{
	public class EmployeeDAL
	{
		MVCDBDataContext dc = new MVCDBDataContext(ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString);

		public List<SelectListItem> GetDepartments()
		{
			List<SelectListItem> Dept = new List<SelectListItem>();  // Creates an empty list to store department items.

            foreach (var item in dc.Departments)
			{
				SelectListItem li = new SelectListItem { Text = item.Dname, Value = item.Did.ToString()}; // Text -> the name of the department(Display in dropdown),  value -> the id of the department(used for storing in database).
				Dept.Add(li);
			}

			return Dept;
		}

        public List<EmpDept> GetEmployees(bool? status)
        {
            dynamic records;

            if(status != null)
            {
                records = (from E in dc.Employees
                           join D in dc.Departments on E.Did equals D.Did
                           where E.Status == true // Even though the method accepts any Status, this code hardcodes true. So even if you pass false, it won't return inactive employees. This is likely a mistake.
                           select new
                           {
                               E.Eid,
                               E.Ename,
                               E.Job,
                               E.Salary,
                               D.Did,
                               D.Dname,
                               D.Location
                           }).ToList();
            }
            else
            {
                records = (from E in dc.Employees
                           join D in dc.Departments on E.Did equals D.Did // If Status is null, it selects all employees without filtering by status.
                           select new
                           {
                               E.Eid,
                               E.Ename,
                               E.Job,
                               E.Salary,
                               D.Did,
                               D.Dname,
                               D.Location,
                           });
            }

            List<EmpDept> Emps = new List<EmpDept>();

            foreach( var record in records)
            {
                EmpDept emp = new EmpDept
                {
                    EId = record.Eid,
                    Ename = record.Ename,
                    Job = record.Job,
                    Salary = record.Salary,
                    Did = record.Did,
                    Dname = record.Dname,
                    Location = record.Location,
                 
                };

                Emps.Add(emp); // Adds each employee's details to the list.
            }

            return Emps; // Returns the list of employees with their department details.
        }


        // This method retrieves an employee's details along with their department information based on the provided employee ID and status.
        public EmpDept GetEmployee(int Eid, bool? status)
		{
			dynamic record;
            if (status == null)
            {
                record = (from E in dc.Employees
                          join D in dc.Departments on E.Did equals D.Did
                          where E.Eid == Eid
                          select new
                          {
                              E.Eid,
                              E.Ename,
                              E.Job,
                              E.Salary,
                              D.Did,
                              D.Dname,
                              D.Location
                          }).Single();
            }
            else
            {
                record = (from E in dc.Employees
                          join D in dc.Departments on E.Did equals D.Did
                          where E.Eid == Eid && E.Status == status
                          select new
                          {
                              E.Eid,
                              E.Ename,
                              E.Job,
                              E.Salary,
                              D.Did,
                              D.Dname,
                              D.Location
                          }).Single();
            }

            EmpDept Emp = new EmpDept
            {
                EId = record.Eid,
                Ename = record.Ename,
                Job = record.Job,
                Salary = record.Salary,
                Did = record.Did,
                Dname = record.Dname,
                Location = record.Location
            };

            return Emp;
        }
    }
}