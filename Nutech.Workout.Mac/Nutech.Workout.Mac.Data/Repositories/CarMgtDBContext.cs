using LiteDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutech.Workout.Mac.Data.Repositories
{
    public sealed class CarMgtDBContext
    {
        private static CarMgtDBContext _instance = null;
        private static LiteDatabase _db = null;
        static string connectionString = ConfigurationManager.AppSettings["DbConnection"] == null ? "Demo" : ConfigurationManager.AppSettings["DbConnection"];
        private CarMgtDBContext() { }
        public static CarMgtDBContext GetInstance()
        {

            if (_instance == null)
            {
                _instance = new CarMgtDBContext();
                _db = new LiteDatabase(connectionString);
            }
            return _instance;

        }
        public LiteDatabase Db
        {
            get
            {
                return _db;
            } 
        }
         
    }
}
