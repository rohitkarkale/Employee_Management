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
        public ViewResult DisplayEmployees(bool? status)
        {
            return View(obj.GetEmployees(true));
        }


        public ViewResult DisplayEmployee(int Eid)
        {
            return View(obj.GetEmployee(Eid,true));
        }
    }
}