using CarService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Service
{
    public interface ICarService
    {
        void AddCar(Car car);

        void ChangeRegistrationNumber(int carId, string newRegistrationNumber);

        void RemoveCustomer(int carId);
    }
}
