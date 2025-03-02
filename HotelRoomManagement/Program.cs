using System.Security.Cryptography;

namespace HotelRoomManagement
{
    internal class Program
    {
        #region Verification methods
        // Methods to verify inputs
        public static bool StringVerifyNull(string variable)
        {
            try
            {
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

        public static bool IntVerify(out int variable)
        {
            try
            {
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

        public static bool IntVerifyOrNull(out int variable)
        {
            try
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    variable = 0;
                    return true; // Treat empty input as valid
                }

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

        // Example: 
        // StringVerifyNull(a_string);
        public static bool CardVerify(out double card)
        {
            try
            {
                string input = Console.ReadLine();
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
        public static string UpperStart(string word)
        {
            string updated_word = word.ToLower();
            char start_chat = char.ToUpper(updated_word[0]);
            updated_word = updated_word.Substring(1);
            return start_chat + updated_word;
        }
        #endregion

        #region Program Title
        public static void ProgramTitle()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("** Levalo's Room Booking System **");
            Console.WriteLine("**********************************");
        }
        #endregion

        #region Display ___ Rooms

        public static void ViewRooms(string option)
        {
            string row = "";
            int loops = 0;
            foreach (Room room in hotelRooms)
            {
                // Adding all rooms, whether occupied or not
                if (option.ToLower() == "all")
                {
                    row += ("[" + room.RoomNumber + "]; ");
                }
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
