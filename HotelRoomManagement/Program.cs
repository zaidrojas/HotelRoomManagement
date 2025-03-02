using System.Security.Cryptography;

namespace HotelRoomManagement
{
    internal class Program
    {
        #region Verification methods
        // Methods to verify inputs
        /// <summary>
        /// Verifies that the string input is not Null or Empty
        /// </summary>
        /// <param name="variable"></param>
        /// <returns> Returns true if string is valid</returns>
        public static bool StringVerifyNull(string variable)
        {
            try
            {
                // if it is null or empty, throw an error message
                if (string.IsNullOrWhiteSpace(variable))
                {
                    throw new ArgumentException("Input must not be Null or Whitespace.");
                }
                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\n***************************");
                Console.WriteLine(ex.Message);
                Console.WriteLine("***************************\n");
                return false;
            }
        }
        // Example: 
        // if (!IntVerify(out a_int))
        // { continue; }

        /// <summary>
        /// Verifies that the input is a valid intiger
        /// </summary>
        /// <param name="variable"></param>
        /// <returns> Returns true if the input is a valid intiger </returns>
        public static bool IntVerify(out int variable)
        {
            try
            {
                // Temporary input that reads the console only to store into the variable when it is read as a valid int
                string input = Console.ReadLine();
                if (!int.TryParse(input, out variable))
                {
                    throw new FormatException("Choice must be a valid integer.");
                }
                return true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\n***************************");
                Console.WriteLine(ex.Message);
                Console.WriteLine("***************************\n");
                variable = 0; 
                return false;
            }
        }

        /// <summary>
        /// Verifies if the input is a Int or null, if not a valid in, it it will store the specified value as a null value
        /// </summary>
        /// <param name="variable"></param>
        /// <returns> returns if the input is valid in or not, if it is empty or null, it returns the specified value as a null. </returns>
        public static bool IntVerifyOrNull(out int? variable)
        {
            try
            {
                // Temporary input that can be TryParsed since null values cannot
                string input = Console.ReadLine();

                // If console input was NullOrEmpty, will return true and set the variable as a null
                if (string.IsNullOrEmpty(input))
                {
                    variable = null;
                    return true;
                }

                // If it is a Int and not a string, it will store the value into the specified variable
                if (!int.TryParse(input, out int tempVar))
                {
                    throw new FormatException("Choice must be a valid integer.");
                }

                variable = tempVar;
                return true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\n***************************");
                Console.WriteLine(ex.Message);
                Console.WriteLine("***************************\n");
                variable = 0;
                return false;
            }
        }

        // Example: 
        // StringVerifyNull(a_string);

        /// <summary>
        /// Is used specifically for the Room Menu's validation of the Card input
        /// </summary>
        /// <param name="card"></param>
        /// <returns> Returns true or false if the card nubmer is proper </returns>
        public static bool CardVerify(out double card)
        {
            try
            {
                // temporary variable to be TryParsed
                string input = Console.ReadLine();

                // If the input is both a valid double and 9 digits in length, it returns true
                if (!double.TryParse(input, out card) || input.Length != 9)
                {
                    throw new FormatException("Card must be a valid 9-digit input.");
                }
                return true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\n***************************");
                Console.WriteLine(ex.Message);
                Console.WriteLine("***************************\n");
                card = 0; 
                return false;
            }
        }

        #endregion

        #region Uppercase string
        /// <summary>
        /// Reformats the inputed string into all but the starting character being lowercased, the starting being uppercased
        /// </summary>
        /// <param name="word"></param>
        /// <returns> reformatted string </returns>
        public static string UpperStart(string word)
        {
            // The word is set entierly lowercased, then split into two
            string updated_word = word.ToLower();
            // The starting character from the initial, set to be uppercased
            char start_chat = char.ToUpper(updated_word[0]);
            // The updated word now only consists of the letters after the 1st character
            updated_word = updated_word.Substring(1);
            // The uppercased letter and rest of the updated word are combined
            return start_chat + updated_word;
        }
        #endregion

        #region Program Title
        /// <summary>
        /// Display's the Title of the Program
        /// </summary>
        public static void ProgramTitle()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("** Melato's Room Booking System **");
            Console.WriteLine("**********************************");
        }
        #endregion

        #region Display ___ Rooms
        /// <summary>
        /// Displays all the rooms and their numbers of the hotel
        /// </summary>
        /// <param name="option"> will determine which rooms will be showed </param>
        public static void ViewRooms(string option)
        {
            // Fields
            string row = ""; // the row of rooms that will be printed
            int loops = 0; // determines the number of rooms gone through for each row loop, will reset after each floor
            foreach (Room room in hotelRooms)
            {
                // Adding all rooms, whether occupied or not
                if (option.ToLower() == "all")
                {
                    row += ("[" + room.RoomNumber + "]; ");
                }
                // Add the rooms that are vacant, will not show room number if occupied
                else if (option.ToLower() == "vacant")
                {
                    if (room.Guests.Count == 0) {
                        row += ("[" + room.RoomNumber + "]; ");
                    }
                    else
                    {
                        row += ("[  ]; ");
                    }
                }
                // Add the rooms that are occupied, will not show room number if vacant
                else if (option.ToLower() == "occupied")
                {
                    if (room.Guests.Count != 0)
                    {
                        row += ("[" + room.RoomNumber + "]; ");
                    }
                    else
                    {
                        row += ("[  ]; ");
                    }
                }
                loops++;

                // After every third loop 
                if (loops == 3)
                {
                    Console.WriteLine($"{row}");
                    row = "";
                    loops = 0;
                }

            }
        }
        #endregion

        #region Add Guests
        public static void RoomToAddGuest(string room_num, Guest newGuest, int daysStaying = 0, double cardInfo = 0, string note = "")
        {
            foreach (Room room in hotelRooms)
            {
                if (room.RoomNumber.ToLower() == room_num.ToLower())
                {
                    if (cardInfo < 0)
                    {
                        room.AddGuest(newGuest);
                    }
                    // If not simply adding the guest but also the other stay information, then it shall be added
                    else if (note == "")
                    {
                        room.AddGuest(newGuest, daysStaying, cardInfo);
                    }
                    else
                    {
                        room.AddGuest(newGuest, daysStaying, cardInfo, note);
                    }
                    return;
                }
            }
        }

        #endregion

        #region VerifyRoom
        public static bool VerifyRoom(string room_num, out Room storedRoom)
        {
            foreach (Room room in hotelRooms)
            {
                if (room.RoomNumber.ToLower() == room_num.ToLower())
                {
                    storedRoom = room;
                    return true;
                }
            }
            Console.WriteLine("\n***************************");
            Console.WriteLine("Room Cannot be found.");
            Console.WriteLine("***************************\n");
            storedRoom = null;
            return false;
        }
        #endregion

        static List<Room> hotelRooms = new List<Room>
        {
            // Level A
            new LuxuryRoom("A1", 4),
            new LuxuryRoom("A2", 4),
            new LuxuryRoom("A3", 4),
            // Level B
            new StandardRoom("B1", 4),
            new StandardRoom("B2", 4),
            new StandardRoom("B3", 4),
            // Level C
            new StandardRoom("C1", 2),
            new StandardRoom("C2", 2),
            new StandardRoom("C3", 2)
        };

        

        static void Main(string[] args)
        {
            // Adding Guest
            Guest tempGuest = new Guest("Josh", "Jacob");
            RoomToAddGuest("A1", tempGuest);

            tempGuest = new Guest("James", "Jacob");
            RoomToAddGuest("A1", tempGuest, 2, 111222333, "James hates blue");

            while (true)
            {
                // Fields
                int choice;
                //

                ProgramTitle();
                Console.WriteLine("----------- Main Menu ------------");
                Console.WriteLine("1.) View All Rooms");
                Console.WriteLine("2.) View Vacant Rooms");
                Console.WriteLine("3.) View Occipied Rooms");
                Console.WriteLine("4.) Search Guest");
                Console.WriteLine("5.) Move to Next Day");
                Console.WriteLine("6.) Exit Program");
                Console.WriteLine("----------------------------------");
                Console.Write("Enter choice: ");
                if (!IntVerify(out choice))
                { continue; }

                // Main Menu Options
                switch (choice)
                {
                    case 1:
                    case 2:
                    case 3:
                        // All Hotel Rooms Menu
                        Console.Clear();
                        FloorMenu.DisplayFloorMenu(choice);
                        Console.Clear();

                        continue;

                    case 4:
                        Console.Clear();
                        while (true)
                        {
                            string g_search;
                            List<Room> guests_rooms= new List<Room>();
                            int interval = 1;
                            int g_select;
                            Room room_selected = null;
                            ProgramTitle();
                            Console.WriteLine("---------- Guest Search ----------");
                            Console.WriteLine("(Enter on blank to go back)");
                            Console.Write("Enter the last name of guest: ");
                            g_search = Console.ReadLine();

                            if (string.IsNullOrEmpty(g_search)) { Console.Clear();  break; }

                            foreach (Room room in hotelRooms)
                            {
                                foreach (Guest guest in room.Guests)
                                {
                                    if (guest.LastName.ToLower() == g_search.ToLower())
                                    {
                                        Console.WriteLine($"{interval}: {guest.FirstName} {guest.LastName}");
                                        guests_rooms.Add(room);
                                        interval++;
                                    }
                                }
                            }
                            Console.WriteLine("----------------------------------");
                            
                            if (guests_rooms.Count == 0)
                            {
                                Console.WriteLine("\n***************************");
                                Console.WriteLine("Guest is not in our system.");
                                Console.WriteLine("***************************\n");
                                continue;

                            }

                            Console.Write("Enter guest # to find: ");
                            if (!IntVerify(out g_select))
                            { continue; }

                            try
                            {
                                room_selected = guests_rooms[g_select - 1];
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("\n***************************");
                                Console.WriteLine("Guest option is out of range.");
                                Console.WriteLine("***************************\n");
                                continue;
                            }

                            Console.WriteLine($"\nGuest is inside Room: {room_selected.RoomNumber}");
                            Console.WriteLine("All the guests in the room are:");
                            foreach (Guest guest in room_selected.Guests)
                            {
                                Console.WriteLine($"-{guest.FirstName} {guest.LastName}");
                            }
                            Console.WriteLine("----------------------------------");
                            Console.Write("Hit enter to go back: ");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        continue;

                    case 5:
                        Console.Clear();
                        ProgramTitle();
                        Console.WriteLine("------------ Next Day ------------");
                        foreach(Room room in hotelRooms)
                        {
                            if (room.DaysLeft > 0)
                            {
                                room.DaysLeft -= 1;
                                Console.WriteLine($"Room {room.RoomNumber} now has {room.DaysLeft} day/s left of their stay.");
                                if (room.DaysLeft == 0)
                                {
                                    Console.WriteLine($"Room {room.RoomNumber} will be automatically checked out");
                                    room.CheckOutGuests();
                                }
                            }
                        }
                        Console.WriteLine("----------------------------------");
                        Console.Write("Hit enter to go back: ");
                        Console.ReadLine();
                        Console.Clear();
                        continue;

                    case 6:
                        // Exit Program
                        break;

                    default:
                        Console.WriteLine("\n***************************");
                        Console.WriteLine("Choice must be between 1-6.");
                        Console.WriteLine("***************************\n");
                        continue;
                }
                break;

            }

        }
    }
}
