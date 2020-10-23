using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales_MVC.Models;

namespace Sales_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departments = new List<Department>();
            departments.Add(new Department { Id = 1, Name = "Eletronics" });
            departments.Add(new Department { Id = 2, Name = "Computing" });
            departments.Add(new Department { Id = 3, Name = "Tools" });
            departments.Add(new Department { Id = 4, Name = "Home" });
            departments.Add(new Department { Id = 5, Name = "School" });
            departments.Add(new Department { Id = 6, Name = "Fashion" });

            return View(departments);
        }
    }
}
