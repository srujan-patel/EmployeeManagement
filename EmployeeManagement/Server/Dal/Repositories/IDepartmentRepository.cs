using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Server.Dal.Repositories
{
    public interface IDepartmentRepository
    {

        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int departmentId);

    }
}
