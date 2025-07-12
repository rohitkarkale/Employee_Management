using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Models
{
	public class EmpDept
	{
		public int EId { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        public string Ename { get; set; }

        [Required(ErrorMessage = "Job title is required")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(1000, 1000000, ErrorMessage = "Salary must be between ₹1,000 and ₹10,00,000")]
        public decimal Salary  { get; set; }

        [Required(ErrorMessage = "Please select a department")]
        public int? Did { get; set; }
        public string Dname { get; set; }
        public string Location { get; set; }
        public List<SelectListItem> Departments { get; set; }

    }
}