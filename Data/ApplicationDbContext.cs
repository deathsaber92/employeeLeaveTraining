using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EmployeeLeaveTraining.Models;

namespace EmployeeLeaveTraining.Data
{
    /// <summary>
    /// The application database context which is used in the web application
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocation { get; set; } 
        public DbSet<LeaveHistory> LeaveHistory { get; set; }
        public DbSet<LeaveType> LeaveType { get; set; }
        public DbSet<EmployeeLeaveTraining.Models.DetailsLeaveTypeViewModel> DetailsLeaveTypeViewModel { get; set; }
    }
}
