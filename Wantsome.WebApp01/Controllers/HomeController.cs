using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.Mvc;
using Wantsome.WebApp01.Models;
using Wantsome.WebApp01.Models.Employee;

namespace Wantsome.WebApp01.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeManager manager;

        public HomeController()
        {
            manager = new EmployeeManager();
        }

        // GET /
        // GET /home/
        // GET /home/index
        public ActionResult Index()
        {
            var employees = manager.GetAll();

            //Views/Home/Index.cshtml
            return View(employees); //employees - (@model in view)
        }

        // GET /home/details/{id} - id un tip de param (uri param)
        public ActionResult Details(string id)
        {
            var employee = manager.Get(id);

            //Views/Home/Details.cshtml
            return View(employee); //employee - (@model in view)
        }

        // GET /home/add
        [HttpGet]
        public ActionResult Add(string id)
        {
            if (id == null)
            {
                return View();
            }

            var emp = manager.Get(id);

            //Views/Home/Add.cshtml
            return View(emp);
        }

        // POST /home/add + request body
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                manager.Save(employee);

                return Redirect("Index");
            }

            //Views/Home/Add.cshtml
            return View(employee);
        }
    }
}