using CarService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Service
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
    }
}
