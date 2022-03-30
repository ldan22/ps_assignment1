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
        private readonly IShowValidator showValidator;
        public ShowService(IShowRepository showRepository, IShowMapper showMapper, ITicketRepository ticketRepository, 
            ITicketMapper ticketMapper, IShowValidator showValidator)
        {
            this.showRepository = showRepository;
            this.showMapper = showMapper;
            this.ticketRepository = ticketRepository;
            this.ticketMapper = ticketMapper;
            this.showValidator = showValidator;
        }

        public void CreateShow(ShowModel showModel)
        {
            if (!showValidator.validate(showModel))
            {
                throw new ModelValidationException();
            }
            var show = showMapper.Map(showModel);
            showRepository.Insert(show);
        }
        public void UpdateShow(ShowModel showModel)
        {
            if (!showValidator.validate(showModel))
            {
                throw new ModelValidationException();
            }
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
            if (show == null)
            {
                throw new EntityNotFoundException("Show with id " + id + " not found");
            }
            return showMapper.Map(show);
        }
        public void DeleteShowById(int id)
        {
            showRepository.Delete(id);
        }

        public List<TicketModel> GetTickets(int showId)
        {
            var show = GetShowById(showId);
            var tickets = ticketRepository.GetTicketsByShowId(show.Id);
            List<TicketModel> results = new List<TicketModel>();
            tickets.ForEach(t => results.Add(ticketMapper.Map(t)));
            return results;
        }
    }
}
