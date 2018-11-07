using Vehicles.Cqrs.Domain.Events;
using Vehicles.Data;

namespace Vehicles.Cqrs.Domain
{
    internal class VehicleState
    {
        public string Regno { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }
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

        public void Save()
        {
            Store.Save(new Data.Entities.Vehicle(Regno, Brand, Model, Year, Kilometers));
        }
    }
}
