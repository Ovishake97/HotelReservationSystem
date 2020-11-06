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
        [TestMethod]
        public void EntersDateGetsCheapestHotel()
        {
            //Act
            HotelRepository expected = new HotelRepository(200, "Bridgewood", 4);
            HotelRepository actual = hotel.GetCheapestHotel("11Sep2020", "12Sep2020");
            //Assert
            expected.Equals(actual);
        }
    }
}
