using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using DataAccess.Contracts;


namespace BusinessLayer
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IShowRepository showRepository;
        private readonly ITicketMapper ticketMapper;

        public TicketService(ITicketRepository ticketRepository, ITicketMapper ticketMapper, IShowRepository showRepository)
        {
            this.ticketRepository = ticketRepository;
            this.ticketMapper = ticketMapper;
            this.showRepository = showRepository;
        }

        public void CreateTicket(TicketModel ticket)
        {
            int numOfTickets = ticketRepository.CountTicketsByShowId(ticket.Show.Id);
            var show = showRepository.GetById(ticket.Show.Id);
            if(numOfTickets >= show.NumberOfTickets)
            {
                throw new TicketsOverflowException("Number of tickets exceeded.");
            }

            var ticketEntity = ticketMapper.Map(ticket);
            ticketEntity.Show = show;
            ticketRepository.Insert(ticketEntity);
        }

        public void UpdateTicket(TicketModel ticket)
        {
            var show = showRepository.GetById(ticket.Show.Id);
            var ticketEntity = ticketMapper.Map(ticket);
            ticketEntity.Show = show;
            ticketRepository.Update(ticketEntity);
        }

        public List<TicketModel> GetAllTickets()
        {
            List<Ticket> tickets = (List<Ticket>)ticketRepository.GetAll();
            List<TicketModel> results = new List<TicketModel>();
            tickets.ForEach(x => {
                var show = showRepository.GetById(x.ShowId);
                x.Show = show;
                results.Add(ticketMapper.Map(x));
            });
            return results;
        }

        public TicketModel GetTicketById(int id)
        {
            var ticket = ticketRepository.GetById(id);
            var show = showRepository.GetById(ticket.ShowId);
            ticket.Show = show;
            return ticketMapper.Map(ticket);
        }

        public void DeleteTicketById(int id)
        {
            ticketRepository.Delete(id);
        }
    }
}
