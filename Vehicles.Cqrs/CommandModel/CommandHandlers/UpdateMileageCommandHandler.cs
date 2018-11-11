using Vehicles.Cqrs.CommandModel.Commands;
using Vehicles.Cqrs.Domain;
using Vehicles.Data;

namespace Vehicles.Cqrs.CommandModel.CommandHandlers
{
    internal class UpdateMileageCommandHandler : CommandHandler<Vehicle, UpdateMileageCommand>
    {
        public UpdateMileageCommandHandler(IStorage storage) : base(storage)
        {
        }

        public override void Handle(UpdateMileageCommand command)
        {
            LoadAggregate(command.Regno);
            AggregateRoot.UpdateMileage(command.Kilometers);
            Commit();
        }

        private void LoadAggregate(string id)
        {
            var entity = Storage.Get(id);
            AggregateRoot = new Vehicle(entity.Regno, entity.Brand, entity.Model, entity.Year, entity.Kilometers);
        }
    }
}