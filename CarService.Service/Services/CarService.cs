using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Model.Entities;
using CarService.Model;

namespace CarService.Service
{
    public class CarService : ICarService
    {

        private readonly CarServiceContext _db;

        public CarService(CarServiceContext db)
        {
            _db = db;
        }

        public void AddCar(Car car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();
        }

        public void ChangeRegistrationNumber(int carId, string changeRegistrationNumber)
        {
            var foundCar = _db.Cars.FirstOrDefault(o => o.Id == carId);
            foundCar.RegistrationNumber = changeRegistrationNumber;
            _db.Entry(foundCar).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void RemoveCustomer(int carId)
        {
            var foundCar = _db.Cars.FirstOrDefault(o => o.Id == carId);
            foundCar.CustomerId = null;
            _db.Entry(foundCar).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

    }
}
