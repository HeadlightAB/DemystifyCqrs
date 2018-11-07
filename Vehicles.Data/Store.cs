using System.Collections.Generic;
using Vehicles.Data.Entities;
using Vehicles.Data.Exceptions;

namespace Vehicles.Data
{
    public class Store
    {
        private static readonly Dictionary<string, Vehicle> Vehicles = new Dictionary<string, Vehicle>();
        private static readonly List<object> Events = new List<object>();

        public static Vehicle Get(string regno)
        {
            if (!Vehicles.ContainsKey(regno))
            {
                throw new RegnoNotFoundException();
            }

            return Vehicles[regno];
        }

        public static void Save(Vehicle vehicle)
        {
           Vehicles[vehicle.Regno] = vehicle;
        }

        public static void Append(object[] events)
        {
            Events.AddRange(events);
        }
    }
}
