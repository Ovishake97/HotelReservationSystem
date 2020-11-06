using System;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Enter the customer type: Regular or Reward");
            string type = Console.ReadLine();
            Console.WriteLine("Enter the check in date: for example 10Jan2020");
            string date1 = Console.ReadLine();
            Console.WriteLine("Enter the check out date");
            string date2 = Console.ReadLine();
            HotelAdapter adapter = new HotelAdapter();
            HotelRepository result = adapter.GetCheapestHotel(type, date1, date2);
            Console.WriteLine("Cheapest best rated hotel for you is: ");
            Console.WriteLine("Hotel name: "+result.hotelName);
            Console.WriteLine("Price: "+result.rate);
            Console.WriteLine("Rating:" +result.hotelRating);
        }
    }
}
