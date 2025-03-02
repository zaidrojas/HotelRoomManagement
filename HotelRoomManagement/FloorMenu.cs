using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
    /// <summary>
    /// Class that is being used to display the entirety of the Hotel Floors' Menu instead of all the code being compiled in Program.cs
    /// </summary>
    internal class FloorMenu
    {
        /// <summary>
        /// The menu tree that goes through the Floor Menu and handles the room's information
        /// </summary>
        /// <param name="choice">Is the variable that determine which rooms to displayed </param>
        public static void DisplayFloorMenu(int choice)
        {
            while (true)
            {
                // Field
                // the specified room that will be selected to be affected
                Room roomInput = null;
                
                // Display title
                Program.ProgramTitle();

                // Rooms being showed depending on the choice of the user, ie the occupied, vacant, or all rooms
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
                // If the input is null or empty, go back to the main menu
                if (string.IsNullOrEmpty(u_input))
                {
                    break;
                }


                // Will check if the room the user input is even an available room at the hotel
                if (Program.VerifyRoom(u_input, out roomInput))
                {
                    Console.Clear();
                    // Open up and display the Room's Menu to edit the room
                    RoomMenu.DisplayRoomMenu(roomInput);
                }
            }

        }

    }
}
