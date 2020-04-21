using EmployeeLeaveTraining.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Contracts
{
    public interface ILeaveHistoryRepository : IRepositoryBase<LeaveHistory>
    {
    }
}
