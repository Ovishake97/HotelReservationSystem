using System;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelAdapter hotel = new HotelAdapter();
           var output= hotel.GetCheapestHotel("2018/03/02", "2018/03/10");
            Console.WriteLine(output.hotelName,output.rate);
        }
    }
}
