using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts;

namespace LayersOnWeb.Mapper
{
    public class ShowModelDtoMapper : IShowModelDtoMapper
    {
        public ShowModel Map(ShowDto show)
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
        public ShowDto Map(ShowModel show)
        {
            return new ShowDto
            {
                Id = show.Id,
                Date = show.Date,
                Title = show.Title,
                Genre = show.Genre,
                DistributionList = show.DistributionList,
                NumberOfTickets = show.NumberOfTickets
            };
        }
    }
}
