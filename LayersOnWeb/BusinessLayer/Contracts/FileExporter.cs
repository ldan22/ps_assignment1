using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface FileExporter<T>
    {
        string export(List<T> exportData, String path);
    }
}
