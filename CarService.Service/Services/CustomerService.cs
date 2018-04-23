using CarService.Model;
using CarService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CarServiceContext _db;

        public CustomerService(CarServiceContext db)
        {
            _db = db;
        }

        public void AddCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }
    }


}
