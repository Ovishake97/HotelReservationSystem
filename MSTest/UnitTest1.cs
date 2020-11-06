using HotelReservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        /// Checking whether the GetCheapestHotel() method returns
        /// correct object
        [TestMethod]
        public void EntersRewardCustomerGetsCheapestBestRatedHotel() {
            HotelRepository expected = new HotelRepository(140, "Ridgewood", 5);
            HotelRepository actual = hotel.GetCheapestHotel("Reward", "11Sep2020", "12Sep2020");
            expected.Equals(actual);
        }
        /// Checking whether the exception thrown upon entering
        /// a different customer type throws the defined custom exception
        [TestMethod]
        public void EntersWrongCustomerTypeThrowsException() {
            try {
                HotelRepository result = hotel.GetCheapestHotel("Special", "11Sep2020", "12Sep2020");
            }
            catch (HotelReservationCustomException exception) {
                Assert.AreEqual(exception.Message, "No such customer type");
            }
        }
    }
}
