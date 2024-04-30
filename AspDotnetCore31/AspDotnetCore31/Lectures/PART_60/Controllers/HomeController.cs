using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using PART_19.Models;
using System.Diagnostics;

namespace PART_19.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        public ViewResult Details(int? id)
        {
            throw new Exception("Error in Details View");

            // Rest of the code
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Rest of the code
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }

            return View();
        }

    }
    
}
