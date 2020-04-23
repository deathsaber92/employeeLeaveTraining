using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Finds all entities
        /// </summary>
        /// <returns></returns>
        ICollection<T> FindAll();
        /// <summary>
        /// Finds an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById(int id);
        /// <summary>
        /// Creating a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Create(T entity);
        /// <summary>
        /// Updating an existing entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);
        /// <summary>
        /// Deleting an existing entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);
        /// <summary>
        /// Saves the changes done to the db
        /// </summary>
        /// <returns></returns>
        bool Save();
        /// <summary>
        /// Checks by id if an entity exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(int id);
    }
}
