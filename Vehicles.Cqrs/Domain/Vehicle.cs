using Vehicles.Cqrs.CommandModel.EventHandlers;
using Vehicles.Cqrs.Domain.Events;
using Vehicles.Data;

namespace Vehicles.Cqrs.Domain
{
    public class Vehicle : AggregateRoot
    {
        public string Regno { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }
        public int Kilometers { get; }

        private readonly VehicleState _vehicleState;

        public Vehicle(string regno, string brand, string model, int year, int kilometers)
        {
            Regno = regno;
            Brand = brand;
            Model = model;
            Year = year;
            Kilometers = kilometers;

            _vehicleState = new VehicleState(this);
        }

        public void UpdateMileage(int kilometers)
        {
            if (Kilometers != kilometers)
            {
                Apply(new MileageUpdated(Regno, kilometers));
            }
        }

        public void On(MileageUpdated @event)
        {
            _vehicleState.Apply(@event);
        }

        protected override void CommitState()
        {
            Store.Save(new Data.Entities.Vehicle(
                _vehicleState.Regno,
                _vehicleState.Brand,
                _vehicleState.Model,
                _vehicleState.Year,
                _vehicleState.Kilometers));
        }
    }
}
