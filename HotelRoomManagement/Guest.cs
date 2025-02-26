using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
    internal class Guest
    {
        // Fields
        private string _firstName;
        private string _lastName;

        /// <summary>
        /// Gets guest's number
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty or whitespace.");
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty or whitespace.");
                }
                _lastName = value;
            }
        }

        public Guest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
