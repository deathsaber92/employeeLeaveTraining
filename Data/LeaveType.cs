using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Data
{
    /// <summary>
    /// The type of leaves an employee can have
    /// </summary>
    public class LeaveType
    { 
        [Key]
        public int Id { get; set; }
      
        [Required]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
