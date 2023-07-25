using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Client.Srevices
{
    public interface IEmployeeService
    {

        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee updatedEmployee);
        Task<Employee> CreateEmployee(Employee updatedEmployee);
        Task DeleteEmployee(int Id);


    }
}
