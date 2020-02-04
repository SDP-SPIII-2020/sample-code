using System;

/*  Represent data without DTO classes
    Lower memory footprint than a class
    Return multiple values from methods 
    without the need for out variables
*/
namespace ValueTuples
{
    internal static class Program
    {
        static (double lat, double lng) GetCoordinates(string query)
        {
            //DO search query ...
            return (lat: 47.6450905056185, lng: 122.130835641356);
        }

        static void Main(string[] args)
        {
            var pos = GetCoordinates("15700 NE 39th St, Redmond, WA");
            Console.WriteLine(pos.lat); //47.6450905056185 pos.lng; //122.130835641356
        }
    }
}