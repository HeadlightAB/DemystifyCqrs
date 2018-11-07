using Vehicles.Cqrs.Domain.Events;

namespace Vehicles.Cqrs.Domain
{
    public class Vehicle : AggregateRoot
    {
        public string Regno { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }

        public Vehicle(string regno, string brand, string model, int year)
        {
            Regno = regno;
            Brand = brand;
            Model = model;
            Year = year;
        }

        public void UpdateMileage(int kilometers)
        {
            Apply(new UpdateMileageEvent(Regno, kilometers));
        }
    }
}
