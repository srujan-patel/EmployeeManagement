using EmployeeManagement.Server.Dal;
using EmployeeManagement.Server.Dal.Repositories;
using EmployeeManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Web.Server.Models
{
    public class DepartmentRepository : IDepartmentRepository

    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<Department> GetDepartment(int departmentId)
        {
            return await appDbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }


        public async Task<Department> AddDepartment(Department Department)
        {
            var result = await appDbContext.Departments.AddAsync(Department);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
