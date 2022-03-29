using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class InvalidExportFormat : Exception
    {
        public InvalidExportFormat() : base("Format not supported")
        {

        }
    }
}
