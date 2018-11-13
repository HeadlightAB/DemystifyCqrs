using Vehicles.Cqrs.Domain.Events;
using Vehicles.Data;

namespace Vehicles.Cqrs.Domain
{
    internal interface IState
    {
        void Save(IStorage storage);
        void Apply(DomainEvent @event);
    }
}