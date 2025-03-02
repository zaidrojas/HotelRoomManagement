using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
    /// <summary>
    /// Standard Room Class
    /// </summary>
    internal class StandardRoom: Room, IAmenities
    {
        /// <summary>
        /// Constructor that is used to inialize a room.
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <param name="roomCapacity"></param>
        public StandardRoom(string roomNumber, int roomCapacity)
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
            return "--------- Standard Room ----------";
        }

        /// <summary>
        /// Displays the available amenities available in a standard room
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
            Console.WriteLine("----------------------------------");
            Console.Write("(Keep blank and enter to go back): ");
            Console.ReadLine();
        }
    }
}
