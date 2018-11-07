using Vehicles.Cqrs.CommandModel.Commands;
using Vehicles.Cqrs.Domain;

namespace Vehicles.Cqrs.CommandModel.CommandHandlers
{
    public class UpdateMileageCommandHandler : CommandHandler<Vehicle>, IHandleCommand<UpdateMileageCommand>
    {
        public void Handle(UpdateMileageCommand command)
        {
            LoadAggregate(command.Regno);
            AggregateRoot.UpdateMileage(command.Kilometers);
            Commit();
        }
    }
}