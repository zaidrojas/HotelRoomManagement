using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelRoomManagement
{
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

        public void AddGuest(Guest newGuest)
        {
            Guests.Add(newGuest);
        }

        public void AddGuest(Guest newGuest, int daysStaying, double cardInfo)
        {
            AddGuest(newGuest);
            DaysStaying = daysStaying;
            DaysLeft = daysStaying;
            GuestCardNumber = cardInfo;
        }

        public void AddGuest(Guest newGuest, int daysStaying, double cardInfo, string note)
        {
            AddGuest(newGuest, daysStaying, cardInfo);
            GuestNotes.Add(note);
        }

        public void CheckOutGuests()
        {
            GuestNotes.Clear();
            Guests.Clear();
            GuestCardNumber = 0;
            DaysLeft = 0;
            DaysStaying = 0;
        }

        public void RoomInformation()
        {
            Console.WriteLine($"Room Capacity: {RoomCapacity}");
            Console.WriteLine($"Guests: {Guests.Count()}");
            if (Guests.Count != 0)
            {
                foreach (Guest guest in Guests)
                {
                    Console.WriteLine($"-{guest.FirstName} {guest.LastName}");
                }
                Console.WriteLine($"Days Staying: {DaysStaying}");
                Console.WriteLine($"Days Remaining: {DaysLeft}");
                Console.WriteLine($"Card Being Used: {GuestCardNumber}");
            }
        }

        public void DisplayNotes(bool numbers = false)
        {
            // numbers will make it if the notes are numbered or not
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

        public void AddNote(string new_note)
        {
            GuestNotes.Add(new_note);
        }

        public bool RemoveNote(int remove_note)
        {
            remove_note -= 1;
            if (remove_note < 0 || remove_note >= GuestNotes.Count)
            {
                Console.WriteLine("\n***************************");
                Console.WriteLine("Note index is out of range.");
                Console.WriteLine("***************************\n");
                return false;
            }
            GuestNotes.RemoveAt(remove_note);
            return true;
        }

        public void RemoveAllNotes()
        {
            GuestNotes.Clear();
        }

        public void CleaningService()
        {
            Console.WriteLine("-------- Cleaning Service --------");
            Console.WriteLine("\nSending Cleaning Service...");
            Console.WriteLine("Expected to be done in 30 minutes.\n");
            Console.WriteLine("----------------------------------");
            Console.Write("(Keep blank and enter to go back): ");
            Console.ReadLine();
        }

        public void WakeUpCall()
        {
            Console.WriteLine("---------- Wake Up Call ----------");
            Console.WriteLine("\nWake-Up call has been scheduled for tommorow at 8:00 am.\n");
            Console.WriteLine("----------------------------------");
            Console.Write("(Keep blank and enter to go back): ");
            Console.ReadLine();
        }

        // Other rooms will say if they are standard or elite
        public abstract string RoomType();

    }


}
