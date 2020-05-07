using EmployeeLeaveTraining.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        /// <summary>
        /// Checks if a leave type was allocated to an employee
        /// </summary>
        /// <param name="leaveTypeid">Leave type id</param>
        /// <param name="emplyeeId">Employee id</param>
        /// <returns>True: was allocated / False: was not allocated</returns>
        bool CheckAllocation(int leaveTypeid, string emplyeeId);

        /// <summary>
        /// Gets all the leave allocations for one employee by id
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>A collection of LeaveAllocation</returns>
        ICollection<LeaveAllocation> GetLeaveAllocations(string id);
    }
}
