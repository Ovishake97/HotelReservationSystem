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
        public const int LAKEWOOD_RATINGS = 3;
        public const int BRIDGEWOOD_RATINGS = 4;
        public const int RIDGEWOOD_RATINGS = 5;
        /// Method to get the rate of a hotel
        /// in a certain range of dates
        public HotelRepository GetRate(DateTime date ,string hotelName)
        {
            int hotelRate = 0;
            if (hotelName.Equals(String.Empty))
            {
                throw new HotelReservationCustomException(HotelReservationCustomException.ExceptionType.EMPTY_VALUE, "Hotel name is empty");
            }
            else if (hotelName.ToLower().Equals(LAKEWOOD.ToLower()))
            {
                hotelRate = LAKEWOOD_RATINGS;
                //Assigns rate according to weekday and weekends for individual hotels
                if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
                {
                    rate = 90;
                    
                }
                else {
                    rate = 110;
                    
                }
                
            }
            else if (hotelName.ToLower().Equals(BRIDGEWOOD.ToLower()))
            {
                hotelRate = BRIDGEWOOD_RATINGS;
                if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
                {
                    rate = 50;
                    
                }
                else
                {
                    rate = 150;
                    
                }
            }
            else if (hotelName.ToLower().Equals(RIDGEWOOD.ToLower()))
            {
                hotelRate = RIDGEWOOD_RATINGS;
                if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
                {
                    rate = 150;
                    
                }
                else
                {
                    rate = 220;
                    
                }
            }
          
            else
            {
                throw new HotelReservationCustomException(HotelReservationCustomException.ExceptionType.NO_SUCH_HOTEL, "No such hotel");
            }
            return new HotelRepository(rate,hotelName,hotelRate);
        }
        /// Gets the cheapest hotel for a given date range
        public HotelRepository GetCheapestHotel(string dt1,string dt2)
        {
            //Defining a list to store the list of cheapest hotel(s)
            List<HotelRepository> hotels = new List<HotelRepository>();
            HotelRepository hotel = new HotelRepository();
            DateTime date1 = Convert.ToDateTime(dt1);
            DateTime date2 = Convert.ToDateTime(dt2);
            int total1=0, total2=0, total3=0;
            TimeSpan duration = date2.Subtract(date1);
            int length = Convert.ToInt32(duration.TotalDays);
            for (DateTime date = date1; date <= date2; date=date.AddDays(1)) {
                hotel = GetRate(date,LAKEWOOD);
                total1 = total1 + hotel.rate;  
            }

            for (DateTime date = date1; date <=date2; date=date.AddDays(1))

            {
                hotel = GetRate(date, BRIDGEWOOD);
                total2 = total2 + hotel.rate;
            }

            for (DateTime date = date1; date <=date2; date=date.AddDays(1))

            {
                hotel = GetRate(date, RIDGEWOOD);
                total3 = total3 + hotel.rate;
            }
            int minTotalRate = GetMinimum(total1, total2, total3);
            int minRate = minTotalRate / length;
            if (minTotalRate == total1) {
                hotels.Add(new HotelRepository(minRate, LAKEWOOD,LAKEWOOD_RATINGS));
            }
            if (minTotalRate == total2) {
                hotels.Add(new HotelRepository(minRate, BRIDGEWOOD,BRIDGEWOOD_RATINGS));
            }
            if (minTotalRate == total3)
            {
                hotels.Add(new HotelRepository(minRate, RIDGEWOOD,RIDGEWOOD_RATINGS));
            }
            int hotelRate=0;
            List<int> hotelRatings = new List<int>(); 
            foreach (HotelRepository elements in hotels) {
                hotelRatings.Add(elements.hotelRating);
                }
            hotelRate = GetMaximum(hotelRatings);
            switch (hotelRate) {
                case LAKEWOOD_RATINGS: hotelName = LAKEWOOD;
                    break;
                case BRIDGEWOOD_RATINGS: hotelName = BRIDGEWOOD;
                    break;
                case RIDGEWOOD_RATINGS: hotelName = RIDGEWOOD;
                    break;
                default: break;
            }
            return new HotelRepository(minRate,hotelName,hotelRate);
        }
        public HotelRepository GetBestRatedHotel(string dt1, string dt2) {
            HotelRepository hotel = new HotelRepository();
            List<int> hotelRatings = new List<int>();
            DateTime date1 = Convert.ToDateTime(dt1);
            DateTime date2 = Convert.ToDateTime(dt2);
            int total1 = 0, total2 = 0, total3 = 0;
            for (DateTime date = date1; date <= date2; date = date.AddDays(1))
            {
                hotel = GetRate(date, LAKEWOOD);
                total1 = total1 + hotel.rate;
                hotelRatings.Add(hotel.hotelRating);
            }
            for (DateTime date = date1; date <= date2; date = date.AddDays(1))
            {
                hotel = GetRate(date, BRIDGEWOOD);
                total2 = total2 + hotel.rate;
                hotelRatings.Add(hotel.hotelRating);
            }
            for (DateTime date = date1; date <= date2; date = date.AddDays(1))
            {
                hotel = GetRate(date, RIDGEWOOD);
                total3 = total3 + hotel.rate;
                hotelRatings.Add(hotel.hotelRating);
            }
            int maximumRating = GetMaximum(hotelRatings);
            if (maximumRating == LAKEWOOD_RATINGS)
            {
                return new HotelRepository(total1, LAKEWOOD, LAKEWOOD_RATINGS);
            }
            else if (maximumRating == BRIDGEWOOD_RATINGS)
            {
                return new HotelRepository(total2, BRIDGEWOOD, BRIDGEWOOD_RATINGS);
            }
            else {
                return new HotelRepository(total3,RIDGEWOOD,RIDGEWOOD_RATINGS);
            }
        }

        /// Function used to calculate the minimun out of three numbers which is in turn implemented
        /// to get the cheapest rate out of given hotels
        public Func<int, int, int, int> GetMinimum = (a, b, c) => {

            if ((a <b && a < c)||(a==b && a<c)||(a<b && a==c))

            {
                return a;
            }
            else if ((b < c && b < a)||(b==a && b<c)||(b==c && b<a))
            {
                return b;
            }
            else {
                return c;
            }
        };
        /// Function used to get the maximum out of an array which is
        /// useful to get the best rated hotel out of the available hotels
        public Func<List<int>,int> GetMaximum= (arr) => {
            return arr.Max();
        };
    }
}
