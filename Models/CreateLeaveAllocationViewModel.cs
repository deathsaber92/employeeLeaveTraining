using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveTraining.Models
{
    public class CreateLeaveAllocationViewModel
    {
        public int NumberUpdated { get; set; }
        public List<LeaveTypeViewModel> LeaveTypes { get; set; }
    }
}
