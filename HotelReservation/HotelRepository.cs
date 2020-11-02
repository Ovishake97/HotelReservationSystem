using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
   public class HotelRepository
    {
        int rate;
        public const string LAKEWOOD = "Lakewood";
        public const string BRIDGEWOOD = "Bridgewood";
        public const string RIDGEWOOD = "Ridgewood";
        public int GetRate(string hotelName) {
            
                if (hotelName.Equals(String.Empty)) {
                    throw new HotelReservationCustomException(HotelReservationCustomException.ExceptionType.EMPTY_VALUE, "Hotel name is empty");
                }
               else if (hotelName.ToLower().Equals(LAKEWOOD.ToLower()))
                {
                    rate = 110;
                }
                else if (hotelName.ToLower().Equals(BRIDGEWOOD.ToLower()))
                {
                    rate = 160;
                }
                else if (hotelName.ToLower().Equals(RIDGEWOOD.ToLower()))
                {
                    rate = 220;
                }
                
                else {
                    throw new HotelReservationCustomException(HotelReservationCustomException.ExceptionType.NO_SUCH_HOTEL, "No such hotel");
                }
                return rate;
            }
            
        }
    }

