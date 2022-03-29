using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts;


namespace LayersOnWeb.Mapper
{
    public class TicketModelDtoMapper : ITicketModelDtoMapper
    {

        private readonly IShowModelDtoMapper showMapper;

        public TicketModelDtoMapper(IShowModelDtoMapper showMapper)
        {
            this.showMapper = showMapper;
        }

        public TicketDto Map(TicketModel ticket)
        {
            var ticketDto =  new TicketDto
            {
                Id = ticket.Id,
                SeatNumber = ticket.SeatNumber,
                SeatRow = ticket.SeatRow
            };

            if(ticket.Show != null)
            {
                ticketDto.Show = showMapper.Map(ticket.Show);
            }

            return ticketDto;
        }
        public TicketModel Map(TicketDto ticket)
        {
            var ticketModel =  new TicketModel
            {
                Id = ticket.Id,
                SeatNumber = ticket.SeatNumber,
                SeatRow = ticket.SeatRow
            };

            if(ticket.Show != null)
            {
                ticketModel.Show = showMapper.Map(ticket.Show);
            }

            return ticketModel;
        }
    }
}
