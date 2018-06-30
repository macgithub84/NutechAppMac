using LiteDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutech.Workout.Mac.Data.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {

        #region Properties 
        private LiteDatabase _db = null;
        private readonly bool _disposeDatabase;
        public Repository()
        {
            Data.Repositories.CarMgtDBContext dbContext = Data.Repositories.CarMgtDBContext.GetInstance();
            _db = dbContext.Db;

        }
        /// <summary>
        /// Get database instance
        /// </summary>
        public LiteDatabase Database { get { return _db; } }

        /// <summary>
        /// Get engine instance
        /// </summary>
        public LiteEngine Engine { get { return _db.Engine; } }

        #endregion 
        public int Insert(T entity, string collectionName = null)
        {
            collectionName = string.IsNullOrEmpty(collectionName) ?
                typeof(T).Name.ToString() : collectionName;
            var v = _db.GetCollection<T>(collectionName).Insert(entity);

            return v.AsInt32;
        }
        public bool Update(T entity, string collectionName = null)
        {
            return _db.GetCollection<T>(collectionName).Update(entity);
        }

        public bool Delete(int Id, string collectionName = null)
        {
            return _db.GetCollection<T>(collectionName).Delete(Id);
        }

        public T Get(int Id)
        {
            return _db.GetCollection<T>().FindById(new BsonValue(Id));
        }

        public List<T> GetAll()
        {
            return _db.GetCollection<T>().FindAll().ToList();
        }

        public void Dispose()
        {
            if (_disposeDatabase)
            {
                _db?.Dispose();
            }

            _db = null;
        }
    }
}
