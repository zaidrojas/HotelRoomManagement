using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<string> _guestNotes;
        private List<Guest> _guests;
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

        public void RoomInformation()
        {
            // Room Capacity
            // Current Guests #
               // Guest Names
            // Total Days Staying
            // Days Remaining
            // Card payment info
        }

        public void DisplayNotes()
        {

        }

        public void AddNote()
        {

        }

        public void RemoveNote()
        {

        }

        // Other rooms will say if they are standard or elite
        public abstract string RoomType();
    
    }
}
