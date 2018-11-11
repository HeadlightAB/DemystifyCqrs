using Vehicles.Data.Entities;

namespace Vehicles.Data
{
    public interface IStorage
    {
        Vehicle Get(string regno);
        void Save(Vehicle vehicle);
        void Append(object[] events);
    }
}