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
		MVCDBDataContext context = new MVCDBDataContext(ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString);

		public List<SelectListItem> GetDepartments()
		{
			List<SelectListItem> Dept = new List<SelectListItem>();  // <selectedList> Used for Dropdown list

			foreach(var item in context.Departments)
			{
				SelectListItem li = new SelectListItem { Text = item.Dname, Value = item.Did.ToString()};
				Dept.Add(li);
			}

			return Dept;
		}
	}
}