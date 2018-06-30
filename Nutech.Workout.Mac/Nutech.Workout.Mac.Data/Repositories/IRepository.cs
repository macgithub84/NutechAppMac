using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutech.Workout.Mac.Data.Repositories
{
    /// <summary>
    /// Repository Interface defines the base
    /// functionality required by all Repositories.
    /// </summary>
    /// <typeparam name="T">
    /// The entity type that requires a Repository.
    /// </typeparam>
    public interface IRepository<T> where T:class
    {
        int Insert(T entity, string collectionName = null);
        bool Update(T entity, string collectionName = null);
        bool Delete(int Id, string collectionName = null);
        T Get(int Id);
        List<T> GetAll();
    }
}
