using Vehicles.Cqrs.Domain.Events;
using Vehicles.Cqrs.Domain.Exceptions;

namespace Vehicles.Cqrs.Domain
{
    internal class Vehicle : AggregateRoot
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
                if (kilometers > 0)
                {
                    Apply(new MileageUpdated(Regno, kilometers));
                }
                else
                {
                    throw new BusinessException("Mileage in kilometers must be greater than 0");
                }
            }
        }

        public void RegisterNew()
        {
            Apply(new VehiceRegistered(Regno, Brand, Model, Year));
        }

        public void On(MileageUpdated @event)
        {
            _vehicleState.Apply(@event);
        }

        public void On(VehiceRegistered @event)
        {
            _vehicleState.Apply(@event);
        }

        protected override void CommitState()
        {
            _vehicleState.Save();
        }
    }
}
