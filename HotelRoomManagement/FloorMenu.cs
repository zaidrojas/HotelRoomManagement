using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
    internal class FloorMenu
    {
        public static void DisplayFloorMenu(int choice)
        {
            while (true)
            {
                // Field
                Room roomInput = null;
                
                // Display title
                Program.ProgramTitle();

                // Rooms being showed
                if (choice == 1)
                {
                    Console.WriteLine("----------- All Rooms ------------");
                    Program.ViewRooms("all");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("---------- Vacant Rooms ----------");
                    Program.ViewRooms("vacant");
                }
                else if (choice == 3)
                {
                    Console.WriteLine("--------- Occupied Rooms ---------");
                    Program.ViewRooms("occupied");
                }
                // User Input
                Console.WriteLine("----------------------------------");
                Console.WriteLine("(Keep blank and enter to return to Main Menu)");
                Console.Write("Enter room (Format: A1): ");
                string u_input = Console.ReadLine();
                if (string.IsNullOrEmpty(u_input))
                {
                    break;
                }


                // Room Menu
                if (Program.VerifyRoom(u_input, out roomInput))
                {
                    Console.Clear();
                    RoomMenu.DisplayRoomMenu(roomInput);
                }
            }

        }

    }
}
