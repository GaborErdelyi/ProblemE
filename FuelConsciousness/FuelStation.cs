namespace FuelConsciousness
{
    /// <summary>
    /// Contains a fuel station
    /// </summary>
    public sealed class FuelStation
    {
        #region Members

        /// <summary>
        /// The distance from the starting point
        /// </summary>
        public readonly ulong Distance;

        /// <summary>
        /// The fuel price of this fuel station
        /// </summary>
        public readonly ulong Price;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="FuelStation"/> class.
        /// </summary>
        /// <param name="distance">The distance from the starting point.</param>
        /// <param name="price">The fuel price of this fuel station.</param>
        public FuelStation(ulong distance, ulong price)
        {
            Distance = distance;
            Price = price;
        }

        #endregion
    }
}
