using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using DataAccess.Contracts;

namespace BusinessLayer
{
    public class ExportTicketsService: IExportTicketsService
    {
        private readonly IShowService showService;

        public ExportTicketsService(IShowService showService)
        {
            this.showService = showService;
        }

        public string ExportTicketsForShow(string format, int showId)
        {
            List<TicketModel> tickets = showService.GetTickets(showId);
            string fileName = @"D:\Facultate\PS\assignment1\LayersOnWeb\LayersOnWeb\Static\Tickets\Show#" + showId;
            
            FileExporter<TicketModel> exporter = getExporter(format);
            return exporter.export(tickets, fileName);
        }
        
        private FileExporter<TicketModel> getExporter(string format)
        {
            if (format.ToLower() == "csv")
            {
                return new CsvExporter<TicketModel>();
            }

            if (format.ToLower() == "xml")
            {
                return new XmlExporter<TicketModel>();
            }

            throw new InvalidExportFormat();
        }
    }
}
