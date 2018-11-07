using Vehicles.Cqrs.CommandModel.Commands;

namespace Vehicles.Cqrs.CommandModel.CommandHandlers
{
    public interface IHandleCommand<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}