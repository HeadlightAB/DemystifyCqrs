using System.Collections.Generic;
using Vehicles.Data.Entities;
using Vehicles.Data.Exceptions;

namespace Vehicles.Data
{
    public class InMemoryStorage : IStorage
    {
        private static readonly Dictionary<string, Vehicle> Vehicles = new Dictionary<string, Vehicle>();
        private static readonly List<object> Events = new List<object>();

        public Vehicle Get(string regno)
        {
            if (!Vehicles.ContainsKey(regno))
            {
                throw new RegnoNotFoundException();
            }

            return Vehicles[regno];
        }

        public void Save(Vehicle vehicle)
        {
           Vehicles[vehicle.Regno] = vehicle;
        }

        public void Append(object[] events)
        {
            Events.AddRange(events);
        }
    }
}
