using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class TicketModel
    {
        public int Id { get; set; }
        public ShowModel Show { get; set; }
        public int SeatRow { get; set; }
        public int SeatNumber { get; set; }
    }
}
