using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
    /// <summary>
    /// Interface for all the rooms to follow
    /// </summary>
    internal interface IAmenities
    {
        /// <summary>
        /// Shows the ammenities that are available depending on the room
        /// </summary>
        void DisplayAmenities();
    }
}
