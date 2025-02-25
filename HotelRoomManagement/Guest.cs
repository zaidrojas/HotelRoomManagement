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
        private string _name;

        /// <summary>
        /// Gets guest's number
        /// </summary>
        public string Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty or whitespace.");
                }
                _name = value;
            }
        }

    }
}
