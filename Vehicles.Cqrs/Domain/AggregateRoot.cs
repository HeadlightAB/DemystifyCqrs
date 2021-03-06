﻿using System.Collections.Generic;
using System.Linq;
using Vehicles.Cqrs.Domain.Events;
using Vehicles.Data;

namespace Vehicles.Cqrs.Domain
{
    internal abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _events = new List<DomainEvent>();
        protected IState State;

        protected void Apply(DomainEvent @event)
        {
            _events.Add(@event);
        }

        internal void CommitEvents(IStorage storage)
        {
            var eventHandlingMethods = GetType().GetMethods().Where(x =>
                x.Name == "On" &&
                x.GetParameters().SingleOrDefault(p => p.ParameterType.BaseType == typeof(DomainEvent)) != null).ToList();

            foreach (var domainEvent in _events)
            {
                eventHandlingMethods
                    .Where(m => m.GetParameters()[0].ParameterType == domainEvent.GetType()).ToList()
                    .ForEach(x => x.Invoke(this, new object[] {domainEvent}));
            }

            CommitState(storage);
            storage.Append(_events.ToArray());
            _events.Clear();
        }

        private void CommitState(IStorage storage)
        {
            State.Save(storage);
        }
    }
}