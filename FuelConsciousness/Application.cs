#region Used assemblies

using System;
using System.IO;
using System.Linq;

#endregion

namespace FuelConsciousness
{
    public class Application
    {
        #region Public functions

        /// <summary>
        /// Reads the information from the input file.
        /// </summary>
        /// <param name="filePath">The input file path.</param>
        /// <returns>The extracted info in a Trip object</returns>
        public static Trip ReadInput(string filePath)
        {
            string[] lines;
            ulong tripLength;
            ulong tankCapacity;
            ulong stationCount;

            // Read the lines of the file
            try {
                lines = File.ReadAllLines(filePath);
            } catch (Exception e) {
                throw new Exception($"Could not open file: {e.Message}");
            }

            // Check minimum line count
            if (lines.Length < 3)
                return null;

            // Read basic info
            try {
                tripLength = ulong.Parse(lines[0]);
                tankCapacity = ulong.Parse(lines[1]);
                stationCount = ulong.Parse(lines[2]);
            } catch (Exception e) {
                throw new Exception($"Invalid input data format: {e.Message}");
            }

            // Check exact line count
            if (lines.Length != (int)(stationCount + 3))
                throw new Exception("Number of fuel stations is incorrect");

            var car = new Vehicle(tankCapacity);
            var tripInfo = new Trip(tripLength, car, stationCount);

            // Read fuel stations
            try {
                for (ulong i = 3; i < (stationCount + 3); i++)
                {
                    ulong[] temp = lines[i].Split(' ').Select(ulong.Parse).ToArray();
                    tripInfo.FuelStations.Add(new FuelStation(temp[0], temp[1]));
                }
            } catch (Exception e) {
                throw new Exception($"Invalid input data format: {e.Message}");
            }

            return tripInfo;
        }

        /// <summary>
        /// Writes the given string to a text file.
        /// </summary>
        /// <param name="text">The text to write.</param>
        /// <param name="filePath">The output text file path.</param>
        public static void WriteOutput(string text, string filePath)
        {
            File.WriteAllText(filePath, text);
        }

        #endregion

        #region Entry point

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            // Read input file
            Trip trip = ReadInput(@"in.txt");

            // Write calculated price to "out.txt"
            WriteOutput(trip.CalculateMinimumPrice().ToString(), @"out.txt");
        }

        #endregion
    }
}
