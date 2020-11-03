using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservation
{
    public class HotelAdapter
    {
         
        public string hotelName;
        int rate;
        public const string LAKEWOOD = "Lakewood";
        public const string BRIDGEWOOD = "Bridgewood";
        public const string RIDGEWOOD = "Ridgewood";
        public HotelRepository GetRate(DateTime date ,string hotelName)
        {
            int hotelRate = 0;
            if (hotelName.Equals(String.Empty))
            {
                throw new HotelReservationCustomException(HotelReservationCustomException.ExceptionType.EMPTY_VALUE, "Hotel name is empty");
            }
            else if (hotelName.ToLower().Equals(LAKEWOOD.ToLower()))
            {
                //Assigns rate according to weekday and weekends for individual hotels
                if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
                {
                    rate = 90;
                    hotelRate = 3;
                }
                else {
                    rate = 110;
                    hotelRate = 3;
                }
                
            }
            else if (hotelName.ToLower().Equals(BRIDGEWOOD.ToLower()))
            {
                if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
                {
                    rate = 50;
                    hotelRate = 4;
                }
                else
                {
                    rate = 160;
                    hotelRate = 4;
                }
            }
            else if (hotelName.ToLower().Equals(RIDGEWOOD.ToLower()))
            {
                if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
                {
                    rate = 150;
                    hotelRate = 5;
                }
                else
                {
                    rate = 220;
                    hotelRate = 5;
                }
            }
          
            else
            {
                throw new HotelReservationCustomException(HotelReservationCustomException.ExceptionType.NO_SUCH_HOTEL, "No such hotel");
            }
            return new HotelRepository(rate,hotelName,hotelRate);
        }
        /// Gets the cheapest hotel for a given date range
        public List<HotelRepository> GetCheapestHotel(string dt1,string dt2)
        {
            //Defining a list to store the list of cheapest hotel(s)
            List<HotelRepository> hotels = new List<HotelRepository>();
            HotelRepository hotel = new HotelRepository();
            DateTime date1 = Convert.ToDateTime(dt1);
            DateTime date2 = Convert.ToDateTime(dt2);
            int total1=0, total2=0, total3=0;
            TimeSpan duration = date2.Subtract(date1);
            int length = Convert.ToInt32(duration.TotalDays);
            for (DateTime date = date1; date < date2; date=date.AddDays(1)) {
                hotel = GetRate(date,LAKEWOOD);
                total1 = total1 + hotel.rate;  
            }

            for (DateTime date = date1; date <date2; date=date.AddDays(1))

            {
                hotel = GetRate(date, BRIDGEWOOD);
                total2 = total2 + hotel.rate;
            }

            for (DateTime date = date1; date <date2; date=date.AddDays(1))

            {
                hotel = GetRate(date, RIDGEWOOD);
                total3 = total3 + hotel.rate;
            }
            int minTotalRate = GetMinimum(total1, total2, total3);
            int minRate = minTotalRate / length;
            if (minTotalRate == total1) {
                hotels.Add(new HotelRepository(minRate, LAKEWOOD,3));
            }
            else if (minTotalRate == total2) {
                hotels.Add(new HotelRepository(minRate, BRIDGEWOOD,4));
            }
            else {
                hotels.Add(new HotelRepository(minRate, RIDGEWOOD,5));
            }

            return hotels;
        }
        /// Function used to calculate the minimun out of three numbers which is in turn implemented
        /// to get the cheapest rate out of given hotels
        public Func<int, int, int, int> GetMinimum = (a, b, c) => {

            if (a <b && a < c)

            {
                return a;
            }
            else if (b < c && b < a)
            {
                return b;
            }
            else {
                return c;
            }
        };
    }
}
