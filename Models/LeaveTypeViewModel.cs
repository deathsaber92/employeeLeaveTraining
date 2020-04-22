using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Models
{
    /// <summary>
    /// View model for details leave type
    /// </summary>
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Date Created")]
        public DateTime? DateCreated { get; set; }
    }
}
