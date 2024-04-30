
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

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }

}