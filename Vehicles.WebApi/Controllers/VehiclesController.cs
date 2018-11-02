using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vehicles.WebApi.Models;
using Vehicles.WebApi.Requests;

namespace Vehicles.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{regno}")]
        public ActionResult<Vehicle> Get(string regno)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post([FromBody] CreateVehiceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
