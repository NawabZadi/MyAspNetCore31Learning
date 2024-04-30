

namespace PART_19.Models
{
    public class MockEmployeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Amina", Department = "CS", Email = "Amina@gmail.com" } 
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
        
}