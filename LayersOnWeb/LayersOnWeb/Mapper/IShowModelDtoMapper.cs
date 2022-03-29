using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts;

namespace LayersOnWeb.Mapper
{
    public interface IShowModelDtoMapper
    {
        ShowModel Map(ShowDto show);
        ShowDto Map(ShowModel show);
    }
}
