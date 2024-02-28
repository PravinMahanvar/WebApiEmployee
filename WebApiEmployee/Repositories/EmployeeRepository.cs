using WebApiEmployee.Data;
using WebApiEmployee.Model;

namespace WebApiEmployee.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddEmployee(Employee employee)
        {
           db.Employees.Add(employee);
            int result =db.SaveChanges();
            return result;
        }

        public int DeleteEmployee(int id)
        {
            int res = 0;
            var result= db.Employees.Where(X => X.Id == id).FirstOrDefault();
            if (result != null)
            {
                db.Employees.Remove(result);// remove for db set
                res =db.SaveChanges();

            }
            return res;
        }

        public Employee getEmployee(int id)
        {
            var result = db.Employees.Where(X => X.Id == id).FirstOrDefault();
            return result;

        }
        public IEnumerable<Employee> getEmployees()
        {
           return db.Employees.ToList();
        }

        public int UpdateEmployee(Employee employee)
        {
            int res = 0;
            var result = db.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (result != null)
            {
                result.Name = employee.Name;
                result.Age = employee.Age;
                result.salary = employee.salary;
                result.City = employee.City;
                result.Contactno = employee.Contactno;
                res = db.SaveChanges();
            }
            return res;


        }
    }
}
