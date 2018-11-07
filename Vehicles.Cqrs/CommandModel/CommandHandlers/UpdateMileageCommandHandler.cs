using Vehicles.Cqrs.CommandModel.Commands;
using Vehicles.Cqrs.Domain;

namespace Vehicles.Cqrs.CommandModel.CommandHandlers
{
    public class UpdateMileageCommandHandler : CommandHandler, IHandleCommand<UpdateMileageCommand>
    {
        private Vehicle _vehicle;

        public void Handle(UpdateMileageCommand command)
        {
            LoadAggregate(command.Regno);
            _vehicle.UpdateMileage(command.Kilometers);
            Commit();
        }
    }
}