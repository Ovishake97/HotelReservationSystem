using System;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelAdapter hotel = new HotelAdapter();
           var output= hotel.GetCheapestHotel("16Dec2020", "20Dec2020");
            Console.WriteLine(output.hotelName,output.rate);
        }
    }
}
