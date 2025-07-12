using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeDAL obj = new EmployeeDAL();
        public ViewResult DisplayEmployees(bool? status)   // Displays the list of employees 
        {
            return View(obj.GetEmployees(true));
        }

        public ViewResult DisplayEmployee(int Eid)
        {
            return View(obj.GetEmployee(Eid,true));
        }

        [HttpGet]
        public ViewResult AddEmployee()   // Shows the empty form and department dropdown
        {
            EmpDept emp = new EmpDept();
            emp.Departments = obj.GetDepartments();
            return View(emp);
        }

        [HttpPost]
        public RedirectToRouteResult AddEmployee(EmpDept emp)  // Handles form submission and adds the employee to the database
        {
            obj.Employee_Insert(emp);  // Insert into DB
            return RedirectToAction("DisplayEmployees");  // Go back to the employee list
        }
    }
}