using Vehicles.Cqrs.Domain;
using Vehicles.Cqrs.Domain.Events;

namespace Vehicles.Cqrs.CommandModel.EventHandlers
{
    internal class VehicleState
    {
        public string Regno { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public int Kilometers { get; private set; }

        public VehicleState(Vehicle vehicle)
        {
            Regno = vehicle.Regno;
            Brand = vehicle.Brand;
            Model = vehicle.Model;
            Year = vehicle.Year;
        }

        public void Apply(MileageUpdated @event)
        {
            Kilometers = @event.Kilometers;
        }
    }
}
