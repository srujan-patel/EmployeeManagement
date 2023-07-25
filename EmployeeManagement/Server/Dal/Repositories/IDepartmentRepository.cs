using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Server.Dal.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
        Task<Department> AddDepartment(Department department);

    }
}
