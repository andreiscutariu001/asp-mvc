using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Wantsome.WebApp01.Models;

namespace Wantsome.WebApp01.Controllers
{
    public class HomeController : Controller
    {
        //site/
        //site/home/
        //site/home/index
        public ActionResult Index()
        {
            var employees = GetList();

            //in folderul views
            //Views/Home/Index.cshtml
            return View(employees); //employees - modelul (prezent @model in view)
        }

        //site/home/details/{id} - id un tip de param (uri param)
        public ActionResult Details(string id)
        {
            var employees = GetList();
            var employee = FindById(employees, id);

            //Views/Home/Details.cshtml
            return View(employee); //employee - modelul (prezent @model in view)
        }

        private Employee FindById(List<Employee> employees, string id)
        {
            foreach (var employee in employees)
            {
                if (employee.Id == id)
                {
                    return employee;
                }
            }

            return null;
        }

        private List<Employee> GetList()
        {
            var e1 = new Employee { Id = "1", Name = "Daniel", Email = "Daniel@yahoo.com " };
            var e2 = new Employee { Id = "2", Name = "Vasile", Email = "Vasile@yahoo.com " };
            var e3 = new Employee { Id = "3", Name = "Popescu", Email = "Popescu@yahoo.com " };

            return new List<Employee> { e1, e2, e3 };
        }
    }
}