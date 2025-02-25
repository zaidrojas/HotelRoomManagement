﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
    internal class StandardRoom: Room, IAmenities
    {
        public StandardRoom(string roomNumber, int roomCapacity)
        {
            RoomNumber = roomNumber;
            RoomCapacity = roomCapacity;
        }

        public override string RoomType()
        {
            return "--------- Standard Room ----------";
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
        }
    }
}
