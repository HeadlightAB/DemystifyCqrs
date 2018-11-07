using Vehicles.Cqrs.CommandModel.Commands;
using Vehicles.Cqrs.Domain;

namespace Vehicles.Cqrs.CommandModel.CommandHandlers
{
    internal abstract class CommandHandler<TAggregateRoot, TCommand> 
        where TAggregateRoot : AggregateRoot 
        where TCommand : ICommand
    {
        protected TAggregateRoot AggregateRoot;

        public abstract void Handle(TCommand command);

        protected void Commit()
        {
            AggregateRoot.CommitEvents();
        }
    }
}