using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;

namespace BusinessLayer.Contracts
{
    public interface ITicketMapper
    {
        TicketModel Map(Ticket ticket);

        Ticket Map(TicketModel ticketModel);
    }
}
