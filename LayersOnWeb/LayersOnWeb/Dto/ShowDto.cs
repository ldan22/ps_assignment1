using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Contracts;

namespace LayersOnWeb
{
    public class ShowDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Title { get; set; }
        public ShowGenre Genre { get; set; }
        public String DistributionList { get; set; }
        public int NumberOfTickets { get; set; }
        public List<TicketDto> Tickets { get; set; }
    }
}
