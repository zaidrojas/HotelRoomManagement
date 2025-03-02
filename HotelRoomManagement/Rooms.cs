using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelRoomManagement
{
    /// <summary>
    /// General abstract class of the rooms
    /// </summary>
    abstract class Room
    {
        // Fields
        private string _roomNumber;
        private int _roomCapacity;
        private List<string> _guestNotes = new List<string>();
        private List<Guest> _guests = new List<Guest>();
        private double _guestCardNumber;
        private int _daysStaying;
        private int _daysLeft;

        /// <summary>
        /// Gets room number
        /// </summary>
        public string RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Room number cannot be empty or whitespace.");
                }
                _roomNumber = value;
            }
        }

        /// <summary>
        /// Gets rooms capacity
        /// </summary>
        public int RoomCapacity
        {
            get { return _roomCapacity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Room capacity must be a valid integer greater than or equal to 0.");
                }
                _roomCapacity = value;
            }
        }


        /// <summary>
        /// Gets list of the guest notes
        /// </summary>
        public List<string> GuestNotes
        {
            get { return _guestNotes; }
        }

        /// <summary>
        /// Gets list of current guests
        /// </summary>
        public List<Guest> Guests
        {
            get { return _guests; }
        }

        /// <summary>
        /// Gets the card number paying for the room
        /// </summary>
        public double GuestCardNumber
        {
            get { return _guestCardNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card number must be a valid integer greater than or equal to 0.");
                }
                _guestCardNumber = value;
            }
        }

        /// <summary>
        /// Gets the number of days the guests are paying to stay for
        /// </summary>
        public int DaysStaying
        {
            get { return _daysStaying; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Days staying must be a valid integer greater than or equal to 0.");
                }
                _daysStaying = value;
            }
        }

        /// <summary>
        /// Gets the number of days the guests have left
        /// </summary>
        public int DaysLeft
        {
            get { return _daysLeft; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Days left must be a valid integer greater than or equal to 0.");
                }
                _daysLeft = value;
            }
        }

        /// <summary>
        /// Add the guest to the Guest List of Guest Classes
        /// </summary>
        /// <param name="newGuest"></param>
        public void AddGuest(Guest newGuest)
        {
            Guests.Add(newGuest);
        }

        /// <summary>
        /// Adds the guest to the Guest list, and updates the days staying, and the card information for payment
        /// </summary>
        /// <param name="newGuest"></param>
        /// <param name="daysStaying"></param>
        /// <param name="cardInfo"></param>
        public void AddGuest(Guest newGuest, int daysStaying, double cardInfo)
        {
            AddGuest(newGuest);
            DaysStaying = daysStaying;
            DaysLeft = daysStaying;
            GuestCardNumber = cardInfo;
        }

        /// <summary>
        /// Adds the guest to the Guest list, and updates the days staying, and the card information for payment, and adds a note to the list of notes
        /// </summary>
        /// <param name="newGuest"></param>
        /// <param name="daysStaying"></param>
        /// <param name="cardInfo"></param>
        /// <param name="note"></param>
        public void AddGuest(Guest newGuest, int daysStaying, double cardInfo, string note)
        {
            AddGuest(newGuest, daysStaying, cardInfo);
            GuestNotes.Add(note);
        }

        /// <summary>
        /// Will set all the information regarding the guests staying—including the actual guests, days staying, notes, and card payment, as empty or 0
        /// </summary>
        public void CheckOutGuests()
        {
            GuestNotes.Clear();
            Guests.Clear();
            GuestCardNumber = 0;
            DaysLeft = 0;
            DaysStaying = 0;
        }

        /// <summary>
        /// Will Display the Room's basic information, and will display information regarding the guests should there be guest currently staying
        /// </summary>
        public void RoomInformation()
        {
            // Individual room's information
            Console.WriteLine($"Room Capacity: {RoomCapacity}");
            Console.WriteLine($"Guests: {Guests.Count()}");
            if (Guests.Count != 0)
            {
                // Display's each guest
                foreach (Guest guest in Guests)
                {
                    Console.WriteLine($"-{guest.FirstName} {guest.LastName}");
                }
                // the guest's staying information 
                Console.WriteLine($"Days Staying: {DaysStaying}");
                Console.WriteLine($"Days Remaining: {DaysLeft}");
                Console.WriteLine($"Card Being Used: {GuestCardNumber}");
            }
        }

        /// <summary>
        /// Displays the notes available on the notes list, will number the notes if asked
        /// </summary>
        /// <param name="numbers"></param>
        public void DisplayNotes(bool numbers = false)
        {
            // Numbers-bool will make it if the notes are numbered or not
            Console.WriteLine("**** Notes ****");
            for (var i = 0; i < GuestNotes.Count; i++)
            {
                if (numbers)
                {
                    Console.WriteLine($"{i + 1}] {GuestNotes[i]}");
                }
                else
                {
                    Console.WriteLine($"[] {GuestNotes[i]}");
                }
            }
            Console.WriteLine("***************");

        }

        /// <summary>
        /// Adds a note to the note list.
        /// </summary>
        /// <param name="new_note"></param>
        public void AddNote(string new_note)
        {
            GuestNotes.Add(new_note);
        }

        /// <summary>
        /// Removes the note at a the specified index
        /// </summary>
        /// <param name="remove_note"></param>
        /// <returns>bool if it was possible to remove a note at that index</returns>
        public bool RemoveNote(int? remove_note)
        {
            // Since Notes list begins at 1, the actual value is one less the displayed list #
            remove_note -= 1;

            // if the input is null, or not within the range of the Notes list, it will throw an error
            if (remove_note < 0 || remove_note >= GuestNotes.Count || remove_note == null)
            {
                Console.WriteLine("\n***************************");
                Console.WriteLine("Note index is out of range.");
                Console.WriteLine("***************************\n");
                return false;
            }

            // RemoveAt does not work with null values, so int index is used as the int value determined by the possible-null remove_note variable
            int index = remove_note.Value;
            GuestNotes.RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Clears the Guest Notes list
        /// </summary>
        public void RemoveAllNotes()
        {
            GuestNotes.Clear();
        }

        /// <summary>
        /// Will inform the user that the cleaning service has been sent, displaying it in the console
        /// </summary>
        public void CleaningService()
        {
            Console.WriteLine("-------- Cleaning Service --------");
            Console.WriteLine("\nSending Cleaning Service...");
            Console.WriteLine("Expected to be done in 30 minutes.\n");
            Console.WriteLine("----------------------------------");
            Console.Write("(Keep blank and enter to go back): ");
            Console.ReadLine();
        }

        /// <summary>
        /// Will inform the user that the Wake-Up call will be active for the guest staying, displaying it in the console
        /// </summary>
        public void WakeUpCall()
        {
            Console.WriteLine("---------- Wake Up Call ----------");
            Console.WriteLine("\nWake-Up call has been scheduled for tommorow at 8:00 am.\n");
            Console.WriteLine("----------------------------------");
            Console.Write("(Keep blank and enter to go back): ");
            Console.ReadLine();
        }

        // Other rooms will say if they are standard or luxery rooms
        public abstract string RoomType();

    }


}
