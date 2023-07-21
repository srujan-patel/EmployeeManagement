﻿using EmployeeManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Server.Dal
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        
      }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
