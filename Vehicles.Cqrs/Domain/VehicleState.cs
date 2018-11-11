using Vehicles.Cqrs.Domain.Events;
using Vehicles.Data;

namespace Vehicles.Cqrs.Domain
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

        public void Apply(VehiceRegistered @event)
        {
            Regno = @event.Regno;
            Brand = @event.Brand;
            Model = @event.Model;
            Year = @event.Year;
        }

        public void Save(IStorage storage)
        {
            storage.Save(new Data.Entities.Vehicle(Regno, Brand, Model, Year, Kilometers));
        }
    }
}
