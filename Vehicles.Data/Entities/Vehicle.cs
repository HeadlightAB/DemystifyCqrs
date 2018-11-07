namespace Vehicles.Data.Entities
{
    public class Vehicle
    {
        public Vehicle(string regno, string brand, string model, int year, int kilometers)
        {
            Regno = regno;
            Brand = brand;
            Model = model;
            Year = year;
            Kilometers = kilometers;
        }

        public string Regno { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Kilometers { get; set; }
    }
}
