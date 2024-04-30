using Microsoft.AspNetCore.Mvc;
using PART_19.Models;
using System.Diagnostics;
using EmployeeManagement.Models;
using EmployeeManagement.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace PART_19.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        // It is through IDataProtector interface Protect and Unprotect methods,
        // we encrypt and decrypt respectively
        private readonly IDataProtector protector;

        // It is the CreateProtector() method of IDataProtectionProvider interface
        // that creates an instance of IDataProtector. CreateProtector() requires
        // a purpose string. So both IDataProtectionProvider and the class that
        // contains our purpose strings are injected using the contructor
        public HomeController(IEmployeeRepository employeeRepository,
                              IDataProtectionProvider dataProtectionProvider,
                              DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            _employeeRepository = employeeRepository;
            // Pass the purpose string as a parameter
            this.protector = dataProtectionProvider.CreateProtector(
                dataProtectionPurposeStrings.EmployeeIdRouteValue);
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee()
                            .Select(e =>
                            {
                                // Encrypt the ID value and store in EncryptedId property
                                e.EncryptedId = protector.Protect(e.Id.ToString());
                                return e;
                            });
            return View(model);
        }

        // Details view receives the encrypted employee ID
        [AllowAnonymous]
        public ViewResult Details(string id)
        {
            // Decrypt the employee id using Unprotect method
            string decryptedId = protector.Unprotect(id);
            int decryptedIntId = Convert.ToInt32(decryptedId);

            Employee employee = _employeeRepository.GetEmployee(decryptedIntId);

            return View(employee);
        }
    }
}

