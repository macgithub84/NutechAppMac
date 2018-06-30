using Nutech.Workout.Mac.Domain.Entities;
using Nutech.Workout.Mac.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nutech.Workout.Mac.WebApi.Controllers
{
    public class CarController : ApiController
    {
        private readonly ICarService _service;
        //public CarController() { }

        public CarController(ICarService service)
        {
            _service = service;
        }
        // GET api/values     
        [HttpGet]
        public List<Car> GetAllCarDetails()
        {
            return _service.GetEntities();
        }

        // POST api/values 
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [HttpPost]
        public HttpResponseMessage CreateANewCarMake(Car entity)
        {
            try
            {
                _service.CreateEntity(entity);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = HttpStatusCode.ExpectationFailed.ToString()
                };
            }

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
        // POST api/values 
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [HttpPut]
        public void UpdateCarMake(Car entity)
        {
            _service.UpdateEntity(entity);
        }
        [System.Web.Http.AcceptVerbs("GET", "DELETE")]
        [HttpDelete]
        public int DeleteCarMake(int id)
        {
            var isDeleted = _service.DeleteEntityById(id);
            if (isDeleted) return id;
            else return 0;
        }
    }
}