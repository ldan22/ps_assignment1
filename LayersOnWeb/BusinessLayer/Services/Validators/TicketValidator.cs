using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contracts;

namespace BusinessLayer
{
    public class TicketValidator : ITicketValidator
    {
        public bool validate(TicketModel ticket)
        {
            if(ticket.SeatNumber <= 0 || ticket.SeatRow <= 0)
            {
                return false;
            }

            return true;
        }

    }
}
