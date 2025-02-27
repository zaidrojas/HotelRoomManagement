using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelRoomManagement
{
    internal class RoomMenu
    {
        public static void DisplayRoomMenu(Room roomInput)
        {
            #region Room Menu
            while (true)
            {
                // Display of most room information
                Program.ProgramTitle();
                Console.WriteLine($"{roomInput.RoomType()}");
                roomInput.RoomInformation();
                // Will be used for the user to determine what will be done with the room
                int roomChoice;

                //Specified Room's Menu Options with or without guests
                if (roomInput.Guests.Count() == 0)
                {
                    Console.WriteLine("\n1.) Ammenities");
                    Console.WriteLine("2.) Check In Guests");
                }
                else
                {
                    Console.WriteLine("\n1.) Ammenities");
                    Console.WriteLine("2.) Check Out Guests");
                    Console.WriteLine("3.) Guest/s Notes");
                    Console.WriteLine("4.) Send Cleaning Service");
                    Console.WriteLine("5.) Schedule Wake-up Call");
                }
                Console.WriteLine("----------------------------------");
                Console.WriteLine("(Keep blank and enter to go back)");
                Console.Write("Enter choice: ");
                
                string input = Console.ReadLine(); 
                if (string.IsNullOrEmpty(input))
                {
                    Console.Clear();
                    break;
                }
                if (!int.TryParse(input, out roomChoice))
                {
                    Console.WriteLine("\n***************************");
                    Console.WriteLine("Choice must be a valid integer.");
                    Console.WriteLine("***************************\n");
                    continue;
                }

                switch (roomChoice)
                {
                    case 1:
                        // Display the ammenities
                        Console.Clear();
                        Program.ProgramTitle();
                        ((IAmenities)roomInput).DisplayAmenities();
                        Console.Clear();
                        break;

                    case 2:
                        // Fields
                        string f_name;
                        string l_name;

                        // Check in Guests
                        Console.Clear();
                        Program.ProgramTitle();
                        for (int i = 0; i < roomInput.RoomCapacity; i++)
                        {
                            Console.Write("Enter guest first name: ");
                            f_name = Console.ReadLine();
                            if (string.IsNullOrEmpty(f_name))
                            { break; }


                            Console.Write("Enter guest last name: ");
                            l_name = Console.ReadLine();
                            Program.StringVerifyNull(l_name);
                        }

                        Console.Clear();
                        Program.ProgramTitle();
                        Console.WriteLine("Enter the ");

                        // Check out Guests

                        break;

                    case 3: 
                        // Guests notes
                        
                        break;

                    case 4:
                        // Send Cleaning Service
                        Console.Clear();
                        Program.ProgramTitle();
                        roomInput.CleaningService();
                        Console.Clear();
                        break;

                    case 5:
                        // Set up wake up call
                        Console.Clear();
                        Program.ProgramTitle();
                        roomInput.WakeUpCall();
                        Console.Clear();
                        break;

                    default:
                        break;
                }

            }
            #endregion
        }

    }
}
