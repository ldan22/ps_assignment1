using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using DataAccess.Contracts;

namespace BusinessLayer
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository showRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly IShowMapper showMapper;
        private readonly ITicketMapper ticketMapper;

        public ShowService(IShowRepository showRepository, IShowMapper showMapper, ITicketRepository ticketRepository, ITicketMapper ticketMapper)
        {
            this.showRepository = showRepository;
            this.showMapper = showMapper;
            this.ticketRepository = ticketRepository;
            this.ticketMapper = ticketMapper;
        }

        public void CreateShow(ShowModel showModel)
        {
            var show = showMapper.Map(showModel);
            showRepository.Insert(show);
        }
        public void UpdateShow(ShowModel showModel)
        {
            var show = showMapper.Map(showModel);
            showRepository.Update(show);
        }
        public List<ShowModel> GetAllShows()
        {
            List<Show> shows = (List<Show>)showRepository.GetAll();
            List<ShowModel> results = new List<ShowModel>();
            shows.ForEach(x => results.Add(showMapper.Map(x)));
            return results;
        }
        public ShowModel GetShowById(int id)
        {
            var show = showRepository.GetById(id);
            return showMapper.Map(show);
        }
        public void DeleteShowById(int id)
        {
            showRepository.Delete(id);
        }

        public List<TicketModel> GetTickets(int showId)
        {
            var tickets = ticketRepository.GetTicketsByShowId(showId);
            List<TicketModel> results = new List<TicketModel>();
            tickets.ForEach(t => results.Add(ticketMapper.Map(t)));
            return results;
        }
    }
}
