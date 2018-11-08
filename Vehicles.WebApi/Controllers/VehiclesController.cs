using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vehicles.Core.Exceptions;
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
        public void Post([FromBody] RegisterVehiceRequest request)
        {
            EnsureRequest(request);

            _commandRouter.Handle(new RegisterVehicleCommand(request.Regno, request.Brand, request.Model, request.Year));
        }

        [HttpPut("{regno}/mileage")]
        public void Put(string regno, [FromBody] UpdateMileageRequest request)
        {
            EnsureRequest(request);

            _commandRouter.Handle(new UpdateMileageCommand(regno, request.Kilometers));
        }

        private static void EnsureRequest(RegisterVehiceRequest request)
        {
            Assert(!string.IsNullOrWhiteSpace(request.Regno), new BadRequestException("Regno missing"));
            Assert(!string.IsNullOrWhiteSpace(request.Brand), new BadRequestException("Brand missing"));
            Assert(!string.IsNullOrWhiteSpace(request.Model), new BadRequestException("Model missing"));
            Assert(request.Year > 0, new Exception("Year missing"));
        }

        public void EnsureRequest(UpdateMileageRequest request)
        {
            Assert(request.Kilometers >= 0, new BadRequestException("Kilometers invalid"));
        }

        private static void Assert(bool isValid, Exception exception)
        {
            if (!isValid) throw exception;
        }
    }
}
