using System.Collections.Generic;
using Vehicles.Cqrs.Domain.Events;

namespace Vehicles.Cqrs.Domain
{
    public class AggregateRoot
    {
        private readonly List<DomainEvent> _events = new List<DomainEvent>();

        public void Apply(DomainEvent @event)
        {
            _events.Add(@event);
        }
    }
}