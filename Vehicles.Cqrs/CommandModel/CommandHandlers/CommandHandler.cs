using Vehicles.Cqrs.Domain;

namespace Vehicles.Cqrs.CommandModel.CommandHandlers
{
    public abstract class CommandHandler<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        protected TAggregateRoot AggregateRoot;

        protected void LoadAggregate(string id)
        {
            //_aggregateRoot = 
        }

        protected void Commit()
        {
            AggregateRoot.CommitEvents();
        }
    }
}