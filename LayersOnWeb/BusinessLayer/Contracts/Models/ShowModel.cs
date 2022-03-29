using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;

namespace BusinessLayer.Contracts
{
    public class ShowModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Title { get; set; }
        public ShowGenre Genre { get; set; }
        public String DistributionList { get; set; }
        public int NumberOfTickets { get; set; }

        public List<TicketModel> Tickets { get; set; }
    }
}
