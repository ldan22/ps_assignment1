using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using DataAccess.Contracts;


namespace BusinessLayer
{
    public class TicketMapper : ITicketMapper
    {
        private readonly IShowMapper showMapper;

        public TicketMapper(IShowMapper showMapper)
        {
            this.showMapper = showMapper;
        }

        public TicketModel Map(Ticket ticket)
        {
            var ticketModel =  new TicketModel
            {
                Id = ticket.Id,
                SeatNumber = ticket.SeatNumber,
                SeatRow = ticket.SeatRow,
            };
            if (ticket.Show != null)
            {
                ticketModel.Show = showMapper.Map(ticket.Show);
            }
            return ticketModel;
        }

        public Ticket Map(TicketModel ticketModel)
        {
            var ticket =  new Ticket
            {
                Id = ticketModel.Id,
                SeatNumber = ticketModel.SeatNumber,
                SeatRow = ticketModel.SeatRow,
                Show = showMapper.Map(ticketModel.Show)
            };

            if (ticketModel.Show != null)
            {
                ticket.Show = showMapper.Map(ticketModel.Show);
            }
            return ticket;
        }
    }
}
