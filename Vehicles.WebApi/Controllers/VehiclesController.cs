using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vehicles.Cqrs.CommandModel;
using Vehicles.Cqrs.CommandModel.Commands;
using Vehicles.WebApi.Models;
using Vehicles.WebApi.Requests;

namespace Vehicles.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly ICommandRouter _commandRouter;

        public VehiclesController(ICommandRouter commandRouter)
        {
            _commandRouter = commandRouter;
        }

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

        [HttpPut("{regno}/mileage")]
        public void Put(string regno, [FromBody] UpdateMileageRequest request)
        {
            _commandRouter.Handle(new UpdateMileageCommand());
        }
    }
}
