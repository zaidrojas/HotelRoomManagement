using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
    /// <summary>
    /// Luxery Room Class
    /// </summary>
    internal class LuxuryRoom : Room, IAmenities
    {
        /// <summary>
        /// Constructor that is used to inialize a room. 
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <param name="roomCapacity"> How many people the room can fit </param>
        public LuxuryRoom(string roomNumber, int roomCapacity)
        {
            RoomNumber = roomNumber;
            RoomCapacity = roomCapacity;
        }

        /// <summary>
        /// Displays the type of room it is
        /// </summary>
        /// <returns> a string is returned for the program to then display </returns>
        public override string RoomType()
        {
            return "---------- Luxury Room -----------";
        }

        /// <summary>
        /// Displays the available amenities available in a luxery room
        /// </summary>
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
