using HotelReservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {
        HotelReservation.HotelAdapter hotel = null;
        [TestInitialize]
        public void SetUp() {
            hotel = new HotelReservation.HotelAdapter();
        }
        [TestMethod]
        public void EntersDateGetsCheapestHotel()
        {
            HotelRepository expected = new HotelRepository(110, "Lakewood");
            HotelRepository actual = hotel.GetCheapestHotel("10Dec2020", "20Dec2020");
            Assert.AreEqual(expected, actual);
        }
    }
}
