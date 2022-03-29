using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;

namespace DataAccess
{
    public class TicketRepository: BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDbContext context) : base(context)
        {
        }

        public List<Ticket> GetTicketsByShowId(int id)
        {
            return dbSet.Where(t => t.ShowId == id).ToList();
        }

        public int CountTicketsByShowId(int id)
        {
            return dbSet.Count(t => t.ShowId == id);
        }
    }
}
