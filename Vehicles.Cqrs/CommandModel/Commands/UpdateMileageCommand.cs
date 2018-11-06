namespace Vehicles.Cqrs.CommandModel.Commands
{
    public class UpdateMileageCommand : ICommand
    {
        public string Regno { get; }
        public int Kilometers { get; }

        public UpdateMileageCommand(string regno, int kilometers)
        {
            Regno = regno;
            Kilometers = kilometers;
        }
    }
}
