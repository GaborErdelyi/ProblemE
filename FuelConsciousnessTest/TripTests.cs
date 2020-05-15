#region Used assemblies

using System;
using FuelConsciousness;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace FuelConsciousnessTest
{
    #region Test methods

    /// <summary>
    /// Test class for "Trip" class
    /// </summary>
    [TestClass]
    public class TripTests
    {
        /// <summary>
        /// Empty trip test
        /// </summary>
        [TestMethod]
        public void TestMethod_EmptyTrip()
        {
            ulong expected = 0;

            Trip trip = new Trip(0, null, 0);

            ulong actual = trip.CalculateMinimumPrice();
            Assert.AreEqual(expected, actual, 0);
        }

        /// <summary>
        /// Invalid trip test (the maximum distance between 2 fuel stations is bigger than the tank capacity of the car)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Trip is not possible due to fuel station distances")]
        public void TestMethod_InvalidTrip()
        {
            Trip trip = new Trip(120, new Vehicle(50), 5);

            trip.FuelStations.Add(new FuelStation(20, 10));
            trip.FuelStations.Add(new FuelStation(90, 70));

            trip.CalculateMinimumPrice();
        }

        /// <summary>
        /// Valid trip test
        /// </summary>
        [TestMethod]
        public void TestMethod_ValidTrip_1()
        {
            ulong expected = 1050;

            Trip trip = new Trip(120, new Vehicle(50), 5);

            trip.FuelStations.Add(new FuelStation(20, 10));
            trip.FuelStations.Add(new FuelStation(30, 20));
            trip.FuelStations.Add(new FuelStation(50, 60));
            trip.FuelStations.Add(new FuelStation(60, 5));
            trip.FuelStations.Add(new FuelStation(90, 70));

            ulong actual = trip.CalculateMinimumPrice();
            Assert.AreEqual(expected, actual, 0);
        }

        /// <summary>
        /// Valid trip test
        /// </summary>
        [TestMethod]
        public void TestMethod_ValidTrip_2()
        {
            ulong expected = 1500;

            Trip trip = new Trip(100, new Vehicle(50), 4);

            trip.FuelStations.Add(new FuelStation(20, 100));
            trip.FuelStations.Add(new FuelStation(30, 10));
            trip.FuelStations.Add(new FuelStation(50, 60));
            trip.FuelStations.Add(new FuelStation(70, 70));

            ulong actual = trip.CalculateMinimumPrice();
            Assert.AreEqual(expected, actual, 0, "msg");
        }

        /// <summary>
        /// Valid trip test
        /// </summary>
        [TestMethod]
        public void TestMethod_ValidTrip_3()
        {
            ulong expected = 101590;

            Trip trip = new Trip(2801, new Vehicle(672), 9);

            trip.FuelStations.Add(new FuelStation(1157, 41));
            trip.FuelStations.Add(new FuelStation(497, 95));
            trip.FuelStations.Add(new FuelStation(124, 14));
            trip.FuelStations.Add(new FuelStation(2020, 46));
            trip.FuelStations.Add(new FuelStation(1608, 65));
            trip.FuelStations.Add(new FuelStation(1346, 100));
            trip.FuelStations.Add(new FuelStation(2764, 46));
            trip.FuelStations.Add(new FuelStation(2247, 56));
            trip.FuelStations.Add(new FuelStation(481, 63));

            ulong actual = trip.CalculateMinimumPrice();
            Assert.AreEqual(expected, actual, 0);
        }

        /// <summary>
        /// Valid trip test
        /// </summary>
        [TestMethod]
        public void TestMethod_ValidTrip_4()
        {
            ulong expected = 417336;

            Trip trip = new Trip(12797, new Vehicle(910), 30);

            trip.FuelStations.Add(new FuelStation(6603, 57));
            trip.FuelStations.Add(new FuelStation(9960, 58));
            trip.FuelStations.Add(new FuelStation(2492, 91));
            trip.FuelStations.Add(new FuelStation(8766, 52));
            trip.FuelStations.Add(new FuelStation(8058, 23));
            trip.FuelStations.Add(new FuelStation(8955, 62));
            trip.FuelStations.Add(new FuelStation(5825, 31));
            trip.FuelStations.Add(new FuelStation(4473, 87));
            trip.FuelStations.Add(new FuelStation(701, 8));
            trip.FuelStations.Add(new FuelStation(5554, 65));
            trip.FuelStations.Add(new FuelStation(3038, 91));
            trip.FuelStations.Add(new FuelStation(7661, 63));
            trip.FuelStations.Add(new FuelStation(8896, 53));
            trip.FuelStations.Add(new FuelStation(6982, 33));
            trip.FuelStations.Add(new FuelStation(9431, 20));
            trip.FuelStations.Add(new FuelStation(5081, 59));
            trip.FuelStations.Add(new FuelStation(12468, 42));
            trip.FuelStations.Add(new FuelStation(11364, 2));
            trip.FuelStations.Add(new FuelStation(7725, 56));
            trip.FuelStations.Add(new FuelStation(7425, 49));
            trip.FuelStations.Add(new FuelStation(6937, 47));
            trip.FuelStations.Add(new FuelStation(9563, 26));
            trip.FuelStations.Add(new FuelStation(7028, 87));
            trip.FuelStations.Add(new FuelStation(1725, 14));
            trip.FuelStations.Add(new FuelStation(1318, 17));
            trip.FuelStations.Add(new FuelStation(6222, 93));
            trip.FuelStations.Add(new FuelStation(11759, 37));
            trip.FuelStations.Add(new FuelStation(3688, 6));
            trip.FuelStations.Add(new FuelStation(8823, 75));
            trip.FuelStations.Add(new FuelStation(10850, 38));

            ulong actual = trip.CalculateMinimumPrice();
            Assert.AreEqual(expected, actual, 0);
        }

        /// <summary>
        /// Valid trip test
        /// </summary>
        [TestMethod]
        public void TestMethod_ValidTrip_5()
        {
            ulong expected = 21615588;

            Trip trip = new Trip(656949, new Vehicle(6859), 195);

            trip.FuelStations.Add(new FuelStation(349729, 58));
            trip.FuelStations.Add(new FuelStation(190317, 57));
            trip.FuelStations.Add(new FuelStation(366307, 72));
            trip.FuelStations.Add(new FuelStation(544385, 35));
            trip.FuelStations.Add(new FuelStation(598305, 97));
            trip.FuelStations.Add(new FuelStation(55911, 52));
            trip.FuelStations.Add(new FuelStation(606448, 51));
            trip.FuelStations.Add(new FuelStation(618144, 70));
            trip.FuelStations.Add(new FuelStation(247490, 13));
            trip.FuelStations.Add(new FuelStation(474091, 82));
            trip.FuelStations.Add(new FuelStation(206820, 82));
            trip.FuelStations.Add(new FuelStation(22036, 28));
            trip.FuelStations.Add(new FuelStation(196917, 41));
            trip.FuelStations.Add(new FuelStation(240726, 27));
            trip.FuelStations.Add(new FuelStation(377027, 24));
            trip.FuelStations.Add(new FuelStation(184318, 30));
            trip.FuelStations.Add(new FuelStation(521286, 71));
            trip.FuelStations.Add(new FuelStation(574151, 26));
            trip.FuelStations.Add(new FuelStation(322018, 96));
            trip.FuelStations.Add(new FuelStation(549837, 1));
            trip.FuelStations.Add(new FuelStation(100057, 60));
            trip.FuelStations.Add(new FuelStation(105701, 38));
            trip.FuelStations.Add(new FuelStation(75662, 90));
            trip.FuelStations.Add(new FuelStation(414386, 20));
            trip.FuelStations.Add(new FuelStation(323610, 91));
            trip.FuelStations.Add(new FuelStation(341221, 45));
            trip.FuelStations.Add(new FuelStation(624412, 60));
            trip.FuelStations.Add(new FuelStation(355769, 63));
            trip.FuelStations.Add(new FuelStation(146743, 97));
            trip.FuelStations.Add(new FuelStation(461888, 6));
            trip.FuelStations.Add(new FuelStation(53046, 27));
            trip.FuelStations.Add(new FuelStation(640130, 63));
            trip.FuelStations.Add(new FuelStation(636163, 72));
            trip.FuelStations.Add(new FuelStation(164945, 99));
            trip.FuelStations.Add(new FuelStation(539849, 52));
            trip.FuelStations.Add(new FuelStation(107372, 97));
            trip.FuelStations.Add(new FuelStation(428714, 73));
            trip.FuelStations.Add(new FuelStation(360600, 98));
            trip.FuelStations.Add(new FuelStation(555204, 79));
            trip.FuelStations.Add(new FuelStation(350224, 78));
            trip.FuelStations.Add(new FuelStation(205327, 59));
            trip.FuelStations.Add(new FuelStation(451069, 83));
            trip.FuelStations.Add(new FuelStation(107762, 85));
            trip.FuelStations.Add(new FuelStation(426311, 75));
            trip.FuelStations.Add(new FuelStation(275116, 72));
            trip.FuelStations.Add(new FuelStation(277266, 16));
            trip.FuelStations.Add(new FuelStation(254729, 70));
            trip.FuelStations.Add(new FuelStation(282020, 58));
            trip.FuelStations.Add(new FuelStation(637405, 72));
            trip.FuelStations.Add(new FuelStation(4487, 31));
            trip.FuelStations.Add(new FuelStation(230387, 67));
            trip.FuelStations.Add(new FuelStation(258896, 71));
            trip.FuelStations.Add(new FuelStation(493318, 41));
            trip.FuelStations.Add(new FuelStation(547079, 1));
            trip.FuelStations.Add(new FuelStation(586248, 45));
            trip.FuelStations.Add(new FuelStation(447908, 76));
            trip.FuelStations.Add(new FuelStation(561469, 69));
            trip.FuelStations.Add(new FuelStation(535144, 25));
            trip.FuelStations.Add(new FuelStation(109018, 20));
            trip.FuelStations.Add(new FuelStation(180576, 68));
            trip.FuelStations.Add(new FuelStation(16046, 96));
            trip.FuelStations.Add(new FuelStation(545411, 84));
            trip.FuelStations.Add(new FuelStation(160735, 34));
            trip.FuelStations.Add(new FuelStation(581073, 37));
            trip.FuelStations.Add(new FuelStation(266056, 76));
            trip.FuelStations.Add(new FuelStation(599987, 81));
            trip.FuelStations.Add(new FuelStation(306495, 25));
            trip.FuelStations.Add(new FuelStation(478342, 24));
            trip.FuelStations.Add(new FuelStation(132432, 88));
            trip.FuelStations.Add(new FuelStation(297919, 94));
            trip.FuelStations.Add(new FuelStation(116145, 8));
            trip.FuelStations.Add(new FuelStation(101168, 4));
            trip.FuelStations.Add(new FuelStation(848, 23));
            trip.FuelStations.Add(new FuelStation(228639, 77));
            trip.FuelStations.Add(new FuelStation(378894, 28));
            trip.FuelStations.Add(new FuelStation(445079, 80));
            trip.FuelStations.Add(new FuelStation(218176, 20));
            trip.FuelStations.Add(new FuelStation(568079, 1));
            trip.FuelStations.Add(new FuelStation(147381, 76));
            trip.FuelStations.Add(new FuelStation(345390, 5));
            trip.FuelStations.Add(new FuelStation(65731, 24));
            trip.FuelStations.Add(new FuelStation(397392, 79));
            trip.FuelStations.Add(new FuelStation(526719, 3));
            trip.FuelStations.Add(new FuelStation(644065, 4));
            trip.FuelStations.Add(new FuelStation(266071, 43));
            trip.FuelStations.Add(new FuelStation(191530, 10));
            trip.FuelStations.Add(new FuelStation(329089, 13));
            trip.FuelStations.Add(new FuelStation(605875, 21));
            trip.FuelStations.Add(new FuelStation(227088, 59));
            trip.FuelStations.Add(new FuelStation(513576, 79));
            trip.FuelStations.Add(new FuelStation(182496, 100));
            trip.FuelStations.Add(new FuelStation(81451, 20));
            trip.FuelStations.Add(new FuelStation(311217, 16));
            trip.FuelStations.Add(new FuelStation(505646, 32));
            trip.FuelStations.Add(new FuelStation(394487, 90));
            trip.FuelStations.Add(new FuelStation(111604, 98));
            trip.FuelStations.Add(new FuelStation(259634, 3));
            trip.FuelStations.Add(new FuelStation(163120, 52));
            trip.FuelStations.Add(new FuelStation(125710, 41));
            trip.FuelStations.Add(new FuelStation(632477, 33));
            trip.FuelStations.Add(new FuelStation(62991, 30));
            trip.FuelStations.Add(new FuelStation(417289, 27));
            trip.FuelStations.Add(new FuelStation(464396, 24));
            trip.FuelStations.Add(new FuelStation(541097, 42));
            trip.FuelStations.Add(new FuelStation(599926, 89));
            trip.FuelStations.Add(new FuelStation(466529, 82));
            trip.FuelStations.Add(new FuelStation(335768, 54));
            trip.FuelStations.Add(new FuelStation(612830, 24));
            trip.FuelStations.Add(new FuelStation(525525, 18));
            trip.FuelStations.Add(new FuelStation(240356, 63));
            trip.FuelStations.Add(new FuelStation(155688, 4));
            trip.FuelStations.Add(new FuelStation(131198, 44));
            trip.FuelStations.Add(new FuelStation(137661, 49));
            trip.FuelStations.Add(new FuelStation(559754, 48));
            trip.FuelStations.Add(new FuelStation(598330, 13));
            trip.FuelStations.Add(new FuelStation(579285, 39));
            trip.FuelStations.Add(new FuelStation(213407, 52));
            trip.FuelStations.Add(new FuelStation(43397, 63));
            trip.FuelStations.Add(new FuelStation(381246, 45));
            trip.FuelStations.Add(new FuelStation(224363, 45));
            trip.FuelStations.Add(new FuelStation(193444, 29));
            trip.FuelStations.Add(new FuelStation(369249, 37));
            trip.FuelStations.Add(new FuelStation(472596, 64));
            trip.FuelStations.Add(new FuelStation(340506, 98));
            trip.FuelStations.Add(new FuelStation(50756, 83));
            trip.FuelStations.Add(new FuelStation(270053, 12));
            trip.FuelStations.Add(new FuelStation(538554, 26));
            trip.FuelStations.Add(new FuelStation(92611, 67));
            trip.FuelStations.Add(new FuelStation(268349, 61));
            trip.FuelStations.Add(new FuelStation(648300, 4));
            trip.FuelStations.Add(new FuelStation(285055, 28));
            trip.FuelStations.Add(new FuelStation(588512, 79));
            trip.FuelStations.Add(new FuelStation(187661, 71));
            trip.FuelStations.Add(new FuelStation(251947, 3));
            trip.FuelStations.Add(new FuelStation(625555, 71));
            trip.FuelStations.Add(new FuelStation(123846, 73));
            trip.FuelStations.Add(new FuelStation(484746, 1));
            trip.FuelStations.Add(new FuelStation(25465, 43));
            trip.FuelStations.Add(new FuelStation(411737, 92));
            trip.FuelStations.Add(new FuelStation(203186, 97));
            trip.FuelStations.Add(new FuelStation(141597, 71));
            trip.FuelStations.Add(new FuelStation(607606, 67));
            trip.FuelStations.Add(new FuelStation(354153, 89));
            trip.FuelStations.Add(new FuelStation(153664, 43));
            trip.FuelStations.Add(new FuelStation(545288, 59));
            trip.FuelStations.Add(new FuelStation(652748, 16));
            trip.FuelStations.Add(new FuelStation(437991, 30));
            trip.FuelStations.Add(new FuelStation(457086, 5));
            trip.FuelStations.Add(new FuelStation(439367, 30));
            trip.FuelStations.Add(new FuelStation(530847, 82));
            trip.FuelStations.Add(new FuelStation(132263, 69));
            trip.FuelStations.Add(new FuelStation(375144, 98));
            trip.FuelStations.Add(new FuelStation(49206, 12));
            trip.FuelStations.Add(new FuelStation(177358, 21));
            trip.FuelStations.Add(new FuelStation(37180, 67));
            trip.FuelStations.Add(new FuelStation(176796, 91));
            trip.FuelStations.Add(new FuelStation(295075, 7));
            trip.FuelStations.Add(new FuelStation(260838, 30));
            trip.FuelStations.Add(new FuelStation(209448, 3));
            trip.FuelStations.Add(new FuelStation(389187, 2));
            trip.FuelStations.Add(new FuelStation(96758, 72));
            trip.FuelStations.Add(new FuelStation(432733, 8));
            trip.FuelStations.Add(new FuelStation(88309, 6));
            trip.FuelStations.Add(new FuelStation(32234, 92));
            trip.FuelStations.Add(new FuelStation(593039, 53));
            trip.FuelStations.Add(new FuelStation(514873, 12));
            trip.FuelStations.Add(new FuelStation(57389, 8));
            trip.FuelStations.Add(new FuelStation(71213, 81));
            trip.FuelStations.Add(new FuelStation(648682, 54));
            trip.FuelStations.Add(new FuelStation(324845, 52));
            trip.FuelStations.Add(new FuelStation(294665, 81));
            trip.FuelStations.Add(new FuelStation(383820, 2));
            trip.FuelStations.Add(new FuelStation(301381, 11));
            trip.FuelStations.Add(new FuelStation(630850, 64));
            trip.FuelStations.Add(new FuelStation(235709, 47));
            trip.FuelStations.Add(new FuelStation(405673, 35));
            trip.FuelStations.Add(new FuelStation(510999, 91));
            trip.FuelStations.Add(new FuelStation(170798, 15));
            trip.FuelStations.Add(new FuelStation(9992, 93));
            trip.FuelStations.Add(new FuelStation(457446, 46));
            trip.FuelStations.Add(new FuelStation(606648, 3));
            trip.FuelStations.Add(new FuelStation(328513, 91));
            trip.FuelStations.Add(new FuelStation(317990, 21));
            trip.FuelStations.Add(new FuelStation(517227, 98));
            trip.FuelStations.Add(new FuelStation(487866, 41));
            trip.FuelStations.Add(new FuelStation(158799, 28));
            trip.FuelStations.Add(new FuelStation(424098, 9));
            trip.FuelStations.Add(new FuelStation(97983, 87));
            trip.FuelStations.Add(new FuelStation(121411, 60));
            trip.FuelStations.Add(new FuelStation(500089, 67));
            trip.FuelStations.Add(new FuelStation(112845, 56));
            trip.FuelStations.Add(new FuelStation(289620, 4));
            trip.FuelStations.Add(new FuelStation(66436, 60));
            trip.FuelStations.Add(new FuelStation(84893, 65));
            trip.FuelStations.Add(new FuelStation(403228, 47));

            ulong actual = trip.CalculateMinimumPrice();
            Assert.AreEqual(expected, actual, 0);
        }
    }

    #endregion
}
