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
            HotelRepository actual = hotel.GetCheapestHotel("2018/03/18", "2018/03/27");
            Assert.AreEqual(expected, actual);
        }
    }
}
