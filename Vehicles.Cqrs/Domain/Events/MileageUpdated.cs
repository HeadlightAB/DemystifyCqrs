﻿namespace Vehicles.Cqrs.Domain.Events
{
    internal class MileageUpdated : DomainEvent
    {
        public string Regno { get; }
        public int Kilometers { get; }

        public MileageUpdated(string regno, int kilometers)
        {
            Regno = regno;
            Kilometers = kilometers;
        }
    }
}