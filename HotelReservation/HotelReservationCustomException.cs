using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    /// Defining custom exceptions for the program
    public class HotelReservationCustomException : Exception
    {
        public enum ExceptionType
        {
            NO_SUCH_HOTEL,
            EMPTY_VALUE
        }
        public ExceptionType type;

        public HotelReservationCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
