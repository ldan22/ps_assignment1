using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts;

namespace LayersOnWeb
{
    public interface ITicketModelDtoMapper
    {
        TicketModel Map(TicketDto ticket);
        TicketDto Map(TicketModel ticket);
    }
}
