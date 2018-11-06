using Vehicles.Cqrs.CommandModel.Commands;

namespace Vehicles.Cqrs.CommandModel
{
    public interface ICommandRouter
    {
        void Handle<TCommand>(TCommand command) where TCommand : ICommand;
    }
}