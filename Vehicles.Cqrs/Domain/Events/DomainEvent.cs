using System;

namespace Vehicles.Cqrs.Domain.Events
{
    public abstract class DomainEvent
    {
        public DateTimeOffset Timestamp { get; }

        protected DomainEvent()
        {
            Timestamp = DateTimeOffset.Now;;
        }
    }
}