namespace Vehicles.Cqrs.CommandModel.Commands
{
    public class RegisterVehicleCommand : ICommand
    {
        public string Regno { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }

        public RegisterVehicleCommand(string regno, string brand, string model, int year)
        {
            Regno = regno;
            Brand = brand;
            Model = model;
            Year = year;
        }
    }
}