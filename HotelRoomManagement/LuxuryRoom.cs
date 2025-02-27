using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
    internal class LuxuryRoom : Room, IAmenities
    {

        public LuxuryRoom(string roomNumber, int roomCapacity)
        {
            RoomNumber = roomNumber;
            RoomCapacity = roomCapacity;
        }

        public override string RoomType()
        {
            return "---------- Luxury Room -----------";
        }

        public void DisplayAmenities()
        {
            Console.WriteLine("------------ Amenities -----------");
            Console.WriteLine("-Mini Fridge");
            Console.WriteLine("-Microwave");
            Console.WriteLine("-Desk");
            Console.WriteLine("-Alarm Clock");
            Console.WriteLine("-Wifi");
            Console.WriteLine("-Hair Dryer");
            Console.WriteLine("-A/C");
            Console.WriteLine("-Televisoin");
            Console.WriteLine("-Toiletries");
            Console.WriteLine("-Sound System");
            Console.WriteLine("-Two Bathrobes");
            Console.WriteLine("-Balcony With Beach View");
            Console.WriteLine("-Locking Safe");
            Console.WriteLine("----------------------------------");
            Console.Write("(Keep blank and enter to go back): ");
            Console.ReadLine();
        }
    }
}
