using WebApiEmployee.Model;
using WebApiEmployee.Repositories;

namespace WebApiEmployee.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository repo;
        public EmployeeService(IEmployeeRepository repo)
        {
          this.repo = repo;
        }

        public int AddEmployee(Employee employee)
        {
           return repo.AddEmployee(employee);
        }

        public int DeleteEmployee(int id)
        {
            return repo.DeleteEmployee(id);
        }

        public Employee GetEmployeeById(int id)
        {
           return repo.getEmployee(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
           return repo.getEmployees();
        }

        public int UpdateEmployee(Employee employee)
        {
           return repo.UpdateEmployee(employee);
        }
    }
}
