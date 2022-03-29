using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;


namespace BusinessLayer.Contracts
{
    public interface ITicketService
    {
        void CreateTicket(TicketModel ticket);
        void UpdateTicket(TicketModel ticket);
        List<TicketModel> GetAllTickets();
        TicketModel GetTicketById(int id);
        void DeleteTicketById(int id);
    }
}
