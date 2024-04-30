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

        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }
    }
}
