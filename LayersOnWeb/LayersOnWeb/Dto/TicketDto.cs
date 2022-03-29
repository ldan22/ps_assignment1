using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb
{
    public class TicketDto
    {
        public int Id { get; set; }
        public ShowDto Show { get; set; }
        public int SeatRow { get; set; }
        public int SeatNumber { get; set; }
    }
}
