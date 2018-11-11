using System;
using Vehicles.Cqrs.CommandModel.Commands;
using Vehicles.Cqrs.Domain;
using Vehicles.Data;
using Vehicles.Data.Exceptions;

namespace Vehicles.Cqrs.CommandModel.CommandHandlers
{
    internal class RegisterVehicleCommandHandler : CommandHandler<Vehicle, RegisterVehicleCommand>
    {
        public RegisterVehicleCommandHandler(IStorage storage) : base(storage)
        {
        }

        public override void Handle(RegisterVehicleCommand command)
        {
            EnsureVehicleUnique(command);
            AggregateRoot.RegisterNew();
            Commit();
        }

        private void EnsureVehicleUnique(RegisterVehicleCommand command)
        {
            try
            {
                Storage.Get(command.Regno);
            }
            catch (RegnoNotFoundException)
            {
                AggregateRoot = new Vehicle(command.Regno, command.Brand, command.Model, command.Year, 0);
                return;
            }

            throw new Exception("Regno already registered");
        }
    }
}