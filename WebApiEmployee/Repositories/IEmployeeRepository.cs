using WebApiEmployee.Model;

namespace WebApiEmployee.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> getEmployees();
        Employee getEmployee(int id);

        int AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        int DeleteEmployee(int id);
    }
}
