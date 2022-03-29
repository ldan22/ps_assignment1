using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IShowService
    {
        void CreateShow(ShowModel showModel);
        void UpdateShow(ShowModel showModel);
        List<ShowModel> GetAllShows();
        ShowModel GetShowById(int id);
        void DeleteShowById(int id);

        List<TicketModel> GetTickets(int showId);
    }
}
