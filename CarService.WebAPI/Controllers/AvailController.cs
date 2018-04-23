using CarService.Model;
using CarService.Service;
using CarService.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CarService.WebAPI.Controllers
{
    [RoutePrefix("api/Avail")]
    public class AvailController : ApiController
    {
        private readonly IAvailService _availService;
        private readonly CarServiceContext _dbContext;


        public AvailController(IAvailService availService, CarServiceContext dbContext)
        {
            _availService = availService;
            _dbContext = dbContext;
        }

        [HttpPut]
        [Route("CloseAvail/{availId}")]
        public IHttpActionResult CloseAvail(int availId)
        {
            _availService.CloseAvail(availId);
            return Ok();
        }


    }
}