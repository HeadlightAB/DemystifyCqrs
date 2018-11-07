namespace Vehicles.Cqrs.Domain.Events
{
    internal class VehiceRegistered : DomainEvent
    {
        public string Regno { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }

        public VehiceRegistered(string regno, string brand, string model, int year)
        {
            Regno = regno;
            Brand = brand;
            Model = model;
            Year = year;
        }
    }
}