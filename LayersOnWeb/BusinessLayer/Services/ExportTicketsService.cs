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
            List<TicketExportModel> ticketExportModels = new List<TicketExportModel>();
            tickets.ForEach(t => ticketExportModels.Add(new TicketExportModel
            {
                Id = t.Id,
                SeatNumber = t.SeatNumber,
                SeatRow = t.SeatRow,
            }));
            string fileName = @"Static\Show_" + showId + "." + format;
            string root = @"wwwroot\";
            FileExporter<TicketExportModel> exporter = getExporter(format);

            exporter.export(ticketExportModels, root + fileName);
            return fileName;
        }
        
        private FileExporter<TicketExportModel> getExporter(string format)
        {
            if (format.ToLower() == "csv")
            {
                return new CsvExporter<TicketExportModel>();
            }

            if (format.ToLower() == "xml")
            {
                return new XmlExporter<TicketExportModel>();
            }

            throw new InvalidExportFormat();
        }
    }
}
