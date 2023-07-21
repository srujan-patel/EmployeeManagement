using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Server.Dal.Repositories
{
  
        public interface IEmployeeRepository
        {


            Task<IEnumerable<Employee>> GetEmployees();
            Task<Employee> GetEmployee(int employeeId);

            Task<Employee> AddEmployee(Employee employee);
            Task<Employee> UpdateEmployee(Employee employee);

            Task<Employee> GetEmployeebyEmail(string email);


             Task<Employee> DeleteEmployee(int employeeId);
        }
    }
