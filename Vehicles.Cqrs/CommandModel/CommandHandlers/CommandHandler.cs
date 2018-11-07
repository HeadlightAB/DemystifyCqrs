using System;

namespace Vehicles.Cqrs.CommandModel.CommandHandlers
{
    public abstract class CommandHandler
    {
        protected void LoadAggregate(string id)
        {
            throw new NotImplementedException();
        }

        protected void Commit()
        {
            throw new NotImplementedException();
        }
    }
}