using System;
using Vehicles.Cqrs.CommandModel.Commands;

namespace Vehicles.Cqrs.CommandModel.CommandHandlers
{
    public class UpdateMileageCommandHandler : ICommandHandler<UpdateMileageCommand>
    {
        public void Handle(UpdateMileageCommand command)
        {
            throw new NotImplementedException();
        }
    }
}