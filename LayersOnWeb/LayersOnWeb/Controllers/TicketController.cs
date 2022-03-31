using BusinessLayer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LayersOnWeb.Mapper;

namespace LayersOnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController
    {
        private readonly ITicketService ticketService;
        private readonly ITicketModelDtoMapper ticketMapper;

        public TicketController(ITicketService ticketService, ITicketModelDtoMapper ticketMapper)
        {
            this.ticketService = ticketService;
            this.ticketMapper = ticketMapper;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<TicketDto> Get()
        {
            var result = new List<TicketDto>();
            foreach (var s in ticketService.GetAllTickets())
            {
                result.Add(ticketMapper.Map(s));
            }
            return result;
        }

        [HttpGet("{id}")]
        [Authorize]
        public TicketDto GetById(int id)
        {
            var ticket = ticketService.GetTicketById(id);
            if (ticket != null)
            {
                return ticketMapper.Map(ticket);
            }
            return null;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public void Post(TicketDto ticketDto)
        {
            ticketService.CreateTicket(ticketMapper.Map(ticketDto));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public void Put(int id, TicketDto ticketDto)
        {
            ticketService.UpdateTicket(ticketMapper.Map(ticketDto));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public void Delete(int id)
        {
            ticketService.DeleteTicketById(id);
        }
    }
}
