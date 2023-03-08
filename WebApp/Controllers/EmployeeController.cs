using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using WebApp.Database;
using WebApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            var entities = _context.Employee.ToList();
            return View(entities);
        }

        public ActionResult GetEmployeeInfo()
        {
            var empInfo = _context.GetEmployeeInfo("ASC").ToList();
            return View(empInfo);
        }

        [HttpPost]
        public ActionResult GetEmployeeInfo(string filter)
        {
            var empInfo = _context.GetEmployeeInfo(filter).ToList();
            return View(empInfo);
        }

    }
}
