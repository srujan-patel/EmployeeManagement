using EmployeeManagement.Server.Dal;
using EmployeeManagement.Server.Dal.Repositories;
using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Web.Server.Models
{
    public class DepartmentRepository : IDepartmentRepository

    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Department GetDepartment(int departmentId)
        {

            var department = appDbContext.Departments
                .FirstOrDefault(d => d.DepartmentId == departmentId);
            
            if (department == null)
            {
                return null;
            }

            return department;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return appDbContext.Departments;
        }

    }
}
