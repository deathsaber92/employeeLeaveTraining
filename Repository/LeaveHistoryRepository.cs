﻿using EmployeeLeaveTraining.Contracts;
using EmployeeLeaveTraining.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db) 
        {
            _db = db;
        }

        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistory.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistory.Remove(entity);
            return Save();
        }

        public bool Exists(int id)
        {
            return _db.LeaveHistory.Any(x => x.Id == id);
        }

        public ICollection<LeaveHistory> FindAll()
        {            
            return _db.LeaveHistory.ToList();
        }

        public LeaveHistory FindById(int id)
        {
            return _db.LeaveHistory.FirstOrDefault(x => x.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;            
        }

        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistory.Update(entity);
            return Save();
        }
    }
}
