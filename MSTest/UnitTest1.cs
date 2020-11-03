using HotelReservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {
        HotelReservation.HotelAdapter hotel = null;
        List<HotelRepository> expected;
        List<HotelRepository> actual;
        [TestInitialize]
        public void SetUp() {
            hotel = new HotelReservation.HotelAdapter();
            expected = new List<HotelRepository>();
            actual = new List<HotelRepository>();
        }
        [TestMethod]
        public void EntersDateGetsCheapestHotel()
        {
            HotelRepository expectedObject = new HotelRepository(110, "Lakewood",3);
            expected.Add(expectedObject);
            actual = hotel.GetCheapestHotel("14Dec2020", "18Dec2020");
            expected.Equals(actual);
        }
        /// Defining a testmethod to check the cheapest hotel(s)
        /// for weekdays and weekends
        [TestMethod]
        public void EntersDateGetsCheapestHotel_Weekday_And_Weekend() {
            HotelRepository expected1 = new HotelRepository(110, "Bridgewood",4);
            HotelRepository expected2 = new HotelRepository(110, "Lakewood",3);
            expected.Add(expected1);
            expected.Add(expected2);
             actual = hotel.GetCheapestHotel("11Sep2020", "12Sep2020");
            expected.Equals(actual);
        }
    }
}
