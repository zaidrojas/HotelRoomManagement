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

                // Handling what shall be done with the room
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
                        if (roomInput.Guests.Count() == 0)
                        {
                            #region Checking in Guests
                            // Fields
                            string f_name, l_name;
                            int days_staying = 0;
                            double card_n = 0;

                            // Check in guests
                            Console.Clear();
                            Program.ProgramTitle();
                            Console.WriteLine("-------- Check In Guest/s --------");
                            Console.WriteLine("(Keep blank and enter when done)");

                            List<Guest> tempGuests = new List<Guest>();

                            // Continuously ask the user to input guests
                            for (int i = 0; i < roomInput.RoomCapacity; i++)
                            {
                                Console.Write("Enter guest first name: ");
                                f_name = Console.ReadLine();

                                // Finish check-in process if input is blank
                                if (string.IsNullOrEmpty(f_name))
                                {
                                    if (tempGuests.Count == 0)
                                    {
                                        Console.WriteLine("No guests added. Returning to menu...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        return;
                                    }

                                    break; // Proceed to payment section
                                }

                                Console.Write("Enter guest last name: ");
                                l_name = Console.ReadLine();
                                Program.StringVerifyNull(l_name);

                                // Capitalize names properly
                                Guest cur_guest = new Guest(Program.UpperStart(f_name), Program.UpperStart(l_name));
                                tempGuests.Add(cur_guest);
                                Console.WriteLine("Guest has been added!");

                                // If room is full, proceed to payment
                                if (i == roomInput.RoomCapacity - 1)
                                {
                                    Console.WriteLine("Room is now full.");
                                    break;
                                }
                            }

                            // Only ask for payment if there are guests
                            if (tempGuests.Count > 0)
                            {
                                Console.Clear();
                                Program.ProgramTitle();
                                while (true)
                                {
                                    Console.WriteLine("-------- Check In Guest/s --------");
                                    Console.Write("Please enter the number of days staying: ");
                                    if (!Program.IntVerify(out days_staying)) continue;

                                    Console.Write("Enter the card number for payment (000-000-000) (do not enter dashes): ");
                                    if (!Program.CardVerify(out card_n)) continue;

                                    // Add all guests to the room
                                    foreach (var guest in tempGuests)
                                    {
                                        roomInput.AddGuest(guest, days_staying, card_n);
                                    }
                                    break;
                                }
                            }

                            // Confirmation message
                            Console.Clear();
                            Program.ProgramTitle();
                            Console.WriteLine("-------- Check In Guest/s --------");
                            Console.WriteLine("All Done!");
                            Console.Write("Enter to go back: ");
                            Console.ReadLine();
                            Console.Clear();
                            #endregion
                        }
                        else
                        {
                            #region Check out guests
                            // Check out Guests
                            Console.Clear();
                            Program.ProgramTitle();
                            Console.WriteLine("-------- Check Out Guest/s -------");
                            Console.WriteLine("\nThe guests have successfully been checked out!\n");
                            roomInput.CheckOutGuests();
                            Console.WriteLine("----------------------------------");
                            Console.Write("Hit enter to go back: ");
                            Console.ReadLine();
                            Console.Clear();
                            #endregion
                        }
                        break;

                    case 3:
                        if (roomInput.Guests.Count() != 0)
                        {
                            // Fields
                            int note_choice;

                            // Guests notes
                            #region Guest Notes
                            Console.Clear();
                            Program.ProgramTitle();
                            Console.WriteLine("---------- Guest Notes -----------");
                            roomInput.DisplayNotes();
                            Console.WriteLine("1.) Add a Note");
                            Console.WriteLine("2.) Remove a Note");
                            Console.WriteLine("3.) Clear Notes");
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("(Keep blank and enter to go back)");
                            Console.Write("Enter choice: ");
                            if (!Program.IntVerify(out note_choice))
                            { continue; }

                            // Handles how to affect the notes
                            switch (note_choice)
                            {
                                case 1:
                                    while (true)
                                    {
                                        // New note to be added
                                        string new_note;

                                        Console.Clear();
                                        Program.ProgramTitle();
                                        Console.WriteLine("---------- Guest Notes -----------");
                                        roomInput.DisplayNotes();
                                        Console.WriteLine("----------------------------------");
                                        Console.WriteLine("(Keep blank and enter to go back): ");
                                        Console.Write("Enter the note: ");
                                        new_note = Console.ReadLine();
                                        if (string.IsNullOrEmpty(new_note))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            roomInput.AddNote(new_note);
                                            continue;
                                        }
                                    }
                                    Console.Clear();
                                    break;

                                case 2:
                                    while (true)
                                    {
                                        break;
                                    }
                                    Console.Clear();
                                    break;

                                case 3:
                                    roomInput.RemoveAllNotes();
                                    break;

                                default:
                                    break;
                            }
                            break;
                            #endregion
                        }
                        else
                        {
                            // Does Not apply to a non occupied room
                            Console.WriteLine("\n***************************");
                            Console.WriteLine("Choose an integer available on the choice list above.");
                            Console.WriteLine("***************************\n");
                        }
                        break;

                    case 4:
                        if (roomInput.Guests.Count() != 0)
                        {
                            // Send Cleaning Service
                            Console.Clear();
                            Program.ProgramTitle();
                            roomInput.CleaningService();
                            Console.Clear();
                        }
                        else
                        {
                            // Does Not applt to a non occupied room
                            Console.WriteLine("\n***************************");
                            Console.WriteLine("Choose an integer available on the choice list above.");
                            Console.WriteLine("***************************\n");
                        }
                        break;

                    case 5:
                        if (roomInput.Guests.Count() != 0)
                        {
                            // Set up wake up call
                            Console.Clear();
                            Program.ProgramTitle();
                            roomInput.WakeUpCall();
                            Console.Clear();
                        }
                        else
                        {
                            // Does Not applt to a non occupied room
                            Console.WriteLine("\n***************************");
                            Console.WriteLine("Choose an integer available on the choice list above.");
                            Console.WriteLine("***************************\n");
                        }
                        break;

                    default:
                        Console.WriteLine("\n***************************");
                        Console.WriteLine("Choose an integer available on the choice list above.");
                        Console.WriteLine("***************************\n");
                        break;
                }

            }
            #endregion
        }

    }
}
