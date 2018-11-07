namespace Vehicles.Cqrs.Domain.Events
{
    public class UpdateMileageEvent : DomainEvent
    {
        public string Regno { get; }
        public int Kilometers { get; }

        public UpdateMileageEvent(string regno, int kilometers) : base()
        {
            Regno = regno;
            Kilometers = kilometers;
        }
    }
}