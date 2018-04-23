using CarService.Model.Entities;
using CarService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CarService.WebAPI.Controllers
{
    [RoutePrefix("api/Car")]
    public class CarController : ApiController
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        [Route("AddCar")]
        public void AddCar([FromBody]Car car)
        {
            _carService.AddCar(car);
        }

        [HttpPut]
        [Route("ChangeRegistrationNumber/{carId}/{changeRegistrationNumber}")]
        public IHttpActionResult ChangeRegistrationNumber(int carId, string changeRegistrationNumber)
        {
            _carService.ChangeRegistrationNumber(carId, changeRegistrationNumber);
            return Ok();
        }

        [HttpPut]
        [Route("RemoveCustomer/{carId}")]
        public IHttpActionResult RemoveCustomer(int carId)
        {
            _carService.RemoveCustomer(carId);
            return Ok();
        }
    }
}