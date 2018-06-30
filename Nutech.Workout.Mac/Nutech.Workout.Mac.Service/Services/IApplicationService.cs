using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutech.Workout.Mac.Service.Services
{
    public interface IApplicationService<T> where T : class
    {
        int CreateEntity(T entity);
        T GetEntityById(int Id);
        List<T> GetEntities();
        bool UpdateEntity(T entity);
        bool DeleteEntityById(int Id);

    }
}
 