﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        List<Ticket> GetTicketsByShowId(int id);
        int CountTicketsByShowId(int id);

        Ticket GetBySeat(int seatRow, int seatNumber);
    }
}
