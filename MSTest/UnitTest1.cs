using HotelReservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {
        HotelReservation.HotelRepository hotel = null;
        [TestInitialize]
        public void SetUp() {
            hotel = new HotelReservation.HotelRepository();
        }
        [TestMethod]
        public void GivenHotelNameReturnsRate()
        {
            //Act
            int actual = hotel.GetRate("Bridgewood");
            int expected = 160;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenWrongHotelNameReturnsException() {
            try
            {
                //Act
                int result = hotel.GetRate("Greenwood");
            }
            catch (HotelReservationCustomException exception) {
                //Assert
                Assert.AreEqual("No such hotel", exception.Message);
            }
        }
    }
}
