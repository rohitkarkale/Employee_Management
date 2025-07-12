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
        public ActionResult AddEmployee(EmpDept emp)
        {
            if (!ModelState.IsValid)
            {
                emp.Departments = obj.GetDepartments(); // repopulate dropdown
                return View(emp); // return the view with validation messages
            }

            obj.Employee_Insert(emp); // insert only when valid
            TempData["Success"] = "Employee added successfully!";
            return RedirectToAction("DisplayEmployees");
        }

    }
}