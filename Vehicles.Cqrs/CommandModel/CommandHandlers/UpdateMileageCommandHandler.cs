using Vehicles.Cqrs.CommandModel.Commands;
using Vehicles.Cqrs.Domain;

namespace Vehicles.Cqrs.CommandModel.CommandHandlers
{
    internal class UpdateMileageCommandHandler : CommandHandler<Vehicle, UpdateMileageCommand>
    {
        public override void Handle(UpdateMileageCommand command)
        {
            LoadAggregate(command.Regno);
            AggregateRoot.UpdateMileage(command.Kilometers);
            Commit();
        }

        private void LoadAggregate(string id)
        {
            var entity = Data.Store.Get(id);
            AggregateRoot = new Vehicle(entity.Regno, entity.Brand, entity.Model, entity.Year, entity.Kilometers);
        }
    }
}