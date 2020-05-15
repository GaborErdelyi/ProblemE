namespace FuelConsciousness
{
    /// <summary>
    /// Stores information about the car used for the trip
    /// </summary>
    public sealed class Vehicle
    {
        #region Members

        /// <summary>
        /// The maximum tank capacity of the car
        /// </summary>
        public readonly ulong TankCapacity;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="tankCapacity">The tank capacity of the car.</param>
        public Vehicle(ulong tankCapacity)
        {
            TankCapacity = tankCapacity;
        }

        #endregion
    }
}
