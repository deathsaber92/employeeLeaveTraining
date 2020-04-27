using EmployeeLeaveTraining.Contracts;
using EmployeeLeaveTraining.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db) 
        {
            _db = db;
        }

        public bool CheckAllocation(int leaveTypeid, string emplyeeId)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(x => x.LeaveTypeId == leaveTypeid && x.EmployeeId == emplyeeId && x.Period == period).Any();
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocation.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocation.Remove(entity);
            return Save();
        }

        public bool Exists(int id)
        {
            return _db.LeaveAllocation.Any(x => x.Id == id);
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            return _db.LeaveAllocation.ToList();
        }

        public LeaveAllocation FindById(int id)
        {
            return _db.LeaveAllocation.FirstOrDefault(x => x.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocation.Update(entity);
            return Save();
        }
    }
}
