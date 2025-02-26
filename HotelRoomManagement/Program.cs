using System.Security.Cryptography;

namespace HotelRoomManagement
{
    internal class Program
    {
        #region Verification methods
        // Methods to verify inputs
        public static bool StringVerifyNull(string variable)
        {

            // variable is the input to be verified
            if (string.IsNullOrWhiteSpace(variable))
            {
                Console.WriteLine("\n***************************");
                Console.WriteLine("Input must not be Null or Whitespace.");
                Console.WriteLine("***************************\n");
                return false;
            }
            return true;
        }
        // Example: 
        // if (!IntVerify(out a_int))
        // { continue; }

        public static bool IntVerify(out int variable)
        {
            // variable is the input to be verified
            if (!int.TryParse(Console.ReadLine(), out variable))
            {
                Console.WriteLine("\n***************************");
                Console.WriteLine("Choice must be a valid integer.");
                Console.WriteLine("***************************\n");
                return false;
            }
            return true;
        }
        // Example: 
        // StringVerifyNull(a_string);
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
                        row += ("[  ]");
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
        public static void RoomToAddGuest(string room_num, Guest newGuest)
        {
            foreach (Room room in hotelRooms)
            {
                if (room.RoomNumber.ToLower() == room_num.ToLower())
                {
                    room.AddGuest(newGuest);
                    return;
                }
            }
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
            while (true)
            {
                Guest tempGuest = new Guest("Josh", "Jacob");
                RoomToAddGuest("A1", tempGuest);
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
                        // Field
                        int roomChoice;

                        Console.Clear();
                        ProgramTitle();
                        Console.WriteLine("----------- All Rooms ------------");
                        ViewRooms("all");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("(Keep blank and enter to return to Main Menu)");
                        Console.Write("Enter room (Format: A1): ");
                        if (!IntVerify(out roomChoice))
                        { continue; }

                        break;

                    case 2:
                        Console.Clear();
                        ProgramTitle();
                        Console.WriteLine("----------- All Rooms ------------");
                        ViewRooms("vacant");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("(Keep blank and enter to return to Main Menu)");
                        Console.Write("Enter room (Format: A1): ");
                        if (!IntVerify(out roomChoice))
                        { continue; }

                        break;

                    case 3:
                        Console.Clear();
                        ProgramTitle();
                        Console.WriteLine("----------- All Rooms ------------");
                        ViewRooms("occupied");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("(Keep blank and enter to return to Main Menu)");
                        Console.Write("Enter room (Format: A1): ");
                        if (!IntVerify(out roomChoice))
                        { continue; }

                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    default:
                        break;
                }


            }

        }
    }
}
