using System.Collections.Generic;
using System.Web.Mvc;
using Wantsome.WebApp01.Models;

namespace Wantsome.WebApp01.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeManager manager;

        public HomeController()
        {
            manager = new EmployeeManager();
        }

        //site/
        //site/home/
        //site/home/index
        public ActionResult Index()
        {
            var employees = manager.GetAll();

            //in folderul views
            //Views/Home/Index.cshtml
            return View(employees); //employees - modelul (prezent @model in view)
        }

        //site/home/details/{id} - id un tip de param (uri param)
        public ActionResult Details(string id)
        {
            var employee = manager.Get(id);

            //Views/Home/Details.cshtml
            return View(employee); //employee - modelul (prezent @model in view)
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                manager.Save(employee);

                return Redirect("Index");
            }

            return View(employee);
        }
    }
}