using Vehicles.Cqrs.CommandModel.Commands;
using Vehicles.Cqrs.Domain;
using Vehicles.Data;

namespace Vehicles.Cqrs.CommandModel.CommandHandlers
{
    internal abstract class CommandHandler<TAggregateRoot, TCommand> 
        where TAggregateRoot : AggregateRoot 
        where TCommand : ICommand
    {
        protected readonly IStorage Storage;

        protected TAggregateRoot AggregateRoot;

        protected CommandHandler(IStorage storage)
        {
            Storage = storage;
        }

        public abstract void Handle(TCommand command);

        protected void Commit()
        {
            AggregateRoot.CommitEvents(Storage);
        }
    }
}