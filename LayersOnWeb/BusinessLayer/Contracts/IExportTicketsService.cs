using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IExportTicketsService
    {
        string ExportTicketsForShow(string format, int showId);
    }
}
