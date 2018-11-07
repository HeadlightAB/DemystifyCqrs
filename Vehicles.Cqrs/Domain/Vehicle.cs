using Vehicles.Cqrs.Domain.Events;

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
                Apply(new MileageUpdated(Regno, kilometers));
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
        {}

        protected override void CommitState()
        {
            _vehicleState.Save();
        }
    }
}
