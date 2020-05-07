using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Data
{
    /// <summary>
    /// Extension for the Employee which is already listed in the dbo.AspNetUsers implementing some extra data properties for an employee
    /// </summary>
    public class Employee : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }             
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
