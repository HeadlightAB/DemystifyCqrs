namespace Vehicles.WebApi.Requests
{
    public class RegisterVehiceRequest
    {
        public string Regno { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}