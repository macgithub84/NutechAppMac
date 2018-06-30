using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutech.Workout.Mac.Domain.Entities;
using Nutech.Workout.Mac.Data.Repositories;

namespace Nutech.Workout.Mac.Service.Services
{
    public class CarService : ICarService
    {
        private IRepository<Car> _oCarRepository;
        private string _collectionName = "Car";
        public CarService(IRepository<Car> oCarRepository)
        {
            _oCarRepository = oCarRepository;
        }
        public int CreateEntity(Car entity)
        {
            return _oCarRepository.Insert(entity, _collectionName);
        }

        public bool DeleteEntityById(int Id)
        {
            return _oCarRepository.Delete(Id);
        }

        public List<Car> GetEntities()
        {
            return _oCarRepository.GetAll();
        }

        public Car GetEntityById(int Id)
        {
            return _oCarRepository.Get(Id);
        }

        public bool UpdateEntity(Car entity)
        {
            return _oCarRepository.Update(entity, _collectionName);
        }
    }
}
