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
        /// It is tested whether the GetCheapestHotel() method
        /// is retruning the best rated and cheapest hotel for the given daterange
        [TestMethod]
        public void EntersDateGetsCheapestHotel()
        {
            //Act
            HotelRepository expected = new HotelRepository(200, "Bridgewood", 4);
            HotelRepository actual = hotel.GetCheapestHotel("11Sep2020", "12Sep2020");
            //Assert
            expected.Equals(actual);
        }
        /// It is tested whether the GetBestRatedHotel() method
        /// is retruning the best rated hotel for the given daterange
        [TestMethod]
        public void EntersDateGetsBestRatedHotel()
        {
            //Act
            HotelRepository expected = new HotelRepository(370, "Ridgewood", 5);
            HotelRepository actual = hotel.GetBestRatedHotel("11Sep2020", "12Sep2020");
            //Assert
            expected.Equals(actual);
        }
    }
}
