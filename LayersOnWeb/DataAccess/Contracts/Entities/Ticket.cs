using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public class Ticket
    {
        public int Id { get; set; }
        public Show Show { get; set; }
        public int ShowId { get; set; }
        public int SeatRow { get; set; }
        public int SeatNumber { get; set; }

    }
}
