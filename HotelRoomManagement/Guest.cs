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
        /// Gets guest's first name
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

        /// <summary>
        /// Gets guest's last name
        /// </summary>
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

        /// <summary>
        /// Constructor to initilize the Guest instance
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Guest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
