using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using DataAccess.Contracts;

namespace BusinessLayer
{
    public class ShowMapper : IShowMapper
    {
        public ShowModel Map(Show show)
        {
            return new ShowModel
            {
                Id = show.Id,
                Date = show.Date,
                Title = show.Title,
                Genre = show.Genre,
                DistributionList = show.DistributionList,
                NumberOfTickets = show.NumberOfTickets
            };
        }
        public Show Map(ShowModel showModel)
        {
            return new Show
            {
                Id = showModel.Id,
                Date = showModel.Date,
                Title = showModel.Title,
                Genre = showModel.Genre,
                DistributionList = showModel.DistributionList,
                NumberOfTickets = showModel.NumberOfTickets
            };
        }
    }
}
