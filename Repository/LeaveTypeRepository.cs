using EmployeeLeaveTraining.Contracts;
using EmployeeLeaveTraining.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveType entity)
        {
            _db.LeaveType.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveType.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            return _db.LeaveType.ToList();
        }

        public LeaveType FindById(int id)
        {
            return _db.LeaveType.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveType.Update(entity);
            return Save();
        }
    }
}
