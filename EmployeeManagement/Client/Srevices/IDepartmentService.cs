using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Client.Srevices
{
    public interface IDepartmentService
    {

        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
    }
}
