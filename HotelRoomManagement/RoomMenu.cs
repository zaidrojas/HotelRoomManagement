using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelRoomManagement
{
    /// <summary>
    /// Class that is being used to display the entirety of the Room Menu instead of all the code being compiled in Program.cs
    /// </summary>
    internal class RoomMenu
    {
        /// <summary>
        /// The menu tree that goes through the Room Menu and handles the room's information
        /// </summary>
        /// <param name="roomInput"> the specified room class the user is editing </param>
        public static void DisplayRoomMenu(Room roomInput)
        {
            #region Room Menu
            while (true)
            {
                // Display program title and room information
                Program.ProgramTitle();
                Console.WriteLine($"{roomInput.RoomType()}");
                roomInput.RoomInformation();
                // Will be used for the user to determine what will be done with the room
                int roomChoice;

                // Specified Room's Menu Options depending if they have guests or not
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
                // If the string is empty, will go back to the hotel floors menu
                string input = Console.ReadLine(); 
                if (string.IsNullOrEmpty(input))
                {
                    Console.Clear();
                    break;
                }
                // Will verify if the input is a proper integer, if not it shall loop
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
                        // Amenities differentiate between the standard and luxery rooms
                        ((IAmenities)roomInput).DisplayAmenities();
                        Console.Clear();
                        break;

                    case 2:
                        // Add or remove guests depending if there are guests

                        if (roomInput.Guests.Count() == 0)
                        {
                            #region Checking in Guests
                            // Fields
                            string f_name, l_name;
                            int days_staying = 0;
                            double card_n = 0;

                            // Ask to check in guests
                            Console.Clear();
                            Program.ProgramTitle();
                            Console.WriteLine("-------- Check In Guest/s --------");
                            Console.WriteLine("(Keep blank and enter when done)");

                            // A placeholder for the guest currently being handled to add into the room 
                            List<Guest> tempGuests = new List<Guest>();

                            // Continuously ask the user to input guests
                            for (int i = 0; i < roomInput.RoomCapacity; i++)
                            {
                                // Willl ask the player to add the nth guest
                                Console.Write($"Enter first name of guest {i+1}: ");
                                f_name = Console.ReadLine();

                                // Continue to the checking in process if input is blank
                                if (string.IsNullOrEmpty(f_name))
                                {
                                    // If the user has not added any guests into the room, it it will inform that the guest's in the room will remain 0
                                    if (tempGuests.Count == 0)
                                    {
                                        Console.Write("No guests added. Returning to menu, hit enter: ");
                                        Console.ReadLine();
                                        Console.Clear();
                                        return;
                                    }

                                    // Proceed to payment section
                                    break;
                                }

                                Console.Write($"Enter last name of guest {i + 1}: ");
                                l_name = Console.ReadLine();
                                // if nth guest's last name is improper, it will go back to asking for the guest's first name
                                if (!Program.StringVerifyNull(l_name))
                                { i--;  continue; }

                                // Capitalize names properly when adding into the list
                                Guest cur_guest = new Guest(Program.UpperStart(f_name), Program.UpperStart(l_name));
                                tempGuests.Add(cur_guest);
                                Console.WriteLine("Guest has been added!");

                                // Once the room is full, proceed 
                                if (i == roomInput.RoomCapacity - 1)
                                {
                                    Console.Write("Room is now full, hit enter to proceed: ");
                                    Console.ReadLine();
                                    break;
                                }
                            }

                            // Names have been added, will now ask for the days staying and payment information
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
                                    // Makes sure the days staying is greater than 0
                                    if (days_staying <= 0) 
                                    {
                                        Console.WriteLine("\n***************************");
                                        Console.WriteLine("Days staying must be greater than 0");
                                        Console.WriteLine("***************************\n");
                                        continue;
                                    }

                                    // If the card number entered is not 9-digits, it will make the user restart from the # of days section
                                    Console.Write("Enter the card number for payment (000-000-000) (do not enter dashes): ");
                                    if (!Program.CardVerify(out card_n)) continue;

                                    // Add all guests in the guest list to the room, updating the number of days the room will be occupied at the payment being stored
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
                            // Clears all the guests from the room's guest list and clears the days staying and card information
                            roomInput.CheckOutGuests();
                            Console.WriteLine("----------------------------------");
                            // Goes back to the Room Menu
                            Console.Write("Hit enter to go back: ");
                            Console.ReadLine();
                            Console.Clear();
                            #endregion
                        }
                        break;

                    case 3:
                        if (roomInput.Guests.Count() != 0)
                        {
                            #region Guest Notes
                            Console.Clear();
                            while (true)
                            {
                                // Fields
                                int? note_choice; // used to decide what will be done with the list of guest notes

                                // Guests notes
                                // DIsplay's program title and section user is on
                                Program.ProgramTitle();
                                Console.WriteLine("---------- Guest Notes -----------");
                                // Will display the notes if available
                                roomInput.DisplayNotes();
                                // Note options
                                Console.WriteLine("1.) Add a Note");
                                Console.WriteLine("2.) Remove a Note");
                                Console.WriteLine("3.) Clear Notes");
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine("(Keep blank and enter to go back)");
                                Console.Write("Enter choice: ");
                                if (!Program.IntVerifyOrNull(out note_choice))
                                { continue; }

                                // Should the input be blank, will go back to the room's menu
                                if (note_choice == null)
                                {
                                    Console.Clear();
                                    break;
                                }

                                // Handles how to affect the notes
                                switch (note_choice)
                                {
                                    case 1:
                                        Console.Clear();
                                        while (true)
                                        {
                                            // New note to be added
                                            string new_note;

                                            // Display's program title and guest notes section
                                            Program.ProgramTitle();
                                            Console.WriteLine("---------- Guest Notes -----------");
                                            roomInput.DisplayNotes();
                                            Console.WriteLine("----------------------------------");
                                            Console.WriteLine("(Keep blank and enter to go back): ");
                                            Console.Write("Enter the note: ");

                                            // If user's input is blank, go back to room's menu
                                            new_note = Console.ReadLine();
                                            if (string.IsNullOrEmpty(new_note))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                // Add the note the user has written
                                                roomInput.AddNote(new_note);
                                                Console.Clear();
                                                continue;
                                            }
                                        }
                                        Console.Clear();
                                        break;

                                    case 2:
                                        // Remove a note
                                        Console.Clear();
                                        while (true)
                                        {
                                            // Note to be removed
                                            int? delete_note;

                                            Program.ProgramTitle();
                                            Console.WriteLine("---------- Guest Notes -----------");
                                            roomInput.DisplayNotes(true);
                                            Console.WriteLine("----------------------------------");
                                            Console.WriteLine("(Keep blank and enter to go back): ");
                                            Console.Write("Enter note# to deleted: ");
                                            if (!Program.IntVerifyOrNull(out delete_note))
                                            { continue; }

                                            if (delete_note == null)
                                            {
                                                // user's value was empty so the menu will go back
                                                break;
                                            }
                                            else
                                            {
                                                // if out of range, it will restart from this point
                                                if (!roomInput.RemoveNote(delete_note))
                                                { continue; }
                                                // if within range, will return true and simpl continue
                                                Console.Clear();
                                                continue;
                                            }
                                            
                                        }
                                        Console.Clear();
                                        break;

                                    case 3:
                                        // Clear all the notes
                                        roomInput.RemoveAllNotes();
                                        Console.Clear();
                                        break;

                                    default:
                                        // Should the user input an int not within the options available
                                        Console.WriteLine("\n***************************");
                                        Console.WriteLine("Choose an option from 1-3.");
                                        Console.WriteLine("***************************\n");
                                        continue;
                                }
                                break;
                            }
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
                            // Sends Cleaning Service, letting the user know they have been sent to the room
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
                            // Lets user know a wake up call has been set for the guest/s
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
                        // Should the input not be within the options available
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
