using System.Collections.Generic;
using Vehicles.Data.Entities;
using Vehicles.Data.Exceptions;

namespace Vehicles.Data
{
    public class Store
    {
        private static readonly Dictionary<string, Vehicle> Vehicles = new Dictionary<string, Vehicle>();

        public static void Save(Vehicle vehicle)
        {
            if (Vehicles.ContainsKey(vehicle.Regno))
            {
                throw new DuplicateRegnoException();
            }

            Vehicles.Add(vehicle.Regno, vehicle);
        }

        public static void Update(Vehicle vehicle)
        {
            if (!Vehicles.ContainsKey(vehicle.Regno))
            {
                throw new RegnoNotFoundException();
            }

            Vehicles[vehicle.Regno] = vehicle;
        }
    }
}
