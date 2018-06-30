using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutech.Workout.Mac.Domain.Entities
{
    public class Car
    {
        [BsonId(true)]
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int YearOfManufacture { get; set; }
    }
}
