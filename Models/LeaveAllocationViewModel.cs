using EmployeeLeaveTraining.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Models
{
    /// <summary>
    /// View model for leave allocation
    /// </summary>
    public class LeaveAllocationViewModel
    {      
        public int Id { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public int Period { get; set; }
        public DateTime DateCreated { get; set; }       
        public EmployeeViewModel Employee { get; set; }
        public string EmployeeId { get; set; }      
        public LeaveTypeViewModel LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
