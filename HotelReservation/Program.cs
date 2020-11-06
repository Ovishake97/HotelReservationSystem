using System;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelAdapter hotel = new HotelAdapter();
           HotelRepository hotel1= hotel.GetBestRatedHotel("11Sep2020", "12Sep2020");
            Console.WriteLine(hotel1.rate);
            Console.WriteLine(hotel1.hotelName);
            
        }
    }
}
