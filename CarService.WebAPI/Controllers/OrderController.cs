using AutoMapper;
using CarService.Model;
using CarService.Model.Entities;
using CarService.Service;
using CarService.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarService.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;
        private readonly CarServiceContext _dbContext;


        public OrderController(IOrderService orderService, CarServiceContext dbContext)
        {
            _orderService = orderService;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("AddOrder")]
        public void AddOrder([FromBody]Order order)
        {
            _orderService.AddOrder(order);
        }

        [HttpPut]
        [Route("AddAvailToOrder/{id}")]
        public IHttpActionResult AddAvailToOrder([FromBody]Avail avail, int id)
        {
            _orderService.AddAvailToOrder(avail, id);
            return Ok();
        }

        [HttpPut]
        [Route("AddPartToOrderAvail/{orderId}/{availId}")]
        public IHttpActionResult AddPartToOrderAvail([FromBody]Part part, int orderId, int availId)
        {
            _orderService.AddPartToOrderAvail(part, orderId, availId);
            return Ok();
        }

        [HttpGet]
        [Route("GetOpenOrdersReport")]
        public IHttpActionResult GetOpenOrdersReport()
        {
            return Ok(_orderService.GetOpenOrderReport());
        }
    }
}