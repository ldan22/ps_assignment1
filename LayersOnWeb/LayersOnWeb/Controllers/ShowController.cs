using BusinessLayer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LayersOnWeb.Mapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Text;

namespace LayersOnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController
    {
        private readonly IShowService showService;
        private readonly IShowModelDtoMapper showMapper;
        private readonly ITicketModelDtoMapper ticketMapper;
        private readonly IExportTicketsService exportTicketsService;

        public ShowController(IShowService showService, IShowModelDtoMapper showMapper, 
            ITicketModelDtoMapper ticketMapper, IExportTicketsService exportTicketsService)
        {
            this.showService = showService;
            this.showMapper = showMapper;
            this.ticketMapper = ticketMapper;
            this.exportTicketsService = exportTicketsService;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<ShowDto> Get()
        {
            var result = new List<ShowDto>();
            foreach (var s in showService.GetAllShows())
            {
                result.Add(showMapper.Map(s));
            }
            return result;
        }

        [HttpGet("{id}")]
        [Authorize]
        public ShowDto GetById(int id)
        {
            var show = showService.GetShowById(id);
            if (show != null)
            {
                return showMapper.Map(show);
            }
            return null;
        }

        [HttpGet("{id}/tickets")]
        [Authorize]
        public List<TicketDto> GetTickets(int id)
        {
            var results = new List<TicketDto>();
            foreach (var t in showService.GetTickets(id))
            {
                results.Add(ticketMapper.Map(t));
            }
            return results;
        }

        [HttpGet("{id}/tickets/export")]
        [Authorize]
        public VirtualFileResult ExportTickets([FromQuery(Name = "format")] string format, int id)
        {
            string filePath = exportTicketsService.ExportTicketsForShow(format, id);
            return new VirtualFileResult(@"\" + filePath, "text/" + format);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post(ShowDto showDto)
        {
            showService.CreateShow(showMapper.Map(showDto));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(int id, ShowDto showDto)
        {
            showService.UpdateShow(showMapper.Map(showDto));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            showService.DeleteShowById(id);
        }
    }
}
