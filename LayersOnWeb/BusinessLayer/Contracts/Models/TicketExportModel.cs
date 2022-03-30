using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class TicketExportModel
    {
        public int Id { get; set; }
        public int SeatRow { get; set; }
        public int SeatNumber { get; set; }
    }
}
