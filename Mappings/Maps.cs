using AutoMapper;
using EmployeeLeaveTraining.Data;
using EmployeeLeaveTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Mappings
{
    /// <summary>
    /// Mapping the data types with their view models
    /// </summary>
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();
            CreateMap<LeaveHistory, LeaveHistoryViewModel>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationViewModel>().ReverseMap();   
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
