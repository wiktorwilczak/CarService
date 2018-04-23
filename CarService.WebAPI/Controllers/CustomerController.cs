using AutoMapper;
using CarService.Model;
using CarService.Model.Entities;
using CarService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarService.WebAPI.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;
        private readonly CarServiceContext _dbContext;

        public CustomerController(ICustomerService customerService, CarServiceContext dbContext)
        {
            _customerService = customerService;
            _dbContext = dbContext;
        }


        [HttpPost]
        [Route("AddCustomer")]
        public void AddCustomer([FromBody]Customer customer)
        {
            _customerService.AddCustomer(customer);
        }

        [HttpGet]
        [Route("GetCustomerById/{id}")]

        public Customer GetCustomer(int id)
        {
            var data = _dbContext.Customers.Find(id);
            return data;
        }

        [HttpGet]
        [Route("GetCustomers")]

        public List<Customer> GetCustomer()
        {
            var data = _dbContext.Customers;

            var customerList = new List<Customer>();
            foreach (var item in data)
            {
                customerList.Add(item);
            }
            return customerList;
            
        }

    }
}