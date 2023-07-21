using EmployeeManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.Server.Dal.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var emp= await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (emp == null) return null;
            return emp;

        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateofBirth = employee.DateofBirth;
                result.gender = employee.gender;
                result.DepartmentID = employee.DepartmentID;
                result.PhotoPath = employee.PhotoPath;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
                return result;

            }
            else
                return null;
        }

        public async Task<Employee> GetEmployeebyEmail(string email)
        {
            var emp = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == email);

            if (emp == null) return null;
            return emp;
        }
    }
}


 
