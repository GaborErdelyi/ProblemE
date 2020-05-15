#region Used assemblies

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace FuelConsciousness
{
    /// <summary>
    /// Stores the trip information
    /// </summary>
    public sealed class Trip
    {
        #region Members

        /// <summary>
        /// The overall length of the trip in km
        /// </summary>
        public readonly ulong TripLength;

        /// <summary>
        /// The car used for the trip
        /// </summary>
        public readonly Vehicle Car;

        /// <summary>
        /// The number of fuel stations between the 2 locations
        /// </summary>
        public readonly ulong FuelStationCount;

        /// <summary>
        /// The fuel station list
        /// </summary>
        public List<FuelStation> FuelStations = new List<FuelStation>();

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="Trip"/> class.
        /// </summary>
        /// <param name="tripLength">The overall length of the trip in km.</param>
        /// <param name="car">The car used for the trip.</param>
        /// <param name="fuelStationCount">The number of fuel stations between the 2 locations.</param>
        public Trip(ulong tripLength, Vehicle car, ulong fuelStationCount)
        {
            TripLength = tripLength;
            Car = car;
            FuelStationCount = fuelStationCount;
        }

        #endregion

        #region Public functions

        /// <summary>
        /// Calculates the minimum price for the trip.
        /// </summary>
        /// <returns>The calculated price</returns>
        public ulong CalculateMinimumPrice()
        {
            ulong price = 0;
            ulong fuelRequired = (TripLength > Car?.TankCapacity) ? (TripLength - Car.TankCapacity) : 0;
            ulong distanceTraveled = 0;
            ulong fuelLevel = Car?.TankCapacity ?? 0;
            int fuelStationCounter = 0;

            if (fuelRequired == 0)
            {
                return price;
            }

            // Sort the list by distance in ascending order
            FuelStations = FuelStations.OrderBy(item => item.Distance).ToList();

            while (true)
            {
                FuelStation cheapestFuelStation = null;
                ulong fuelBought = 0;
                ulong minimumPrice = ulong.MaxValue;

                for (int i = fuelStationCounter; i < FuelStations.Count; i++)
                {
                    if ((FuelStations[i].Distance - distanceTraveled) <= fuelLevel &&
                        FuelStations[i].Price <= minimumPrice)
                    {
                        // Update cheapest station
                        minimumPrice = FuelStations[i].Price;
                        cheapestFuelStation = FuelStations[i];
                        fuelBought = (FuelStations[i].Distance - distanceTraveled) + (Car.TankCapacity - fuelLevel);
                        fuelStationCounter = (i + 1);
                    }
                    else if ((FuelStations[i].Distance - distanceTraveled) > fuelLevel)
                    {
                        break;
                    }
                }

                ulong priceDifference = 0;
                if (cheapestFuelStation != null)
                {
                    var minimumFuelLevel = fuelLevel - (cheapestFuelStation.Distance - distanceTraveled);
                    fuelLevel = Car.TankCapacity;

                    // Select the next possible target fuel station
                    for (int i = fuelStationCounter; i < FuelStations.Count; i++)
                    {
                        if (FuelStations[i].Distance - cheapestFuelStation.Distance <= minimumFuelLevel)
                        {
                            continue;
                        }
                        else if (FuelStations[i].Distance - cheapestFuelStation.Distance > fuelLevel)
                        {
                            break;
                        }
                        else if (FuelStations[i].Price < minimumPrice &&
                                 ((Car.TankCapacity - (FuelStations[i].Distance - cheapestFuelStation.Distance)) * (minimumPrice - FuelStations[i].Price)) > priceDifference)
                        {
                            priceDifference = (Car.TankCapacity - (FuelStations[i].Distance - cheapestFuelStation.Distance)) * (minimumPrice - FuelStations[i].Price);
                            fuelBought = (FuelStations[i].Distance - cheapestFuelStation.Distance) - minimumFuelLevel;
                            fuelLevel = minimumFuelLevel + fuelBought;
                        }
                    }
                }
                else
                {
                    throw new Exception("Trip is not possible due to fuel station distances");
                }

                if (fuelRequired < (cheapestFuelStation.Distance - distanceTraveled))
                {
                    price += fuelRequired * cheapestFuelStation.Price;

                    break;
                }
                else
                {
                    price += fuelBought * cheapestFuelStation.Price;
                    fuelRequired -= fuelBought;
                }

                distanceTraveled = cheapestFuelStation.Distance;
            }

            return price;
        }

        #endregion
    }
}
