using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
   public class HotelRepository
    {
        public int rate;
        public string hotelName;
        public int hotelRating;
        public HotelRepository() {
            //default constructor
        }
        public HotelRepository(int rate, string hotelName,int hotelRating)
        {
            this.rate = rate;
            this.hotelName = hotelName;
            this.hotelRating = hotelRating;
        }
        /// Overriding the Equals() method
        /// To compare the objects returned from the methods of 
        /// the HotelAdapter class in the unit tests
        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (!(obj is HotelRepository)) {
                return false;
            }
            HotelRepository hotelRepository = (HotelRepository)obj;
            return this.hotelName == hotelRepository.hotelName && this.rate == hotelRepository.rate && this.hotelRating==hotelRepository.hotelRating;
        }
        /// Overriding the GetHashCode() method to avoid compile time error
        public override int GetHashCode()
        {
            var res1 = this.rate.GetHashCode();
            var res2 = this.hotelName.GetHashCode();
            var res3 = this.hotelRating.GetHashCode();
            return res1 * res2*res3;
        }
    }
    }

